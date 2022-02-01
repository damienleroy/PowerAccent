using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;
using System;
using System.Windows;
using static PowerAccent.Core.Tools.Enums;

namespace PowerAccent.UI;

public partial class Selector : Window
{
    private PowerAccentService _powerAccentService = new PowerAccentService();

    private int index = -1;

    public Selector()
    {
        InitializeComponent();
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        _powerAccentService.KeyDown += PowerAccent_KeyDown;
        _powerAccentService.KeyUp += PowerAccent_KeyUp;
        this.Visibility = Visibility.Hidden;
    }

    private void PowerAccent_KeyUp(LetterKey? letterKey, ArrowKey? arrowKey)
    {
        if (this.Visibility == Visibility.Visible && !letterKey.HasValue)
        {
            this.Visibility = Visibility.Collapsed;
            index = -1;
            if (characters.SelectedItem != null)
            {
                WindowsFunctions.Insert((char)characters.SelectedItem);
            }
        }
    }

    private bool PowerAccent_KeyDown(LetterKey? letterKey, ArrowKey? arrowKey)
    {
        if (this.Visibility != Visibility.Visible && letterKey.HasValue && arrowKey.HasValue)
        {
            FillListBox(letterKey.Value);
            this.Visibility = Visibility.Visible;
            Application.Current.MainWindow.ShowActivated = false;
            Application.Current.MainWindow.Topmost = true;
            CenterWindow();
        }

        if (this.Visibility == Visibility.Visible && arrowKey.HasValue)
        {
            if (index == -1)
            {
                if (arrowKey.Value == ArrowKey.Left)
                    index = characters.Items.Count / 2 - 1;

                if (arrowKey.Value == ArrowKey.Right)
                    index = characters.Items.Count / 2;

                if (index < 0) index = 0;
                if (index > characters.Items.Count - 1) index = characters.Items.Count - 1;

                characters.SelectedIndex = index;
                return false;
            }

            if (arrowKey.Value == ArrowKey.Left && index > 0)
                --index;
            if (arrowKey.Value == ArrowKey.Right && index < characters.Items.Count - 1)
                ++index;

            characters.SelectedIndex = index;
            return false;
        }

        return true;
    }

    private void FillListBox(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                characters.ItemsSource = new char[] { 'ä', 'â', 'á', 'à', 'ã' };
                break;
            case LetterKey.C:
                characters.ItemsSource = new char[] { 'ç' };
                break;
            case LetterKey.E:
                characters.ItemsSource = new char[] { 'ë', 'ê', 'é', 'è', '€' };
                break;
            case LetterKey.I:
                characters.ItemsSource = new char[] { 'ï', 'î', 'í', 'ì' };
                break;
            case LetterKey.O:
                characters.ItemsSource = new char[] { 'ö', 'ô', 'ó', 'ò', 'õ' };
                break;
            case LetterKey.U:
                characters.ItemsSource = new char[] { 'ü', 'û', 'ú', 'ù' };
                break;
            case LetterKey.Y:
                characters.ItemsSource = new char[] { 'ÿ', 'ý' };
                break;
            default:
                break;
        }
    }

    private void MenuExit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void CenterWindow()
    {
        //Method1
        UpdateLayout();
        Point position = CalculatePosition();
        this.Left = position.X;
        this.Top = position.Y;
    }

    private Point CalculatePosition()
    {
        System.Drawing.Point carretPixel = WindowsFunctions.GetCaretPosition();
        Point screen = new Point(SystemParameters.FullPrimaryScreenWidth, SystemParameters.FullPrimaryScreenHeight);

        Point window = new Point(((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualWidth, ((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualHeight);

        if (carretPixel.X == 0 && carretPixel.Y == 0)
        {
            return new Point(screen.X / 2 - window.X / 2, 10);
        }

        PresentationSource source = PresentationSource.FromVisual(this);
        if (source == null)
        {
            return new Point(screen.X / 2 - window.X / 2, 10);
        }

        Point dpi = new Point(source.CompositionTarget.TransformToDevice.M11, source.CompositionTarget.TransformToDevice.M22);

        Point carret = new Point(carretPixel.X / dpi.X, carretPixel.Y / dpi.Y);

        var left = carret.X - window.X / 2; // X default position
        var top = carret.Y - window.Y - 20; // Y default position

        return new Point(left < 0 ? 0 : (left + window.X > screen.X ? screen.X - window.X : left)
            , top < 0 ? carret.Y + 20 : top);
    }

    protected override void OnClosed(EventArgs e)
    {
        _powerAccentService.Dispose();
        base.OnClosed(e);
    }
}
