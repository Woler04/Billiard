using System.ComponentModel.DataAnnotations;

namespace Billiard.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; }
        public string UserReservation { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        public int TableReservation { get; set; }
        public string Description { get; set; }
    }
}
