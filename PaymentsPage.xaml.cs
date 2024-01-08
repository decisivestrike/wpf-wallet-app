using System.Windows;
using System.Windows.Controls;

namespace Coinbase
{
    public partial class PaymentsPage : Page
    {
        private Context _context;
        private User _user;
        public delegate void PaymentHandler(User sender, User reciever, double amount);
        public event PaymentHandler? OnPayment;

        public PaymentsPage(Context context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;
            OnPayment += LogPayment;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string nickname = NicknameTextBox.Text.Trim();

            User? reciever = _context.Users.Where(u => u.Nickname == nickname).FirstOrDefault();

            double amount;

            if (_user != null && reciever != null)
            {
                try
                {
                    amount = double.Parse(AmountTextBox.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (_user.Money < amount)
                {
                    MessageBox.Show("Не хватает средств на счете");
                }
                else if (amount < 0.01)
                {
                    MessageBox.Show("Слишком малое значение для перевода");
                }
                else
                {
                    _user.Money -= amount;
                    reciever.Money += amount;

                    _context.SaveChanges();

                    OnPayment?.Invoke(_user, reciever, amount);

                    MessageBox.Show("Успешный перевод");
                }
            }
            else
            {
                MessageBox.Show("Пользователя не существует");
            }
        }

        private void LogPayment(User sender, User reciever, double amount)
        {
            Log log = new Log(sender.Nickname, reciever.Nickname, amount, DateTime.Now.ToString());

            _context.Logs.Add(log);

            _context.SaveChanges();
        }
    }
}
