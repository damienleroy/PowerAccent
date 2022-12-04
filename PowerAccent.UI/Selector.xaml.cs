using System.Windows;

namespace PowerAccent.UI;

public partial class Selector : Window
{
    public Selector()
    {
        InitializeComponent();
        this.ShowActivated = false;
        this.Topmost = true;
    }

    public void SetChars(char[] selectedCharacters)
    {
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
