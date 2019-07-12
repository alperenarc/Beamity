using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {

        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public async Task<IActionResult> Index()
        {
            var location = HttpContext.Session.GetString("LocationId");
            EntityDTO dto = new EntityDTO
            {
                Id = Guid.Parse(location)
            };

            IEnumerable<ReadRoomDTO> rooms = await _roomService.GetAllRooms(dto);
            return View(rooms);
        }
    }
}