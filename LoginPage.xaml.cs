using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Coinbase
{
    public partial class LoginPage : Page
    {
        private Context _context;

        public LoginPage(Context context)
        {
            InitializeComponent();

            _context = context;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTextBox.Text.Trim().ToLower();
            string password = passwordBox.Password.Trim();

            if (email == string.Empty)
            {
                emailTextBox.ToolTip = "Заполните адрес электронной почты";
                emailTextBox.Background = Brushes.LightYellow;
            }
            else if (email.Length < 5 || !email.Contains('@') || !email.Contains('.'))
            {
                emailTextBox.ToolTip = "Некорректный адрес электронной почты";
                emailTextBox.Background = Brushes.LightYellow;
            }
            else if (password == string.Empty)
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                passwordBox.ToolTip = "Введите пароль";
                passwordBox.Background = Brushes.LightYellow;
            }
            else if (password.Length < 8)
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                passwordBox.ToolTip = "Слабый пароль";
                passwordBox.Background = Brushes.LightYellow;
            }
            else
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                passwordBox.ToolTip = null;
                passwordBox.Background = Brushes.Transparent;

                User? user = null;

                try
                {
                    user = _context.Users.Where(
                        u => u.Email == email
                        && u.Hash == CBFunctions.GetHash(password)
                    ).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Uncorrectable Error");
                }

                if (user != null)
                {
                    UserPageWindow page = new UserPageWindow(_context, user);

                    page.Show();

                    Application.Current.MainWindow.Hide();
                }
                else
                {
                    MessageBox.Show("Проверьте правильность ввода электронной почты и пароля", "Пользователь не найден");
                }
            }
        }

        private void ToRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(_context));
        }
    }
}
