using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BuildingDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpGet("{id}")]
        public async Task<ReadBuildingDTO> GetBuilding(EntityDTO input)
        {
            try
            {
                var building =  await _buildingService.GetBuilding(input);
                return building;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<List<ReadBuildingDTO>> GetAllBuildings()
        {
            //bu yanlı hatayı engellemke için yaptım
            EntityDTO dto = new EntityDTO();
            var buildings = await  _buildingService.GetAllBuildings( dto );
            return buildings;

        }
        //[HttpGet("{id}")]
        //public async Task<List<ReadBuildingDTO>> GetBuildingsAtLocation(EntityDTO input)
        //{
        //    var buildings = await _buildingService.GetBuildingsAtLocation(input);
        //    return buildings;

        //}
        [HttpPost]
        public async Task<IActionResult> CreateBuilding(CreateBuildingDTO input)
        {
            try
            {
                await _buildingService.CreateBuilding(input);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBuilding(UpdateBuildingDTO input)
        {
            try
            {
                await _buildingService.UpdateBuilding(input);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBuilding(DeleteBuildingDTO input)
        {
            try
            {
                await _buildingService.DeleteBuilding(input);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}