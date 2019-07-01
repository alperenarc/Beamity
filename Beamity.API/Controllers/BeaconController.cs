using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeaconController : ControllerBase
    {
        private readonly IBeaconService _beaconService;
        public BeaconController(IBeaconService beaconService)
        {
            _beaconService = beaconService;
        }
       
    }
}