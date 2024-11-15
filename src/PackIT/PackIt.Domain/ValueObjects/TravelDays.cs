using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects;

public record TravelDays
{
    private ushort Value { get; }

    public TravelDays(ushort value)
    {
        if (value is 0 || value > 100) throw new InvalidTravelDaysException(value);
        Value = value;
    }

    public static implicit operator ushort(TravelDays days) => days.Value!;
    public static implicit operator TravelDays(ushort days) => new(days);
}