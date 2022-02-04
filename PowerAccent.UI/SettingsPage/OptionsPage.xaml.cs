using PowerAccent.Core.Services;
using System.Windows;
using System.Windows.Controls;

namespace PowerAccent.UI.SettingsPage
{
    /// <summary>
    /// Logique d'interaction pour OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        private readonly SettingsService _settingService = new SettingsService();

        public OptionsPage()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.UseCaretPosition = ((CheckBox)sender).IsChecked ?? false;
            (Application.Current.MainWindow as Selector).RefreshSettings();
        }
    }
}
