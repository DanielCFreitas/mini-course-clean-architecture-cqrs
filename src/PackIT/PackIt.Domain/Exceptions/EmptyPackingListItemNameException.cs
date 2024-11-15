using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class EmptyPackingListItemNameException() : PackItException("Packing item name cannot be empty.")
{
    
}