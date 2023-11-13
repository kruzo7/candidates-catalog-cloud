using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
