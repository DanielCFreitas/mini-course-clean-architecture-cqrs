using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions;

public class PackingListAlreadyExistsException(string Name)
    : PackItException($"Packing list with name ${Name} already exists");