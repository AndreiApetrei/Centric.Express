using System.Collections.Generic;

namespace CentricExpress.Business.Domain
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly ICustomerTypeProvider customerTypeProvider;

        public DiscountCalculator(ICustomerTypeProvider customerTypeProvider)
        {
            this.customerTypeProvider = customerTypeProvider;
        }

        public Money GetDiscount(Order order, int existingPoints)
        {
            return order.TotalAmount * GetPercent(existingPoints) * (1m/100m);
        }

        private int GetPercent(int existingPoints)
        {
            var customerType = customerTypeProvider.GetCustomerType(existingPoints);
            var percents = new Dictionary<CustomerType, int>()
            {
                {CustomerType.Regular, 0},
                {CustomerType.Bronze, 10},
                {CustomerType.Silver, 20},
                {CustomerType.Gold, 30},
            };

            return percents[customerType];
        }
    }
}