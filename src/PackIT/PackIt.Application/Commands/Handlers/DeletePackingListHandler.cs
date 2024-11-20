using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public class DeletePackingListHandler : ICommandHandler<DeletePackingList>
{
    private readonly IPackingListRepository _repository;

    public DeletePackingListHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandlerAsync(DeletePackingList command)
    {
        var packingList = await _repository.GetAsync(command.Id);

        if (packingList is null)
            throw new PackingListNotFoundException(command.Id);

        await _repository.DeleteAsync(packingList);
    }
}