using Hotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
    
        private readonly HotelDbContext RoomDbContext;

        public RoomsController(HotelDbContext RoomDbContext)
        {
            this.RoomDbContext = RoomDbContext;
        }

        [HttpGet]
        [Route("GetRooms")]

        public List<Rooms> GetRooms()
        {
            return RoomDbContext.Rooms.ToList();
        }


        [HttpPost]
        [Route("AddRooms")]

        public string AddRooms(Rooms room)
        {
            string response = string.Empty;
            RoomDbContext.Rooms.Add(room);
            RoomDbContext.SaveChanges();
            return "Room Added";
        }

        [HttpPut]
        [Route("UpdateRooms")]

        public string UpdateRooms(Rooms room)
        {
            RoomDbContext.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            RoomDbContext.SaveChanges();
            return "Room Updated";
        }


        [HttpDelete]
        [Route("DeleteRoom")]

        public string DeleteRooms(int id)
        {
            Rooms room = RoomDbContext.Rooms.Where(x => x.RoomId == id).FirstOrDefault();
            if (room != null)
            {
                RoomDbContext.Rooms.Remove(room);
                RoomDbContext.SaveChanges();
                return "Rooms Deleted";
            }
            else
            {
                return "No Rooms found";
            }
        }


        // GET: api/room/available
        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            try
            {
                var rooms = RoomDbContext.Rooms.Where(r => r.Availability == true).ToList();
                if (rooms.Count == 0)
                {
                    return NotFound("No available rooms.");
                }
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/room/available/{hotelId}
        [HttpGet("available/{hotelId}")]
        public IActionResult GetAvailableByHotel(int RoomId)
        {
            try
            {
                var rooms = RoomDbContext.Rooms.Where(r => r.RoomId == RoomId && r.Availability == true).ToList();
                if (rooms.Count == 0)
                {
                    return NotFound($"No available rooms in hotel with ID: {RoomId}");
                }
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
