using System.Windows.Controls;

namespace Coinbase
{
    public partial class HistoryPage : Page
    {
        private Context _context;
        private User _user;
        private List<Log> _logs = new List<Log>();
        private List<Data> _history = new List<Data>();

        public struct Data
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public Data(string key, string value)
            {
                Key = key; Value = value;   
            }
        }

        public HistoryPage(Context context, User user)
        {
            InitializeComponent();

            _context = context;
            _user = user;

            LoadLogs();
        }

        public void LoadLogs()
        {
            LogsListBox.ItemsSource = null;

            _logs = _context.Logs.Where(
                l => l.SenderName == _user.Nickname || l.RecieverName == _user.Nickname).ToList();

            if (_history.Count < _logs.Count)
            {
                for (int i = _history.Count; i < _logs.Count; i++)
                {
                    _history.Add(new Data(_logs[i].ToString(_user.Nickname), _logs[i].DateTime));
                }
            }

            if (_history.Count == 0)
            {
                LogsListBox.ItemsSource = new List<string> { "There's nothing here :(" };
            }
            else
            {
                LogsListBox.ItemsSource = _history;
            }
        }
    }
}
