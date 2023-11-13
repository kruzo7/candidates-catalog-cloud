using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Employers
{
    public class UpdateEmployerCommand : ICommand
    {
        public Guid EmployerId { get; set; }
        public EmployerDto Employer { get; set; }

        public UpdateEmployerCommand(Guid employerId, EmployerDto employer)
        {
            EmployerId = employerId;
            Employer = employer;
        }
    }
}
