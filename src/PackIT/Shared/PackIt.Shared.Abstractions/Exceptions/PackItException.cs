namespace PackIt.Shared.Abstractions.Exceptions;

public abstract class PackItException(string message) : Exception(message);