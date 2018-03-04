namespace CentricExpress.Business.Domain
{
    public interface IDiscountCalculator
    {
        Money GetDiscount(Order order, int existingPoints);
    }
}