using System.Net;

namespace ServiceHook.Api.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;

        private readonly ILogger<ErrorHandlerMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                context.Response.StatusCode,
                Message = $"Internal Server Error from {exception.Message} {exception.Source}",
                Detailed = exception.Message,
                Type = exception.GetType().FullName,
                exception.Data,
                exception.Source,
                exception.StackTrace
            };
            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
