using PackIt.Application.DTO;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Application.Queries.Handlers;

public class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
{ 
    public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
    {
        throw new NotImplementedException();
    }
}