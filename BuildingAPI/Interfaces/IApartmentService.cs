using BuildingAPI.Dto;
using BuildingAPI.Dto.Apartment_Dto;
using Microsoft.AspNetCore.Mvc;

namespace BuildingAPI.Interfaces
{
    public interface IApartmentService
    {
        Task<List<ReturnApartmentDto>> GetUserApartments(int userId);
        Task<ReturnApartmentDto> GetApartmentById(int id);
        Task<List<ReturnApartmentDto>> GetApartments();
        Task<ReturnApartmentDto> CreateApartment(CreateApartmentDto request);
        Task<ReturnApartmentDto> UpdateApartment(int id, UpadteApartmentDto request);
        Task<ReturnApartmentDto> DeleteApartment(int id);
        
    }
}
