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
            var defaultValidator = new DefaultQueryValidator<TQuery>();

            try
            {
                var validator = this.resolver.Resolve(typeof(IQueryValidator<TQuery>)) as IQueryValidator<TQuery> ?? defaultValidator;
                return validator;
            }
            catch
            {
                return defaultValidator;
            }
        }
    }
}