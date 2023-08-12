using AsyncInnManagementSystem.Models.DTO;
using AsyncInnManagementSystem.Models.Interfaces;
using AsyncInnManagementSystem.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInnManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser userServies;
        public UsersController(IUser services)
        {
            userServies = services;
        }
        [Authorize(Roles = "Property Manager")]
        [HttpPost("Register/Agent")]
        public async Task<ActionResult<UserDTO>> RegisterAgent(RegisterDTO Data)
        {
            var agentUser = await userServies.RegisterAgent(Data, ModelState);
            if (ModelState.IsValid)
            {
                return agentUser;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }
        [Authorize(Roles = "District Manager")]

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO Data)
        {
            var user = await userServies.Register(Data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LogInDTO loginDto)
        {
            var user = await userServies.LogIn(loginDto.UserName, loginDto.Password);
            if  (user==null)
            {
                return Unauthorized (); 
                
            }
            return Ok(user);
        }
        [Authorize (Roles =  "District Manager")]
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDTO>> Profile()
        {
            return await userServies.GetUser(this.User);
        }
    }
}
