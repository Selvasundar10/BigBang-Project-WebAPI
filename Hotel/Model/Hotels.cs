using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Model
{
    public class Hotels
    {
        [Key]
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Amenities { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        public int Rating { get; set; }


        public ICollection<Rooms>? Rooms { get; set; }

    }
}