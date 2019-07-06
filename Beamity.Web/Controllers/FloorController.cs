using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.FloorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class FloorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReadFloorDTO> floors = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("Floor/GetAllFloors");

                var readTask = responseTask.Content.ReadAsAsync<IList<ReadFloorDTO>>();

                floors = readTask.Result;

            }
            return View(floors);
        }
    }
}