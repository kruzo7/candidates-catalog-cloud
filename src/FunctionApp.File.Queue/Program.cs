using CVGatorBeta.Admin.BusinessLogic;
using CVGatorBeta.AzureStorage;
using CVGatorBeta.Files;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddCVGatorBetaFiles();
        services.AddAzureStorage(Environment.GetEnvironmentVariable("AzureStorage:cvgatorbetauserfiles", EnvironmentVariableTarget.Process));
        services.AddAdminBusinessLogic(Environment.GetEnvironmentVariable("ConnectionStrings:SQLAdmin", EnvironmentVariableTarget.Process));   
    })
    .Build();

await host.RunAsync();
