using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StudentManagementSystem.Dashboards;

namespace StudentManagementSystem.Adduser
{
    public partial class AdduserForm : Form
    {
        ConnectionClass cn = new ConnectionClass();
        MySqlCommand cmd = new MySqlCommand();
        public AdduserForm()
        {
            InitializeComponent();
            getTable();
        }

        private void AdduserForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(Validation.textEmptyValidation(txtUsername.Text,"User Name") && Validation.textEmptyValidation(txtPassword.Text, "Password") && Validation.textEmptyValidation(cmbUsertype.Text, "User Type"))
            {
                try
                {
                    cn.openConnection();
                    cn.insertData("insert into LoginInformation values ('" + txtUsername.Text + "','" + cmbUsertype.Text + "','" + txtPassword.Text + "')");
                    cn.closeConnection();
                    MessageBox.Show("New User Added Successfully");
                    this.ClearAll();
                    this.getTable();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void ClearAll()
        {
            txtPassword.Clear();
            txtUsername.Clear();
            cmbUsertype.Text = "";
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want To Clear All", "Clear All", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.ClearAll();

            }
        }

        private void goToDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentcoordinatorForm s = new StudentcoordinatorForm();
            this.Hide();
            s.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                cn.openConnection();
                cmd = new MySqlCommand("SELECT * FROM LoginInformation WHERE userName = " + txtUsername.Text, cn.getConnection());
                //MessageBox.Show(cmd.ExecuteScalar().ToString());
                MySqlDataReader rd = cmd.ExecuteReader();
                

                while (rd.Read())
                {
                    txtPassword.Text = (rd["password"].ToString());
                    cmbUsertype.Text = (rd["userType"].ToString());

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.closeConnection();
        }

        public void getTable()
        {
            try
            {
                cn.openConnection();
                DataTable dt = new DataTable();
                cn.getDataAdaptor("select * from LoginInformation").Fill(dt);
                dataGridView1.DataSource = dt;
                cn.closeConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtUsername.Text = row.Cells["userName"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
                cmbUsertype.Text = row.Cells["userType"].Value.ToString();
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation.textEmptyValidation(txtUsername.Text, "User Name") && Validation.textEmptyValidation(txtPassword.Text, "Password") && Validation.textEmptyValidation(cmbUsertype.Text, "User Type"))
            {
                DialogResult result = MessageBox.Show("Are You Sure Want To Update Login Informations", "Login Infromation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cn.openConnection();
                        cmd = new MySqlCommand("update LoginInformation set password='" + txtPassword.Text + "', userType='" + cmbUsertype.Text + "'where userName='" + txtUsername.Text + "'", cn.getConnection());
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        this.ClearAll();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    cn.closeConnection();
                    this.getTable();

                }

            }
               
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want To Delete Login Informations", "Login Infromation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    cn.openConnection();
                    cmd = new MySqlCommand("DELETE FROM `LoginInformation` WHERE userName='" + txtUsername.Text + "'", cn.getConnection());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    this.ClearAll();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cn.closeConnection();
                this.getTable();
            }
             
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
