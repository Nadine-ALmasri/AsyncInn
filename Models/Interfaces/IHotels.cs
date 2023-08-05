using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IHotels

  
    {
        //create
        /// <summary>
        /// add new hotel
        /// </summary>
        /// <param name="hotelDTO"></param>
        /// <returns></returns>
        Task<HotelDTO>Create(HotelDTO hotelDTO);
        //get all
        /// <summary>
        /// get all the list of hotels
        /// </summary>
        /// <returns></returns>
        Task<List<HotelDTO>> GetAll();
        //get by id
        /// <summary>
        /// get hotel by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HotelDTO> GetById(int id);
        //update 
        /// <summary>
        /// update the data of a hotel 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotelDTO"></param>
        /// <returns></returns>
        Task<HotelDTO> UpdateHotels(int id , HotelDTO hotelDTO);
        //delete
        /// <summary>
        /// delete a hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HotelDTO> Delete(int id);


    }
}
