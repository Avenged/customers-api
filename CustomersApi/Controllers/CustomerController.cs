using CustomersApi.Domain;
using CustomersApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CustomerDto customer)
        {
            customer = await _customerService.CreateAsync(customer);
            return Ok(customer);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int customerId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);
            return customer != null ? Ok(customer) : NotFound();
        }
    }
}
