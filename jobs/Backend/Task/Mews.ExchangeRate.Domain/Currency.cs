﻿using Ardalis.GuardClauses;

namespace Mews.ExchangeRate.Domain;

public sealed class Currency : IEquatable<Currency>
{
    public string Code { get; }

    public Currency(string code)
    {
        Guard.Against.NullOrWhiteSpace(code, 
            nameof(code));
        
        if (code.Length != 3 || !code.All(char.IsLetter))
        {
            throw new ArgumentException($"The value {code} does not have a valid ISO 4217 format", 
                nameof(code));
        }

        Code = code;
    }

    public bool Equals(Currency? other)
    {
        return other != null && (
            ReferenceEquals(this, other) ||
            other.Code.Equals(this.Code));
    }

    public override bool Equals(object? obj)
    {
        return obj is Currency value &&
            Equals(value);
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    public override string ToString()
    {
        return Code;
    }
}
