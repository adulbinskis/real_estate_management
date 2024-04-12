using BuildingAPI.Dto.Auth_Dto;
using BuildingAPI.Dto.TokenDto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService service)
        {
           _authService= service;

        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authService.Register(request);

            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(UserDto request)
        {
            var tokens = await _authService.Login(request, Response);

            return Ok(tokens);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(UserDto request)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (refreshToken == null) 
            {
                return BadRequest("You dont have refresh token");
            } 
                
            string token = await _authService.RefreshToken(refreshToken, request);

            return Ok(token);
        }

    }
}
