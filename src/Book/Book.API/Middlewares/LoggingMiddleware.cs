namespace Book.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggingMiddleware> logger;

        public LoggingMiddleware(RequestDelegate Next, ILogger<LoggingMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            logger.LogInformation($"Query Keys:{String.Join(',', httpContext.Request.QueryString)}");

            await next.Invoke(httpContext);

            var logMessage = $"Request Path:{httpContext.Request.Path} ," +
                    $" Method:{httpContext.Request.Method} ," +
                    $" Status Code:{httpContext.Response.StatusCode}";

            var path = "logs.txt";

            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
