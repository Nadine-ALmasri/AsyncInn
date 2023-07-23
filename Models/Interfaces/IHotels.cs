namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IHotels
    {
        //create
        Task<Hotel>Create(Hotel hotel);
        //get all
        Task<List<Hotel>> GetAll();
        //get by id
        Task<Hotel> GetById(int id);
        //update 
        Task<Hotel> UpdateHotels(int id , Hotel hotel);
        //delete
        Task Delete(int id);


    }
}
