using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buisness;

namespace DVLManagementSystem
{
    public partial class frmUsersManagement : Form
    {
        private static DataTable _dtAllUsers;
        public frmUsersManagement()
        {
            InitializeComponent();
        }
        private void _LoadUsers()
        {
            _dtAllUsers = clsUsers.GetAll();
            dgvUsers.DataSource = _dtAllUsers;
            clsLoginData.RecrdsNum(dgvUsers, lblRecords);
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser newUser = new frmAddNewUser(-1);
            newUser.ShowDialog();
            _LoadUsers();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
            _LoadUsers();

        }

        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUserInfo userDetails = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            userDetails.ShowDialog();

        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddNewUser user = new frmAddNewUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            user.ShowDialog();
            _LoadUsers();

        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            _LoadUsers();
            cbFilter.SelectedIndex = 0;
            cbSearch.SelectedIndex = 0;
            

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record ?", "Delete User", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
            {
                if (clsUsers.Delete((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Succesfuly");
                    _LoadUsers();
            
                }
                else
                {
                    MessageBox.Show("This User Cann't be deleted because there's data connected to it","Delete User",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.Text == "None")
            {
                txtSearch.Visible = false;
                cbSearch.Visible = false;
            }
            else if (cbFilter.Text == "User ID" || cbFilter.Text == "_UserName" || cbFilter.Text == "Person ID"|| cbFilter.Text == "Full Name")
            {
                txtSearch.Visible = true;
                cbSearch.Visible = false;
            }
            else
            {
                txtSearch.Visible = false;
                cbSearch.Visible = true;
            }
            clsLoginData.RecrdsNum(dgvUsers, lblRecords);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "User ID" || cbFilter.Text == "Person ID" )
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
                
        }
        //private void _LoadUsersByActiveStatus(string status)
        //{
        //    dgvUsers.DataSource = clsUsers.FilterByIs_Avtive(status);
        //    clsLoginData.RecrdsNum(dgvUsers, lblRecords);
        //}

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbSearch.Visible)
            //{
            //    _LoadUsersByActiveStatus(cbSearch.Text);
            //}
            string FilterColumn = "IsActive";
            string FilterValue = cbSearch.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

             clsLoginData.RecrdsNum(dgvUsers,lblRecords);
        }
        private void _FilterUsers()
        {
            //if(cbFilter.Text == "User ID")
            //    dgvUsers.DataSource = clsUsers.FilterByUserID(int.Parse(txtSearch.Text));
            //if(cbFilter.Text == "_UserName")
            //    dgvUsers.DataSource = clsUsers.FilterByUserName(txtSearch.Text);
            //if(cbFilter.Text == "Person ID")
            //    dgvUsers.DataSource = clsUsers.FilterByPersonID(int.Parse(txtSearch.Text));
            //if(cbFilter.Text == "Full Name")
            //    dgvUsers.DataSource = clsUsers.FilterByFullName(txtSearch.Text);

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                clsLoginData.RecrdsNum(dgvUsers, lblRecords);
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            clsLoginData.RecrdsNum(dgvUsers, lblRecords);



        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _LoadUsers();
            }
            else
            {
                _FilterUsers();
            }
        }
    }
}
