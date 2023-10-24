using CQSDotnet.Commands.Interfaces;
using CQSDotnet.Exceptions;

namespace CQSDotnet.Commands
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly ITypeResolver resolver;

        public CommandHandlerFactory(ITypeResolver resolver)
        {
            this.resolver = resolver;
        }

        public ICommandHandler<TCommand> GetHandler<TCommand>() where TCommand : ICommand
        {
            try
            {
                if (this.resolver.Resolve(typeof(ICommandHandler<TCommand>)) is not ICommandHandler<TCommand> handler)
                {
                    throw new ArgumentNullException();
                }

                return handler;
            }
            catch (Exception ex)
            {
                throw new HandlerNotFoundException(typeof(TCommand).Name, ex);
            }
        }
    }
}