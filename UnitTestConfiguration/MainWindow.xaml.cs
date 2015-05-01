using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NationBuilderAPI.V1;

namespace UnitTestConfiguration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NationBuilderAPIv1UnitTests.Settings.Settings Settings = NationBuilderAPIv1UnitTests.Settings.Settings.Default;
        TaskScheduler UiSynchronizationContext = TaskScheduler.FromCurrentSynchronizationContext();

        Brush ErrorForeground = Brushes.Red;
        Brush WarningForeground = Brushes.DarkOrange;
        Brush InfoForeground = Brushes.Black;
        Brush SuccessForeground = Brushes.DarkGreen;

        public MainWindow()
        {
            InitializeComponent();

            SettingsContainer.DataContext = Settings;
        }
        void OutputParagraphString(string message, string expanderHeader, string expanderContent, Brush foreground)
        {
            Task.Factory.StartNew(() =>
            {
                var p = new Paragraph();

                p.Foreground = foreground;
                if (null != message)
                {
                    p.Inlines.Add(message);
                }
                if (null != expanderHeader || null != expanderContent)
                {
                    var expander = new System.Windows.Controls.Expander();

                    expander.Foreground = foreground;
                    if (null != expanderHeader)
                    {
                        expander.Header = expanderHeader;
                    }

                    var content = new System.Windows.Controls.TextBox();

                    content.Foreground = foreground;
                    content.Text = expanderContent;
                    content.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
                    expander.Content = content;

                    p.Inlines.Add(new InlineUIContainer(expander));
                }
                DiagnosticOutputDocument.Blocks.Add(p);
                if (ScrollToEndOnOutputCheckBox.IsChecked.HasValue && ScrollToEndOnOutputCheckBox.IsChecked.Value)
                {
                    DiagnosticOutputTextBox.ScrollToEnd();
                }
            },
            System.Threading.CancellationToken.None,
            TaskCreationOptions.None,
            UiSynchronizationContext);
        }

        void OutputError(string message, string expanderHeader = null, string expanderContent = null)
        {
            OutputParagraphString(message, expanderHeader, expanderContent, ErrorForeground);
        }

        void OutputError(string message, Exception exception)
        {
            OutputParagraphString(message, exception.Message, exception.ToString(), ErrorForeground);
        }

        void OutputWarning(string value, string expanderHeader = null, string expanderContent = null)
        {
            OutputParagraphString(value, expanderHeader, expanderContent, WarningForeground);
        }

        void OutputInformation(string value, string expanderHeader = null, string expanderContent = null)
        {
            OutputParagraphString(value, expanderHeader, expanderContent, InfoForeground);
        }

        void OutputSuccess(string value, string expanderHeader = null, string expanderContent = null)
        {
            OutputParagraphString(value, expanderHeader, expanderContent, SuccessForeground);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Save();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Save();
            this.Close();
        }

        private void TestConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            using (var session = new NationBuilderSession(Settings.TestNationSlug, Settings.TestNationAccessToken))
            {
                try
                {
                    session.PersonMe();
                }
                catch (Exception exc)
                {
                    OutputError("Error connecting to the Nation Builder service.", exc);
                }
            }
        }
    }
}
