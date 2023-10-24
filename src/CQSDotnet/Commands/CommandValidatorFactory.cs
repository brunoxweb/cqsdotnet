using CQSDotnet.Commands.Interfaces;

namespace CQSDotnet.Commands
{
    public class CommandValidatorFactory : ICommandValidatorFactory
    {
        private readonly ITypeResolver resolver;

        public CommandValidatorFactory(ITypeResolver resolver)
        {
            this.resolver = resolver;
        }

        public ICommandValidator<TCommand> GetValidator<TCommand>() where TCommand : ICommand
        {
            var defaultValidator = new DefaultCommandValidator<TCommand>();

            try
            {
                var validator = this.resolver.Resolve(typeof(ICommandValidator<TCommand>)) as ICommandValidator<TCommand> ?? defaultValidator;
                return validator;
            }
            catch
            {
                return defaultValidator;
            }
        }
    }
}