using CentricExpress.Business.DTOs;
using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Services
{
    public interface ICustomerService
    {
        IList<CustomerDto> Get();

        CustomerDto Get(Guid id);

        Guid Add(CustomerDto customerDto);

        void Delete(Guid id);

        CustomerDto Update(Guid id, CustomerDto customerDto);
    }
}
