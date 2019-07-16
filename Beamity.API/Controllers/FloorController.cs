using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.FloorDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;
        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }
        [HttpGet]
        public async Task<ReadFloorDTO> GetFloor(EntityDTO input)
        {
            try
            {
                var floor = await _floorService.GetFloor(input);
                return floor;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<List<ReadFloorDTO>> GetAllFloors(EntityDTO input)
        {
            try
            {
               
                var floors = await _floorService.GetAllFloor(input);
                return floors;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<List<ReadFloorDTO>> GetFloorsAtBuilding(EntityDTO input)
        {
            try
            {
                ///Takes floor ID
                var floors = await _floorService.GetFloorsOnBuilding(input);
                return floors;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateFloor(CreateFloorDTO input)
        {
            await _floorService.CreateFloor(input);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFloor(UpdateFloorDTO input)
        {
            try
            {
               await _floorService.UpdateFloor(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFloor(DeleteFloorDTO input)
        {
            try
            {
                await _floorService.DeleteFloor(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}