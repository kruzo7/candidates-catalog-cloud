using AutoMapper;
using Azure;
using Azure.Search.Documents;
using CVGatorBeta.CognitiveSearch.Commons;
using CVGatorBeta.Commons.Settings;
using CVGatorBeta.DTO.Search;

namespace CVGatorBeta.CognitiveSearch.Candidates
{
    public class SearchCandidatesCognitive : ISearchCandidates
    {
        private int _recordsPerPage;

        private readonly SearchClient _searchClient;
        private readonly IMapper _mapper;

        public SearchCandidatesCognitive(string searchEndpoint, string searchApiKey, IMapper mapper)
        {
            _searchClient = new SearchClient(
                new Uri(searchEndpoint),
                CognitiveSearchCommons.CandidatesIndex,
                new AzureKeyCredential(searchApiKey));

            _mapper = mapper;
        }

        public async Task<(ICollection<SearchCandidateDto> result, int totalPages)> SearchCandidates(SearchCandidateRequestDto searchCandidateRequestDto, int pageNumber, int recordsPerPage)
        {
            _recordsPerPage = recordsPerPage;

            var candidates = _searchClient.Search<CandidateIndexModel>(
                searchCandidateRequestDto.SearchText,
                options: GetSearchOptions(pageNumber));

            var totalPages = CalculateTotalPages(candidates.Value.TotalCount);

            var result = new List<SearchCandidateDto>();

            await foreach (var candidate in candidates.Value.GetResultsAsync())
            {
                result.Add(_mapper.Map<SearchCandidateDto>(candidate.Document));
            }

            return (result, totalPages);
        }

        private int CalculateTotalPages(long? totalCount)
        {
            if (!totalCount.HasValue)
                return 1;

            return (int)Math.Ceiling((decimal)totalCount.Value / _recordsPerPage);
        }

        private SearchOptions GetSearchOptions(int pageNumber)
        {
            return new SearchOptions()
            {
                IncludeTotalCount = true,
                MinimumCoverage = 50,
                Size = _recordsPerPage,
                Skip = GetSkipForPagin(pageNumber),
            };
        }
        private int GetSkipForPagin(int pageNumber)
        {
            return pageNumber > 1 ? (pageNumber - 1) * _recordsPerPage : 0;
        }
    }
}