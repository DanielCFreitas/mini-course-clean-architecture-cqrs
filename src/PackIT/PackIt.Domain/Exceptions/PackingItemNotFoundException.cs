using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class PackingItemNotFoundException(string itemName) : PackItException($"Packing item {itemName} was not found.");