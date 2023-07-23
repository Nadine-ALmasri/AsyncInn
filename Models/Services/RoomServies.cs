using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnManagementSystem.Models.Services
{
    public class RoomServies : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomServies(HotelDbContext context){
            _context = context;
        }
    public async Task<Room> Create(Room room)
        {
_context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
               }

        public async Task DeleteRoom(int id)
        {
          Room room =await  GetRoomById(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<List<Room>> GetAllRooms()
        {
            var AllRooms = await _context.Rooms.ToListAsync();
                return AllRooms;
        }

        public async Task<Room> GetRoomById(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            return room;
        }

        public async Task<Room> UpdateRooms(int id, Room room)
        {
         _context.Entry(room).State = EntityState.Modified;
        await _context.SaveChangesAsync();
            return room;
        }
    }
}
