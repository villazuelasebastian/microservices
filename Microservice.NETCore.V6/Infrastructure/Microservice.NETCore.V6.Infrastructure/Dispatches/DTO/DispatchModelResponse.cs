namespace Microservice.NETCore.V6.Infrastructure.Dispatches.DTO
{
    public class DispatchModelResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}