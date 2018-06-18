using System.Windows;
using WebAppBrowser.Properties;

namespace WebAppBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            Settings.Default.Save();            
        }
    }
}
