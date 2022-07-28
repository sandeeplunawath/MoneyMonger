using Microsoft.AspNetCore.Mvc;
using MM.Repository.Model;
using MM.Services.Services.Interfaces;

namespace MM.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            this.CustomerService = customerService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            await CustomerService.CreateCustomer(customer);
            return Ok(new { message = "Customer created" });
        }

        [HttpGet]
        [Route("selectAllCustomers")]
        public List<Customer> SelectAllCustomers()
        {
            return CustomerService.SelectAllCustomers();
        }

        [HttpGet]
        [Route("selectCustomerById/{Id}")]
        public Customer SelectCustomerById(int Id)
        {
            return CustomerService.SelectCustomerById(Id);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            await CustomerService.UpdateCustomer(customer);
            return Ok(new { message = "Customer Updated" });
        }

        [HttpGet]
        [Route("check")]
        public IActionResult webapiconnect()
        {
            return Ok(new { message = "User created" });
        }
    }
}
