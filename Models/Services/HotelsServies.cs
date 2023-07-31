using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.DTO;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace AsyncInnManagementSystem.Models.Services
{
    public class HotelsServies : IHotels
    {
        private readonly HotelDbContext _context;

        public HotelsServies(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<HotelDTO> Create(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel
            {
                Id = hotelDTO.ID,
                Name = hotelDTO.Name,
                City = hotelDTO.City,
                State = hotelDTO.State,
                StreetAddress = hotelDTO.StreetAddress,
                Phone = hotelDTO.Phone

            };
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelDTO;

        }

        public async Task Delete(int id)

        {
            HotelDTO hotelDTO = await GetById(id);
          

            Hotel hotel = new Hotel
            {
                Id = hotelDTO.ID,
                Name = hotelDTO.Name,
                City = hotelDTO.City,
                State = hotelDTO.State,
                StreetAddress = hotelDTO.StreetAddress,
                Phone = hotelDTO.Phone
                // You can copy other properties if needed.
            };
           

            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<HotelDTO>> GetAll()
        {
            var hotel = await _context.Hotels.Select(h => new HotelDTO()
            {
                ID = h.Id,
                Name = h.Name,
                City = h.City,
                State = h.State,
                StreetAddress = h.StreetAddress,
                Phone = h.Phone,
                Rooms = h.HotelRooms.Select(hr => new HotelRoomDTO()
                {
                    HotelID = hr.HotelId,
                    Rate = hr.Rate,
                    RoomID = hr.RoomId,
                    RoomNumber = hr.RoomNumber,
                    PetFriendly = hr.PetFrindly,
                    Room = new RoomDTO()
                    {
                        ID = hr.Room.Id,
                        Name = hr.Room.Name,
                        Layout = hr.Room.Layout,
                        Amenities = hr.Room.RoomAmenities.Select(ra => new AmenityDTO()
                        {
                            Name = ra.Amenity.Name,
                            ID = ra.Amenity.Id,
                        }).ToList()
                    }
                }).ToList()
            }).ToListAsync(); 

            return hotel;
        }

        public async Task<HotelDTO> GetById(int id)
        {
            var hotel = await _context.Hotels.Select(h => new HotelDTO()
            {
                ID = h.Id, Name = h.Name,
                City = h.City,
                State = h.State,
                StreetAddress = h.StreetAddress,
                Phone = h.Phone,
                Rooms = h.HotelRooms.Select(hr => new HotelRoomDTO() {
                    HotelID = hr.HotelId,
                    Rate = hr.Rate,
                    RoomID = hr.RoomId,
                    RoomNumber = hr.RoomNumber,
                    PetFriendly = hr.PetFrindly,
                    Room = new RoomDTO()
                    {
                        ID = hr.Room.Id,
                        Name = hr.Room.Name,
                        Layout = hr.Room.Layout,
                        Amenities = hr.Room.RoomAmenities.Select(ra => new AmenityDTO()
                        { Name = ra.Amenity.Name,
                            ID = ra.Amenity.Id,
                        }).ToList()
                    }
                }).ToList()
            })
        .FirstOrDefaultAsync();






            return hotel;

        }

        public async Task<HotelDTO> UpdateHotels(int id, HotelDTO hotelDTO)
        {
            _context.Entry(hotelDTO).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelDTO;

        }
    }
}
