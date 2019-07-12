using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BuildingDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    [Authorize]

    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        // GET: Beacon
        public async Task<ActionResult> Index()
        {
            EntityDTO dto = new EntityDTO()
            {
                Id = Guid.Parse(HttpContext.Session.GetString("LocationId"))
            };
            IEnumerable<ReadBuildingDTO> beacons = await _buildingService.GetAllBuildings( dto );
            return View(beacons);
        }


    }
}