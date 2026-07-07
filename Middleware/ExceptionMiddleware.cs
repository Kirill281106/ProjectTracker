namespace ProjectTracker.Middleware
{
    public class ExceptionMiddleware
    {
        public RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception Message {ex.Message}");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"message\":\"Internal Server Error\"}");
            }
        }
    }
}
