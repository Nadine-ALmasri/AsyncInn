using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IHotelRoom
    {
        //create
        /// <summary>
        /// add new hotel room
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="RoomDTO"></param>
        /// <returns></returns>
        Task<HotelRoomDTO> CreateHotelRoom(int hotelId , HotelRoomDTO RoomDTO);
        //get all
        /// <summary>
        /// get all hotel rooms 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        Task<List<HotelRoomDTO>> GetAllHotelRoom(int hotelId);
        //get Room details 

        /// <summary>
        ///  get a room details by its id and number
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        Task<HotelRoomDTO> GetRoomDetails(int hotelId, int roomNumber);
      
        //update 
        /// <summary>
        ///  update room data
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="roomNumber"></param>
        /// <param name="roomDTO"></param>
        /// <returns></returns>
        Task<HotelRoomDTO> UpdateHotelsRoom(int hotelId, int roomNumber, HotelRoomDTO roomDTO);
        //delete
        /// <summary>
        /// delete hotel room
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        Task DeleteHotelRoom(int hotelId, int roomNumber);
    }
}
