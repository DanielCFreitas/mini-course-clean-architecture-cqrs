using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
{
    private readonly IPackingListRepository _repository;

    public RemovePackingItemHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandlerAsync(RemovePackingItem command)
    {
        var packingList = await _repository.GetAsync(command.PackingListId);

        if (packingList is null)
            throw new PackingListNotFoundException(command.PackingListId);
        
        packingList.RemoveItem(command.Name);
        
        await _repository.UpdateAsync(packingList);
    }
}