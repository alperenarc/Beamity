using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class ConfirmationController : Controller
    {
        [HttpGet]
        public IActionResult Verification(string guidcode)
        {
            guidcode = HttpContext.Request.Query["guidcode"].ToString();
            ViewBag.Message = guidcode;
            if (guidcode == null)
            {
                return NotFound();
            }
            return View();
        }
    }
}