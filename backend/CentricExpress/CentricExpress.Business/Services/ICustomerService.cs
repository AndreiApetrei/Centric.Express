using CentricExpress.Business.DTOs;
using System;
using System.Collections.Generic;

namespace CentricExpress.Business.Services
{
    public interface ICustomerService
    {
        IList<CustomerDto> Get();

        CustomerDto Get(Guid id);
    }
}
