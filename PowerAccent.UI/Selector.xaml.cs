using System.Windows;
using Application = System.Windows.Application;

namespace PowerAccent.UI;

public partial class Selector : Window
{
    public Selector(char[] selectedCharacters)
    {
        InitializeComponent();
        Application.Current.MainWindow.ShowActivated = false;
        Application.Current.MainWindow.Topmost = true;
        characters.ItemsSource = selectedCharacters;
        characters.SelectedIndex = 0;
    }

    public void SetIndex(int index)
    {
        characters.SelectedIndex = index;
    }

    public void SetPosition(double left, double top)
    {
        this.Left = left;
        this.Top = top;
    }
}
