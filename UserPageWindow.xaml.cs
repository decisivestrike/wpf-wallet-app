using System.Windows;
using System.Windows.Input;

namespace Coinbase
{
    public partial class UserPageWindow : Window
    {
        private Context _context;

        private User _user;

        private ProfilePage _profilePage;

        private PaymentsPage _paymentsPage;

        private HistoryPage _historyPage;

        public UserPageWindow(Context context, User user)
        {
            InitializeComponent();

            _context = context;

            _user = user;

            _profilePage = new ProfilePage(_context, _user);

            _paymentsPage = new PaymentsPage(_context, _user);

            _historyPage = new HistoryPage(_context, _user);

            UserPageFrame.Content = _profilePage;
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
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AccountExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(_context);

            window.Show();

            Hide();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            _profilePage.Update();

            UserPageFrame.Content = _profilePage;
        }

        private void PaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            UserPageFrame.Content = _paymentsPage;
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _historyPage.LoadLogs();

            UserPageFrame.Content = _historyPage;
        }
    }
}
