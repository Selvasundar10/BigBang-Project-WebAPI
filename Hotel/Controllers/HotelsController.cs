using Hotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelDbContext hotelDbContext;

        public HotelsController(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }

        [HttpGet]
        [Route("GetHotels")]

        public List<Hotels> GetHotels()
        {
            return hotelDbContext.hotel.ToList();  


        }


        [HttpPost]
        [Route("AddHotels")]

        public string AddHotel(Hotels hotel) 
        {
            string response = string.Empty;
            hotelDbContext.hotel.Add(hotel);
            hotelDbContext.SaveChanges();
            return "Hotel Added";
        }

        [HttpPut]
        [Route("UpdateHotels")]

        public string UpdateHotels(Hotels hotel) 
        {
            hotelDbContext.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            hotelDbContext.SaveChanges();
            return "Hotel Updated";
        }


        [HttpDelete]
        [Route("DeleteHotel")]

        public string DeleteHotels(int id) 
        {
            Hotels hotel = hotelDbContext.hotel.Where(x => x.HotelId == id).FirstOrDefault();
            if (hotel != null) 
            {
                hotelDbContext.hotel.Remove(hotel);
                hotelDbContext.SaveChanges();
                return "Hotel Deleted";
            }
            else
            {
                return "No Hotel found";
            }
        }
        [HttpGet("filter")]
        public ActionResult<IEnumerable<Hotels>> FilterHotels(string location, string priceRange, string amenities)
        {
            // Parse the query string values
            decimal minPrice = 0;
            decimal maxPrice = 0;

            var amenitiesList = amenities.Split(',');

            // Apply the filter criteria
            var hotels = hotelDbContext.hotel.Where(h => h.Location == location && amenitiesList.Contains(h.Amenities));

            // Return the filtered hotels
            return hotels.ToList();

        }
    }
}
