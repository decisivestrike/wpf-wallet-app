using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Windows.Controls;

namespace Coinbase
{
    public partial class HistoryPage : Page
    {
        private Context _context;
        private User _user;
        private List<Log> _logs;
        private List<string> _history;

        public HistoryPage(Context context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;

            _logs = _context.Logs.Where(l => l.SenderName == _user.Nickname
                                          || l.RecieverName == _user.Nickname).ToList();

            _history = new List<string>();

            LoadLogs();

            //if (_history.Count == 0)
            //{
            //    LogsListView.ItemsSource = new List<string> { "There's nothing here :(" };
            //}
            //else
            //{
            //    LogsListView.ItemsSource = _history;
            //}

            LogsListBox.ItemsSource = _logs;
        }

        public void LoadLogs()
        {
            //LogsListView.ItemsSource = null;

            //_logs = _context.Logs.Where(l => l.SenderName == _user.Nickname
            //                              || l.RecieverName == _user.Nickname).ToList();

            //if (_history.Count < _logs.Count)
            //{
            //    for (int i = _history.Count; i < _logs.Count; i++)
            //    {
            //        if (_logs[i].SenderName == _user.Nickname)
            //        {
            //            _history.Add($"Send {_logs[i].Amount}$ пользователю '{_logs[i].RecieverName}'");
            //        }
            //        else if (_logs[i].RecieverName == _user.Nickname)
            //        {
            //            _history.Add($"Получено {_logs[i].Amount}$ от пользователя '{_logs[i].RecieverName}'");
            //        }
            //    }
            //}

            //LogsListView.ItemsSource = _history;
        }
    }
}
