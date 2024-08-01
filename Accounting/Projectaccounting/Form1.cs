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
using Accounting.viewmodels.Accounting;
using Accounting.logic;

namespace Projectaccounting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            FrmCustomers frmCustomers = new FrmCustomers();
            frmCustomers.ShowDialog();
        }

        private void btnnewtransaction_Click(object sender, EventArgs e)
        {
            frmNewTransaction frmNewTransaction = new frmNewTransaction();
            frmNewTransaction.ShowDialog();
        }

        private void btnReportpay_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.TypeID = 2;
            frmReport.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.TypeID = 1;
            frmReport.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            using (UnitofWork db = new UnitofWork())
            {
                var login = db.LoginRepositorie.Get().First();
                this.Text = "Accounting " + login.Username;
            }
            lblDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
            this.Hide();
            frmLogin frmlogin = new frmLogin();
            if (frmlogin.ShowDialog() == DialogResult.OK)
            {
                Report();
            }
            else
            {
                Application.Exit();
            }
            
        }
        void Report()
        {
            ReportViewModel report = Account.ReportMain();
            lblPay.Text = report.Pay.ToString("#,0");
            lblRecive.Text = report.Recive.ToString("#,0");
            lblBalance.Text = report.Balance.ToString("#,0");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void loginSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.IsEdit = true;
            frmLogin.ShowDialog();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Report();
        }
    }
}
