using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.Web.Middlewares
{
    public class LocationMiddleware
    {
        private readonly RequestDelegate _next;
        public LocationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            var LocationSession = httpContext.Session.GetString("LocationId");
            var UserSession = httpContext.Session.GetString("UserId");
            if (LocationSession == null && UserSession != null)
            {
                httpContext.Response.Redirect("~/User/Login");
            }
            
        }
    }
}
