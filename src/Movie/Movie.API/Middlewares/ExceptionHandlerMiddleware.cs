using Microsoft.AspNetCore.Diagnostics;
using Movie.API.Exceptions;
using Movie.API.Models.Base;
using System.Text.Json;

namespace Movie.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate Next,ILogger<ExceptionHandlerMiddleware> Logger)
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
                    ClientSideException => 400,
                    NotFoundException => 404,
                    _ => 500
                };

                httpContext.Response.StatusCode = statusCode;

                var response = Response<NoContext>.Fail(ex.Message, statusCode);

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
