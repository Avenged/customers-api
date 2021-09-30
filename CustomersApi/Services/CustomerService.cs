using AutoMapper;
using CustomersApi.Domain;
using CustomersApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto> CreateAsync(CustomerDto customer)
        {
            var customerResult = await _repository.CreateAsync(customer);
            return customerResult;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer;
        }
    }
}
