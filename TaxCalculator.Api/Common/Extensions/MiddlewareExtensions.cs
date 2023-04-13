using TaxCalculator.Api.Middlewares;

namespace Microsoft.AspNetCore.Builder
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder applicationBuilder)
         => applicationBuilder.UseMiddleware<ExceptionHandlingMiddleware>();

    }
}