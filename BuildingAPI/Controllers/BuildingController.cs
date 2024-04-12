using BuildingAPI.Dto;
using BuildingAPI.Dto.Building_Dto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace BuildingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private IBuildingService _service;
        public BuildingController(IBuildingService service)
        {
            _service = service;
        }
        [HttpGet("[action]/{userId}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<ReturnBuildingDto>>> GetUserBuildings(int userId)
        {
            var response = await _service.GetUserBuildings(userId);
            return Ok(response);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnBuildingDto>> GetBuildingById(int id) 
        {
            var response = await _service.GetBuildingById(id);
            return Ok(response);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ReturnBuildingDto>>> GetBuilding()
        {
            var response = await _service.GetBuildings();
            return Ok(response);
        }

        [HttpPost, Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnBuildingDto>> CreateBuilding(CreateBuildingDto request)
        {
            var response = await _service.CreateBuilding(request);
            return Ok(response);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnBuildingDto>> UpdateBuilding(int id,UpdateBuildingDto request)
        {
            var response = await _service.UpdateBuilding(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnBuildingDto>> DeleteBuilding(int id) 
        {
            var response = await _service.DeleteBuilding(id);
            return Ok(response);
        }
    }
}
