using BuildingAPI.Dto;
using BuildingAPI.Dto.Apartment_Dto;
using BuildingAPI.Models;

namespace BuildingAPI.AutoMapperProfiles
{
    public class ApartmentProfile : AutoMapper.Profile
    {
        public ApartmentProfile()
        {
            CreateMap<UpadteApartmentDto, Apartment>();
            CreateMap<CreateApartmentDto, Apartment>();
            CreateMap<ReturnApartmentDto, Apartment>();
            CreateMap<Apartment, UpadteApartmentDto >();
            CreateMap<Apartment ,CreateApartmentDto >();
            CreateMap<Apartment, ReturnApartmentDto>();
        }
    }
}
