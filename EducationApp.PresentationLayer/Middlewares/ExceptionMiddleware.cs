using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ApplicationException ex)
            {
                var message = ex.Message;
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(message);
                return;
            }
            catch (Exception exception)
            {       
                await WriteToFile(exception, "Server is not responding.");
            }


        }

        public static async Task WriteToFile(Exception exception = null, string message = null)
        {
            string fileName = $"{DateTime.UtcNow.Day}_{DateTime.UtcNow.Month}_{DateTime.UtcNow.Year}";
            string logDirectory = Path.Combine("./logs");
            string fullFilePath = Path.Combine(logDirectory, $"{fileName}.txt");

            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            using (StreamWriter sw = new StreamWriter(fullFilePath, true))
            {
                if (exception != null)
                {
                    await sw.WriteLineAsync($"Error on {DateTime.UtcNow}, Exception Message: {exception.Message}, Inner Message: {exception.InnerException}, Line: {exception.StackTrace}");
                }
                else
                {
                    await sw.WriteLineAsync($"Error on {DateTime.UtcNow}, Error Message: {message}");
                }
            }

        }
    }
}
