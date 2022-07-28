using MM.Repository;
using MM.Repository.Model;
using MM.Services.Services.Interfaces;

namespace MM.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MMDbContext context;

        public CustomerService(MMDbContext context)
        {
            this.context = context;
        }

        public async Task CreateCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }
        public List<Customer> SelectAllCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer SelectCustomerById(int id)
        {   
            return context.Customers.Single(x=> x.Id == id);
        }

        public async Task UpdateCustomer(Customer employee)
        {
            context.Customers.Update(employee);
            await context.SaveChangesAsync();
        }
    }
}
