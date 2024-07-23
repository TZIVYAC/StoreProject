using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Primitives;
using System.IO;
using DAL.DTO;
using System.Text.Json;

namespace BL
{
    public class PrintFunctionNameMiddleware
    {
        private readonly RequestDelegate _next;

        public PrintFunctionNameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var functionName = context.Request.Path;
            Console.WriteLine($"Entering function: {functionName}");

            // Call the next delegate/middleware in the pipeline
            await _next(context);

            // You can also log after the request is processed
            Console.WriteLine($"Exiting function: {functionName}");
        }

    }
}
