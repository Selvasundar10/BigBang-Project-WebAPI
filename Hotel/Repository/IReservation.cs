using Hotel.Model;
namespace HotelApi.Repository
{
    public interface IReservation
    {
        IEnumerable<Reservation_Details> GetReservation();
        Reservation_Details GetReservationById(int reservationId);
        Reservation_Details PostReservation(Reservation_Details Reservation);
        Reservation_Details PutReservation(int reservationId, Reservation_Details Reservation);
        Reservation_Details DeleteReservation(int reservationId);
    }
}
