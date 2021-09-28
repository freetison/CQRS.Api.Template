using Microsoft.EntityFrameworkCore;

namespace Application.Mediator
{
    //class TransactionalCommandHandlerDecorator<TCommand>
    //    : ICommandHandler<TCommand>
    //{
    //    readonly DbContext context;
    //    readonly ICommandHandler<TCommand> decorated;

    //    public TransactionCommandHandlerDecorator(
    //        DbContext context,
    //        ICommandHandler<TCommand> decorated)
    //    {
    //        this.context = context;
    //        this.decorated = decorated;
    //    }

    //    public void Handle(TCommand command)
    //    {
    //        this.decorated.Handle(command);

    //        context.SaveChanges();
    //    }
    //}
}