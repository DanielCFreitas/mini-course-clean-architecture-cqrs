﻿using PackIt.Domain.ValueObjects;

namespace PackIt.Domain.Policies.Temperature;

internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Temperature > 250;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>()
        {
            new("Hat", 1),
            new("Sunglasses", 1),
            new("Cream with UV filter", 1)
        };
}