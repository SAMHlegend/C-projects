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
namespace Projectaccounting
{
    public partial class frmLogin : Form
    {
        public bool IsEdit = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using(UnitofWork db = new UnitofWork())
                {
                    if (IsEdit)
                    {
                        var login = db.LoginRepositorie.Get().First();
                        login.Username = txtUserName.Text;
                        login.Password = txtPassword.Text;
                        db.LoginRepositorie.Update(login);
                        MessageBox.Show($"Your username has been changed into {txtUserName.Text} and your password into {txtPassword.Text}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.Save();
                        Application.Restart();
                    }
                    else
                    {
                        if (db.LoginRepositorie.Get(a => a.Username == txtUserName.Text && a.Password == txtPassword.Text).Any())
                        {
                            MessageBox.Show($"Welcome {txtUserName.Text}", "Welcom", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("User name not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                this.Text = "Change your user name or password";
                btnLogIn.Text = "Save changes";
                using (UnitofWork db = new UnitofWork())
                {
                    var login = db.LoginRepositorie.Get().First();
                    txtUserName.Text = login.Username;
                    txtPassword.Text = login.Password;
                }
            }
        }
    }
}
