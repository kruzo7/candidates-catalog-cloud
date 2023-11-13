using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.Files.Commons;
using CVGatorBeta.Files.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CVGatorBeta.Files
{
    /// <summary>
    /// Dummy implementation for file checking. Can be implemented/replaced if needed.
    /// </summary>
    public static class CVGatorBetaFilesExtension
    {
        public static IServiceCollection AddCVGatorBetaFiles(this IServiceCollection services)
        {
            services.AddScoped<IFileValidatorFactory, FileValidatorFactory>();
            services.AddScoped<IFileTypesDetector, FileTypesDetector>();

            return services;
        }
    }
}