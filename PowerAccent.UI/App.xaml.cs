using PowerAccent.UI.Themes;
using System;
using System.Threading;
using System.Windows;

namespace PowerAccent.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex = null;
        private bool _disposed;
        private ThemeManager _themeManager;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "PowerAccent";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                Application.Current.Shutdown();
            }

            _themeManager = new ThemeManager();

            base.OnStartup(e);
        }

        // dispose
        protected override void OnExit(ExitEventArgs e)
        {
            _mutex.ReleaseMutex();
            base.OnExit(e);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _mutex?.Dispose();
                _themeManager?.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
