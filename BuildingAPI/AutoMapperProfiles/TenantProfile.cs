using AutoMapper;
using BuildingAPI.Dto;
using BuildingAPI.Dto.Tentant_Dto;
using BuildingAPI.Models;

namespace BuildingAPI.AutoMapperProfiles
{
    public class TenantProfile : Profile
    {
        public TenantProfile() 
        {
            CreateMap<Tenant, CreateTenantDto>();
            CreateMap<Tenant, UpdateTenantDto>();
            CreateMap<Tenant, ReturnTenantDto>();
            CreateMap<CreateTenantDto, Tenant>();
            CreateMap<UpdateTenantDto, Tenant>();
            CreateMap<ReturnTenantDto, Tenant>();
        }
    }
}
