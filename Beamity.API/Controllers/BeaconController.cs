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
        [HttpGet("{id}")]
        public ReadBeaconDTO GetBeacon(EntityDTO input)
        {
            try
            {
                var beacon = _beaconService.GetBeacon(input);
                return beacon;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public List<ReadBeaconDTO> GetAllBeacons()
        {
            try
            {
                var beacons = _beaconService.GetAllBeacons();
                return beacons;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult CreateBeacon(CreateBeaconDTO input)
        {
            try
            {
                _beaconService.CreateBeacon(input);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPut]
        public IActionResult UpdateBeacon(UpdateBeaconDTO input)
        {
            try
            {
                _beaconService.UpdateBeacon(input);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult DeleteBeacon(DeleteBeaconDTO input)
        {
            try
            {
                _beaconService.DeleteBeacon(input);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}