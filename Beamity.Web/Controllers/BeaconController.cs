using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class BeaconController : Controller
    {
        private readonly IBeaconService _beaconService;
        public BeaconController(IBeaconService beaconService)
        {
            _beaconService = beaconService;
        }
        // GET: Beacon
        public ActionResult Index()
        {
            IEnumerable<ReadBeaconDTO> beacons = _beaconService.GetAllBeacons();
            return View(beacons);
        }

     


    }
}