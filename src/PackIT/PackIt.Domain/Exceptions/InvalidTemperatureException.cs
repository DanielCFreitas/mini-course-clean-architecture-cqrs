using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class InvalidTemperatureException(double value) : PackItException($"Value {value} is invalid temperature.");