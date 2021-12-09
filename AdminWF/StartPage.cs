using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdminWF
{
    public partial class StartPage : Form
    {
        IPersonManager personManager;
        List<PersonDTO> users;
        int lastMatched = -1;
        bool listSorted = false;

        public StartPage(IPersonManager personManager)
        {
            InitializeComponent();
            this.personManager = personManager;

            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            users = personManager.GetUsers();
            listSorted = false;
            SetDataToTable(users);
        }

        private void SetDataToTable(List<PersonDTO> users)
        {
            BindingList<PersonDTO> blUsers = new BindingList<PersonDTO>(users);

            bsPeople.DataSource = blUsers;
            bnPeople.BindingSource = bsPeople;
            PeopleDataGridView.DataSource = bsPeople;

            PeopleDataGridView.Columns["Password"].Visible = false;
            PeopleDataGridView.Columns["Salt"].Visible = false;
            PeopleDataGridView.Columns["RoleId"].Visible = false;
            PeopleDataGridView.Columns["RowInsertTime"].Visible = false;
            PeopleDataGridView.Columns["RowUpdateTime"].Visible = false;
            PeopleDataGridView.Columns["RowInsertTimeStatus"].Visible = false;
            PeopleDataGridView.Columns["RowUpdateTimeStatus"].Visible = false;
            PeopleDataGridView.Columns["Status"].HeaderText = "Active";
        }

        private void UsersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = users[e.RowIndex];
            Edit(user);
        }

        private void Edit(PersonDTO person = null)
        {
            try
            {
                using (PersonInfo pI = new PersonInfo(personManager, person))
                {
                    var temp = pI.ShowDialog();
                    if (temp == DialogResult.OK || temp == DialogResult.Cancel)
                    {
                        RefreshDataGrid();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddNewItem_Click(object sender, EventArgs e)
        {
            Edit();
            RefreshDataGrid();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (listSorted)
                SortByNameButton_Click(sender,e);
            else
                RefreshDataGrid();
            try {
                if (lastMatched < 0)
                    throw new Exception("No row is chosen!");
                var user = users[lastMatched];
                if (user.isEmpty())
                    throw new Exception("Can't delete not existing person!");
                if (user.RoleId == (int)Roles.User)
                {
                    var result = MessageBox.Show($"Do you really want to delete {user.Firstname} {user.Lastname}?", "Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                        personManager.DeletePerson(user);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                RefreshDataGrid();
            }
        }

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            var user = users[PeopleDataGridView.CurrentCell.RowIndex];
            if (user.RoleId == (int)Roles.User)
            {
                user.Status = true;
                UpdateStatus(user);
            }
        }

        private void BlockButton_Click(object sender, EventArgs e)
        {
            var user = users[PeopleDataGridView.CurrentCell.RowIndex];
            if (user.RoleId == (int)Roles.User)
            {
                user.Status = false;
                UpdateStatus(user);
            }
        }

        private void UpdateStatus(PersonDTO user)
        {
            personManager.UpdateUserStatus(user);
            RefreshDataGrid();
        }

        private void SortByNameButton_Click(object sender, EventArgs e)
        {
            users = personManager.GetSortedUsersByName();
            SetDataToTable(users);
            listSorted = true;
        }

        private void GetUsersButton_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void GetAllButton_Click(object sender, EventArgs e)
        {
            users = personManager.GetAll();
            SetDataToTable(users);
        }

        private void FindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FindPerson(FindTextBox.Text);
        }

        private void FindPerson(string text)
        {
            PersonDTO user = new PersonDTO();
            int n = 0;
            if (!String.IsNullOrEmpty(FindTextBox.Text))
            {
                if (Int32.TryParse(text, out n))
                    user = personManager.GetUserById(n);
                else
                {
                    user = personManager.GetUserByEmail(text);
                    if (user == null)
                        user = personManager.GetUserByFullName(text);
                }
            }
            if (user != null)
            {
                using (PersonInfo pI = new PersonInfo(personManager, user))
                {
                    var temp = pI.ShowDialog();
                    if (temp == DialogResult.OK || temp == DialogResult.Cancel)
                    {
                        RefreshDataGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("No user", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PeopleDataGridView_RowCellClick(object sender, DataGridViewCellEventArgs e)
        {
            lastMatched = PeopleDataGridView.CurrentRow.Index;
        }
    }
}
