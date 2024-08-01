using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.viewmodels.Accounting;
using Accounting.data.Content;
namespace Accounting.logic
{
    public class Account
    {
        public static ReportViewModel ReportMain()
        {
            ReportViewModel rp = new ReportViewModel();
            using (UnitofWork db = new UnitofWork())
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 30);

                var recive = db.AccountingRepositorie.Get(s => s.TypeID == 1 && s.DateTime >= startDate && s.DateTime <= endDate).Select(s=>s.Amount).ToList();
                var pay = db.AccountingRepositorie.Get(s => s.TypeID == 2 && s.DateTime >= startDate && s.DateTime <= endDate).Select(s => s.Amount).ToList();

                rp.Recive = recive.Sum();
                rp.Pay = pay.Sum();
                rp.Balance = (recive.Sum() - pay.Sum());
            }
            return rp;
        }
    }
}
