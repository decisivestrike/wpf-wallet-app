using System.Windows;
using System.Windows.Controls;

namespace Coinbase
{
    public partial class ProfilePage : Page
    {
        private Context _context;

        private User _user;

        public ProfilePage(Context context, User user)
        {
            InitializeComponent();

            _context = context;

            _user = user;

            Nickname_TextBlock.Text = $"Name: {_user.Nickname}";

            Email_TextBlock.Text = $"E-mail: {_user.Email}";

            Money_TextBlock.Text = $"{Math.Round(_user.Money, 2)}$";
        }

        private void AddMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                _user.Money += 100.01;

                _context.SaveChanges();

                Money_TextBlock.Text = $"{Math.Round(_user.Money, 2)}$";
            }
        }

        public void Update()
        {
            Money_TextBlock.Text = $"{Math.Round(_user.Money, 2)}$";
        }
    }
}
