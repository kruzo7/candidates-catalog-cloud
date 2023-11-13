using Azure;
using CVGatorBeta.CognitiveSearch.Commons;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;

namespace CVGatorBeta.CognitiveSearch.Candidates
{
    internal class IndexCandidatesCognitive : IIndexCandidatesCognitive
    {
        private readonly SearchIndexClient _searchIndexClient;
        private readonly string _indexName = CognitiveSearchCommons.CandidatesIndex;

        public IndexCandidatesCognitive(string searchEndpoint, string searchApiKey)
        {
            _searchIndexClient = new SearchIndexClient(
                new Uri(searchEndpoint),
                new AzureKeyCredential(searchApiKey));
        }

        public async Task CreateIndexCandidatesCognitive()
        {
            var searchIndex = GetIndexCandidatesCognitive();

            await _searchIndexClient.CreateOrUpdateIndexAsync(searchIndex);
        }

        private SearchIndex GetIndexCandidatesCognitive()
        {
            return new SearchIndex(_indexName)
            {
                Fields = new FieldBuilder().Build(typeof(CandidateIndexModel)),
            };
        }
    }
}
