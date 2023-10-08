using System.Net;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "An unhandled exception occurred.");

            // Customize the response based on the exception type
            var response = context.Response;
            response.ContentType = "application/json";

            if (ex is UnauthorizedAccessException)
            {
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            // Create a user-friendly error message
            var errorMessage = new
            {
                message = "Internal Server Error",
                details = ex.Message
            };

            // Serialize the error message to JSON
            var errorJson = System.Text.Json.JsonSerializer.Serialize(errorMessage);

            // Write the error response to the client
            await response.WriteAsync(errorJson);
        }
    }
}