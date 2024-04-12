using BuildingAPI.Dto;
using BuildingAPI.Dto.Apartment_Dto;
using BuildingAPI.Dto.User_Dto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace BuildingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService serveice )
        {
            _service = serveice;
        }

        [HttpGet, Authorize(Roles = "Admin")] // AllowAnonymous]
        public async Task<ActionResult<List<UserReturnDto>>> GetUsers()
        {
            var response = await _service.GetUsers();
            return Ok(response);
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserReturnDto>>> UpdateRole(int id) 
        {
            var response = await _service.UpdateRole(id);
            return Ok(response);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserReturnDto>>> DeleteUser(int id)
        {
            var response = await _service.DeleteUser(id);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<UserReturnDto>> GetAuthenticatedUser()
        {
            var userEmail = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);

            if (userEmail == null)
            {
                throw new Exception("Claim not found");
            }
            var user = await _service.GetAuthenticatedUser(userEmail);

            return user;
        }
    }
}
