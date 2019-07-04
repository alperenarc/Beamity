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
        //[HttpGet("{id}")]
        //public async Task<ReadBuildingDTO> GetBuilding(EntityDTO input)
        //{
        //    try
        //    {
        //        var building = await  _buildingService.GetBuildingAsync(input);
        //        return building;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        [HttpGet]
        [AllowAnonymous]
        public async Task<string> GetAllBuildings()
        {
                //var buildings = await _buildingService.GetAllBuildings();
                return "eray";
         
        }
        //[HttpGet("{id}")]
        //public async Task<string> GetBuildingsAtLocation(EntityDTO input)
        //{
        //       //var buildings = await _buildingService.GetBuildingsAtLocation(input);
        //        //return buildings;
           
        //}
        //[HttpPost]
        //public IActionResult CreateBuilding(CreateBuildingDTO input)
        //{
        //    try
        //    {
        //        _buildingService.CreateBuildingAsync(input);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //[HttpPut]
        //public IActionResult UpdateBuilding(UpdateBuildingDTO input)
        //{
        //    try
        //    {
        //        _buildingService.UpdateBuilding(input);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //[HttpDelete]
        //public IActionResult DeleteBuilding(DeleteBuildingDTO input)
        //{
        //    try
        //    {
        //        _buildingService.DeleteBuilding(input);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}