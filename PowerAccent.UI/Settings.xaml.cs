using PowerAccent.Core.Services;
using System.Windows;

namespace PowerAccent.UI
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private readonly SettingsService _settingService;

        public Settings()
        {
            InitializeComponent();
            _settingService = new SettingsService();
            RefreshPosition();
        }

        private void Position_Up_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.Top);
            RefreshPosition();
        }
        private void Position_Down_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.Bottom);
            RefreshPosition();
        }
        private void Position_Left_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.Left);
            RefreshPosition();
        }
        private void Position_Right_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.Right);
            RefreshPosition();
        }
        private void Position_UpLeft_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.TopLeft);
            RefreshPosition();
        }
        private void Position_UpRight_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.TopRight);
            RefreshPosition();
        }
        private void Position_DownLeft_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.BottomLeft);
            RefreshPosition();
        }
        private void Position_DownRight_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.BottomRight);
            RefreshPosition();
        }
        private void Position_Center_Checked(object sender, RoutedEventArgs e)
        {
            _settingService.SetPosition(Position.Center);
            RefreshPosition();
        }

        private void RefreshPosition()
        {
            var position = _settingService.Position;
            Position_Up.IsChecked = position == Position.Top;
            Position_Down.IsChecked = position == Position.Bottom;
            Position_Left.IsChecked = position == Position.Left;
            Position_Right.IsChecked = position == Position.Right;
            Position_UpRight.IsChecked = position == Position.TopRight;
            Position_UpLeft.IsChecked = position == Position.TopLeft;
            Position_DownRight.IsChecked = position == Position.BottomRight;
            Position_DownLeft.IsChecked = position == Position.BottomLeft;
            Position_Center.IsChecked = position == Position.Center;

            (Application.Current.MainWindow as Selector).Refresh();
        }
    }
}
