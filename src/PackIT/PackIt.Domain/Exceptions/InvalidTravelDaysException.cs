using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class InvalidTravelDaysException(ushort days) : PackItException($"Value {days} is invalid travel days.");