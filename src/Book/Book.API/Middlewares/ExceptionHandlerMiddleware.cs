using Book.API.Data;
using System.Text.Json;

namespace Book.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate Next, ILogger<ExceptionHandlerMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                httpContext.Response.ContentType = "application/json";

                var statusCode = ex switch
                {
                    _ => 500
                };

                httpContext.Response.StatusCode = statusCode;

                var response = Response<NoContent>.Fail(ex.Message, statusCode);

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
