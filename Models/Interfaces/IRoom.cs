using AsyncInnManagementSystem.Models.DTO;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IRoom
    {
        //create
        Task<RoomDTO>Create(RoomDTO room);
        //get all 
        Task<List<RoomDTO>> GetAllRooms();
        //get by id 
        Task<RoomDTO> GetRoomById(int id);
        //update 
        Task<RoomDTO> UpdateRooms(int id , RoomDTO room);
        //delete 
        Task DeleteRoom(int id);
        Task AddAmenityToRoom(int roomId, int amenityId);

        Task RemoveAmenityFromRoom(int roomId, int amenityId);
      
    }
}
