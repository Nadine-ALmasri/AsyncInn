namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IRoom
    {
        //create
        Task<Room>Create(Room room);
        //get all 
        Task<List<Room>> GetAllRooms();
        //get by id 
        Task<Room> GetRoomById(int id);
        //update 
        Task<Room> UpdateRooms(int id , Room room);
        //delete 
        Task DeleteRoom(int id);
    }
}
