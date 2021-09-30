using CustomersApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> CreateAsync(CustomerDto customer);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
    }
}