using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Model
{
    public class Rooms
    {

        [Key]
        public int RoomId { get; set; }

        [ForeignKey("Hotels")]
        public int HotelId { get; set; }

        public int RoomCount { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }
        public bool Availability { get; set; }
    }
}
