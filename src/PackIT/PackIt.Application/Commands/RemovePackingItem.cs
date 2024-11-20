using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record RemovePackingItem(Guid PackingListId, string Name) : ICommand;