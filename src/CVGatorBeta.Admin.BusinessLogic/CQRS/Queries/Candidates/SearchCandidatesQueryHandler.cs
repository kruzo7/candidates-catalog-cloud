using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Commons.Settings;
using CVGatorBeta.DTO.Search;
using Microsoft.Extensions.Options;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates
{
    public class SearchCandidatesQueryHandler : IQueryHandler<SearchCandidatesQuery, SearchCandidateResponseDto>
    {
        private readonly ISearchCandidates _searchCandidates;
        private readonly CVGatorSetting _cVGatorSetting;

        public SearchCandidatesQueryHandler(ISearchCandidates searchCandidates, IOptions<CVGatorSetting> cVGatorSetting)
        {
            _searchCandidates = searchCandidates;
            _cVGatorSetting = cVGatorSetting.Value;
        }

        public async Task<SearchCandidateResponseDto> Handle(SearchCandidatesQuery query, CancellationToken cancellationToken)
        {
            var (result, totalPages) = await _searchCandidates.SearchCandidates(query.SearchCandidateRequestDto, query.SearchCandidateRequestDto.PageNumber, _cVGatorSetting.RecordsPerPage);

            return new SearchCandidateResponseDto()
            {
                SearchCandidateDtos = result.ToList(),
                TotalPages = totalPages,
                Page = query.SearchCandidateRequestDto.PageNumber,
            };
        }
    }
}
