using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnManagementSystem.Models.Services
{
    public class AmenitiesServies : IAmenities
    {
        private readonly HotelDbContext _context;

        public AmenitiesServies(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> CreateAmenity(Amenity amenity)
        {
            _context.Amenities.AddAsync(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task DeleteAmenity(int id)
        {
            Amenity amenity = await GetAmenityById(id);
            _context.Entry(amenity).State = EntityState.Deleted;   
            await _context.SaveChangesAsync();
        }
        public Task<List<Amenity>> GetAllAmenities()
        {
            var amenities = _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> GetAmenityById(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
        
            return amenity;
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            return amenity;
                }
    }
}
