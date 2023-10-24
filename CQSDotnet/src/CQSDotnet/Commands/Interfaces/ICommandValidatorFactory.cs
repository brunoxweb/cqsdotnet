namespace CQSDotnet.Commands.Interfaces
{
    public interface ICommandValidatorFactory
    {
        ICommandValidator<TCommand> GetValidator<TCommand>() where TCommand : ICommand;
    }
}