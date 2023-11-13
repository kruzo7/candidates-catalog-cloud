using AutoMapper;
using CVGatorBeta.CognitiveSearch.Candidates;
using CVGatorBeta.Commons.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace CVGatorBeta.Admin.BusinessLogic
{
    public static class CognitiveSearchExtension
    {
        public static IServiceCollection AddCognitiveSearch(this IServiceCollection services, string? searchEndpoint, string? searchApiKey, string? msSqlConnectionString)
        {
            if (string.IsNullOrEmpty(searchEndpoint)) throw new ArgumentNullException(nameof(searchEndpoint));
            if (string.IsNullOrEmpty(searchApiKey)) throw new ArgumentNullException(nameof(searchApiKey));
            if (string.IsNullOrEmpty(msSqlConnectionString)) throw new ArgumentNullException(nameof(msSqlConnectionString));

            services.AddScoped<ISearchCandidates, SearchCandidatesCognitive>(x => new SearchCandidatesCognitive(searchEndpoint, searchApiKey, x.GetRequiredService<IMapper>()));

            services.AddTransient<IIndexCandidatesCognitive, IndexCandidatesCognitive>(x => new IndexCandidatesCognitive(searchEndpoint, searchApiKey));
            services.AddTransient<IIndexerCandidatesCognitive, IndexerCandidatesCognitive>(x => new IndexerCandidatesCognitive(searchEndpoint, searchApiKey, msSqlConnectionString));

            return services;
        }
    }
}
