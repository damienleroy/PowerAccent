using PowerAccent.UI.SettingsPage;
using System;
using System.Windows;
using System.Windows.Input;

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
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Countries.IsChecked = true;
        }

        private void Countries_Checked(object sender, RoutedEventArgs e)
        {
            Position.IsChecked = false;
            Options.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new CountriesPage());
        }

        private void Position_Checked(object sender, RoutedEventArgs e)
        {
            Countries.IsChecked = false;
            Options.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new PositionPage());
        }

        private void Options_Checked(object sender, RoutedEventArgs e)
        {
            Countries.IsChecked = false;
            Position.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new OptionsPage());
        }

        private void Sort_Checked(object sender, RoutedEventArgs e)
        {
            Countries.IsChecked = false;
            Options.IsChecked = false;
            Position.IsChecked = false;
            this.ParentFrame.Navigate(new SortPage());
        }
    }
}
