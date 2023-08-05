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
        }/// <summary>
        /// create new hotel
        /// </summary>
        /// <param name="hotelDTO"></param>
        /// <returns></returns>
        public async Task<HotelDTO> Create(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel
            {
                Id = hotelDTO.ID,
                Name = hotelDTO.Name,
                City = hotelDTO.City,
                State = hotelDTO.State,
                StreetAddress = hotelDTO.StreetAddress,
                Phone = hotelDTO.Phone,
                country = hotelDTO.country
                

            };
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelDTO;

        }
        /// <summary>
        /// delete a spasfic hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public async Task<HotelDTO> Delete(int id)

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
            };
           

            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return hotelDTO;
        }
        /// <summary>
        /// get all the hotels in list
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        }/// <summary>
        /// update the data for a spasfic hotel 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedHotel"></param>
        /// <returns></returns>
        public async Task<HotelDTO> UpdateHotels(int id, HotelDTO updatedHotel)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return null; // Or throw an exception if you prefer
            }

            hotel.Name = updatedHotel.Name;
            hotel.City = updatedHotel.City;
            hotel.State = updatedHotel.State;
            hotel.StreetAddress = updatedHotel.StreetAddress;
            hotel.Phone = updatedHotel.Phone;

            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Convert the updated entity back to HotelDTO and return it
            return new HotelDTO
            {
                ID = hotel.Id,
                Name = hotel.Name,
                City = hotel.City,
                State = hotel.State,
                StreetAddress = hotel.StreetAddress,
                Phone = hotel.Phone
            };
        }

        /* public async Task<HotelDTO> UpdateHotels(int id, HotelDTO hotelDTO)
         {

            /* _context.Entry(hotelDTO).State = EntityState.Modified;
             await _context.SaveChangesAsync();
             return hotelDTO;*/

   
    }
}
