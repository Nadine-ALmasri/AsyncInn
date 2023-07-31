using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models.DTO;
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
        public async Task<AmenityDTO> CreateAmenity(AmenityDTO amenity)
        {
            Amenity amenity1 = new Amenity();
            {
                amenity1.Name = amenity.Name ;
                amenity1.Id = amenity.ID;
            }
            _context.Amenities.AddAsync(amenity1);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task DeleteAmenity(int id)
        {
            AmenityDTO amenityDTO = await GetAmenityById(id);

            Amenity amenity = new Amenity()
            {
                Id = amenityDTO.ID,
                Name = amenityDTO.Name

            };
                
               
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public Task<List<AmenityDTO>> GetAllAmenities()
        {

            var amenities = _context.Amenities.Select(a => new AmenityDTO()
            {
                Name = a.Name,
                ID=a.Id

            }).ToListAsync();
            return amenities;
        }

        public async Task<AmenityDTO> GetAmenityById(int id)
        {
            var amenity = await _context.Amenities.Select(a => new AmenityDTO()
            {
                Name = a.Name, ID=a.Id
                
            }).FirstOrDefaultAsync();
        
            return amenity;
        }

        public async Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenityDTO)
        {
            var amenity = await _context.Amenities.FindAsync(id);

            if (amenity != null)
            {
                amenity.Name = amenityDTO.Name;
                amenity.Id = amenityDTO.ID;

                await _context.SaveChangesAsync();
            }

            return amenityDTO;
        }
    }
}