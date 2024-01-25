using PowerAccent.UI.SettingsPage;
using System;
using System.Windows;
using System.Windows.Input;

namespace PowerAccent.UI
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            DefaultStyleKey = typeof(Settings);
            //CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, CloseWindow));
            //CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, MaximizeWindow, CanResizeWindow));
            //CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, MinimizeWindow, CanMinimizeWindow));
            //CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, RestoreWindow, CanResizeWindow));
            //CommandBindings.Add(new CommandBinding(SystemCommands.ShowSystemMenuCommand, ShowSystemMenu));
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Countries.IsChecked = true;
        }

        private void Countries_Checked(object sender, RoutedEventArgs e)
        {
            Position.IsChecked = false;
            Options.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new CountriesPage());
        }

        private void Position_Checked(object sender, RoutedEventArgs e)
        {
            Countries.IsChecked = false;
            Options.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new PositionPage());
        }

        private void Options_Checked(object sender, RoutedEventArgs e)
        {
            Countries.IsChecked = false;
            Position.IsChecked = false;
            Sort.IsChecked = false;
            this.ParentFrame.Navigate(new OptionsPage());
        }

        private void Sort_Checked(object sender, RoutedEventArgs e)
        {
            Countries.IsChecked = false;
            Options.IsChecked = false;
            Position.IsChecked = false;
            this.ParentFrame.Navigate(new SortPage());
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            if (SizeToContent == SizeToContent.WidthAndHeight)
                InvalidateMeasure();
        }

        #region Window Commands  

        private void CanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        private void CanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ResizeMode != ResizeMode.NoResize;
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void MinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void RestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }


        private void ShowSystemMenu(object sender, ExecutedRoutedEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            if (element == null)
                return;

            var point = WindowState == WindowState.Maximized ? new System.Windows.Point(0, element.ActualHeight)
                : new System.Windows.Point(Left + BorderThickness.Left, element.ActualHeight + Top + BorderThickness.Top);
            point = element.TransformToAncestor(this).Transform(point);
            SystemCommands.ShowSystemMenu(this, point);
        }

        #endregion
    }
}
