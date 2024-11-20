using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record DeletePackingList(Guid Id) : ICommand;