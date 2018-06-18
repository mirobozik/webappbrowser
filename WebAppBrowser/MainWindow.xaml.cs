using System.Windows;
using Microsoft.Win32;
using WebAppBrowser.Models;

namespace WebAppBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowModel();

            var pricipal = new System.Security.Principal.WindowsPrincipal(
                System.Security.Principal.WindowsIdentity.GetCurrent());
            if (pricipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator)) {
                RegistryKey registrybrowser = Registry.LocalMachine.OpenSubKey
                    (@"Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                var currentValue = registrybrowser.GetValue("*");
                if (currentValue == null || (int)currentValue != 0x00002af9)
                    registrybrowser.SetValue("*", 0x00002af9, RegistryValueKind.DWord);
            }
            else
                this.Title += " (The first time to run with the rights of the administrator)";
            InitializeComponent();
        }       

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Browser.Navigate(((MainWindowModel) DataContext).Url);            
        }        
    }
}
