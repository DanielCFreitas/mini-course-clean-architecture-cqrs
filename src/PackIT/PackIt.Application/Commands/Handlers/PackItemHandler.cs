using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public class PackItemHandler : ICommandHandler<PackItem>
{
    private readonly IPackingListRepository _repository;

    public PackItemHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandlerAsync(PackItem command)
    {
        var packingList = await _repository.GetAsync(command.PackListId);

        if (packingList is null)
            throw new PackingListNotFoundException(command.PackListId);

        packingList.PackItem(command.Name);

        await _repository.UpdateAsync(packingList);
    }
}