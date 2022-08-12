namespace Movie.API.Logging
{
    public class CustomLoggerFactory : ILoggerProvider
    {
        private readonly string _path;
        public CustomLoggerFactory(string path)
        {
            _path = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger(_path);
        }
        public void Dispose()
        {

        }
    }

    public class CustomLogger : ILogger
    {
        private readonly string _path;
        public CustomLogger(string path)
        {
            _path = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string logMessage = formatter(state, exception);

            logMessage = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logMessage}";

            using (StreamWriter writer = new StreamWriter(_path,true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
