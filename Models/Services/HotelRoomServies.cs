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
            var hotel = await _context.Hotels.FindAsync(hotelId);
            if (hotel == null)
                return null;
            HotelRoom.HotelId = hotelId;
            _context.AddAsync(HotelRoom);
                await _context.SaveChangesAsync();
            return HotelRoom;
        }

        public async Task DeleteHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms.Where(hotelroom => hotelroom.HotelId==hotelId&&hotelroom.RoomNumber==roomNumber).FirstOrDefaultAsync();

            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
         

        }

        public Task<List<Models.HotelRoom>> GetAllHotelRoom(int hotelId)
        {
        var allHotelRomms=    _context.HotelRooms.Where(h => h.HotelId == hotelId).Include(hr => hr.Room).ToListAsync();
            return allHotelRomms;   

        }

        public Task<Models.HotelRoom> GetRoomDetails(int hotelId, int roomNumber)
        {
            var roomDetails = _context.HotelRooms
                   .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                   .Include(hr => hr.Room)
                   .FirstOrDefaultAsync();
            return roomDetails;
        }

        public async  Task<HotelRoom> UpdateHotelsRoom(int hotelId, int roomNumber, HotelRoom room)
        {
            var updatedRoom =await _context.HotelRooms.Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber).Include(hr => hr.Room)
        .FirstOrDefaultAsync();
            if (updatedRoom != null)
            {
                // Update the properties of the hotelRoom object with the new values from 'room'
                updatedRoom.Rate = room.Rate;
                updatedRoom.PetFrindly = room.PetFrindly;

               

                await _context.SaveChangesAsync();
            }

            return updatedRoom;
        }
    }
}
