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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDTO input)
        {
            try
            {
                await _locationService.CreateLocation(input);

                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the creating process. Please try again !");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDTO input)
        {
            try
            {
                await _locationService.UpdateLocation(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the updating process. Please try again !");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(DeleteLocationDTO input)
        {
            try
            {
                await _locationService.DeleteLocation(input);
                return Ok("The process is success");
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the deleting process. Please try again !");
            }
        }
        [HttpPost]
        public async Task<List<ReadLocationDTO>> GetAllLocation(EntityDTO dto)
        {
            //App sends Project id
            var list = await _locationService.GetAllLocation( dto );
            return list;
        }
        [HttpPost]
        public async Task<List<ReadLocationDTO>> GetAllLocationWithUser(EntityDTO dto)
        {
            //App sends User id
            var list = await _locationService.GetAllLocationWithUser(dto);
            return list;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ReadLocationDTO> GetLocation(EntityDTO input)
        {
            var location = await  _locationService.GetLocation(input);
            return location;
        }
    }
}