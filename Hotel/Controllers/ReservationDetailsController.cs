using Hotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDetailsController : ControllerBase
    {
        private readonly HotelDbContext ReservationDbContext;

        public ReservationDetailsController(HotelDbContext ReservationDbContext)
        {
            this.ReservationDbContext = ReservationDbContext;
        }

        [HttpGet]
        [Route("GetReservation")]

        public List<Reservation_Details> GetReservation()
        {
            return ReservationDbContext.Customer.ToList();
        }


        [HttpPost]
        [Route("AddReservation")]

        public string AddReservation(Reservation_Details reservationDetails)
        {
            string response = string.Empty;
            ReservationDbContext.Customer.Add(reservationDetails);
            ReservationDbContext.SaveChanges();
            return "Reservation Added";
        }

        [HttpPut]
        [Route("UpdateReservation")]

        public string UpdateHotels(Reservation_Details reservationDetails)
        {
            ReservationDbContext.Entry(reservationDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ReservationDbContext.SaveChanges();
            return "Reservation Updated";
        }


        [HttpDelete]
        [Route("DeleteReservation")]

        public string DeleteHotels(int id)
        {
            Reservation_Details reservationDetails = ReservationDbContext.Customer.Where(x => x.Reservation_Id == id).FirstOrDefault();
            if (reservationDetails != null)
            {
                ReservationDbContext.Customer.Remove(reservationDetails);
                ReservationDbContext.SaveChanges();
                return "Reservation Deleted";
            }
            else
            {
                return "No Reservation found";
            }
        }

    }
}
