using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class UserController : Controller
    { 
        
        public ActionResult Profile(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Register()
        {
            return View();
        }
        

        public ActionResult Login()
        {
            return View();
        }

    }
}