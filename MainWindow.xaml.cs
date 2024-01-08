using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Coinbase
{
    public partial class MainWindow : Window
    {
        private Context _context;

        public MainWindow()
        {
            InitializeComponent();

            _context = new Context();

            MainWindowFrame.Content = new LoginPage(_context);

            //ImageBrush brush = new ImageBrush() { ImageSource = new BitmapImage(new Uri("src/background.jpg", UriKind.Relative))};

            //MainWindowFrame.Background = brush;
        }

        public MainWindow(Context context)
        {
            InitializeComponent();

            _context = context;

            MainWindowFrame.Content = new LoginPage(_context);
        }

        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                BorderThickness = new Thickness(7);
            }
            else
            {
                BorderThickness = new Thickness(0);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}