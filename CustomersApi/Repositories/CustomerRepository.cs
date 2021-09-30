using AutoMapper;
using CustomersApi.Database;
using CustomersApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            var mappedCustomers = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return mappedCustomers;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _dbContext.Customers.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var mappedCustomer = _mapper.Map<CustomerDto>(customer);

            return mappedCustomer;
        }

        public async Task<CustomerDto> CreateAsync(CustomerDto customer)
        {
            var mappedCustomer = _mapper.Map<Customer>(customer);

            await _dbContext.AddAsync(mappedCustomer);
            await _dbContext.SaveChangesAsync();

            var customerResult = _mapper.Map<CustomerDto>(mappedCustomer);

            return customerResult;
        }
    }
}
