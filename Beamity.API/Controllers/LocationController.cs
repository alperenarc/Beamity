using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        public IActionResult CreateLocation(CreateLocationDTO input)
        {
            try
            {
                _locationService.CreateLocation(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the creating process. Please try again !");
            }
        }
        [HttpPut]
        public IActionResult UpdateLocation(UpdateLocationDTO input)
        {
            try
            {
                _locationService.UpdateLocation(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the updating process. Please try again !");
            }
        }
        [HttpDelete]
        public IActionResult DeleteLocation(DeleteLocationDTO input)
        {
            try
            {
                _locationService.DeleteLocation(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the deleting process. Please try again !");
            }
        }
        [HttpGet]
        public List<ReadLocationDTO> GetAllLocation()
        {
            var list =_locationService.GetAllLocation();
            return list;
        }
        [HttpGet("{id}")]
        public ReadLocationDTO GetLocation(EntityDTO input)
        {
            var location = _locationService.GetLocation(input);
            return location;
        }
    }
}