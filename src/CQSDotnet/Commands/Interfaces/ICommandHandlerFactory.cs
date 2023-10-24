namespace CQSDotnet.Commands.Interfaces
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> GetHandler<TCommand>() where TCommand : ICommand;
    }
}