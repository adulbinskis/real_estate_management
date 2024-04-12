
using BuildingAPI.Dto;
using BuildingAPI.Dto.Building_Dto;
using BuildingAPI.Models;

namespace BuildingAPI.AutoMapperProfiles
{
    public class BuildingProfile : AutoMapper.Profile
    {
        public BuildingProfile()
        {
            CreateMap<UpdateBuildingDto, Building>();
            CreateMap<CreateBuildingDto, Building>();
            CreateMap<ReturnBuildingDto, Building>();
            CreateMap<Building, UpdateBuildingDto>();
            CreateMap<Building, CreateBuildingDto>();
            CreateMap<Building, ReturnBuildingDto>();
        }
    }
}
