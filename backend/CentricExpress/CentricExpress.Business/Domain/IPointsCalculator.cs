namespace CentricExpress.Business.Domain
{
    public interface IPointsCalculator
    {
        int Calculate(Order order);
    }
}