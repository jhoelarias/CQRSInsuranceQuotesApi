namespace Coterie.Api.ExceptionHelpers
{
    using Domain.Responses;
    using FluentValidation;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var response = context.Response;

            var appContext = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;

            ApiResponse<string> actionResponse = new()
            {
                Message = "An error has occurred",
                Error = $"{appContext.Error.Message} {appContext.Error.InnerException} {appContext.Error.StackTrace}"
            };

            switch (exception)
            {
                case IndexOutOfRangeException:
                case NullReferenceException:
                case ArgumentException:
                    // Bad Request status
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    actionResponse.Error = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                    actionResponse.Message = "One or more validation errors occurred."; break;

                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            await response.WriteAsJsonAsync(actionResponse);
        }
    }
}