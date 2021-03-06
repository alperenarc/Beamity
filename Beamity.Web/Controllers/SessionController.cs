﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult SetVariable(string key, string value)
        {
            HttpContext.Session.SetString(key, value);

            return this.Json(new { success = true });
        }
        
        public ActionResult GetVariable(string key)
        {
            string  r = HttpContext.Session.GetString(key);

            return this.Json(new { d = r });
        }
    }
}