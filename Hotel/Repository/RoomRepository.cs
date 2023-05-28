
using Hotel.Model;
using Microsoft.AspNetCore.Mvc;


namespace HotelApi.Repository
{
    public class RoomRepository : IRoom
    {
        private readonly HotelDbContext Roomcontext;

        public RoomRepository(HotelDbContext context)
        {
            Roomcontext = context;
        }

        [HttpGet]
        [Route("api/Room")]
        [ProducesResponseType(typeof(IEnumerable<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Rooms> GetRooms()
        {
            try
            {
                return Roomcontext.Rooms.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve rooms.", ex);
            }
        }

        [HttpGet]
        [Route("api/room/{id}")]
        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Rooms GetRoomById(int id)
        {
            try
            {
                return Roomcontext.Rooms.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Room not found with ID: {id}", ex);
            }
        }

        [HttpPost]
        [Route("api/room")]
        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Rooms PostRoom([FromBody] Rooms room)
        {
            try
            {
                Roomcontext.Add(room);
                Roomcontext.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create room.", ex);
            }
        }

        [HttpPut]
        [Route("api/room")]
        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Rooms PutRoom([FromBody] Rooms room)
        {
            try
            {
                Roomcontext.Update(room);
                Roomcontext.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update room.", ex);
            }
        }

        [HttpDelete]
        [Route("api/room/{id}")]
        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void DeleteRoom(int id)
        {
            try
            {
                var room = Roomcontext.Rooms.Find(id);
                if (room != null)
                {
                    Roomcontext.Remove(room);
                    Roomcontext.SaveChanges();
                }
                else
                {
                    throw new Exception($"Room not found with ID: {id}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete room.", ex);
            }
        }

        public Rooms PutRoom(int id, Rooms room)
        {
            throw new NotImplementedException();
        }


        [HttpGet("available/{hotelId}")]
        [ProducesResponseType(typeof(IEnumerable<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Rooms> GetAvailableRoomsByHotel(int hotelId)
        {
            try
            {
                return Roomcontext.Rooms.Where(r => r.HotelId == hotelId && r.Availability == true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve available rooms in hotel with ID: {hotelId}", ex);
            }
        }

        public IEnumerable<Rooms> GetAvailableRooms()
        {
            throw new NotImplementedException();
        }
    }
}

