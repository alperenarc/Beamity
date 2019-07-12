using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beamity.Web.Middlewares
{
    static public class HelloMiddlewareExtension
    {
        public static IApplicationBuilder UseLocationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LocationMiddleware>();
        }
    }
}
