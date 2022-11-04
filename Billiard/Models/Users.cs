using System.ComponentModel.DataAnnotations;

namespace Billiard.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public List<Reservations> reservations = new List<Reservations>();
    }
}
