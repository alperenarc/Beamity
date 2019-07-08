using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class RoomController : Controller
    {

        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public async  Task<IActionResult> Index()
        {
            IEnumerable<ReadRoomDTO> rooms = _roomService.GetAllRooms();
            return View(rooms);
        }
    }
}