using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnManagementSystem.Models.Services
{
    public class HotelRoomServies : IHotelRoom
    {
        private readonly HotelDbContext _context;

        public HotelRoomServies(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoom> CreateHotelRoom(int hotelId, HotelRoom HotelRoom)
        {
            var room = await _context.Rooms.FindAsync(HotelRoom.RoomId);
            var hotel = await _context.Hotels.FindAsync(HotelRoom.HotelId);
            if (hotel == null)
                return null;
            HotelRoom.HotelId = hotelId;
            HotelRoom.Room = room;
            HotelRoom.Hotel = hotel;
            _context.HotelRooms.Add(HotelRoom);

            await _context.SaveChangesAsync();

            return HotelRoom;
        }

        public async Task DeleteHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms.Where(hotelroom => hotelroom.HotelId==hotelId&&hotelroom.RoomNumber==roomNumber).FirstOrDefaultAsync();

            if (hotelRoom != null)
            {
                _context.Entry<HotelRoom>(hotelRoom).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }

        }

        public Task<List<Models.HotelRoom>> GetAllHotelRoom(int hotelId)
        {
        var allHotelRomms=    _context.HotelRooms.Where(h => h.HotelId == hotelId).Include(hr => hr.Room).ToListAsync();
            return allHotelRomms;   

        }

        public Task<Models.HotelRoom> GetRoomDetails(int hotelId, int roomNumber)
        {
            var roomDetails = _context.HotelRooms
                   .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber).Include(hotel => hotel.Hotel)
                   .Include(hr => hr.Room).ThenInclude(roomAmenities => roomAmenities.RoomAmenities)
                .ThenInclude(amenity => amenity.Amenity)
                   .FirstOrDefaultAsync();
            return roomDetails;
        }

        public async  Task<HotelRoom> UpdateHotelsRoom(int hotelId, int roomNumber, HotelRoom room)
        {
            var hotel = await _context.HotelRooms.FindAsync(hotelId, roomNumber);

            if (hotel != null)
            {
                hotel.HotelId = room.HotelId;
                hotel.RoomId = room.RoomId;
                hotel.RoomNumber = room.RoomNumber;
                hotel.Rate =   room.Rate;
                hotel.PetFrindly = room.PetFrindly;

                await _context.SaveChangesAsync();
            }

            return hotel;

        }
    }
}
