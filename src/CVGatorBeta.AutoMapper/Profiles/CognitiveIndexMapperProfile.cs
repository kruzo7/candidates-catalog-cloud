using AutoMapper;
using CVGatorBeta.CognitiveSearch.Candidates;
using CVGatorBeta.DTO.Search;

namespace CVGatorBeta.AutoMapper.Profiles
{
    public class CognitiveIndexMapperProfile : Profile
    {
        public CognitiveIndexMapperProfile()
        {
            CreateMap<CandidateIndexModel, SearchCandidateDto>().ReverseMap();
        }
    }
}
