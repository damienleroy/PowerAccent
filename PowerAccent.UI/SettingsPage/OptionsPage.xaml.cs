using ModernWpf.Controls;
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
/// Logique d'interaction pour OptionsPage.xaml
/// </summary>
public partial class OptionsPage : System.Windows.Controls.Page
{
    private readonly SettingsService _settingService = new SettingsService();

    public OptionsPage()
    {
        InitializeComponent();
    }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        IsUseCaretPosition.IsOn = _settingService.UseCaretPosition;
        IsSpaceBarActive.IsOn = _settingService.IsSpaceBarActive;
        DisableInFullScreen.IsOn = _settingService.DisableInFullScreen;
        InputTime.Value = _settingService.InputTime;
    }

    private void UseCaretPosition_Checked(object sender, RoutedEventArgs e)
    {
        _settingService.UseCaretPosition = ((ToggleSwitch)sender).IsOn;
        (Application.Current.MainWindow as MainWindow).RefreshSettings();
    }

    private void SpaceBarActive_Checked(object sender, RoutedEventArgs e)
    {
        _settingService.IsSpaceBarActive = ((ToggleSwitch)sender).IsOn;
        (Application.Current.MainWindow as MainWindow).RefreshSettings();
    }

    private void DisableInFullScreen_Toggled(object sender, RoutedEventArgs e)
    {
        _settingService.DisableInFullScreen = ((ToggleSwitch)sender).IsOn;
        (Application.Current.MainWindow as MainWindow).RefreshSettings();
    }

    private void InsertSpaceAfterSelection_Toggled(object sender, RoutedEventArgs e)
    {
        _settingService.InsertSpaceAfterSelection = ((ToggleSwitch)sender).IsOn;
        (Application.Current.MainWindow as MainWindow).RefreshSettings();
    }

    private void InputTime_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
    {
        int value = (int)args.NewValue;
        _settingService.InputTime = value >= 0 ? value : 200;
        (Application.Current.MainWindow as MainWindow).RefreshSettings();
    }
}