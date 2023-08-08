using AsyncInnManagementSystem.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IUser
    {
        public Task <UserDTO> Register (RegisterDTO registerDTO , ModelStateDictionary modelState );
        public Task<UserDTO> LogIn(string UserName , string Password );

    }
}
