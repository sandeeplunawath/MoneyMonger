using MM.Repository.Model;

namespace MM.Services.Services.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer employee);
        List<Customer> SelectAllCustomers();
        Customer SelectCustomerById(int Id);
        Task UpdateCustomer(Customer employee);
    }
}
