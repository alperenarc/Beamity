using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Building
        public ActionResult Index()
        {
            return View();
        }

        // GET: Building/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            return View();
        }

      
        // GET: Building/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Building/Edit/5
     
        // GET: Building/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

      
    }
}