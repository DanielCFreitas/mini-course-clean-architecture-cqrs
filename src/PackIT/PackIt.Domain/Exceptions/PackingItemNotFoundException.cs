using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class PackingItemNotFoundException(string ItemName) : PackItException($"Packing item {ItemName} was not found.");