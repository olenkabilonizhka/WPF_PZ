using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminWF
{
    public partial class LoginForm : Form
    {
        IAuthManager authManager;

        public LoginForm(IAuthManager authManager)
        {
            InitializeComponent();
            this.authManager = authManager;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (authManager.Login(EmailTextBox.Text, PasswordTextBox.Text))
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("No access!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void EmailTextBox_Enter(object sender, EventArgs e)
        {
            if(EmailTextBox.Text == " Email")
            {
                EmailTextBox.Text = "";
                EmailTextBox.ForeColor = Color.Black;
            }
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            if (EmailTextBox.Text == "")
            {
                EmailTextBox.Text = " Email";
                EmailTextBox.ForeColor = Color.Silver;
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == " Password")
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.UseSystemPasswordChar = true;
                PasswordTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                PasswordTextBox.Text = " Password";
                PasswordTextBox.UseSystemPasswordChar = false;
                PasswordTextBox.ForeColor = Color.Silver;
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginButton.PerformClick();
        }
    }
}
