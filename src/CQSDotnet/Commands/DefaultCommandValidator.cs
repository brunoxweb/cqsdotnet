using CQSDotnet.Commands.Interfaces;
using CQSDotnet.Models;

namespace CQSDotnet.Commands
{
    public sealed class DefaultCommandValidator<TCommand> : ICommandValidator<TCommand>
        where TCommand : ICommand
    {
        public ValidationStatus Validate(TCommand command)
        {
            return new ValidationStatus();
        }
    }
}