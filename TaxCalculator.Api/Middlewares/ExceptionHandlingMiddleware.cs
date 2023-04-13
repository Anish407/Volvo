using System.Net;
using TaxCalculator.Api.Middlewares.Models;
using TaxCalculator.Core.Common.Exceptions;

namespace TaxCalculator.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        public ExceptionHandlingMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
        {
            Logger = loggerFactory.CreateLogger(nameof(ExceptionHandlingMiddleware));
            Next = next;
        }
        public ILogger Logger { get; }
        public RequestDelegate Next { get; }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            Guid LogId = Guid.NewGuid();
            try
            {
                await Next(httpContext);
            }
            catch (ReturnMessageToCallerExceptions ex)
            {
                await HandleExceptionAsync(httpContext, new ExceptionResponseModel
                {
                    LogMessage = $"{ex.Message}, Query: {ex.Details}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReponseMessage = ex.Message
                });
            }
            catch (DatabaseException ex) 
            {
                await HandleExceptionAsync(httpContext, new ExceptionResponseModel
                {
                    LogMessage = $"{ex.Message}, details: {ex.Details}, StackTrace: {ex.StackTrace}",
                    StatusCode = HttpStatusCode.BadRequest,
                    ReponseMessage = ex.Message
                });
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, new ExceptionResponseModel
                {
                    LogMessage = $"{ex.Message}, Stack Trace:{ex.StackTrace}, Inner: {ex.InnerException}",
                    ReponseMessage = "Something Went Wrong"
                });
            }
            Task HandleExceptionAsync(HttpContext context, ExceptionResponseModel exceptionResponse)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                Logger.LogError($"LogId:{LogId}: Message: {exceptionResponse.LogMessage}");
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    Message = $"{exceptionResponse.ReponseMessage} ,LogId: {LogId}"
                }.Serialize());
            }
        }
    }
}
