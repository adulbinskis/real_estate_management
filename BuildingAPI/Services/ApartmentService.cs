using AutoMapper;
using BuildingAPI.Data;
using BuildingAPI.Dto.Apartment_Dto;
using Microsoft.EntityFrameworkCore;
using BuildingAPI.Interfaces;
using BuildingAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using BuildingAPI.Models;
using BuildingAPI.Dto.Building_Dto;

namespace BuildingAPI.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ApartmentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReturnApartmentDto>> GetUserApartments(int userId)
        {
            var apartDB = await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(b => b.Building)
                .SelectMany(a => a.Apartments)
                .ToListAsync(); 

            var response = _mapper.Map<List<ReturnApartmentDto>>(apartDB);
            return response;
        }

        //public async Task<List<ReturnApartmentDto>> GetBuildingApartmentById(int id)
        //{
        //    var apartDB = await _context.Apartments.Where(a => a.BuildingId ==id).ToListAsync();
        //    var response = _mapper.Map<List<ReturnApartmentDto>>(apartDB);
        //    return response;
        //}

        public async Task<ReturnApartmentDto> GetApartmentById(int id)
        {
            var apartDB = await _context.Apartments.FindAsync(id);
            var response = _mapper.Map<ReturnApartmentDto>(apartDB);
            return response;
        }

        public async Task<List<ReturnApartmentDto>> GetApartments()
        {
            var apartDB = await _context.Apartments.ToListAsync();
            var response = _mapper.Map<List<ReturnApartmentDto>>(apartDB);

            return response;
        }

        public async Task<ReturnApartmentDto> CreateApartment(CreateApartmentDto request)
        {
            Apartment apartment = _mapper.Map<CreateApartmentDto, Apartment>(request);

            _context.Apartments.Add(apartment);

            await _context.SaveChangesAsync();

            
            var response = _mapper.Map<ReturnApartmentDto>(apartment);
            response.Action = "create";
            return response;
        }

        public async Task<ReturnApartmentDto> UpdateApartment(int id, UpadteApartmentDto request)
        {

            var dbApartment = await _context.Apartments.FindAsync(id);

            if (dbApartment == null)
            {
                throw new ArgumentNullException("Apartment Not Found");
            }

            dbApartment = _mapper.Map(request, dbApartment);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<ReturnApartmentDto>(dbApartment);
            response.Action = "update";
            return response;
        }

        public async Task<ReturnApartmentDto> DeleteApartment(int id)
        {
            var dbApartment = await _context.Apartments.FindAsync(id);
            if (dbApartment == null)
            {
                throw new ArgumentNullException("Apartment Not Found");
            }
                
            _context.Apartments.Remove(dbApartment);

            await _context.SaveChangesAsync();

            var response = new ReturnApartmentDto { Id = id };
            response.Action = "delete";
            return response;
        }
    }
}
