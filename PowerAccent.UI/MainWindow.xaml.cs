using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Point = PowerAccent.Core.Point;
using Size = PowerAccent.Core.Size;
using Application = System.Windows.Application;

namespace PowerAccent.UI;

public partial class MainWindow : Window
{
    private Core.PowerAccent _powerAccent = new Core.PowerAccent();
    private Selector _selector;
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        _powerAccent.OnChangeDisplay += PowerAccent_OnChangeDisplay;
        _powerAccent.OnSelectCharacter += PowerAccent_OnSelectionCharacter;
        this.Visibility = Visibility.Hidden;
    }

    private void PowerAccent_OnSelectionCharacter(int index, char character)
    {
         _selector?.SetIndex(index);
    }

    private void PowerAccent_OnChangeDisplay(bool isActive, char[] chars)
    {
        //this.Visibility = isActive ? Visibility.Visible : Visibility.Collapsed;
        if (isActive)
        {
            _selector = new Selector(chars);
            _selector.Show();
            CenterWindow();
        }
        else
        {
            _selector.Close();
        }
    }

    private void CenterWindow()
    {
        UpdateLayout();
        Size window = new Size(((System.Windows.Controls.Panel)_selector.Content).ActualWidth, ((System.Windows.Controls.Panel)_selector.Content).ActualHeight);
        double primaryDPI = Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;
        Point position = _powerAccent.GetDisplayCoordinates(window, primaryDPI);
        _selector.Left = position.X;
        _selector.Top = position.Y;
    }

    #region TaskBar
    private void Settings_Click(object sender, RoutedEventArgs e)
    {
        Settings settings = new Settings();
        settings.Show();
    }

    private void MenuExit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Pause_Click(object sender, RoutedEventArgs e)
    {
        _powerAccent.IsPaused = !_powerAccent.IsPaused;
        ((MenuItem)sender).FontWeight = _powerAccent.IsPaused ? FontWeights.Bold : FontWeights.Thin;
    }

    #endregion

    protected override void OnClosed(EventArgs e)
    {
        _powerAccent.Dispose();
        base.OnClosed(e);
    }

    public void RefreshSettings()
    {
        _powerAccent.ReloadSettings();
    }
}
