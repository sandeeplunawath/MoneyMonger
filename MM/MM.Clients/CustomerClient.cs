using MM.Repository.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Clients
{
    public class CustomerClient
    {
        HttpClient client = new HttpClient();

        public CustomerClient()
        {
            client.BaseAddress = new Uri("http://localhost:4001");
            //client.BaseAddress = new Uri(CommonSettings.config["Url"]);

        }

        public async Task CreateCustomer(Customer customer)
        {
            var data = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Customer/create", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Customer>> SelectAllCustomers()
        {
            HttpResponseMessage response =  await client.GetAsync("Customer/selectAllCustomers");
            return JsonConvert.DeserializeObject<List<Customer>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Customer> SelectCustomerById(int id)
        {
            HttpResponseMessage response =  await client.GetAsync($"Customer/selectCustomerById/{id}");
            string responseDetails = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Customer>(responseDetails);
        }
        public async Task UpdateCustomer(Customer customer)
        {
            var data = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Customer/update", data);
            response.EnsureSuccessStatusCode();
        }

    }
}
