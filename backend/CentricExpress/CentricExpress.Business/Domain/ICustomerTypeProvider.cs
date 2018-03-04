namespace CentricExpress.Business.Domain
{
    public interface ICustomerTypeProvider
    {
        CustomerType GetCustomerType(int existingPoints);
    }
}