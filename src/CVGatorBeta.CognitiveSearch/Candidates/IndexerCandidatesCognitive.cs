using Azure;
using CVGatorBeta.CognitiveSearch.Commons;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;

namespace CVGatorBeta.CognitiveSearch.Candidates
{
    internal class IndexerCandidatesCognitive : IIndexerCandidatesCognitive
    {
        private readonly string _connectionString;
        private readonly SearchIndexerClient _searchIndexerClient;
        private readonly string _indexerName = CognitiveSearchCommons.CandidatesIndexer;
        private readonly string _indexName = CognitiveSearchCommons.CandidatesIndex;
        private readonly string _dataSourceName = CognitiveSearchCommons.CandidatesDataSource;
        private readonly string _tableName = CognitiveSearchCommons.CandidatesDataSourceTableName;
        private readonly string _jsonArrayToStringFieldMappingName = "jsonArrayToStringCollection";

        public IndexerCandidatesCognitive(string searchEndpoint, string searchApiKey, string msSqlConnectionString)
        {
            _connectionString = msSqlConnectionString;
            _searchIndexerClient = new SearchIndexerClient(
                new Uri(searchEndpoint),
                new AzureKeyCredential(searchApiKey));
        }

        public async Task CreateIndexerCandidatesCognitive()
        {
            var indexer = GetIndexerCandidatesCognitive();
            var dataSource = GetDataSourceCandidatesCognitive();

            await _searchIndexerClient.CreateOrUpdateDataSourceConnectionAsync(dataSource);

            await _searchIndexerClient.CreateOrUpdateIndexerAsync(indexer);
        }

        public async Task RunIndexerCandidatesCognitive()
        {
            await _searchIndexerClient.RunIndexerAsync(_indexerName);
        }

        private SearchIndexer GetIndexerCandidatesCognitive()
        {
            return new SearchIndexer(_indexerName, _dataSourceName, _indexName)
            {
                Schedule = new IndexingSchedule(new TimeSpan(0, 5, 0))
                {
                    StartTime = DateTimeOffset.UtcNow,
                },
                Parameters = new IndexingParameters()
                {
                    BatchSize = 100,
                    MaxFailedItems = 0,
                    MaxFailedItemsPerBatch = 0,
                },
                FieldMappings =
                {
                    new FieldMapping(nameof(CandidateIndexModel.CandidateCategories)) { MappingFunction  = new FieldMappingFunction(_jsonArrayToStringFieldMappingName) },
                    new FieldMapping(nameof(CandidateIndexModel.CandidateCertificates)) { MappingFunction  = new FieldMappingFunction(_jsonArrayToStringFieldMappingName) },
                    new FieldMapping(nameof(CandidateIndexModel.CandidateCourses)) { MappingFunction  = new FieldMappingFunction(_jsonArrayToStringFieldMappingName) },
                    new FieldMapping(nameof(CandidateIndexModel.CandidateEmployers)) { MappingFunction  = new FieldMappingFunction(_jsonArrayToStringFieldMappingName) },
                    new FieldMapping(nameof(CandidateIndexModel.CandidateActualEmployers)) { MappingFunction  = new FieldMappingFunction(_jsonArrayToStringFieldMappingName) },
                    new FieldMapping(nameof(CandidateIndexModel.CandidateSchools)) { MappingFunction  = new FieldMappingFunction(_jsonArrayToStringFieldMappingName) },
                }
            };
        }

        private SearchIndexerDataSourceConnection GetDataSourceCandidatesCognitive()
        {
            return new SearchIndexerDataSourceConnection(
                _dataSourceName,
                SearchIndexerDataSourceType.AzureSql,
                _connectionString,
                 new SearchIndexerDataContainer(_tableName))
            {
                DataChangeDetectionPolicy = new SqlIntegratedChangeTrackingPolicy()
            };
        }
    }
}
