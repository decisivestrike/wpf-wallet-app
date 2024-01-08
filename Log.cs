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

        public override string ToString()
        {
            return $"{SenderName} -> {RecieverName}({Amount}$) {DateTime}";
        }
    }
}
