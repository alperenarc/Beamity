using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.ContentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class ContentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReadContentDTO> buildings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("Content/GetAllContents");

                var readTask = responseTask.Content.ReadAsAsync<IList<ReadContentDTO>>();

                buildings = readTask.Result;

            }
            return View(buildings);
        }
    }
}