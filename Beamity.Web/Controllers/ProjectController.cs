using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.LocationDTOs;
using Beamity.Application.DTOs.ProjectDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class ProjectController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReadProjectDTO> projects = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("Project/GetAllProject");

                var readTask = responseTask.Content.ReadAsAsync<List<ReadProjectDTO>>();

                projects = readTask.Result;

            }
            return View(projects);
            
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}