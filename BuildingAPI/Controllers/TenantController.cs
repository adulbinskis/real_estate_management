using BuildingAPI.Dto;
using BuildingAPI.Dto.Apartment_Dto;
using BuildingAPI.Dto.Building_Dto;
using BuildingAPI.Dto.Tentant_Dto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BuildingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private ITenantService _service;
        public TenantController(ITenantService service)
        {
            _service= service;
        }

        [HttpGet("[action]/{userId}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<ReturnTenantDto>>> GetUserTenants(int userId)
        {
            var response = await _service.GetUserTenants(userId);
            return Ok(response);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<ReturnTenantDto>>> GetTenantById(int id)
        {
            var response = await _service.GetTenantById(id);
            return Ok(response);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ReturnTenantDto>>> GetTenant()
        {
            var response = await _service.GetTenants();
            return Ok(response);
        }

        [HttpPost, Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnTenantDto>> CreateTenant(CreateTenantDto request)
        {
            var response = await _service.CreateTenant(request);
            return Ok(response);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnTenantDto>> UpdateTenant(int id, UpdateTenantDto request)
        {
            var response = await _service.UpdateTenant(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnTenantDto>> DeleteTenant(int id)
        {
           var response = await _service.DeleteTenant(id);
            return Ok(response);
        }
    }
}
