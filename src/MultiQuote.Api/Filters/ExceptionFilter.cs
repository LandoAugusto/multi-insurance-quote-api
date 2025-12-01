using Component.Log.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiQuoteApi.Core.Infrastructure.Exceptions;
using MultiQuoteApi.Core.Infrastructure.Interfaces;
using MultiQuoteApi.Core.Models;
using System.Net;

namespace MultiQuote.Api.Filters
{
    internal class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogWriter _logWriter;
        private readonly IApiWorkContext _requestContextHolder;
        public ExceptionFilter(ILogWriter logWriter, IApiWorkContext requestContextHolder) =>
            (_logWriter, _requestContextHolder) = (logWriter, requestContextHolder);

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var httpStatusCode = HttpStatusCode.InternalServerError;
            context.ExceptionHandled = false;

            try
            {
                if (exception is NotFoundException) httpStatusCode = HttpStatusCode.NotFound;
                if (exception is BusinessException) httpStatusCode = HttpStatusCode.BadRequest;
                if (exception is UnauthorizedAccessException) httpStatusCode = HttpStatusCode.Unauthorized;
                if (exception is ServiceUnavailableException) httpStatusCode = HttpStatusCode.ServiceUnavailable;
            }
            finally
            {
                var response = new BaseDataResponseModel<object>
                {
                    TransactionStatus = new StatusResponseModel
                    {
                        Code = (int)httpStatusCode,
                        Message = ((!string.IsNullOrEmpty(exception.Message)) ? exception.Message : "Sistema temporariamente indisponível."),
                        Details = $"{"InnerException"}: {exception.InnerException} ---- {"StackTrace"}: {exception.StackTrace}"
                    }
                   
                };
                context.Result = new ObjectResult(response)
                {
                    StatusCode = (int)httpStatusCode
                };
            }
        }
    }
}


