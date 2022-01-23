namespace Microservice.NETCore.V6.Application.Common.Options
{
    public class DispatchOptions
    {
        public const string Dispatch = "DispatchOptions";

        public string Name { get; set; }
        public string UrlBase { get; set; }
        public string UrlGetAll { get; set; }
        public string UrlGetById { get; set; }
    }
}