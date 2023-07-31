
using AsyncInnManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnManagementSystem.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                Name = "Marriot",
                City = "AMMAN",
                country = "Jordan",
                StreetAddress = "12.456",
                Phone = "01345775",
                State = "west"
            },
             new Hotel
             {
                 Id = 2,
                 Name = "chiraton",
                 City = "Aqaba",
                 country = "Jordan",
                 StreetAddress = "100.123",
                 Phone = "154634645",
                 State = "north"
             },
             new Hotel
             {
                 Id = 3,
                 Name = "Rotana",
                 City = "Irbd",
                 country = "Jordan",
                 StreetAddress = "120.456",
                 Phone = "154545454",
                 State = "south"
             }
            );

            modelBuilder.Entity<Room>().HasData(
         new Room { Id = 1, Layout = 1, Name = "first Room" }, new Room { Id = 2, Layout = 3, Name = "secound Room" }, new Room { Id = 3, Layout = 1, Name = "third Room" }
            );

            modelBuilder.Entity<Amenity>().HasData(
           new Amenity
           {
               Id = 1,
               Name = "condition"
           }, new Amenity
           {
               Id = 2,
               Name = "coffee and tea"
           }, new Amenity
           {
               Id = 3,
               Name = "big sofa"
           }
            );
            modelBuilder.Entity<RoomAmenity>().HasKey(
               RoomAmenities => new { RoomAmenities.RoomId, RoomAmenities.AmenityId });



            modelBuilder.Entity<HotelRoom>().HasKey(
                  HotelRooms => new
                  {
                      HotelRooms.RoomId,
                      HotelRooms.RoomNumber
                  });

            modelBuilder.Entity<HotelRoom>()
                .Property(hotelRoom => hotelRoom.Rate)
                .HasPrecision(18, 2); // Specify the appropriate precision and scale



            modelBuilder.Entity<HotelRoom>().HasKey(
               Keys => new
               {
                   Keys.HotelId,
                   Keys.RoomNumber


               });
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

    }
}
