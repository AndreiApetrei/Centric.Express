namespace CentricExpress.Business.Domain
{
    public class CustomerTypeProvider : ICustomerTypeProvider
    {
        private const int GoldLevel = 3000;
        private const int SilverLevel = 2000;
        private const int BronzeLevel = 1000;

        public CustomerType GetCustomerType(int existingPoints)
        {
            return existingPoints >= GoldLevel
                ? CustomerType.Gold
                : (existingPoints >= SilverLevel
                    ? CustomerType.Silver
                    : (existingPoints >= BronzeLevel ? CustomerType.Bronze : CustomerType.Regular));
        }
    }
}