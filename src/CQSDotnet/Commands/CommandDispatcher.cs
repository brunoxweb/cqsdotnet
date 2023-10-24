namespace CQSDotnet.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQSDotnet.Commands.Interfaces;
    using CQSDotnet.Exceptions;

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerFactory queryHandlerFactory;
        private readonly ICommandValidatorFactory queryValidatorFactory;

        public CommandDispatcher(
            ICommandHandlerFactory commandHandlerFactory,
            ICommandValidatorFactory commandValidatorFactory)
        {
            this.queryHandlerFactory = commandHandlerFactory;
            this.queryValidatorFactory = commandValidatorFactory;
        }

        public Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            var handler = queryHandlerFactory.GetHandler<TCommand>();
            var validator = queryValidatorFactory.GetValidator<TCommand>();

            var validationStatus = validator.Validate(command);

            if (validationStatus.IsValid)
            {
                return handler.HandleAsync(command, cancellationToken);
            }
            else
            {
                throw new ValidationStatusException(validationStatus);
            }
        }
    }
}