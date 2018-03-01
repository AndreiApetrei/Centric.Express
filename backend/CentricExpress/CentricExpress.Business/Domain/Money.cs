using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace CentricExpress.Business.Domain
{
    public class Money
    {
        private Money()
        {
            //orm
        }

        public static Money Zero => new Money(0, Domain.Currency.Nothing);

        private Money(decimal value, Currency currency) : this(value, currency.ToString())
        {
        }

        public Money(decimal value, string currency)
        {
            Currency = currency;
            Value = value;
        }
        
        public string Currency { get; private set;}
        public decimal Value { get; private set; }

        public static Money operator *(Money money, int quantity)
        {
            return money.MultiplyWith(quantity);
        }

        private Money MultiplyWith(int quantity)
        {
            return new Money(Value * quantity, this.Currency);
        }

        private bool Equals(Money other)
        {
            return string.Equals(Currency, other.Currency) && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Currency != null ? Currency.GetHashCode() : 0) * 397) ^ Value.GetHashCode();
            }
        }

        public static Money From(decimal value, Currency currency)
        {
            return new Money(value, currency);
        }
    }
}