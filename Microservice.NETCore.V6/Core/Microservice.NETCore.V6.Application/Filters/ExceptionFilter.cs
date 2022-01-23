using Microservice.NETCore.V6.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Microservice.NETCore.V6.Application.Filters;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class ExceptionsAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorDetail = SetExceptionType(context);
        errorDetail.Detail = context.Exception.Message;
        errorDetail.Errors.Add(new Error
        {
            Code = SetErrorCode(context),
            Title = context.Exception.Message,
            Detail = context.Exception.InnerException?.Message ?? string.Empty,
            Source = context.Exception?.Source ?? string.Empty,
            SpvTrackId = context.HttpContext.TraceIdentifier
        });

        context.Result = new ObjectResult(errorDetail);
        context.HttpContext.Response.StatusCode = errorDetail.Code;
    }

    private static int SetErrorCode(ExceptionContext context)
    {
        var exceptionType = context.Exception.GetType();

        switch (exceptionType.Name)
        {
            case nameof(BusinessException):
                var exception = (BusinessException)context.Exception;
                return !string.IsNullOrEmpty(exception.Code) ? int.Parse(exception.Code) : 422;

            default:
                return 500;
        }
    }

    private static ErrorDetailModel SetExceptionType(ExceptionContext context)
    {
        var exceptionType = context.Exception.GetType();

        switch (exceptionType.Name)
        {
            case nameof(BusinessException):
                return SetErrorDetailModel("Negocio", HttpStatusCode.UnprocessableEntity.ToString(), (int)HttpStatusCode.UnprocessableEntity);

            default:
                return SetErrorDetailModel("Tecnico", HttpStatusCode.InternalServerError.ToString(), (int)HttpStatusCode.InternalServerError);
        }
    }

    public static ErrorDetailModel SetErrorDetailModel(string type, string state, int code)
    {
        return new ErrorDetailModel
        {
            Type = type,
            State = state,
            Code = code
        };
    }
}