using Hotel.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Repository
{
    public interface IRoom
    {
        [HttpGet]
        [Route("api/room")]
        IEnumerable<Rooms> GetRooms();

        [HttpGet]
        [Route("api/room/{id}")]
        Rooms GetRoomById(int id);

        [HttpPost]
        [Route("api/room")]
        Rooms PostRoom(Rooms room);

        [HttpPut]
        [Route("api/room/{id}")]
        Rooms PutRoom(int id, Rooms room);


        [HttpDelete]
        [Route("api/room/{id}")]
        void DeleteRoom(int id);

        [HttpGet("available")]
        IEnumerable<Rooms> GetAvailableRooms();


        [HttpGet("available/{hotelId}")]
        IEnumerable<Rooms> GetAvailableRoomsByHotel(int hotel_Id);

     
    }
}

