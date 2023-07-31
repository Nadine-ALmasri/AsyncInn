using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IAmenities
    {
        //create  
        Task<AmenityDTO> CreateAmenity(AmenityDTO amenity);
        //get all
        Task<List<AmenityDTO>> GetAllAmenities();
        // get by id
        Task<AmenityDTO> GetAmenityById(int id);
        // update 
        Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenity);
        // delete 
        Task DeleteAmenity(int id);
    }
}
