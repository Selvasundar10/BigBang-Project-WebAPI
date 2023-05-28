using Hotel.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repository
{
    
        public class ReservationRepository : IReservation
        {
            private readonly HotelDbContext ReservationContext;

            public ReservationRepository(HotelDbContext con)
            {
                ReservationContext = con;
            }

            public IEnumerable<Reservation_Details> GetReservation()
            {
                try
                {
                    return ReservationContext.Customer.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve  ", ex);
                }
            }

            public Reservation_Details GetReservationById(int reservationId)
            {
                try
                {
                    return ReservationContext.Customer.FirstOrDefault(x => x.Reservation_Id == reservationId);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Not found with ID: {reservationId}", ex);
                }
            }

            public Reservation_Details PostReservation(Reservation_Details Reservation)
            {
                try
                {
                    ReservationContext.Add(Reservation);
                    ReservationContext.SaveChanges();
                    return Reservation;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to create booking.", ex);
                }
            }

            public Reservation_Details PutReservation(int reservationId, Reservation_Details Reservation)
            {
                try
                {
                    var reserve = ReservationContext.Customer.Find(Reservation.Reservation_Id);
                    ReservationContext.Entry(Reservation).State = EntityState.Modified;
                    ReservationContext.SaveChanges();
                    return Reservation;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update booking.", ex);
                }
            }

            public void DeleteReservation(int reservationId)
            {
                try
                {

                var reserve = ReservationContext.Customer.Find(reservationId);

                ReservationContext.Customer.Remove(reserve);
                        ReservationContext.SaveChanges();
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to delete booking.", ex);
                }
            }

            Reservation_Details IReservation.DeleteReservation(int reservationId)
            {
                throw new NotImplementedException();
            }
        }
    }
 