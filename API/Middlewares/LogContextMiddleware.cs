using Azure.Core;
using System.Reflection;
using Domain.Entities.Log;
using NuGet.Protocol.Core.Types;

namespace API.Middlewares
{
    public class LogContextMiddleware
    {
        private readonly RequestDelegate _next;
        public LogContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            LogContextManager.Current = new LogEvent()
            {
                RequestId = Guid.NewGuid().ToString(),
                ClientIp = context.Connection.RemoteIpAddress?.ToString(),
                UserAgent = context.Request.Headers["User-Agent"],
                UserRole = context.User?.FindFirst("role")?.Value,
                ServiceName = "API",
                MethodName = "RequestHandling",
                Path = context.Request.Path,
                Method = context.Request.Method,
            };

            await _next(context);
        }
    }
}
