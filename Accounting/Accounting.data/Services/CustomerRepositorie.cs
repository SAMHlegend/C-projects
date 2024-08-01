using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.data.Reposotories;
using System.Data.Entity;
using Accounting.viewmodels.Customers;
namespace Accounting.data.Services
{
    public class CustomerRepositorie : ICustomerRepositorie
    {
        private Accounting_DBEntities db;

        public CustomerRepositorie(Accounting_DBEntities context)
        {
            db = context;
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = GetCustomerById(customerId);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customer> GetallCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public int GetCustomerIdByName(string name)
        {
            return db.Customers.First(c => c.Name == name).CustomersID;
        }

        public string GetCustomerNameByID(int customerId)
        {
            return db.Customers.Find(customerId).Name;
        }

        public IEnumerable<Customer> GetCustomersByfilter(string parameter)
        {
            return db.Customers.Where(c => c.Name.Contains(parameter) || c.Email.Contains(parameter) || c.Phone.Contains(parameter)).ToList();
        }

        public List<ListCusstomerViewModel> GetNameCustomers(string Filter = "")
        {
            if (Filter == null)
            {
                return db.Customers.Select(c => new ListCusstomerViewModel()
                {
                    CustomerID = c.CustomersID,
                    Name = c.Name
                }).ToList();
            }
            return db.Customers.Where(c => c.Name.Contains(Filter)).Select(c => new ListCusstomerViewModel()
            {
                CustomerID = c.CustomersID,
                Name = c.Name
            }).ToList();

        }

        public bool InsertCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            //try
            //{
            var local = db.Set<Customer>()
                .Local
                .FirstOrDefault(f => f.CustomersID == customer.CustomersID);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(customer).State = EntityState.Modified;
            return true;
            // }
            // catch
            //{
            //  return false;
            //}
        }
    }
}
