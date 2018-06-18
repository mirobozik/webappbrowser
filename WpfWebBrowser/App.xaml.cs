using System.Windows;

namespace WpfWebBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            WpfWebBrowser.Properties.Settings.Default.Save();            
        }
    }
}
