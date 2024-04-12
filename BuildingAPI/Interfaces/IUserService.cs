using BuildingAPI.Dto.User_Dto;
using System.Security.Claims;

namespace BuildingAPI.Interfaces
{
    public interface IUserService
    {
        Task<List<UserReturnDto>> GetUsers();
        Task<List<UserReturnDto>> UpdateRole(int id);
        Task<List<UserReturnDto>> DeleteUser(int id);
        Task<UserReturnDto> GetAuthenticatedUser(Claim userEmail);
    }
}
