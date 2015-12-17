using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Xml.Linq;

namespace NationBuilderAPIv1UnitTests.Settings
{
    /// <summary>
    /// A custom SettingsProvider to override the default local settings file location of .NET's <see cref="LocalFileSettingsProvider"/>.
    /// 
    /// From <http://stackoverflow.com/questions/2265271/custom-path-of-the-user-config>.
    /// </summary>
    class SystemFileSettingsProvider : SettingsProvider
    {
        /// <summary>
        /// Helper struct.
        /// </summary>
        internal struct SettingStruct
        {
            internal string name;
            internal string serializeAs;
            internal string value;
        }


        const string NAME = "name";
        const string SERIALIZE_AS = "serializeAs";
        const string CONFIG = "configuration";
        const string USER_SETTINGS = "userSettings";
        const string SETTING = "setting";
        const string szOID_EFS_CRYPTO = "1.3.6.1.4.1.311.10.3.4";
        const string szOID_EFS_RECOVERY = "1.3.6.1.4.1.311.10.3.4.1";

        bool _loaded;

        /// <summary>
        /// In memory storage of the settings values.
        /// </summary>
        private Dictionary<string, SettingStruct> SettingsDictionary { get; set; }



        /// <summary>
        /// Override.
        /// </summary>
        public override string ApplicationName
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name;
            }
            set
            {
                // Do nothing.
            }
        }

        /// <summary>
        /// The path to the configuration file.
        /// </summary>
        private string UserConfigPath
        {
            get
            {
                //return Properties.Settings.Default.SettingsKey;
                //string res = Assembly.GetAssembly(typeof(SystemFileSettingsProvider)).Location + ".config";
                string res = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "NationBuilderAPI",
                    "NationBuilderAPIv1UnitTests.config");

                return res;
            }
        }



        /// <summary>
        /// Loads the file into memory.
        /// </summary>
        public SystemFileSettingsProvider()
        {
            SettingsDictionary = new Dictionary<string, SettingStruct>();
        }

        /// <summary>
        /// Override.
        /// </summary>
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(ApplicationName, config);
        }

        /// <summary>
        /// Must override this, this is the bit that matches up the designer properties to the dictionary values.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            // Load the file:
            if (!_loaded)
            {
                _loaded = true;
                LoadValuesFromFile();
            }

            // Collection that will be returned:
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

            // Iterate thought the properties we get from the designer, checking to see if the setting is in the dictionary:
            foreach (SettingsProperty setting in collection)
            {
                SettingsPropertyValue value = new SettingsPropertyValue(setting);
                value.IsDirty = false;

                // Need the type of the value for the strong typing:
                var t = Type.GetType(setting.PropertyType.FullName);

                if (SettingsDictionary.ContainsKey(setting.Name))
                {
                    value.SerializedValue = SettingsDictionary[setting.Name].value;
                    value.PropertyValue = Convert.ChangeType(SettingsDictionary[setting.Name].value, t);
                }
                else // Use defaults in the case where there are no settings yet:
                {
                    value.SerializedValue = setting.DefaultValue;
                    value.PropertyValue = Convert.ChangeType(setting.DefaultValue, t);
                }

                values.Add(value);
            }
            return values;
        }

        /// <summary>
        /// Must override this, this is the bit that does the saving to file.  Called when Settings.Save() is called.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="collection"></param>
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            // Grab the values from the collection parameter and update the values in our dictionary:
            foreach (SettingsPropertyValue value in collection)
            {
                var setting = new SettingStruct()
                {
                    value = (value.PropertyValue == null ? String.Empty : value.PropertyValue.ToString()),
                    name = value.Name,
                    serializeAs = value.Property.SerializeAs.ToString()
                };

                if (!SettingsDictionary.ContainsKey(value.Name))
                {
                    SettingsDictionary.Add(value.Name, setting);
                }
                else
                {
                    SettingsDictionary[value.Name] = setting;
                }
            }

            // Now that our local dictionary is up-to-date, save it to disk:
            SaveValuesToFile();
        }

        /// <summary>
        /// Loads the values of the file into memory.
        /// </summary>
        private void LoadValuesFromFile()
        {
            if (!File.Exists(UserConfigPath))
            {
                // If the config file is not where it's supposed to be create a new one:
                CreateEmptyConfig();
            }

            // Load the XML:
            var configXml = LoadConfiguration();

            // Get all of the <setting name="..." serializeAs="..."> elements:
            var settingElements = configXml.Element(CONFIG).Element(USER_SETTINGS).Element(typeof(Settings).FullName).Elements(SETTING);

            // Iterate through, adding them to the dictionary, (checking for nulls, XML no likey nulls),
            // using "String" as default serializeAs...just in case, no real good reason:
            foreach (var element in settingElements)
            {
                var newSetting = new SettingStruct()
                {
                    name = element.Attribute(NAME) == null ? String.Empty : element.Attribute(NAME).Value,
                    serializeAs = element.Attribute(SERIALIZE_AS) == null ? "String" : element.Attribute(SERIALIZE_AS).Value,
                    value = element.Value ?? String.Empty
                };
                SettingsDictionary.Add(element.Attribute(NAME).Value, newSetting);
            }
        }

        /// <summary>
        /// Creates an empty user.config file...looks like the one MS creates.  
        /// This could be overkill a simple key/value pairing would probably do.
        /// </summary>
        private void CreateEmptyConfig()
        {
            var doc = new XDocument();
            var declaration = new XDeclaration("1.0", "utf-8", "true");
            var config = new XElement(CONFIG);
            var userSettings = new XElement(USER_SETTINGS);
            var group = new XElement(typeof(Settings).FullName);

            userSettings.Add(group);
            config.Add(userSettings);
            doc.Add(config);
            doc.Declaration = declaration;
            SaveConfiguration(doc);
        }

        /// <summary>
        /// Saves the in memory dictionary to the user config file.
        /// </summary>
        private void SaveValuesToFile()
        {
            // Load the current XML from the file:
            var import = LoadConfiguration();

            // Get the settings group (e.g. <Company.Project.Desktop.Settings>):
            var settingsSection = import.Element(CONFIG).Element(USER_SETTINGS).Element(typeof(Settings).FullName);

            // Iterate though the dictionary, either updating the value or adding the new setting:
            foreach (var entry in SettingsDictionary)
            {
                var setting = settingsSection.Elements().FirstOrDefault(e => e.Attribute(NAME).Value == entry.Key);
                if (setting == null) // This can happen if a new setting is added via the .settings designer.
                {
                    var newSetting = new XElement(SETTING);
                    newSetting.Add(new XAttribute(NAME, entry.Value.name));
                    newSetting.Add(new XAttribute(SERIALIZE_AS, entry.Value.serializeAs));
                    newSetting.Value = (entry.Value.value ?? String.Empty);
                    settingsSection.Add(newSetting);
                }
                else // Update the value, if it exists:
                {
                    setting.Value = (entry.Value.value ?? String.Empty);
                }
            }

            SaveConfiguration(import);
        }

        private XDocument LoadConfiguration()
        {
            using (var fileStream = File.Open(UserConfigPath, FileMode.Open, FileAccess.Read))
            {
                // Created a decrypted file stream:
                using (var inputStream = new Utilities.DpapiStream(fileStream))
                {
                    return XDocument.Load(inputStream);
                }
            }
        }

        private void SaveConfiguration(XDocument configurationDocument)
        {
            var path = UserConfigPath;

            // Make sure the configuration directory exists:
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (var fileStream = File.Create(path))
            {
                // Encrypt the file, since it contains authentication information.
                using (var encryptedStream = new Utilities.DpapiStream(fileStream))
                {
                    configurationDocument.Save(encryptedStream);
                }
            }
        }

        /// <summary>
        /// Extract an X.509 certificate for EFS file encryption from the user's certificate store, if one exists.
        /// </summary>
        /// <param name="validOnly">Whether to search only for valid certificates.</param>
        /// <returns>An X.509 certificate to use for encrypting the configuration file, or <c>null</c>, if a certificate was not found the store.</returns>
        private X509Certificate2 GetConfigurationEncryptionCertificate(bool validOnly)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            var certificates = store.Certificates;
            var matchingCertficates = certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DataEncipherment, validOnly);

            foreach (var certificate in matchingCertficates)
            {
                foreach (var extension in certificate.Extensions)
                {
                    if (extension.Oid.FriendlyName == "Enhanced Key Usage")
                    {
                        var keyUsage = (X509EnhancedKeyUsageExtension)extension;

                        foreach (var oid in keyUsage.EnhancedKeyUsages)
                        {
                            if (oid.Value == szOID_EFS_CRYPTO || oid.Value == szOID_EFS_RECOVERY)
                            {
                                return certificate;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
