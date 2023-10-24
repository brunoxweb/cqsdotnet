using CQSDotnet.Models;

namespace CQSDotnet.Queries.Interfaces
{
    public interface IQueryValidator<TQuery>
        where TQuery : IQuery
    {
        ValidationStatus Validate(TQuery query);
    }
}