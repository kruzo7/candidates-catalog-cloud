using CVGatorBeta.Admin.BusinessLogic.Process;
using CVGatorBeta.Admin.BusinessLogic.Process.FileUpload;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CVGatorBeta.Admin.BusinessLogic
{
    public static class AdminBusinessLogicExtension
    {
        public static IServiceCollection AddAdminBusinessLogic(this IServiceCollection services, string? msSqlConnectionString)
        {
            if(string.IsNullOrEmpty(msSqlConnectionString)) throw new ArgumentNullException(nameof(msSqlConnectionString));

            services.AddDbContext<CVGatorBetaAdminContext>(x => x.UseSqlServer(msSqlConnectionString), ServiceLifetime.Scoped);
            services.AddMediatR(typeof(AdminBusinessLogicExtension).Assembly);

            AddBusinessLogicProcess(services);

            return services;
        }

        private static void AddBusinessLogicProcess(IServiceCollection services)
        {
            services.AddScoped<ProcessFileUploadMainDirector>();
            
            services.AddScoped<IProcessFileUploadBuilderFactory, ProcessFileUploadBuilderFactory>();
            services.AddScoped<ProcessFileUploadBuilderDocument>();
            services.AddScoped<ProcessFileUploadBuilderImage>();

        }
    }
}
