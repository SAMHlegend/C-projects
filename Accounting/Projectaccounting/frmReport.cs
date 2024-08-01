using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.data.Content;
using Accounting.data.Services;
using Accounting.data.Reposotories;
using Accounting.viewmodels.Customers;
namespace Projectaccounting
{
    public partial class frmReport : Form
    {
        public int TypeID = 0;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            using(UnitofWork db = new UnitofWork())
            {
                List<ListCusstomerViewModel> list = new List<ListCusstomerViewModel>();
                list.Add(new ListCusstomerViewModel()
                {
                    CustomerID = 0,
                    Name = "Choose"
                });
                list.AddRange(db.CustomerRepository.GetNameCustomers());
                cbCustomer.DataSource = list;
                cbCustomer.DisplayMember = "Name";
                cbCustomer.ValueMember = "CustomerID";
            };
            
            if(TypeID == 1)
            {
                this.Text = "Salaries report";
            }
            else
            {
                this.Text = "Payment report";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filter();
        }
        void filter()
        {
            using(UnitofWork db = new UnitofWork())
            {
                List<Accounting.data.Accounting> resault = new List<Accounting.data.Accounting>();
                DateTime? startDate;
                DateTime? endDate;

                if ((int)cbCustomer.SelectedValue != 0)
                {
                    int customerid = int.Parse(cbCustomer.SelectedValue.ToString());
                    resault.AddRange(db.AccountingRepositorie.Get(a => a.TypeID == TypeID && a.CustomerID == customerid));
                }
                else
                {
                    resault.AddRange(db.AccountingRepositorie.Get(a => a.TypeID == TypeID));
                }

                if (txtFromdate.Text != "    /  /")
                {
                    startDate = Convert.ToDateTime(txtFromdate.Text);
                    resault = resault.Where(r => r.DateTime >= startDate.Value).ToList();
                }
                if (txtToDate.Text != "    /  /")
                {
                    endDate = Convert.ToDateTime(txtToDate.Text);
                    resault = resault.Where(r => r.DateTime <= endDate.Value).ToList();

                }


                dgReport.AutoGenerateColumns = false;
                // dgReport.DataSource = resault;
                dgReport.Rows.Clear();
               foreach(var accounting in resault)
                {
                    string customername = db.CustomerRepository.GetCustomerNameByID(accounting.CustomerID);
                    dgReport.Rows.Add(accounting.ID, customername, accounting.Amount, accounting.DateTime,accounting.Discription);
                }
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgReport.CurrentRow != null)
            {
                int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                string name = dgReport.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show($"Are you sure about deleting {name}'s report?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (UnitofWork db = new UnitofWork())
                    {
                        db.AccountingRepositorie.Delete(id);
                        db.Save();
                        filter();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                frmNewTransaction frmnewtransaction = new frmNewTransaction();
                frmnewtransaction.AccountID = id;
                if(frmnewtransaction.ShowDialog()== DialogResult.OK)
                {
                    filter();
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            dtPrint.Columns.Add("Customer");
            dtPrint.Columns.Add("Amount");
            dtPrint.Columns.Add("Date");
            dtPrint.Columns.Add("Discription");
            foreach (DataGridViewRow item in dgReport.Rows)
            {
                dtPrint.Rows.Add(
                    item.Cells[1].Value.ToString(),
                    item.Cells[2].Value.ToString(),
                    item.Cells[3].Value.ToString(),
                    item.Cells[4].Value.ToString()
                    );

            }
            stiReport1.Load(Application.StartupPath + "/Report.mrt");
            stiReport1.RegData("DT", dtPrint);
            stiReport1.Show();

        }
    }
}
