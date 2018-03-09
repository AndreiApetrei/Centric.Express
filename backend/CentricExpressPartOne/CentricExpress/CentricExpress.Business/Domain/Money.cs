namespace CentricExpress.Business.Domain
{
    public class Money
    {
        public Money()
        {
            //orm
        }

        public Money(decimal value,string currency)
        {
            Currency = currency;
            Value = value;
        }

        public string Currency { get; set; }
        public decimal Value { get; set; }
    }
}
