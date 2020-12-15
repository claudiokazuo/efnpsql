using Api.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations
{
    public static class MiddlewareConfigExtension
    {
        public static void UseMiddlewareConfig(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
