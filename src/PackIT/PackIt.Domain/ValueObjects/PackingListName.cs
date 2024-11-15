﻿using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects;

public record PackingListName 
{
    private string Value { get; }

    public PackingListName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new EmptyPackingListNameException();
        Value = value;
    }
    
    public static implicit operator string(PackingListName name) => name.Value!;
    public static implicit operator PackingListName(string value) => new(value);
}