using CVGatorBeta.DTO.Search;

namespace CVGatorBeta.Commons.Settings
{
    public interface ISearchCandidates
    {
        Task<(ICollection<SearchCandidateDto> result, int totalPages)> SearchCandidates(SearchCandidateRequestDto searchCandidateRequestDto, int pageNumber, int recordsPerPage);
    }
}
