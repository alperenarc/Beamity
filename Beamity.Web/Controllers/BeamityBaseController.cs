using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class BeamityBaseController : Controller
    {
        public BeamityBaseController()
        {
            //if (HttpContext.Session.GetString("LocationId") == null)
            //{
            //    return RedirectToAction("ChooseLocation", "Location");
            //}
        }
    }
}