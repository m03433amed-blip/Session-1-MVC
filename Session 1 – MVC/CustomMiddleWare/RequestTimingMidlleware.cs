using System.Diagnostics;

namespace Session_1___MVC.CustomMiddleWare
{
    public class RequestTimingMidlleware
    {
        private readonly RequestDelegate _next;
        public RequestTimingMidlleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            Console.WriteLine($"[[{context.Request.Path}]] => {watch.ElapsedMilliseconds} ms");
        }
    }
}
