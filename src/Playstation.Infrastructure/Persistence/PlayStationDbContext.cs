using Microsoft.EntityFrameworkCore;
using Playstation.Domain.Entity;
using System.Reflection;

namespace Playstation.Infrastructure.Persistence
{
    public class PlayStationDbContext : DbContext
    {
        public PlayStationDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSnack> BookingSnacks { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayStationRoom> PlayStationRooms { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<PlayStationRoomGame> PlayStationRoomGames { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
