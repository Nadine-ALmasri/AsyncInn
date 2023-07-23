using AsyncInnManagementSystem.Models.Interfaces;

namespace AsyncInnManagementSystem.Models.Services
{
    public class HotelsServies : IHotels
    {
        public Task<Hotel> Create(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> UpdateHotels(int id, Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
