using System.Text;
using System.Text.Json;

namespace Movie.API.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestResponseMiddleware> logger;

        public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            logger.LogInformation($"Query Keys:{String.Join(',', httpContext.Request.QueryString)}");

            await next.Invoke(httpContext);

            logger.LogInformation($"Status Code:{String.Join(',', httpContext.Response.StatusCode)}");
        }
    }
}
