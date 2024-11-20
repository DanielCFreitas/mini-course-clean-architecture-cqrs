using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record PackItem(Guid PackListId, string Name) : ICommand;