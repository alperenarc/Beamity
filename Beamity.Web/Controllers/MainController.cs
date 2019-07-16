using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}