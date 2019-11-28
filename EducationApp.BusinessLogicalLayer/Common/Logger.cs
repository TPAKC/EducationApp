using Microsoft.Extensions.Logging;

namespace EducationApp.BusinessLogicalLayer.Common
{
    public static class Logger
    {
/*public class CustomClass
{
private readonly ILogger _logger = Log.CreateLogger<customclass>();

        public CustomClass()
        {
            _logger.LogInformation("test message");
        }
    }*/
        public static ILoggerFactory LoggerFactory { get; set; }
        public static ILogger CreateLogger<t>() => LoggerFactory.CreateLogger<t>();
        public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}
