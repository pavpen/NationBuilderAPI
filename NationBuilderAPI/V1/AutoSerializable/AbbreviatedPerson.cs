using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.AutoSerializable
{
    [DataContract]
    public class AbbreviatedPerson
    {
        public DateTime? birthdate;

        [DataMember(Name = "birthdate")]
        private string birthdate_SerializationForm;

        [DataMember]
        public string city_district;

        [DataMember]
        public string civicrm_id;

        [DataMember]
        public string county_district;

        [DataMember]
        public string county_file_id;

        public DateTimeOffset created_at;

        [DataMember(Name = "created_at")]
        private string created_at_SerializationForm;

        [DataMember]
        public bool do_not_call;

        [DataMember]
        public bool do_not_contact;

        [DataMember]
        public int? dw_id;

        [DataMember]
        public string email;

        [DataMember]
        public bool email_opt_in;

        [DataMember]
        public string employer;

        [DataMember]
        public string external_id;

        [DataMember]
        public string federal_district;

        [DataMember]
        public string fire_district;

        [DataMember]
        public string first_name;

        [DataMember]
        public bool has_facebook;

        [DataMember]
        public int? id;

        [DataMember]
        public bool is_twitter_follower;

        [DataMember]
        public bool is_volunteer;

        [DataMember]
        public string judicial_district;

        [DataMember]
        public string labour_region;

        [DataMember]
        public string last_name;

        [DataMember]
        public string linkedin_id;

        [DataMember]
        public bool mobile_opt_in;

        [DataMember]
        public string mobile;

        [DataMember]
        public string nbec_guid;

        [DataMember]
        public string ngp_id;

        [DataMember]
        public string note;

        [DataMember]
        public string occupation;

        [DataMember]
        public string party;

        [DataMember]
        public string pf_strat_id;

        [DataMember]
        public string phone;

        [DataMember]
        public string precinct_id;

        [DataMember]
        public Address primary_address;

        [DataMember]
        public string recruiter_id;

        [DataMember]
        public string rnc_id;

        [DataMember]
        public string rnc_regid;

        [DataMember]
        public string salesforce_id;

        [DataMember]
        public string school_district;

        [DataMember]
        public string school_sub_district;

        [DataMember]
        public string sex;

        [DataMember]
        public string state_file_id;

        [DataMember]
        public string state_lower_district;

        [DataMember]
        public string state_upper_district;

        [DataMember]
        public int? support_level;

        [DataMember]
        public string supranational_district;

        [DataMember]
        public string[] tags;

        [DataMember]
        public string twitter_id;

        [DataMember]
        public string twitter_name;

        public DateTimeOffset updated_at;

        [DataMember(Name = "updated_at")]
        private string updated_at_SerializationForm;

        [DataMember]
        public string van_id;

        [DataMember]
        public string village_district;

        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            birthdate_SerializationForm = birthdate.HasValue ?
                birthdate.Value.ToString(NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture) : null;
            created_at_SerializationForm = created_at.ToString(NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
            updated_at_SerializationForm = updated_at.ToString(NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            birthdate = null == birthdate_SerializationForm ?
                (DateTime?)null :
                DateTime.ParseExact(birthdate_SerializationForm, NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
            created_at = DateTimeOffset.ParseExact(created_at_SerializationForm, NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
            updated_at = DateTimeOffset.ParseExact(updated_at_SerializationForm, NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convert this object to the cannonical <see cref="NationBuilderAPI.V1.AbbreviatedPerson"/>.
        /// </summary>
        /// <returns>The resulting AbbreviatedPerson object.</returns>
        public NationBuilderAPI.V1.AbbreviatedPerson ToAbbreviatedPerson()
        {
            var res = new NationBuilderAPI.V1.AbbreviatedPerson();

            res.CopyFrom(this);

            return res;
        }
    }
}