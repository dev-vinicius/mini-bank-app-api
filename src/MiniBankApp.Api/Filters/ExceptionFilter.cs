using MiniBankApp.Communication.Responses;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiniBankApp.Communication.Responses.Shared;

namespace MiniBankApp.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is MiniBankAppException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException ex)
        {
            var errorResponse = new ResponseErrorJson(ex.Errors);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorJson(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
