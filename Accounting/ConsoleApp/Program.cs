using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.data.Reposotories;
using Accounting.data.Services;
using Accounting.data.Content;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitofWork db = new UnitofWork();

            var list = db.CustomerRepository.GetallCustomers();
            db.Dispose();
        }
    }
}
