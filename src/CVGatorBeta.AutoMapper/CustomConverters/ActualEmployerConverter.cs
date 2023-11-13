using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.DTO.Enums;
using Newtonsoft.Json;

namespace CVGatorBeta.AutoMapper.CustomConverters
{
    internal class ActualEmployerConverter : IValueConverter<ICollection<CandidatesEmployer>, string>
    {
        public string Convert(ICollection<CandidatesEmployer> source, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(
                source
                ?.Where(x => x?.EmploymentStatus == (short)EmploymentStatus.Actual)
                ?.Select(x => x.Employer.EmployerName));
        }
    }
}