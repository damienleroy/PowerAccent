﻿using System;
using System.Windows;
using System.Windows.Controls;
using Point = PowerAccent.Core.Point;
using Size = PowerAccent.Core.Size;

namespace PowerAccent.UI;

public partial class Selector : Window
{
    private Core.PowerAccent _powerAccent = new Core.PowerAccent();

    public Selector()
    {
        InitializeComponent();
        Application.Current.MainWindow.ShowActivated = false;
        Application.Current.MainWindow.Topmost = true;
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
        characters.SelectedIndex = index;
    }

    private void PowerAccent_OnChangeDisplay(bool isActive, char[] chars)
    {
        this.Visibility = isActive ? Visibility.Visible : Visibility.Collapsed;
        if (isActive)
        {
            CenterWindow();
            characters.ItemsSource = chars;
        }
    }

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

    private void CenterWindow()
    {
        UpdateLayout();
        Size window = new Size(((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualWidth, ((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualHeight);
        Point position = _powerAccent.GetDisplayCoordinates(window);
        this.Left = position.X;
        this.Top = position.Y;
    }

    protected override void OnClosed(EventArgs e)
    {
        _powerAccent.Dispose();
        base.OnClosed(e);
    }

    public void RefreshSettings()
    {
        _powerAccent.ReloadSettings();
    }

    public void HideTaskbarIcon()
    {
        this.TaskbarIcon.Visibility = Visibility.Collapsed;
    }
}
