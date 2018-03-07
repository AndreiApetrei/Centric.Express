using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IList<CustomerDto> Get()
        {
            return this.customerRepository.Get()?.Select(c => CustomerDto.FromDomain(c)).ToList();
        }

        public CustomerDto Get(Guid id)
        {
            var customer = this.customerRepository.GetById(id);

            return CustomerDto.FromDomain(customer);
        }
    }
}
