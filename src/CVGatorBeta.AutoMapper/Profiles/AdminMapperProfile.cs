using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.DTO.CandidateDetails;
using CVGatorBeta.DTO.Candidates;
using CVGatorBeta.DTO.Categories;
using CVGatorBeta.DTO.Enums;
using CVGatorBeta.DTO.Commons;
using File = CVGatorBeta.Admin.EntityFramework.AdminModels.File;

namespace CVGatorBeta.AutoMapper.Profiles
{
    public class AdminMapperProfile : Profile
    {
        public AdminMapperProfile()
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<CandidatesAddress, CandidatesAddressDto>().ReverseMap();
            CreateMap<CandidatesCategory, CandidateCategoryDto>().ReverseMap();
            CreateMap<CandidatesCertificate, CandidatesCertificateDto>().ReverseMap();
            CreateMap<CandidatesCourse, CandidatesCourseDto>().ReverseMap();
            CreateMap<CandidatesEmployer, CandidatesEmployerDto>().ReverseMap();
            CreateMap<CandidatesSchool, CandidatesSchoolDto>().ReverseMap();            
            CreateMap<CandidatesFile, CandidatesFileDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Certificate, CertificateDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Employer, EmployerDto>().ReverseMap();
            CreateMap<School, SchoolDto>().ReverseMap();            
            CreateMap<File, FileDto>().ReverseMap();

            CreateMap<EmploymentStatus, short>().ReverseMap();
        }
    }
}
