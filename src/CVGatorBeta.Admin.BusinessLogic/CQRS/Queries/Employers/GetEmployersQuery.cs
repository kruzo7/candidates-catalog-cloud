using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Employers
{
    public class GetEmployersQuery : IQuery<IEnumerable<EmployerDto>>
    {
        public GetEmployersQuery()
        {
        }
    }
}
