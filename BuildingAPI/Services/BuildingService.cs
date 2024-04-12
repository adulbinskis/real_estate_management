using AutoMapper;
using BuildingAPI.Data;
using BuildingAPI.Dto;
using BuildingAPI.Dto.Apartment_Dto;
using BuildingAPI.Dto.Building_Dto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BuildingAPI.Services
{
    public class BuildingService: IBuildingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BuildingService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReturnBuildingDto>> GetUserBuildings(int userId)
        {
            var buildDB = await _context.Buildings.Where(a => a.UserId == userId).ToListAsync();
            var response = _mapper.Map<List<ReturnBuildingDto>>(buildDB);
            return response;
        }

        public async Task<ReturnBuildingDto> GetBuildingById(int id)
        {
            var buildDB = await _context.Buildings.FindAsync(id);
            var response = _mapper.Map<ReturnBuildingDto>(buildDB);
            return response;
        }

        public async Task<List<ReturnBuildingDto>> GetBuildings()
        {
            var buildDB = await _context.Buildings.ToListAsync();
            var response = _mapper.Map<List<ReturnBuildingDto>>(buildDB);

            return response;
        }

        public async Task<ReturnBuildingDto> CreateBuilding(CreateBuildingDto request) 
        {
            var building = _mapper.Map<Building>(request);

            _context.Buildings.Add(building);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<ReturnBuildingDto>(building);
            response.Action = "create";
            return response;

        }

        public async Task<ReturnBuildingDto> UpdateBuilding(int id, UpdateBuildingDto request) 
        {

            var dbBuilding = await _context.Buildings.FindAsync(id);
            if (dbBuilding == null)
            {
                throw new ArgumentNullException("Building Not Found");
            }

            dbBuilding = _mapper.Map(request, dbBuilding);

            await _context.SaveChangesAsync();
    

            var response = _mapper.Map<ReturnBuildingDto> (dbBuilding);
            response.Action = "update";
            return response;
        }

        public async Task<ReturnBuildingDto> DeleteBuilding(int id)
        {

            var dbBuilding = await _context.Buildings.FindAsync(id);

            if (dbBuilding == null)
            {
                throw new ArgumentNullException("Building Not Found");
            }

            _context.Buildings.Remove(dbBuilding);

            await _context.SaveChangesAsync();


            var response = new ReturnBuildingDto { Id = id };
            response.Action = "delete";
            return response;
        }
    }
}
