using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.RoomDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class RoomController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            IEnumerable<ReadRoomDTO> rooms = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("Room/GetAllRooms");

                var readTask = responseTask.Content.ReadAsAsync<IList<ReadRoomDTO>>();

                rooms = readTask.Result;

            }
            return View(rooms);
        }
    }
}