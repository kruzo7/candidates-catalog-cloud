using CVGatorBeta.Admin.BusinessLogic;
using CVGatorBeta.AzureStorage;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CVGatorBeta.AutoMapper;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddCvGatorAutoMapper();
        services.AddAdminBusinessLogic(Environment.GetEnvironmentVariable("ConnectionStrings:SQLAdmin", EnvironmentVariableTarget.Process));
        services.AddAzureStorage(Environment.GetEnvironmentVariable("AzureStorage:cvgatorbetauserfiles", EnvironmentVariableTarget.Process));
    })
    .Build();

await host.RunAsync();
