using System.Net;
using System.Text.Json;

namespace TaxCalculator.Api.Middlewares.Models
{
    public struct ExceptionResponseModel
    {
        public string LogMessage { get; set; }
        public string ReponseMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public struct ErrorDetails
    {
        public string Message { get; set; }

        public string Serialize() => JsonSerializer.Serialize(this);
    }
}
