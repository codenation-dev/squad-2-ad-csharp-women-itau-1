using Microsoft.AspNetCore.Mvc.Filters;
using CentralDeErros.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Filters
{
    public class ErrorResponseFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = ErrorResponse.From(context.Exception);
            context.Result = new ObjectResult(errorResponse) { StatusCode = 500 };
        }
    }
}