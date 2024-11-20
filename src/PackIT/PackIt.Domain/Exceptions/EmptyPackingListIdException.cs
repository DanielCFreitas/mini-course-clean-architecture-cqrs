using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class EmptyPackingListIdException() : PackItException("Packing list id can't be empty.");