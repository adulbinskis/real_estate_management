using BuildingAPI.Dto.Building_Dto;
using BuildingAPI.Dto;

namespace BuildingAPI.Interfaces
{
    public interface IBuildingService
    {
        Task<ReturnBuildingDto> GetBuildingById(int id);
        Task<List<ReturnBuildingDto>> GetBuildings();
        Task<List<ReturnBuildingDto>> GetUserBuildings(int userId);
        Task<ReturnBuildingDto> CreateBuilding(CreateBuildingDto request);
        Task<ReturnBuildingDto> UpdateBuilding(int id, UpdateBuildingDto request);
        Task<ReturnBuildingDto> DeleteBuilding(int id);
        
    }
}
