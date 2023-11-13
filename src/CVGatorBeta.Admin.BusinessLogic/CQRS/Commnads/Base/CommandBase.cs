namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base
{
    internal class CommandBase : ICommand
    {
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
    }

}
