using AutoMapper;
using BuildingAPI.Data;
using BuildingAPI.Dto;
using BuildingAPI.Dto.Apartment_Dto;
using BuildingAPI.Models;
using BuildingAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BuildingAPI.Dto.Building_Dto;

namespace BuildingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private IApartmentService _service;
        public ApartmentController(IApartmentService service)
        {
            _service = service;
        }
        [HttpGet("[action]/{userId}")]
        public async Task<ActionResult<List<ReturnApartmentDto>>> GetUserApartments(int userId)
        {
            var response = await _service.GetUserApartments(userId);
            return Ok(response);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnApartmentDto>> GetApartmentById(int id)
        {
            var response = await _service.GetApartmentById(id);
            return Ok(response);
        }

        [HttpGet, Authorize(Roles = "Admin")] // AllowAnonymous
        public async Task<ActionResult<List<ReturnApartmentDto>>> GetApartment()
        {
            var response = await _service.GetApartments();
            return Ok(response);
        }

        [HttpPost, Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnApartmentDto>> CreateApartment([FromBody] CreateApartmentDto request)
        {
            var response = await _service.CreateApartment(request);
            return Ok(response);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnApartmentDto>> UpdateApartment(int id, [FromBody]  UpadteApartmentDto request)
        {
            var response = await _service.UpdateApartment(id,request);
            return Ok(response);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReturnApartmentDto>> DeleteApartment(int id)
        {
            var response = await _service.DeleteApartment(id);
            return Ok(response);
        }
    }
}
