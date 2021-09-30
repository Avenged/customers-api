using AutoMapper;
using CustomersApi.Domain;
using CustomersApi.Repositories;
using CustomersApi.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CustomersApi.Moq
{
    public class CustomerServiceTests
    {
        private readonly CustomerService _sut;
        private readonly Mock<ICustomerRepository> _customerRepoMock = new();

        public CustomerServiceTests()
        {
            var configuration = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            var mapper = new Mapper(configuration);

            _sut = new CustomerService(_customerRepoMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = 1;
            var customerName = "Jose Chaudary";
            var customer = new CustomerDto
            {
                Id = customerId,
                Name = customerName
            };
            _customerRepoMock.Setup(x => x.GetByIdAsync(customerId))
                .ReturnsAsync(customer);

            // Act
            var customerDto = await _sut.GetByIdAsync(customerId);

            // Assert
            Assert.Equal(customerId, customerDto.Id);
        }
    }
}
