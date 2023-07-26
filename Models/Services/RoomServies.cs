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
            var AllRooms = await _context.Rooms.Include(x => x.RoomAmenities).ToListAsync();
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
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomAmenities)
                .FirstOrDefaultAsync(r => r.Id == roomId);

            var amenity = await _context.Amenities.FindAsync(amenityId);

            if (room != null && amenity != null)
            {
                var roomAmenity = new RoomAmenity { RoomId = roomId, AmenityId = amenityId };
                room.RoomAmenities.Add(roomAmenity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomAmenities)
                .FirstOrDefaultAsync(r => r.Id == roomId);

            var roomAmenity = room?.RoomAmenities.FirstOrDefault(ra => ra.AmenityId == amenityId);

            if (roomAmenity != null)
            {
                room.RoomAmenities.Remove(roomAmenity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

