using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IHotelRoom
    {
        //create
        Task<HotelRoomDTO> CreateHotelRoom(int hotelId , HotelRoomDTO RoomDTO);
        //get all
        Task<List<HotelRoomDTO>> GetAllHotelRoom(int hotelId);
        //get Room details 
        Task<HotelRoomDTO> GetRoomDetails(int hotelId, int roomNumber);
      
        //update 
        Task<HotelRoomDTO> UpdateHotelsRoom(int hotelId, int roomNumber, HotelRoomDTO roomDTO);
        //delete
        Task DeleteHotelRoom(int hotelId, int roomNumber);
    }
}
