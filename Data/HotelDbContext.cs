
using AsyncInnManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AsyncInnManagementSystem.Data
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
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
            SeedRoles(modelBuilder); // Call the role seeding here once

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
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            SeedRole(modelBuilder, "District Manager", "create", "update", "delete", "read");
            SeedRole(modelBuilder, "Property Manager", "create", "update", "read");
            SeedRole(modelBuilder, "Agent", "create", "update", "read");
            SeedRole(modelBuilder, "Anonymous users");
        }
        int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var roleId = roleName.Replace(" ", "").ToLower(); // Convert "District Manager" to "districtmanager"

            var role = new IdentityRole
            {
                Id = roleId,
                Name = roleName,
                NormalizedName = roleName.ToUpper() ,
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
                new IdentityRoleClaim<string>
                {
                    Id = nextId++,
                    RoleId = role.Id,
                    ClaimType = "permissions",
                    ClaimValue = permission
                }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
           
        }
       

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

    }
}
