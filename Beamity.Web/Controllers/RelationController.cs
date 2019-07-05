using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.RelationDTO;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class RelationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReadRelationDTO> relations = null;

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://localhost:5001/api/");
                    var responseTask = await client.GetAsync("Relation/GetAllRelations");
                    var readTask = responseTask.Content.ReadAsAsync<List<ReadRelationDTO>>();

                    relations = readTask.Result;
                }
                catch (Exception e)
                {

                    throw e;
                }

            }
            if( relations != null)
                return View(relations);
            else {
                return View();
            }
        }
    }
}