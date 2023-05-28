using System.ComponentModel.DataAnnotations;

namespace Hotel.Model
{
    public class Reservation_Details
    {
        
            [Key]
        public int Reservation_Id { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public ICollection<Hotels>? Hotel { get; set; }

        public ICollection<Rooms>? Room { get; set; }
    }
}
