using CQSDotnet.Models;

namespace CQSDotnet.Commands.Interfaces
{
    public interface ICommandValidator<TCommand> where TCommand : ICommand
    {
        ValidationStatus Validate(TCommand command);
    }
}