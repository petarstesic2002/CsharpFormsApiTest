using API.Application.Dto;
using API.Application.Interfaces;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorLogger _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, IErrorLogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException validationExcepiton)
            {
                context.Response.StatusCode = 422;
                context.Response.ContentType = "application/json";
                var errors = validationExcepiton.Errors.Select(x => new
                {
                    x.PropertyName,
                    x.ErrorMessage
                });
                await context.Response.WriteAsJsonAsync(errors);
            }
            catch (System.Exception ex)
            {
                Guid guid = Guid.NewGuid();
                AppError error = new AppError
                {
                    ErrorId = guid,
                    Exception = ex
                };
                _logger.Log(error);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var responseBody = new
                {
                    message = $"There was an error, please contact support with this error code: {guid}."
                };

                await context.Response.WriteAsJsonAsync(responseBody);
            }
            
        }
    }
}
