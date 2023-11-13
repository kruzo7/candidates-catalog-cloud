using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using Newtonsoft.Json;

namespace CVGatorBeta.AutoMapper.CustomConverters
{
    internal class EmployerConverter : IValueConverter<ICollection<CandidatesEmployer>, string>
    {
        public string Convert(ICollection<CandidatesEmployer> source, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Select(x => x.Employer.EmployerName));
        }
    }
}
