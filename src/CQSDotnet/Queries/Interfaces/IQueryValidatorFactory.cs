namespace CQSDotnet.Queries.Interfaces
{
    public interface IQueryValidatorFactory
    {
        IQueryValidator<TQuery> GetValidator<TQuery, TResult>() where TQuery : IQuery<TResult>;
    }
}