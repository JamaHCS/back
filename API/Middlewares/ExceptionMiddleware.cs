using Domain.Entities.Global;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                var response = ex switch
                {
                    UnauthorizedAccessException => Result.Failure("Token inválido o permisos insuficientes", ex.Message, 401),
                    _ => Result.Failure("Ocurrió un error inesperado.", ex.Message, 500)
                };

                context.Response.StatusCode = response.Status;

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
