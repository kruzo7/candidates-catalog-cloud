using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
