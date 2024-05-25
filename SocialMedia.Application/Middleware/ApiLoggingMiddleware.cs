using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Middleware
{
   
        public class ApiLoggingMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ApiLoggingMiddleware> _logger;

            public ApiLoggingMiddleware(RequestDelegate next, ILogger<ApiLoggingMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task Invoke(HttpContext context)
            {
                // Log request
                _logger.LogInformation($"Received {context.Request.Method} request for {context.Request.Path}");

                // Capture request body (optional)
                var requestBody = await FormatRequestBody(context.Request);

                // Call the next middleware in the pipeline
                await _next(context);

                // Log response
                _logger.LogInformation($"Response {context.Response.StatusCode} for {context.Request.Path}");


                // Log request and response bodies
                _logger.LogDebug($"Request Body: {requestBody}");

            }

            private async Task<string> FormatRequestBody(HttpRequest request)
            {
                request.EnableBuffering();

                using (var reader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();
                    request.Body.Seek(0, SeekOrigin.Begin);
                    return body;
                }
            }

        }
}
