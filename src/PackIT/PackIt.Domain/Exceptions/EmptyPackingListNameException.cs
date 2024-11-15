using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class EmptyPackingListNameException() : PackItException("Packing list name cannot be empty.");