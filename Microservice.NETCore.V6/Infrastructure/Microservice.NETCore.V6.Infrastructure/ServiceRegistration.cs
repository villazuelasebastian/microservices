namespace Microservice.NETCore.V6.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("DispatchesHttpClient", configure =>
            {
                configure.BaseAddress = new Uri(configuration.GetSection("DispatchOptions:UrlBase").Value);
                configure.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}