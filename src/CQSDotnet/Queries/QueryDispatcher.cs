namespace CQSDotnet.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQSDotnet.Exceptions;
    using CQSDotnet.Queries.Interfaces;

    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IQueryHandlerFactory queryHandlerFactory;
        private readonly IQueryValidatorFactory queryValidatorFactory;

        public QueryDispatcher(
            IQueryHandlerFactory queryHandlerFactory,
            IQueryValidatorFactory queryValidatorFactory)
        {
            this.queryHandlerFactory = queryHandlerFactory;
            this.queryValidatorFactory = queryValidatorFactory;
        }

        public Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>
        {
            var validator = queryValidatorFactory.GetValidator<TQuery, TResult>();
            var validationStatus = validator.Validate(query);

            if (validationStatus.IsValid)
            {
                var handler = queryHandlerFactory.GetHandler<TQuery, TResult>();
                return handler.HandleAsync(query, cancellationToken);
            }
            else
            {
                throw new ValidationStatusException(validationStatus);
            }
        }
    }
}