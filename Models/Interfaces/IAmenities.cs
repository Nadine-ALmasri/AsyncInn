using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IAmenities
    {
        //create  
        /// <summary>
        /// add new amenity
        /// </summary>
        /// <param name="amenity"></param>
        /// <returns></returns>
        Task<AmenityDTO> CreateAmenity(AmenityDTO amenity);
        //get all
        /// <summary>
        /// get all the amenites
        /// </summary>
        /// <returns></returns>
        Task<List<AmenityDTO>> GetAllAmenities();
        // get by id
        /// <summary>
        /// get amentity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmenityDTO> GetAmenityById(int id);
        // update 
        /// <summary>
        /// modifie an amenity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amenity"></param>
        /// <returns></returns>
        Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenity);
        // delete 
        /// <summary>
        /// remove an amenity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAmenity(int id);
    }
}
