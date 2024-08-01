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
using Accounting.data.Reposotories;
using Accounting.data.Services;
namespace Projectaccounting
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }

        private void dgcustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        void BindGrid()
        {
            using (UnitofWork db = new UnitofWork())
            {
                dgcustomers.AutoGenerateColumns = false;
                dgcustomers.DataSource = db.CustomerRepository.GetallCustomers();
            }
        }

        private void BtnRefreshcustomer_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void txtfilter_Click(object sender, EventArgs e)
        {

        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitofWork db = new UnitofWork())
            {
                dgcustomers.DataSource = db.CustomerRepository.GetCustomersByfilter(txtfilter.Text);
            }
        }

        private void BtnDeletecustomer_Click(object sender, EventArgs e)
        {
            if(dgcustomers.CurrentRow != null)
            {
                using (UnitofWork db = new UnitofWork())
                {
                    string name = dgcustomers.CurrentRow.Cells[1].Value.ToString();
                    if (MessageBox.Show($"Are you sure about deleting {name}","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                    {
                        int customerid = int.Parse(dgcustomers.CurrentRow.Cells[0].Value.ToString());
                        db.CustomerRepository.DeleteCustomer(customerid);
                        db.Save();
                        BindGrid();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Please Select a row");
            }
        }

        private void BtnAddcustomer_Click(object sender, EventArgs e)
        {
            frmAddorEditCustomers frmadd = new frmAddorEditCustomers();
            if (frmadd.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void BtnEditcustomer_Click(object sender, EventArgs e)
        {
            if(dgcustomers.CurrentRow != null)
            {
                int customerId = int.Parse(dgcustomers.CurrentRow.Cells[0].Value.ToString()); ;
                    frmAddorEditCustomers frmaddOrEdit = new frmAddorEditCustomers();
                    frmaddOrEdit.customerId = customerId;
                    if (frmaddOrEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindGrid();
                    }  
            }
        }
    }
}
