using AsyncInnManagementSystem.Models.DTO;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AsyncInnManagementSystem.Models.Services
{
    public class UserServies : IUser
    {
        private UserManager<ApplicationUser> _userManager;
        public UserServies(UserManager<ApplicationUser> manager)
        {
            _userManager = manager;


        }



        public async Task<UserDTO> LogIn(string UserName, string Password)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            bool vaildtionOfPassword = await _userManager.CheckPasswordAsync(user, Password);
            if (vaildtionOfPassword)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };
            }
            return null; 
        }

        public async Task<UserDTO> Register(RegisterDTO registerDTO, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerDTO.UserName,
                PhoneNumber = registerDTO.Phone ,
                Email = registerDTO.Email ,


            };
            var result = await _userManager.CreateAsync(user , registerDTO.Password);
            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            foreach (var error in result.Errors) {
                var errorKey = error.Code.Contains("Password") ? nameof(registerDTO.Password) :
                     error.Code.Contains("Email") ? nameof(registerDTO.Email) :
                      error.Code.Contains("UserName") ? nameof(registerDTO.UserName) : "";
                modelState.AddModelError(errorKey, error.Description);

            }
            return null;
        }
    }
}

