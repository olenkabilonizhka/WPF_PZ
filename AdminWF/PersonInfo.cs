using BLL;
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
    public partial class PersonInfo : Form
    {
        IPersonManager personManager;
        PersonDTO person;

        public PersonInfo(IPersonManager personManager, PersonDTO person = null)
        {
            InitializeComponent();
            this.personManager = personManager;
            this.person = person;

            if (person != null)
            {
                PersonIdTextBox.Text = person.PersonId.ToString();
                FirstNameTextBox.Text = person.Firstname;
                LastNameTextBox.Text = person.Lastname;
                EmailTextBox.Text = person.Email;
                AddButton.Visible = false;
                if (person.RoleId == (int)Roles.Admin)
                {
                    PersonIdTextBox.ReadOnly = true;
                    FirstNameTextBox.ReadOnly = true;
                    LastNameTextBox.ReadOnly = true;
                    EmailTextBox.ReadOnly = true;
                    StatusLabel.Visible = false;
                    StatusTextBox.Visible = false;
                    UpdateButton.Visible = false;
                    PasswordTextBox.ReadOnly = true;
                }
                else
                {
                    StatusTextBox.Text = (bool)person.Status ? "active" : "blocked";
                }
            }
            else
            {
                this.person = new PersonDTO();
                UpdateButton.Visible = false;
                PersonIdTextBox.Visible = false;
                PersonIdLabel.Visible = false;
                StatusTextBox.Visible = false;
                StatusLabel.Visible = false;
                PasswordTextBox.Text = String.Empty;
                PasswordTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == " ********" || (person !=null && person.RoleId == (int)Roles.User))
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "" || (person != null && person.RoleId == (int)Roles.User))
            {
                PasswordTextBox.Text = " ********";
                PasswordTextBox.ForeColor = Color.Silver;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                person.Firstname = !String.IsNullOrEmpty(FirstNameTextBox.Text) ? FirstNameTextBox.Text.Trim() : throw new Exception("First name can't be empty!");
                person.Lastname = !String.IsNullOrEmpty(LastNameTextBox.Text) ? LastNameTextBox.Text.Trim() : throw new Exception("Last name can't be empty!");
                person.Email = !String.IsNullOrEmpty(EmailTextBox.Text) ? EmailTextBox.Text.Replace(" ","") : throw new Exception("Email can't be empty!");
                person.Password = !String.IsNullOrEmpty(PasswordTextBox.Text) ? Encoding.UTF8.GetBytes(PasswordTextBox.Text.Replace(" ","")) : throw new Exception("Password can't be empty!");
                person.RoleId = (int)Roles.User;
                personManager.CreatePerson(person);
                MessageBox.Show("Added!", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                person.Firstname = !String.IsNullOrEmpty(FirstNameTextBox.Text) ? FirstNameTextBox.Text.Trim() : throw new Exception("First name can't be empty!");
                person.Lastname = !String.IsNullOrEmpty(LastNameTextBox.Text) ? LastNameTextBox.Text.Trim() : throw new Exception("Last name can't be empty!");
                person.Email = !String.IsNullOrEmpty(EmailTextBox.Text) ? EmailTextBox.Text.Replace(" ", "") : throw new Exception("Email can't be empty!");
                var passwordChanged = false;
                if (!String.IsNullOrEmpty(PasswordTextBox.Text)) {
                    if (PasswordTextBox.Text != " ********")
                    {
                        passwordChanged = true;
                        Encoding.UTF8.GetBytes(PasswordTextBox.Text.Replace(" ", ""));
                    }
                } 
                else 
                    throw new Exception("Password can't be empty!");
                
                personManager.UpdatePersonInfo(person,passwordChanged);
                MessageBox.Show("Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
