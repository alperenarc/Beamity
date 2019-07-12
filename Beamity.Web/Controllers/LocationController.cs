using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.API.Controllers;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<IActionResult> Index()
        {
            //get user with Session
            EntityDTO dto = new EntityDTO();
            IEnumerable<ReadLocationDTO> locations = await _locationService.GetAllLocationWithUser(dto);
            return View(locations);
        }
    }
}