
using Microsoft.AspNetCore.Mvc;

using Hotel.Model;
namespace HotelApi.Repository
{
    public interface IHotelRepository
    {
        [HttpGet]
        [Route("api/hotels")]
        public IEnumerable<Hotels> GetHotel();

        [HttpGet]
        [Route("api/hotels/{HotelId}")]
        public Hotels GetHotelById(int HotelId);

        [HttpPost]
        [Route("api/hotel")]
        public Hotels PostHotel(Hotels hotel);

        [HttpPut]
        [Route("api/hotel/{HotelId}")]
        public Hotels PutHotel(int HotelId, Hotels hotel);

        [HttpDelete]
        [Route("api/hotel/{HotelId}")]
        public Hotels DeleteHotel(int HotelId);

        [HttpGet]
        public IEnumerable<Hotels> GetHotels(Hotels filter);
    }
   
}
