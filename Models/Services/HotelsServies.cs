using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.Interfaces;
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
        public async Task<Hotel> Create(Hotel hotel)
        {
           _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)

        {
            Hotel hotel = await GetById(id);

            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
                }

        public async Task<List<Hotel>> GetAll()
        {
           var hotels =await _context.Hotels.Include(h => h.HotelRooms)
                    .ThenInclude(hr => hr.Room) // Eagerly load the Room entity
                .ToListAsync(); ;
            return hotels;
        }

        public async Task<Hotel> GetById(int id)
        {
           var hotel =await _context.Hotels.FindAsync(id);
            return hotel;

        }

        public async Task<Hotel> UpdateHotels(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;

        }
    }
}
