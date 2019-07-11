using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.FloorDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    [Authorize(Policy ="Common")]
    public class FloorController : Controller
    {
        private readonly IFloorService _floorService;
        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }
        public async Task<IActionResult> Index()
        {
            //it's temporary 
            //get project ID
            EntityDTO dto = new EntityDTO();
            IEnumerable<ReadFloorDTO> floors = await _floorService.GetAllFloor( dto );
            return View(floors);
        }
    }
}