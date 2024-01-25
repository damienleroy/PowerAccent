using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Point = PowerAccent.Core.Point;
using Size = PowerAccent.Core.Size;
using Application = System.Windows.Application;
using System.Collections.Generic;

namespace PowerAccent.UI;

public partial class MainWindow : Window
{
    private Core.PowerAccent _powerAccent = new Core.PowerAccent();
    private Selector _selector;
    private Stack<Selector> _selectorStack = new Stack<Selector>();

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
        _powerAccent.CheckVersion();
    }

    private void PowerAccent_OnSelectionCharacter(int index)
    {
         _selector?.SetIndex(index);
    }

    private void PowerAccent_OnChangeDisplay(bool isActive, char[] chars)
    {
        if (isActive)
        {
            Selector selector = new Selector(chars);
            selector.Show();
            CenterWindow(selector);
            _selectorStack.Push(selector);
            _selector = selector;
        }
        else
        {
            while (_selectorStack.Count > 0)
            {
                _selectorStack.Pop().Close();
            }
        }
    }

    private void CenterWindow(Selector selector)
    {
        Size window = new Size(((System.Windows.Controls.Panel)selector.Content).ActualWidth, ((System.Windows.Controls.Panel)selector.Content).ActualHeight);
        double primaryDPI = Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;
        Point position = _powerAccent.GetDisplayCoordinates(window, primaryDPI);
        selector.SetPosition(position.X, position.Y);
        selector.SetBorderWindowAlignment(_powerAccent.IsLeftPosition());
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

    public void RefreshSettings()
    {
        _powerAccent.ReloadSettings();
    }

    protected override void OnClosed(EventArgs e)
    {
        _powerAccent.Dispose();
        base.OnClosed(e);
    }

    public void Dispose()
    {
        _powerAccent.Dispose();
        GC.SuppressFinalize(this);
    }
}
