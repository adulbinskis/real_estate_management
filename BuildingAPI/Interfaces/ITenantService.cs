using BuildingAPI.Dto;
using BuildingAPI.Dto.Apartment_Dto;
using BuildingAPI.Dto.Tentant_Dto;
using Microsoft.AspNetCore.Mvc;

namespace BuildingAPI.Interfaces
{
    public interface ITenantService
    {
        Task<List<ReturnTenantDto>> GetUserTenants(int userId);
        Task<ReturnTenantDto> GetTenantById(int id);
        Task<List<ReturnTenantDto>> GetTenants();
        Task<ReturnTenantDto> CreateTenant(CreateTenantDto request);
        Task<ReturnTenantDto> UpdateTenant(int id, UpdateTenantDto request);
        Task<ReturnTenantDto> DeleteTenant(int id);
    }
}
