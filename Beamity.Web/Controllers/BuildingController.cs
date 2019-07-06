using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.BuildingDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Building
        public async  Task<ActionResult> Index()
        {
            IEnumerable<ReadBuildingDTO> buildings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("Building/GetAllBuildings");

                var readTask = responseTask.Content.ReadAsAsync<List<ReadBuildingDTO>>();

                buildings = readTask.Result;

            }
            return View(buildings);
        }

      
      
    }
}