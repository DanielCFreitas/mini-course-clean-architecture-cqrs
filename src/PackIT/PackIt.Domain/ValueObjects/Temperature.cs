﻿using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects;

public record Temperature
{
    private double Value { get; }

    public Temperature(double value)
    {
        if (value is < -100 or > 100) throw new InvalidTemperatureException(value);
        Value = value;
    }

    public static implicit operator double(Temperature temperature) => temperature.Value!;
    public static implicit operator Temperature(double temperature) => new(temperature);
}