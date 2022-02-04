using PowerAccent.UI.SettingsPage;
using System.Windows;

namespace PowerAccent.UI
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            this.ParentFrame.Navigate(new PositionPage());
        }

        private void Position_Checked(object sender, RoutedEventArgs e)
        {
            Options.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new PositionPage());
        }

        private void Options_Checked(object sender, RoutedEventArgs e)
        {
            Position.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new OptionsPage());
        }

        private void Sort_Checked(object sender, RoutedEventArgs e)
        {
            Options.IsChecked = false;
            Position.IsChecked = false;
            this.ParentFrame.Navigate(new SortPage());
        }
    }
}
