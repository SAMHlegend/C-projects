using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.viewmodels.Customers;
namespace Accounting.data.Reposotories
{
    public interface ICustomerRepositorie
    {
        List<Customer> GetallCustomers();
        IEnumerable<Customer> GetCustomersByfilter(string parameter);
        List<ListCusstomerViewModel> GetNameCustomers(string Filter = "");
        Customer GetCustomerById(int customerId);
        bool InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        bool DeleteCustomer(int customerId);

        int GetCustomerIdByName(string name);

        string GetCustomerNameByID(int customerId);
        

    }
}
