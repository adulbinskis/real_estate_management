using AutoMapper;
using BuildingAPI.Data;
using BuildingAPI.Dto;
using BuildingAPI.Dto.Tentant_Dto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingAPI.Services
{
    public class TenantService : ITenantService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TenantService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ReturnTenantDto>> GetUserTenants(int userId)
        {
            var tentDB = await _context.Users
              .Where(u => u.Id == userId)
              .SelectMany(b => b.Building)
              .SelectMany(a => a.Apartments)
              .SelectMany(t => t.Tenants)
              .ToListAsync();

            var response = _mapper.Map<List<ReturnTenantDto>>(tentDB);
            return response;
        }

        public async Task<ReturnTenantDto> GetTenantById(int id)
        {
            var tentDB = await _context.Tenants.FindAsync(id);
            var response = _mapper.Map<ReturnTenantDto>(tentDB);
            return response;
        }

        public async Task<List<ReturnTenantDto>> GetTenants()
        {
            var tentDB = await _context.Tenants.ToListAsync();
            var response = _mapper.Map<List<ReturnTenantDto>>(tentDB);
            return response;
        }

        public async Task<ReturnTenantDto> CreateTenant(CreateTenantDto request)
        {
            var tentant = _mapper.Map<Tenant>(request);

            _context.Tenants.Add(tentant);

            await _context.SaveChangesAsync();


            var response = _mapper.Map<ReturnTenantDto>(tentant);
            response.Action= "create";
            return response;
        }

        public async Task<ReturnTenantDto> UpdateTenant(int id, UpdateTenantDto request)
        {
            var dbTentant = await _context.Tenants.FindAsync(id);

            if (dbTentant == null)
            {
                throw new ArgumentNullException("Tentant Not Found");
            }

            dbTentant = _mapper.Map(request, dbTentant);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<ReturnTenantDto>(dbTentant);
            response.Action = "update";
            return response;
        }

        public async Task<ReturnTenantDto> DeleteTenant(int id) 
        {
            var dbTentant = await _context.Tenants.FindAsync(id);
            if (dbTentant == null)
            {
                throw new ArgumentNullException("Tentant Not Found");
            }

            _context.Tenants.Remove(dbTentant);
            await _context.SaveChangesAsync();

            var response = new ReturnTenantDto { Id = id };
            response.Action = "delete";
            return response;
        }

    }
}
