using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.DTO;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnManagementSystem.Models.Services
{
    public class RoomServies : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomServies(HotelDbContext context){
            _context = context;
        }/// <summary>
        /// add new room
        /// </summary>
        /// <param name="roomDTO"></param>
        /// <returns></returns>
        public async Task<RoomDTO> Create(RoomDTO roomDTO)
        {
            var room = new Room
            {
                Name = roomDTO.Name,
                Layout = roomDTO.Layout,
                RoomAmenities = roomDTO.Amenities.Select(a => new RoomAmenity { AmenityId = a.ID }).ToList()
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            roomDTO.ID = room.Id;
            return roomDTO;
        }
        /// <summary>
        /// delete spasfic room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return true; // Return true to indicate successful deletion
            }

            return false; // Return false to indicate room not found
        }

        /// <summary>
        /// get all the rooms 
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoomDTO>> GetAllRooms()
        {
            var allRooms = await _context.Rooms.Select(r => new RoomDTO
                {
                    ID = r.Id,
                    Name = r.Name,
                    Layout = r.Layout,
                    Amenities = r.RoomAmenities.Select(ra => new AmenityDTO
                    {
                        ID = ra.Amenity.Id,
                        Name = ra.Amenity.Name
                    }).ToList()
                })
                .ToListAsync();

            return allRooms;
        }

        /// <summary>
        /// get room by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RoomDTO> GetRoomById(int id)
        {
            var room = await _context.Rooms.Select(r => new RoomDTO
            {
                ID = r.Id,
                Name = r.Name,
                Layout = r.Layout,
                Amenities = r.RoomAmenities.Select(ra => new AmenityDTO
                {
                    ID = ra.Amenity.Id,
                    Name = ra.Amenity.Name
                }).ToList()
            })
                .FirstOrDefaultAsync();


            return room;
        }
        /// <summary>
        /// update the data of spasfic room
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roomDTO"></param>
        /// <returns></returns>
        public async Task<RoomDTO> UpdateRooms(int id, RoomDTO roomDTO)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room != null)
            {
                room.Name = roomDTO.Name;
                room.Layout = roomDTO.Layout;

                // Remove all existing room amenities and add the ones from DTO
                room.RoomAmenities.Clear();
                room.RoomAmenities = roomDTO.Amenities.Select(a => new RoomAmenity { AmenityId = a.ID }).ToList();

                await _context.SaveChangesAsync();
            }

            return roomDTO;
        }/// <summary>
        /// add amenity to a spasfic room
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="amenityId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// delete amenity from a room
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="amenityId"></param>
        /// <returns></returns>
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

