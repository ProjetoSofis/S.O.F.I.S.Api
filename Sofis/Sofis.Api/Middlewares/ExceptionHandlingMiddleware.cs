using Sofis.Api.Domain.Exceptions;
namespace Sofis.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext http)
        {
            try
            {
                await _next(http);
            } catch (ValidationException vex)
            {
                http.Response.StatusCode = StatusCodes.Status400BadRequest;
                await http.Response.WriteAsJsonAsync(new { error = vex.Message });
            } catch (EntityNotFoundException enx)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                await http.Response.WriteAsJsonAsync(new { error = enx.Message });
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado");
                http.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await http.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
        }
    }
}
