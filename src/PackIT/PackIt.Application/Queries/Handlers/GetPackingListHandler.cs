using PackIt.Application.DTO;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Application.Queries.Handlers;

public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly IPackingListRepository _repository;

    public GetPackingListHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        var packingList = await _repository.GetAsync(query.Id);

        throw new NotImplementedException();
    }
}