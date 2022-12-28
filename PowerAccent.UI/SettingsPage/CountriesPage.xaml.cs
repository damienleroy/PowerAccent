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

        Countries.ItemsSource = Enum.GetNames<Language>().Select(l => new Country
        {
            Name = l,
            ImageUrl = $"/Resources/Flags/{l}.jpg",
            IsChecked = l == _settingService.SelectedLanguage.ToString()
        }).ToList();
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        _settingService.SelectedLanguage = Enum.Parse<Language>((((RadioButton)sender).DataContext as Country).Name);
        (Application.Current.MainWindow as MainWindow).RefreshSettings();
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