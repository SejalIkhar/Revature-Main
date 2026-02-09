//Method Overriding example

using System;

public class Money : IComparable<Money>
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency = "USD")
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money left, Money right)
    {
        ValidateCurrency(left, right);
        return new Money(left.Amount + right.Amount, left.Currency);
    }

    public static Money operator -(Money left, Money right)
    {
        ValidateCurrency(left, right);
        return new Money(left.Amount - right.Amount, left.Currency);
    }

    public static Money operator *(Money left, decimal multiplier)
    {
        return new Money(left.Amount * multiplier, left.Currency);
    }

    public static Money operator *(decimal multiplier, Money right)
    {
        return right * multiplier;
    }

    public static Money operator /(Money left, decimal divisor)
    {
        return new Money(left.Amount / divisor, left.Currency);
    }

    public static bool operator ==(Money? left, Money? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        return left.Amount == right.Amount &&
               left.Currency == right.Currency;
    }

    public static bool operator !=(Money left, Money right)
    {
        return !(left == right);
    }

    public static bool operator <(Money left, Money right)
    {
        ValidateCurrency(left, right);
        return left.Amount < right.Amount;
    }

    public static bool operator >(Money left, Money right)
    {
        ValidateCurrency(left, right);
        return left.Amount > right.Amount;
    }

    public static bool operator <=(Money left, Money right)
    {
        return left < right || left == right;
    }

    public static bool operator >=(Money left, Money right)
    {
        return left > right || left == right;
    }

    public static explicit operator decimal(Money money)
    {
        return money.Amount;
    }

    public static implicit operator Money(decimal amount)
    {
        return new Money(amount);
    }

    public override bool Equals(object? obj)
    {
        return obj is Money m && this == m;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }

    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }

    public int CompareTo(Money? other)
    {
        if (other == null) return 1;
        ValidateCurrency(this, other);
        return Amount.CompareTo(other.Amount);
    }

    private static void ValidateCurrency(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException("Currency mismatch");
    }
}

class Program
{
    static void Main()
    {
        var price1 = new Money(100, "USD");
        var price2 = new Money(50, "USD");

        Console.WriteLine(price1 + price2);   // 150 USD
        Console.WriteLine(price1 - price2);   // 50 USD
        Console.WriteLine(price1 * 2);        // 200 USD
        Console.WriteLine(price1 / 4);        // 25 USD

        Console.WriteLine(price1 > price2);   // True
        Console.WriteLine(price1 == price1);  // True

        Money m = 75.50m;
        decimal amount = (decimal)price1;

        Console.WriteLine(m);
        Console.WriteLine(amount);
    }
}
