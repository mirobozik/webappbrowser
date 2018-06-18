using System.ComponentModel;
using System.Configuration;
using System.Windows;
using WpfWebBrowser.Properties;

namespace WpfWebBrowser.Models
{
    public class MainWindowModel : ModelBase
    {
        private double _top;
        private double _left;
        private double _height;
        private double _width;
        private WindowState _windowState;

        public MainWindowModel()
        {
            Top = Settings.Default.MainWindow_Top;
            Left = Settings.Default.MainWindow_Left;
            Height = Settings.Default.MainWindow_Height;
            Width = Settings.Default.MainWindow_Width;
            WindowState = Settings.Default.MainWindow_State;

            Url = ConfigurationManager.AppSettings["Url"];
            Title = ConfigurationManager.AppSettings["Title"];

            PropertyChanged += BrowserModel_PropertyChanged;
        }

        #region Property Changed Handler

        private void BrowserModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Top))
            {
                Settings.Default.MainWindow_Top = Top;
            }
            if (e.PropertyName == nameof(Left))
            {
                Settings.Default.MainWindow_Left = Left;
            }
            if (e.PropertyName == nameof(Width))
            {
                Settings.Default.MainWindow_Width = Width;
            }
            if (e.PropertyName == nameof(Height))
            {
                Settings.Default.MainWindow_Height = Height;
            }

            if (e.PropertyName == nameof(WindowState))
            {
                Settings.Default.MainWindow_State = WindowState;
            }
        }

        #endregion

        #region Window State Properties

        public double Top
        {
            get { return _top; }
            set
            {
                _top = value;
                OnPropertyChanged();
            }
        }

        public double Left
        {
            get { return _left; }
            set
            {
                _left = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                _windowState = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public string Url { get; set; }

        public string Title { get; set; }
    }
}