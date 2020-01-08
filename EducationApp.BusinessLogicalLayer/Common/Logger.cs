using Microsoft.Extensions.Logging;

namespace EducationApp.BusinessLogicalLayer.Common
{
    public class Logger
    {
        public ILoggerFactory LoggerFactory { get; set; }
        public ILogger CreateLogger<t>() => LoggerFactory.CreateLogger<t>();
        public ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}
