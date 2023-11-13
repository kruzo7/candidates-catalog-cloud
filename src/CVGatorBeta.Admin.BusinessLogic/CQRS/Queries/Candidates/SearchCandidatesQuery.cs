using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.Search;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates
{
    public class SearchCandidatesQuery : IQuery<SearchCandidateResponseDto>
    {
        public SearchCandidateRequestDto SearchCandidateRequestDto { get; set; }

        public SearchCandidatesQuery(SearchCandidateRequestDto searchCandidateDto)
        {
            SearchCandidateRequestDto = searchCandidateDto;
        }
    }
}
