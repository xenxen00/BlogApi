using Application.Exeptions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (ForbiddenUseCase ex) {
                httpContext.Response.StatusCode = 401;
            }
            catch (UnauthorizedAccessException ex)
            {
                httpContext.Response.StatusCode = 401;
            }
            catch (ValidationException ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                List<ErrorBody> response = new List<ErrorBody>();
                foreach (var error in ex.Errors)
                {
                    response.Add(new ErrorBody { PropertyName = error.PropertyName, Message = error.ErrorMessage });
                }
                await httpContext.Response.WriteAsJsonAsync(response);
            }
            catch (System.Exception ex)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "application/json";

                var response = new
                {
                    message = $"There was an error, please contact support with this error code: ."
                };

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }

    public class ErrorBody
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
