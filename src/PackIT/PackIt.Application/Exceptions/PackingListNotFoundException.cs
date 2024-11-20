using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions;

public class PackingListNotFoundException(Guid id) : PackItException($"Packing List with Id ${id} not found.");