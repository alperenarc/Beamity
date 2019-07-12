using Beamity.Application.DTOs;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            
            EntityDTO dto = new EntityDTO()
            {
                Id = Guid.Parse(HttpContext.Session.GetString("UserId"))
            };
            IEnumerable<ReadLocationDTO> locations = await _locationService.GetAllLocationWithUser(dto);
            return View(locations);
        }
        public async Task<IActionResult> ChooseLocation()
        {
            //get user with Session
            EntityDTO dto = new EntityDTO()
            {
                Id = Guid.Parse(HttpContext.Session.GetString("UserId"))
            };
            IEnumerable<ReadLocationDTO> locations = await _locationService.GetAllLocationWithUser(dto);
            return View(locations);
        }

    }
}