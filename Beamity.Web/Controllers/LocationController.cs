using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.LocationDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class LocationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReadLocationDTO> locations = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("Location/GetAllLocation");

                var readTask = responseTask.Content.ReadAsAsync<IList<ReadLocationDTO>>();

                locations = readTask.Result;

            }
            return View(locations);
        }
    }
}