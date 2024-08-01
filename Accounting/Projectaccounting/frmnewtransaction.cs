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
using ValidationComponents;
using Accounting.data.Reposotories;
using Accounting.data.Services;
namespace Projectaccounting
{
    public partial class frmNewTransaction : Form
    {
        private UnitofWork db;
        public int AccountID = 0;

        public frmNewTransaction()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmNewTransaction_Load(object sender, EventArgs e)
        {
            db = new UnitofWork();
            dgCustomers.AutoGenerateColumns = false;
            dgCustomers.DataSource = db.CustomerRepository.GetNameCustomers();
            if(AccountID != 0)
            {
                var account = db.AccountingRepositorie.GetByID(AccountID);
                txtAmount.Value = Convert.ToInt32(account.Amount);
                txtname.Text = db.CustomerRepository.GetCustomerNameByID(account.CustomerID);
                txtDescription.Text = account.Discription.ToString();
                if(account.TypeID == 1)
                {
                    rbRecieve.Checked = true;          
                }else
                {
                    rbPay.Checked = true;
                }
                this.Text = "Edit";
                btnSave.Text = "Edit";
                db.Dispose();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            dgCustomers.AutoGenerateColumns = false;
            dgCustomers.DataSource = db.CustomerRepository.GetNameCustomers(txtFilter.Text);
        }

        private void dgCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = dgCustomers.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if(rbPay.Checked || rbRecieve.Checked)
                {
                    db = new UnitofWork();
                    Accounting.data.Accounting accounting = new Accounting.data.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CustomerID = db.CustomerRepository.GetCustomerIdByName(txtname.Text),
                        TypeID = (rbRecieve.Checked)?1:2,
                        DateTime = DateTime.Now,
                        Discription = txtDescription.Text
                    };
                    if(AccountID == 0)
                    {
                        db.AccountingRepositorie.Insert(accounting);
                        MessageBox.Show("Transaction has been completed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.Save();
                    }
                    else
                    { 
                            accounting.ID = AccountID;
                            db.AccountingRepositorie.Update(accounting);
                            MessageBox.Show($"Customer named {txtname.Text} has been editted","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
                              
                    }
                    db.Save();
                    db.Dispose();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please choose a type of transaction","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
