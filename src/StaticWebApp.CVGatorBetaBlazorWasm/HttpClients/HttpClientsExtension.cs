using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace StaticWebApp.CVGatorBetaBlazorWasm.HttpClients
{
    public static class HttpClientsExtension
    {
        public const string CVGatorAdminHttpClient = "CVGatorAdminHttpClient";
        public const string UploadFileClinet = "UploadFileClinet";

        public static IServiceCollection AddCvGatorHttpClients(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddScoped<CVGatorHttpClientFactory>();
            services.AddScoped<FileHttpClient>();

            if (isDevelopment)
            {
                services.AddHttpClient(CVGatorAdminHttpClient, x => x.BaseAddress = new Uri(configuration["HttpClients:CVGatorAdminHttpClient"]));
                services.AddHttpClient(UploadFileClinet, x => x.BaseAddress = new Uri(configuration["HttpClients:CVGatorUploadFileClinet"]));
            }
            else
            {
                services.AddHttpClient(CVGatorAdminHttpClient, x => x.BaseAddress = new Uri(configuration["HttpClients:CVGatorAdminHttpClient"])).AddToken();
                services.AddHttpClient(UploadFileClinet, x => x.BaseAddress = new Uri(configuration["HttpClients:CVGatorUploadFileClinet"])).AddToken();
            }

            return services;
        }

        private static IHttpClientBuilder AddToken(this IHttpClientBuilder httpClientBuilder)
        {
            httpClientBuilder
             .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
             .ConfigureHandler(
                         authorizedUrls: new[] { "https://cvgator-beta-apigateway-consumption.azure-api.net" },
                         scopes: new[] { "api://b5c7f38b-0836-455a-8e5f-5c07443f6c6a/api" }));

            return httpClientBuilder;
        }
    }
}
