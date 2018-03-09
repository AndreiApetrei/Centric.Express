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
        
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(IRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public Guid Add(CustomerDto customerDto)
        {
            customerDto.Id = Guid.NewGuid();

            customerRepository.Insert(customerDto.ToDomain());
            unitOfWork.Commit();

            return customerDto.Id;
        }

        public void Delete(Guid id)
        {
            customerRepository.Remove(id);
            unitOfWork.Commit();
        }

        public IList<CustomerDto> Get()
        {
            return customerRepository.Get()?.Select(CustomerDto.FromDomain).ToList();
        }

        public CustomerDto Get(Guid id)
        {
            var customer = customerRepository.GetById(id);

            return CustomerDto.FromDomain(customer);
        }

        public CustomerDto Update(Guid id, CustomerDto customerDto)
        {
            var customer = customerRepository.GetById(id);

            if (customer == null)
            {
                return null;
            }

            customer.Age = customerDto.Age;
            customer.FirstName = customerDto.FullName.Split(' ')[0];
            customer.Surname = customerDto.FullName.Split(' ')[1];

            customerRepository.Update(customer);
            unitOfWork.Commit();

            return CustomerDto.FromDomain(customer);
        }
    }
}