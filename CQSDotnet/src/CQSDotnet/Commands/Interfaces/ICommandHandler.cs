namespace CQSDotnet.Commands.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}