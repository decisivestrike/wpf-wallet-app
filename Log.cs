using System.ComponentModel.DataAnnotations;

namespace Coinbase
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderName { get; set; }

        [Required]
        public string RecieverName { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string DateTime { get; set; }

        public Log(string senderName, string recieverName, double amount, string dateTime) 
        {
            SenderName = senderName;
            RecieverName = recieverName;
            Amount = amount;
            DateTime = dateTime;
        }

        public string ToString(string username)
        {
            if (username == SenderName)
            {
                return $"Send {Amount}$ to '{RecieverName}'";
            }
            else if (username == RecieverName)
            {
                return $"Received {Amount}$ from '{SenderName}'";
            }
            return username;
        }
    }
}
