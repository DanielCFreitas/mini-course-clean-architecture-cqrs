using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class InvalidTemperatureException(double Value) : PackItException($"Value {Value} is invalid temperature.");