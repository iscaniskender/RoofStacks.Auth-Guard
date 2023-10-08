public class IdentityServerLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<IdentityServerLoggingMiddleware> _logger;

    public IdentityServerLoggingMiddleware(RequestDelegate next, ILogger<IdentityServerLoggingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Invoke(HttpContext context)
    {
        // Capture the start time of the request
        var startTime = DateTimeOffset.Now;

        // Copy the request body to a memory stream for logging
        var requestBodyStream = new MemoryStream();
        var originalRequestBody = context.Request.Body;
        await context.Request.Body.CopyToAsync(requestBodyStream);
        requestBodyStream.Seek(0, SeekOrigin.Begin);
        var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
        context.Request.Body = originalRequestBody;

        // Proceed with the request
        await _next(context);

        // Capture the end time of the request
        var endTime = DateTimeOffset.Now;

        // Log the request details

        var logMessage = $"Request: {context.Request.Method} {context.Request.Path}, " +
                         $"Status Code: {context.Response.StatusCode}, " +
                         $"Request Body: {requestBodyText}, " +
                         $"Response Time: {(endTime - startTime).TotalMilliseconds}ms";

        _logger.LogInformation(logMessage);
    }
}