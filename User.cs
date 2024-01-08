using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coinbase
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Nickname), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Hash { get; set; }

        [Required]
        public double Money { get; set; }

        public User(string email, string nickname, string hash, double money) 
        {
            Email = email;
            Nickname = nickname;
            Hash = hash;
            Money = money;
        }

        public override string ToString()
        {
            return $"{Email} - {Nickname} - {Hash} - {Money}";
        }
    }
}
