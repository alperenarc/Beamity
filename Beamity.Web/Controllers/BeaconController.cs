using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    [Authorize(Policy ="Common")]
    public class BeaconController : Controller
   {
       private readonly IBeaconService _beaconService;
       public BeaconController(IBeaconService beaconService)
       {
           _beaconService = beaconService;
       }
       // GET: Beacon
       public async Task<ActionResult> Index()
       {
            //ProjectID
            EntityDTO dto = new EntityDTO();
            IEnumerable<ReadBeaconDTO> beacons = await _beaconService.GetAllBeacons(dto);
           return View(beacons);
       }




   }
}