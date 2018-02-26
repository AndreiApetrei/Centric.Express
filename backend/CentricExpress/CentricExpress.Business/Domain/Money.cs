namespace CentricExpress.Business.Domain
{
    public class Money
    {
        private Money()
        {
            //orm
        }

        public Money(decimal value, string currency)
        {
            Currency = currency;
            Value = value;
        }

        protected bool Equals(Money other)
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

        public string Currency { get; private set;}
        public decimal Value { get; private set; }
    }
}