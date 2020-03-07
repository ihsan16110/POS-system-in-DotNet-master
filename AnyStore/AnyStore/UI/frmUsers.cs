using AnyStore.BLL;
using AnyStore.DAL;
using AnyStore.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore
{
    public partial class txtpassword : Form
    {
        public txtpassword()
        {
            InitializeComponent();
        }

        userBLL u = new userBLL();
        userDAL dal = new userDAL();


        private void pictureBoxClose_Click_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string loggedUser = frmLogin.loggedIn;

            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.contact = txtContact.Text;
            u.password = txtpass.Text;
            u.address = txtAddress.Text;
            u.gender = cmbgender.Text;
            u.user_type = CmbUserType.Text;
            u.added_date = DateTime.Now;

            userBLL usr = dal.GetIDFromUsername(loggedUser);


            u.added_by = usr.id;

            bool success = dal.Insert(u);

            if(success=true)
            {
                MessageBox.Show("User Created");
                clear();
            }

            else
            {
                MessageBox.Show("User not Created");
            }

            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtUserID.Text);
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username =txtUsername.Text;
            u.password =txtpass.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender =cmbgender.Text;
            u.user_type = CmbUserType.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;

            bool success = dal.Update(u);

            if (success == true)
            {
                MessageBox.Show("USER SUCCESSFULLY UPDATED");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to update user");
            }
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;



        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void clear()
        {
            txtUserID.Text = "";
            txtUsername.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtpass.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmbgender.Text = "";
            CmbUserType.Text = "";
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtpass.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbgender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            CmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void UserName_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtUserID.Text);

            bool success = dal.Delete(u);

            if (success == true)
            {
                MessageBox.Show("User Deleted successfully");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete User");
            }

            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
