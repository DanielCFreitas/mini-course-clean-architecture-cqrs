using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
{
    private readonly IPackingListRepository _repository;

    public AddPackingItemHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandlerAsync(AddPackingItem command)
    {
        var packingList = await _repository.GetAsync(command.PackingListId);

        if (packingList is null)
            throw new PackingListNotFoundException(command.PackingListId);

        var packingItem = new PackingItem(command.Name, command.Quantity);
        packingList.AddItem(packingItem);

        await _repository.UpdateAsync(packingList);
    }
}