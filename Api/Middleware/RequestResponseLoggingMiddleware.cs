using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(ILogger<RequestResponseLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            RequestLog requestLog = await LogRequest(context);
            _logger.LogInformation(requestLog.ToString());

            ResponseLog responseLog = await LogResponse(context);
            _logger.LogInformation(responseLog.ToString());
        }

        private async Task<RequestLog> LogRequest(HttpContext context)
        {
            string bodyStr = string.Empty;
            var request = context.Request;
            request.EnableBuffering();
            using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = await reader.ReadToEndAsync();
                request.Body.Position = 0;
            }

            return new RequestLog(request.Scheme, 
                request.Host.Value, 
                request.Path.Value, 
                request.QueryString.Value, 
                bodyStr);
        }

        private async Task<ResponseLog> LogResponse(HttpContext context)
        {
            var response = context.Response;
            var bodyStr = string.Empty;
            
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                response.Body.Seek(0, SeekOrigin.Begin);

                using (StreamReader reader = new StreamReader(response.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                    response.Body.Seek(0, SeekOrigin.Begin);
                }

                await responseBody.CopyToAsync(originalBodyStream);
            }

            return new ResponseLog(response.StatusCode, bodyStr);
        }
    }
}
