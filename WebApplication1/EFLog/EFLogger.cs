using Microsoft.EntityFrameworkCore;

namespace WebApplication1.EFLog
{
    public class EFLogger : ILogger
    {
        private readonly string categoryName;

        public EFLogger(string categoryName) => this.categoryName = categoryName;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            //ALL Log
            //var logContent = formatter(state, exception);
            //Console.WriteLine();
            //Console.WriteLine(categoryName+"----"+logContent);

            //过滤打印
            var showLogCategorys = new List<string>(){ "Microsoft.EntityFrameworkCore.Database.Connection", "Microsoft.EntityFrameworkCore.Database.Command" };
            if (showLogCategorys.Any(x=>x== categoryName))
            {
                var logContent = formatter(state, exception);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logContent);
                Console.ResetColor();
            }
        }
        public IDisposable BeginScope<TState>(TState state) => null;
    }
   
}
