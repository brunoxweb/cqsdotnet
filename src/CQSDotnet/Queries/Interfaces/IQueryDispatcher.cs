namespace CQSDotnet.Queries.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>;
    }
}