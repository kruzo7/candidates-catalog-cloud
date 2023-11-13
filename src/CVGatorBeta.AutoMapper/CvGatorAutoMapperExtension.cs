using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CVGatorBeta.AutoMapper
{
    public static class CvGatorAutoMapperExtension
    {
        public static IServiceCollection AddCvGatorAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(new List<Assembly>() { typeof(CvGatorAutoMapperProfile).Assembly }, serviceLifetime: ServiceLifetime.Transient);

            return services;
        }
    }
}
