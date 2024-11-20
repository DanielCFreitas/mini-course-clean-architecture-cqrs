using PackIt.Application.DTO;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Application.Queries;

public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
{
    public string SearchPhrase { get; set; }
}