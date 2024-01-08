using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Coinbase
{
    public partial class RegistrationPage : Page
    {
        private Context _context;

        public RegistrationPage(Context context)
        {
            InitializeComponent();

            _context = context;
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTextBox.Text.Trim().ToLower();
            string nickname = nameTextBox.Text.Trim();
            string primaryPassword = primaryPasswordBox.Password.Trim();
            string secondaryPassword = secondaryPasswordBox.Password.Trim();

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
            else if (nickname.Length < 2 || nickname.Length > 20)
            {
                nameTextBox.ToolTip = "Некорректное имя пользователя";
                nameTextBox.Background = Brushes.LightYellow;
            }
            else if (primaryPassword == string.Empty)
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                primaryPasswordBox.ToolTip = "Введите пароль";
                primaryPasswordBox.Background = Brushes.LightYellow;
            }
            else if (primaryPassword.Length < 8)
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                primaryPasswordBox.ToolTip = "Слабый пароль";
                primaryPasswordBox.Background = Brushes.LightYellow;
            }
            else if (secondaryPassword == string.Empty)
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                primaryPasswordBox.ToolTip = null;
                primaryPasswordBox.Background = Brushes.Transparent;

                secondaryPasswordBox.ToolTip = "Повторите пароль";
                secondaryPasswordBox.Background = Brushes.LightYellow;
            }
            else if (primaryPassword != secondaryPassword
                && secondaryPassword != string.Empty)
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                primaryPasswordBox.ToolTip = null;
                primaryPasswordBox.Background = Brushes.Transparent;

                secondaryPasswordBox.ToolTip = "Пароли не совпадают";
                secondaryPasswordBox.Background = Brushes.LightYellow;
            }
            else
            {
                emailTextBox.ToolTip = null;
                emailTextBox.Background = Brushes.Transparent;

                primaryPasswordBox.ToolTip = null;
                primaryPasswordBox.Background = Brushes.Transparent;

                secondaryPasswordBox.ToolTip = null;
                secondaryPasswordBox.Background = Brushes.Transparent;

                try
                {
                    User user = new User(email, nickname, CBFunctions.GetHash(primaryPassword), 0);

                    _context.Users.Add(user);

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException)
                    {
                        MessageBox.Show(ex.Message, "Ошибка регистрации");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Uncorrectable Error");
                    }
                }
            }
        }

        private void ToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage(_context));
        }

        private void RickrollButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=dQw4w9WgXcQ"){UseShellExecute = true});
        }
    }
}

