using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.data.Reposotories;
using Accounting.data.Services;

namespace Accounting.data.Content
{
    public class UnitofWork:IDisposable
    {
        Accounting_DBEntities db = new Accounting_DBEntities();

        private ICustomerRepositorie _customerrepository;

        public ICustomerRepositorie CustomerRepository {
            get
            {
                if(_customerrepository == null)
                {
                    _customerrepository = new CustomerRepositorie(db);
                }
                return _customerrepository;
            }
        }

        private GenericRepositorie<Accounting> _accountingRepositorie;

        public GenericRepositorie<Accounting> AccountingRepositorie {
            get
            {
                if (_accountingRepositorie == null)
                {
                    _accountingRepositorie = new GenericRepositorie<Accounting>(db);
                }
                return _accountingRepositorie;
            }
        }

        private GenericRepositorie<Login> _loginRepositorie;

        public GenericRepositorie<Login> LoginRepositorie {
            get {
                if(_loginRepositorie == null)
                {
                    _loginRepositorie = new GenericRepositorie<Login>(db);
                }
                return _loginRepositorie;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
   
}
