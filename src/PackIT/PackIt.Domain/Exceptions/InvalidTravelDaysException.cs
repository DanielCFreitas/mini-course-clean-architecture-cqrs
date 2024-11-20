using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class InvalidTravelDaysException(ushort Days) : PackItException($"Value {Days} is invalid travel days.");