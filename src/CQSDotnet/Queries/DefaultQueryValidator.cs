using CQSDotnet.Models;
using CQSDotnet.Queries.Interfaces;

namespace CQSDotnet.Queries
{
    public sealed class DefaultQueryValidator<TQuery> : IQueryValidator<TQuery>
        where TQuery : IQuery
    {
        public ValidationStatus Validate(TQuery query)
        {
            return new ValidationStatus();
        }
    }
}