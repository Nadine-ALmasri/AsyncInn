using AsyncInnManagementSystem.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace AsyncInnManagementSystem.Models.Interfaces
{
    public interface IUser
    {
        public Task <UserDTO> Register (RegisterDTO registerDTO , ModelStateDictionary modelState );
        public Task<UserDTO> LogIn(string UserName , string Password );
        public Task<UserDTO> GetUser(ClaimsPrincipal principal);
        public Task<ActionResult<UserDTO>> RegisterAgent(RegisterDTO registerDTO, ModelStateDictionary modelState);

    }
}
