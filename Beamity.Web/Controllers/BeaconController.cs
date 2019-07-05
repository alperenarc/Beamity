using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.DTOs.BeaconDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class BeaconController : Controller
    {
        // GET: Beacon
        public async Task<ActionResult> Index()
        {
            IEnumerable<ReadBeaconDTO> beacons = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("Beacon/GetAllBeacons");

                var readTask = responseTask.Content.ReadAsAsync<List<ReadBeaconDTO>>();

                beacons = readTask.Result;

            }
            return View(beacons);
        }

        // GET: Beacon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beacon/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Beacon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // GET: Beacon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}