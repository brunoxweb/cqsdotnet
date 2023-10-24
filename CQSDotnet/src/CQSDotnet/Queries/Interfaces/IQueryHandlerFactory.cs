namespace CQSDotnet.Queries.Interfaces
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery, TResult> GetHandler<TQuery, TResult>() where TQuery : IQuery<TResult>;
    }
}