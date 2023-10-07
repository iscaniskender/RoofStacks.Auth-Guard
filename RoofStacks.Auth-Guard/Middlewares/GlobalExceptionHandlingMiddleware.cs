using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace RoofStacks.Auth_Guard.Middlewares
{
    public class GlobalExceptionHandlingMiddleware:IMiddleware
    {
        private readonly ILog _logger;

        public GlobalExceptionHandlingMiddleware(ILog logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Error",
                    Title = "Server Error",
                    Detail = "An internal server has occurred"
                };
                string json = JsonSerializer.Serialize(problem);

                await context.Response.WriteAsync(json);

                context.Response.ContentType = "application/json";
            }
        }
    }
}
