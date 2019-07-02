using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.FloorDTOs;
using Beamity.Application.Service.IServices;
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
        [HttpGet("{id}")]
        public ReadFloorDTO GetFloor(EntityDTO input)
        {
            try
            {
                var floor = _floorService.GetFloor(input);
                return floor;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public List<ReadFloorDTO> GetAllFloors()
        {
            try
            {
                var floors = _floorService.GetAllFloor();
                return floors;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<List<ReadFloorDTO>> GetFloorsAtBuilding(EntityDTO input)
        {
            try
            {
                var floors = await _floorService.GetFloorsOnBuilding(input);
                return floors;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult CreateFloor(CreateFloorDTO input)
        {
            try
            {
                _floorService.CreateFloor(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult UpdateFloor(UpdateFloorDTO input)
        {
            try
            {
                _floorService.UpdateFloor(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult DeleteFloor(DeleteFloorDTO input)
        {
            try
            {
                _floorService.DeleteFloor(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}