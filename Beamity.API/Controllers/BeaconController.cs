using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BeaconController : ControllerBase
    {
        private readonly IBeaconService _beaconService;
        public BeaconController(IBeaconService beaconService)
        {
            _beaconService = beaconService;
        }
        [HttpGet]
        public async Task<ReadBeaconDTO> GetBeacon(EntityDTO input)
        {
            try
            {
                var beacon = await _beaconService.GetBeacon(input);
                return beacon;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ReadBeaconDTO>> GetAllBeacons()
        {
            try
            {
                //ProjectID
                EntityDTO dto = new EntityDTO();
                var beacons = await _beaconService.GetAllBeacons(dto);
                return beacons;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBeacon(CreateBeaconDTO input)
        {
            try
            {
                await _beaconService.CreateBeacon(input);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBeacon(UpdateBeaconDTO input)
        {
            try
            {
                await _beaconService.UpdateBeacon(input);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBeacon(DeleteBeaconDTO input)
        {
            try
            {
               await  _beaconService.DeleteBeacon(input);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}