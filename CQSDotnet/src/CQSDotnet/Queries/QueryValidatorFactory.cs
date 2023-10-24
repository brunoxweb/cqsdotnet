using CQSDotnet.Queries.Interfaces;

namespace CQSDotnet.Queries
{
    public class QueryValidatorFactory : IQueryValidatorFactory
    {
        private readonly ITypeResolver resolver;

        public QueryValidatorFactory(ITypeResolver resolver)
        {
            this.resolver = resolver;
        }

        public IQueryValidator<TQuery> GetValidator<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            return this.resolver.Resolve(typeof(IQueryValidator<TQuery>)) as IQueryValidator<TQuery> ?? new DefaultQueryValidator<TQuery>();
        }
    }
}