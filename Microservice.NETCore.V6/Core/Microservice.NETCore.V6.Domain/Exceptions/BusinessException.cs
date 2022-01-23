using Microsoft.Extensions.Logging;

namespace Microservice.NETCore.V6.Domain.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string? message, string? code)
            : base(message)
        {
            Code = code;
        }

        public BusinessException(EventId eventId) : base(eventId.Name)
        {
            Code = eventId.Id.ToString();
            Errors = new Dictionary<string, string[]> { { Code, new[] { eventId.Name } } };
        }

        public string? Code { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}