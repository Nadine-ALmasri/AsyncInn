using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.DTO;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AsyncInnManagementSystem.Models.Services
{
    public class HotelRoomServies : IHotelRoom
    {
        private readonly HotelDbContext _context;

        public HotelRoomServies(HotelDbContext context)
        {
            _context = context;
        }/// <summary>
        /// create new hotelroom
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="HotelRoomDTO"></param>
        /// <returns></returns>
        public async Task<HotelRoomDTO> CreateHotelRoom(int hotelId, HotelRoomDTO HotelRoomDTO)
        {
            var room = await _context.Rooms.FindAsync(HotelRoomDTO.RoomID);
            var hotel = await _context.Hotels.FindAsync(HotelRoomDTO.HotelID);
            if (hotel == null || room == null)
                return null;
            HotelRoom hotelroom = new HotelRoom
            {
                HotelId = HotelRoomDTO.HotelID,
                RoomId = HotelRoomDTO.RoomID,
                RoomNumber = HotelRoomDTO.RoomNumber,
                Rate = HotelRoomDTO.Rate,
                PetFrindly = HotelRoomDTO.PetFriendly
             };

            _context.HotelRooms.Add(hotelroom);
            await _context.SaveChangesAsync();

            return HotelRoomDTO;
        }
        /// <summary>
        /// delete a spasfic hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public async Task DeleteHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber);

            if (hotelRoom != null)
            {
                _context.Entry<HotelRoom>(hotelRoom).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// get all the hotelrooms in a list
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public Task<List<HotelRoomDTO>> GetAllHotelRoom(int hotelId)
        {
            var allHotelRomms = _context.HotelRooms.Select(h => new HotelRoomDTO()
            {
                HotelID = h.HotelId,
                RoomNumber = h.RoomNumber,
                Rate = h.Rate,
                PetFriendly = h.PetFrindly,
                RoomID = h.RoomId,
                Room = new RoomDTO()
                {
                    ID = h.Room.Id,
                    Name = h.Room.Name,
                    Layout = h.Room.Layout,
                    Amenities = h.Room.RoomAmenities.Select(ra => new AmenityDTO()
                    {
                        Name = ra.Amenity.Name,
                        ID = ra.Amenity.Id,
                    }).ToList()
                }
            
            }).ToListAsync(); 

            return allHotelRomms;


    }


        /// <summary>
        /// get room details 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>

    public async Task<HotelRoomDTO> GetRoomDetails(int hotelId, int roomNumber)
    {
        var roomDetails = await _context.HotelRooms
            .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
            .Include(hotel => hotel.Hotel)
            .Include(hr => hr.Room)
            .ThenInclude(roomAmenities => roomAmenities.RoomAmenities)
            .ThenInclude(amenity => amenity.Amenity)
            .Select(hr => new HotelRoomDTO
            {
                HotelID = hr.HotelId,
                RoomNumber = hr.RoomNumber,
                Rate = hr.Rate,
              PetFriendly = hr.PetFrindly,
                RoomID = hr.RoomId,
                Room = new RoomDTO
                {
                    ID = hr.Room.Id,
                    Name = hr.Room.Name,
                    Layout = hr.Room.Layout,
                    Amenities = hr.Room.RoomAmenities
                        .Select(ra => new AmenityDTO
                        {
                            ID = ra.Amenity.Id,
                            Name = ra.Amenity.Name
                        }).ToList()
                }
            })
            .FirstOrDefaultAsync();

        return roomDetails;
    }
        /// <summary>
        /// update spasfic room hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="roomNumber"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        public async Task<HotelRoomDTO> UpdateHotelsRoom(int hotelId, int roomNumber, HotelRoomDTO room)
        {
            var hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber);

            if (hotelRoom != null)
            {
                hotelRoom.HotelId = room.HotelID;
                hotelRoom.RoomId = room.RoomID;
                hotelRoom.RoomNumber = room.RoomNumber;
                hotelRoom.Rate = room.Rate;
                hotelRoom.PetFrindly = room.PetFriendly;

                await _context.SaveChangesAsync();
            }

            return room;
        }
    }
}