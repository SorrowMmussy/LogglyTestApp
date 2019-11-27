using System.Windows;
using log4net;
using LogglyTestApp.Logger;

namespace LogglyTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var loggerSetup = new LoggerSetup();
            loggerSetup.Setup();
        }

        private void LoggerButtonClick(object sender, RoutedEventArgs e)
        {
            var logger = LogManager.GetLogger("loggly");
            logger.Info("Send a log message without using app.config for setup :)");
        }
    }
}
