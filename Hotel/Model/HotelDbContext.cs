
using Hotel.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Model
{
    public class HotelDbContext : DbContext
    {
        internal static readonly object Hotels;
        internal static object hotels;

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public DbSet<Hotels> hotel { get; set; }

        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Reservation_Details> Customer { get; set; }

        public DbSet<User> User { get; set; }

    }
}