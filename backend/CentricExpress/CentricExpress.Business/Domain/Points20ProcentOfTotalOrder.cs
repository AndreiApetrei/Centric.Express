using System;

namespace CentricExpress.Business.Domain
{
    public class Points20ProcentOfTotalOrder: IPointsCalculator
    {
        private static decimal procent = 0.2m; // 20%

        public int Calculate(Order order)
        {
            var value = (order.TotalAmount * procent).Value;
            return (int) Math.Round(value);
        }
    }
}