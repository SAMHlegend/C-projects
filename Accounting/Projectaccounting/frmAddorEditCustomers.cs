using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using Accounting.data.Content;
using Accounting.data.Reposotories;
using Accounting.data.Services;
using Accounting.data;
using System.IO;
namespace Projectaccounting
{
    public partial class frmAddorEditCustomers : Form
    {
        public int customerId = 0;

        UnitofWork db = new UnitofWork();
        
        public frmAddorEditCustomers()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                PcCustomer.ImageLocation = openFile.FileName;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            
            if (BaseValidator.IsFormValid(this.components) && txtEmail.Text.Contains("@gmail.com"))
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(PcCustomer.ImageLocation);

                string path = Application.StartupPath + "/Images/";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                PcCustomer.Image.Save(path+imageName);
                Customer customer = new Customer()
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Image = imageName

                };
                if(customerId == 0)
                {
                    MessageBox.Show($"The customer named {txtName.Text} has been added", "Customer added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.CustomerRepository.InsertCustomer(customer);
                }
                else
                {
                    MessageBox.Show($"The customer named {txtName.Text} has been editted", "Customer added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    customer.CustomersID = customerId;
                    db.CustomerRepository.UpdateCustomer(customer);
                }
                
                    DialogResult = DialogResult.OK;
                    db.Save();


            }
            else
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddorEditCustomers_Load(object sender, EventArgs e)
        {
            if (customerId != 0)
            {
                this.Text = "Edit Customer";
                btnsave.Text = "Edit customer";
                var customer = db.CustomerRepository.GetCustomerById(customerId);
                txtEmail.Text = customer.Email;
                txtName.Text = customer.Name;
                txtPhone.Text = customer.Phone;
                txtAddress.Text = customer.Address;
                PcCustomer.ImageLocation = Application.StartupPath + "/Images/" + customer.Image;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
 