using System.ComponentModel.DataAnnotations;

namespace Billiard.Models
{
    public class BilliardTables
    {
        [Key]
        public int Id { get; set; }
        public string Seats { get; set; }
        public bool IsForSmokers { get; set; }
    }
}
