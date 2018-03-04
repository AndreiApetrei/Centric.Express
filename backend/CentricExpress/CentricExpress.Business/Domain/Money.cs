using System;
using System.Runtime.InteropServices.WindowsRuntime;

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

        public string Currency { get; private set; }
        public decimal Value { get; private set; }

        public static Money operator *(Money money, decimal quantity)
        {
            return money.MultiplyWith(quantity);
        }

        private static Money PerformOperatorOperation(Money money, Money otherMoney, Func<decimal, decimal, decimal> operatorFunc)
        {
            if (money == Zero)
            {
                return otherMoney;
            }

            if (otherMoney == Zero)
            {
                return money;
            }

            if (!Equals(money.Currency, money.Currency))
            {
                throw new ArgumentException("if you want to sum up Money they should have the same currency", "money");
            }

            return new Money(operatorFunc(money.Value, otherMoney.Value), money.Currency);
        }

        public static Money operator -(Money money, Money otherMoney)
        {
            return PerformOperatorOperation(money, otherMoney, (arg1, arg2) => arg1 - arg2);
        }

        public static Money operator +(Money money, Money otherMoney)
        {
            return PerformOperatorOperation(money, otherMoney, (arg1, arg2) => arg1 + arg2);
        }
        
        public static bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }

        private Money MultiplyWith(decimal quantity)
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

        public override string ToString()
        {
            return $"{nameof(Currency)}: {Currency}, {nameof(Value)}: {Value}";
        }

        public Money Copy()
        {
            return new Money(this.Value, this.Currency);
        }
    }
}