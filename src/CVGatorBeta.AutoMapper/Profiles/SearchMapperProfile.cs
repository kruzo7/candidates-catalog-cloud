using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.AutoMapper.CustomConverters;
using CVGatorBeta.DTO.Enums;

namespace CVGatorBeta.AutoMapper.Profiles
{
    public class SearchMapperProfile : Profile
    {
        public SearchMapperProfile()
        {
            CreateMap<EmploymentStatus, short>().ReverseMap();
            
            CreateMap<Candidate, SearchCandidate>()
                .ForMember(dest => dest.CandidateCity, opt => opt.MapFrom(src => src.CandidatesAddress!.CityName))
                .ForMember(dest => dest.CandidateCategories, opt => opt.ConvertUsing<CategoryConverter, ICollection<CandidatesCategory>>(x => x.CandidatesCategories))
                .ForMember(dest => dest.CandidateCertificates, opt => opt.ConvertUsing<CertificateConverter, ICollection<CandidatesCertificate>>(x => x.CandidatesCertificates))
                .ForMember(dest => dest.CandidateCourses, opt => opt.ConvertUsing<CourseConverter, ICollection<CandidatesCourse>>(x => x.CandidatesCourses))
                .ForMember(dest => dest.CandidateEmployers, opt => opt.ConvertUsing<EmployerConverter, ICollection<CandidatesEmployer>>(x => x.CandidatesEmployers))
                .ForMember(dest => dest.CandidateActualEmployers, opt => opt.ConvertUsing<ActualEmployerConverter, ICollection<CandidatesEmployer>>(x => x.CandidatesEmployers))
                .ForMember(dest => dest.CandidateSchools, opt => opt.ConvertUsing<SchoolConverter, ICollection<CandidatesSchool>>(x => x.CandidatesSchools));
        }
    }
}
