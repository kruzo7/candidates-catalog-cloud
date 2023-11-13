using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using Newtonsoft.Json;

namespace CVGatorBeta.AutoMapper.CustomConverters
{
    internal class CategoryConverter : IValueConverter<ICollection<CandidatesCategory>, string>
    {
        public string Convert(ICollection<CandidatesCategory> source, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Select(x => x.Category.CategoryName));
        }
    }
}
