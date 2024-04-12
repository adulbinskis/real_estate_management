using BuildingAPI.Dto;
using BuildingAPI.Dto.User_Dto;
using BuildingAPI.Models;
using System.Collections.Generic;

namespace BuildingAPI.AutoMapperProfiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserReturnDto>();
            CreateMap<UserReturnDto, User>();
            //CreateMap<List<UserReturnDto>, List<User>>();
            //CreateMap<List<User>, List<UserReturnDto>>();
        }
    }
}
