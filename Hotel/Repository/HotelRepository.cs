
using Microsoft.EntityFrameworkCore;
using Hotel.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _hoteldbContext;

        public HotelRepository(HotelDbContext con)
        {
            _hoteldbContext = con;
        }


        public IEnumerable<Hotels> GetHotel()
        {
            try
            {
                return _hoteldbContext.hotel.Include(x => x.Rooms).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve hotels.", ex);
            }
        }

        public Hotels GetHotelById(int HotelId)
        {
            try
            {
                return _hoteldbContext.hotel.FirstOrDefault(x => x.HotelId == HotelId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve hotel by ID.", ex);
            }
        }

        public Hotels PostHotel(Hotels hotel)
        {
            try
            {
                _hoteldbContext.hotel.Add(hotel);
                _hoteldbContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create hotel.", ex);
            }
        }

        public Hotels PutHotel(int HotelId, Hotels hotel)
        {
            try
            {
                _hoteldbContext.Entry(hotel).State = EntityState.Modified;
                _hoteldbContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update hotel.", ex);
            }
        }

        public Hotels DeleteHotel(int HotelId)
        {
            try
            {
                var hotel = _hoteldbContext.hotel.Find(HotelId);
                _hoteldbContext.hotel.Remove(hotel);
                _hoteldbContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete hotel.", ex);
            }
        }
        //filter
        [HttpGet]
        public IEnumerable<Hotels> GetHotels(Hotels filter)
        {
            var query = _hoteldbContext.hotel.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Location))
            {
                query = query.Where(h => h.Location == filter.Location);
            }

            if (!string.IsNullOrEmpty(filter.Amenities))
            {
                var amenitiesList = filter.Amenities.Split(',');
                query = query.Where(h => amenitiesList.Contains(h.Amenities));
            }

            return query.ToList();
        }
    }
}
 
