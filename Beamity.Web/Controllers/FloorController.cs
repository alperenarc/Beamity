using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.FloorDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class FloorController : Controller
    {
        private readonly IFloorService _floorService;
        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }
        public IActionResult Index()
        {
            IEnumerable<ReadFloorDTO> floors = _floorService.GetAllFloor();
            return View(floors);
        }
    }
}