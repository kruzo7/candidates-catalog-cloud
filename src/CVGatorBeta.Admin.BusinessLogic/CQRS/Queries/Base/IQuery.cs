using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
