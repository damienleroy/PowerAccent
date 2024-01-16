using PowerAccent.Core;
using PowerAccent.Core.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PowerAccent.UI.SettingsPage;

/// <summary>
/// Logique d'interaction pour CountriesPage.xaml
/// </summary>
public partial class CountriesPage : Page
{
    private readonly SettingsService _settingService = new SettingsService();


    public CountriesPage()
    {
        InitializeComponent();
    }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        RefreshData();
    }

    private void RefreshData()
    {
        Countries.ItemsSource = Enum.GetNames<Language>().Select(l => new Country
        {
            Name = l,
            ImageUrl = $"/Resources/Flags/{l}.jpg",
            IsChecked = _settingService.SelectedLanguages.Any(s => s.ToString() == l)
        }).ToList();
    }

    private void CheckBox_OnChanged(object sender, RoutedEventArgs e)
    {
        var selectedCountry = ((CheckBox)sender).DataContext as Country;
        var doRefresh = false;
        var selectedLanguages = Countries.Items.Cast<Country>().Where(c => c.IsChecked).Select(c => Enum.Parse<Language>(c.Name)).ToArray();
        if (selectedCountry.Name == Core.Language.ALL.ToString() && selectedCountry.IsChecked)
        {
            selectedLanguages = new[] { Core.Language.ALL };
            Countries.ItemsSource.Cast<Country>().ToList().ForEach(c => c.IsChecked = false);
            Countries.ItemsSource.Cast<Country>().First(c => c.Name == Core.Language.ALL.ToString()).IsChecked = true;
            doRefresh = true;
        }
        else if (selectedLanguages.Length == 0)
        {
            selectedLanguages = new[] { Core.Language.ALL };
            Countries.ItemsSource.Cast<Country>().First(c => c.Name == Core.Language.ALL.ToString()).IsChecked = true;
            doRefresh = true;
        }
        else if (selectedLanguages.Length > 1 && selectedLanguages.Any(s => s == Core.Language.ALL))
        {
            selectedLanguages = selectedLanguages.Where(s => s != Core.Language.ALL).ToArray();
            Countries.ItemsSource.Cast<Country>().First(c => c.Name == Core.Language.ALL.ToString()).IsChecked = false;
            doRefresh = true;
        }
        
        _settingService.SelectedLanguages = selectedLanguages;
        (Application.Current.MainWindow as MainWindow).RefreshSettings();
        if (doRefresh)
        RefreshData();
    }
}

public class StringToImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return new BitmapImage(new Uri("pack://application:,,,/PowerAccent;component/" + value.ToString(), UriKind.Absolute));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}