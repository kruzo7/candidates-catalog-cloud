using CVGatorBeta.Admin.BusinessLogic;
using CVGatorBeta.Commons.Settings;
using CVGatorBeta.Commons.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CVGatorBeta.AutoMapper;

var host = new HostBuilder()    
    .ConfigureFunctionsWorkerDefaults(worker =>
    {
        worker.UseNewtonsoftJson();
        worker.UseMiddleware<ExceptionHandlingMiddleware>();           
    })
    .ConfigureOpenApi()    
    .ConfigureServices(services =>
    {        
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
        {
            var options = new OpenApiConfigurationOptions()
            {
                Info = new OpenApiInfo()
                {
                    Version = "0.0.1",
                    Title = "FunctionApp.Admin",
                    Description = "FunctionApp.Admin",
                    Contact = new OpenApiContact()
                    {
                        Name = "Waldemar Rutkowski",
                    },
                },
                Servers = DefaultOpenApiConfigurationOptions.GetHostNames(),
                OpenApiVersion = OpenApiVersionType.V3,
                IncludeRequestingHostName = false,
                ForceHttps = false,
                ForceHttp = false,
            };

            return options;
        });
        
        services.AddCvGatorAutoMapper();
        services.AddAdminBusinessLogic(Environment.GetEnvironmentVariable("ConnectionStrings:SQLAdmin", EnvironmentVariableTarget.Process));
        services.AddCognitiveSearch(
            Environment.GetEnvironmentVariable("CognitiveSearchEndpoint", EnvironmentVariableTarget.Process),
            Environment.GetEnvironmentVariable("CognitiveSearchApiKey", EnvironmentVariableTarget.Process),
            Environment.GetEnvironmentVariable("ConnectionStrings:SQLAdmin", EnvironmentVariableTarget.Process));

        services.AddOptions<CVGatorSetting>().Configure<IConfiguration>((settings, configuration) =>
        {
            configuration.GetSection("CVGatorSetting").Bind(settings);
        });
    });

await host.Build().RunAsync();
