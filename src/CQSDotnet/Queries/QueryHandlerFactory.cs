using CQSDotnet.Exceptions;
using CQSDotnet.Queries.Interfaces;

namespace CQSDotnet.Queries
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly ITypeResolver resolver;

        public QueryHandlerFactory(ITypeResolver resolver)
        {
            this.resolver = resolver;
        }

        public IQueryHandler<TQuery, TResult> GetHandler<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            try
            {
                if (this.resolver.Resolve(typeof(IQueryHandler<TQuery, TResult>)) is not IQueryHandler<TQuery, TResult> handler)
                {
                    throw new ArgumentNullException();
                }

                return handler;
            }
            catch (Exception ex)
            {
                throw new HandlerNotFoundException(typeof(TQuery).Name, ex);
            }
        }
    }
}