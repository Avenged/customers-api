using CustomersApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersApi.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateAsync(CustomerDto customer);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
    }
}