using BuildingAPI.Dto.Auth_Dto;
using BuildingAPI.Dto.TokenDto;
using BuildingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingAPI.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(UserDto request);
        Task<TokenDto> Login(UserDto request, HttpResponse httpResponse);

        Task<string> RefreshToken(string token, UserDto request);

    }
}
