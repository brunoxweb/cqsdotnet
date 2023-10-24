using CQSDotnet.Commands.Interfaces;

namespace CQSDotnet.Tests.Commands.Models
{
    public class MyCommandHandler : ICommandHandler<MyCommand>
    {
        public Task HandleAsync(MyCommand command, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}