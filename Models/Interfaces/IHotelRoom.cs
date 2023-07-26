namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IHotelRoom
    {
        //create
        Task<HotelRoom> CreateHotelRoom(int hotelId , HotelRoom Room);
        //get all
        Task<List<HotelRoom>> GetAllHotelRoom(int hotelId);
        //get Room details 
        Task<HotelRoom> GetRoomDetails(int hotelId, int roomNumber);
      
        //update 
        Task<HotelRoom> UpdateHotelsRoom(int hotelId, int roomNumber, HotelRoom room);
        //delete
        Task DeleteHotelRoom(int hotelId, int roomNumber);
    }
}
