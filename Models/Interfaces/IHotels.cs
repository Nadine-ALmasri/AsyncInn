using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IHotels

  
    {
        //create
        Task<HotelDTO>Create(HotelDTO hotelDTO);
        //get all
        Task<List<HotelDTO>> GetAll();
        //get by id
        Task<HotelDTO> GetById(int id);
        //update 
        Task<HotelDTO> UpdateHotels(int id , HotelDTO hotelDTO);
        //delete
        Task Delete(int id);


    }
}
