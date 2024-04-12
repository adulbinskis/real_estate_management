using AutoMapper;
using BuildingAPI.Data;
using BuildingAPI.Dto.Apartment_Dto;
using BuildingAPI.Dto.Auth_Dto;
using BuildingAPI.Dto.User_Dto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace BuildingAPI.Services
{
    public class UserService: IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserReturnDto>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            
            var response = _mapper.Map<List<UserReturnDto>>(users);
            return response;
        }

        public async Task<List<UserReturnDto>> UpdateRole(int id) 
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
                if (user.Role == "Admin")
                {
                    user.Role = "User";
                }
                else
                {
                    user.Role = "Admin";
                }
            await _context.SaveChangesAsync();

            var users = await _context.Users.ToListAsync();
            var response = _mapper.Map<List<UserReturnDto>>(users);
            return response;
        }
        public async Task<List<UserReturnDto>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentNullException("Apartment Not Found");
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            var users = await _context.Users.ToListAsync();
            var response = _mapper.Map<List<UserReturnDto>>(users);
            return response;
        }

        public async Task<UserReturnDto> GetAuthenticatedUser(Claim userEmail)
        {
            var email = userEmail.Value;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            var response = _mapper.Map<UserReturnDto>(user);
            return response;
        }
    }
}
