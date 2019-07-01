using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BuildingDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpGet("{id}")]
        public ReadBuildingDTO GetBuilding(EntityDTO input)
        {
            try
            {
                var building = _buildingService.GetBuilding(input);
                return building;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public List<ReadBuildingDTO> GetAllBuildings()
        {
            try
            {
                var buildings = _buildingService.GetAllBuildings();
                return buildings;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<List<ReadBuildingDTO>> GetBuildingsAtLocation(EntityDTO input)
        {
            try
            {
                var buildings = await _buildingService.GetBuildingsAtLocation(input);
                return buildings;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult CreateBuilding(CreateBuildingDTO input)
        {
            try
            {
                _buildingService.CreateBuilding(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult UpdateBuilding(UpdateBuildingDTO input)
        {
            try
            {
                _buildingService.UpdateBuilding(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult DeleteBuilding(DeleteBuildingDTO input)
        {
            try
            {
                _buildingService.DeleteBuilding(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}