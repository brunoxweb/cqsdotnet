namespace CQSDotnet.Commands.Interfaces
{
    public interface ICommandDispatcher
    {
        Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand;
    }
}