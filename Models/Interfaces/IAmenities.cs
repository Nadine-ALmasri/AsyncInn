namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IAmenities
    {
        //create  
        Task<Amenity> CreateAmenity(Amenity amenity);
        //get all
        Task<List<Amenity>> GetAllAmenities();
        // get by id
        Task<Amenity> GetAmenityById(int id);
        // update 
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);
        // delete 
        Task DeleteAmenity(int id);
    }
}
