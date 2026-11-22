using System.Diagnostics;

namespace MVC_Session01.CustomMiddleware
{
    public class ReqMiddleware
    {
        private readonly RequestDelegate _next;
        public ReqMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            Console.WriteLine($"Request took {watch.ElapsedMilliseconds} ms");
        }
    }
}
