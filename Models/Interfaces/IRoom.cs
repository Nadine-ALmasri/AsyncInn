using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IRoom
    {/// <summary>
    /// add new room
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
        //create
        Task<RoomDTO>Create(RoomDTO room);
        //get all 
        /// <summary>
        /// get all the rooms
        /// </summary>
        /// <returns></returns>
        Task<List<RoomDTO>> GetAllRooms();
        //get by id 
        /// <summary>
        /// get room by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RoomDTO> GetRoomById(int id);
        //update 
        /// <summary>
        /// update room data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        Task<RoomDTO> UpdateRooms(int id , RoomDTO room);
        //delete 
        /// <summary>
        /// delet room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteRoom(int id);
        /// <summary>
        /// add amenity to a spasfic room
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="amenityId"></param>
        /// <returns></returns>
        Task AddAmenityToRoom(int roomId, int amenityId);
        /// <summary>
        /// remove amentiy from a room 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="amenityId"></param>
        /// <returns></returns>
        Task RemoveAmenityFromRoom(int roomId, int amenityId);
      
    }
}
