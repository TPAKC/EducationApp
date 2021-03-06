﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
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
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.LogCritical("LogCritical {0}", context.Request.Path);
                _logger.LogDebug("LogDebug {0}", context.Request.Path);
                _logger.LogError("LogError {0}", context.Request.Path);
                _logger.LogInformation("LogInformation {0}", context.Request.Path);
                _logger.LogWarning("LogWarning {0}", context.Request.Path);
                await InternalServerError(context);
            }
        }

        public async Task InternalServerError(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("Internal server error,");
        }
    }
}
