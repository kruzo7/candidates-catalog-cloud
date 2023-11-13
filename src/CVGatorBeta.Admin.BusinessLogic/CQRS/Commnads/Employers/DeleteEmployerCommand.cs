using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Employers
{
    public class DeleteEmployerCommand : ICommand
    {
        public Guid EmployerId { get; set; }

        public DeleteEmployerCommand(Guid employerId)
        {
            EmployerId = employerId;
        }
    }
}
