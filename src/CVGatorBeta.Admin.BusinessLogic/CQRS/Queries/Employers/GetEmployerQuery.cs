using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Employers
{
    public class GetEmployerQuery : IQuery<EmployerDto>
    {
        public Guid EmployerId { get; set; }

        public GetEmployerQuery(Guid employerId)
        {
            EmployerId = employerId;
        }
    }
}
