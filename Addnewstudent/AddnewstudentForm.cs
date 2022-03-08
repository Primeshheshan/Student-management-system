using StudentManagementSystem.Dashboards;
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


namespace StudentManagementSystem.Addnewstudent
{
    public partial class AddnewstudentForm : Form
    {
        // user Inputs
        public string fullName;
        public string nic;
        public string address;
        public string email;
        public string mobile;
        public string parentMobile;
        public string gender;
        public string district;
        public string userName;
        public string alStream;
        public string batch;
        public string course;
        public string birthday;
        public int enrollNumber;


        public AddnewstudentForm()
        {
            InitializeComponent();
            this.getMaxNumber();
            this.getTable();
        }
        ConnectionClass cn = new ConnectionClass();
        MySqlCommand cmd = new MySqlCommand();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFullname_TextChanged(object sender, EventArgs e)
        {
            fullName = txtFullname.Text;
        }

        private void txtNic_TextChanged(object sender, EventArgs e)
        {
            nic = txtNic.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            address = txtAddress.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {           
            email = txtEmail.Text;            
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            mobile = txtMobile.Text;
        }

        private void txtPMobile_TextChanged(object sender, EventArgs e)
        {
            parentMobile = txtPMobile.Text;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = rbMale.Checked;
            if (isChecked)
                gender = rbMale.Text;
            else
                gender = rbMale.Text;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = rbFemale.Checked;
            if (isChecked)
                gender = rbFemale.Text;
            else
                gender = rbFemale.Text;
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            district = cmbDistrict.Text;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            userName = txtUsername.Text;
        }

        private void cmbALStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            alStream = cmbALStream.Text;
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            batch = cmbBatch.Text;
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            course = cmbCourse.Text;
        }

        private void txtBirthday_ValueChanged(object sender, EventArgs e)
        {
            birthday = txtBirthday.Value.ToShortDateString();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {            
            DialogResult result = MessageBox.Show("Are You Sure Want To Clear All", "Clear All", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.ClearAll();
            }
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            

            if (Validation.textEmptyValidation(txtFullname.Text, "Full Name") && Validation.textEmptyValidation(txtNic.Text, "National Id") && Validation.textEmptyValidation(txtBirthday.Text, "Birthday") && 
                Validation.textEmptyValidation(txtAddress.Text, "Address") && Validation.textEmptyValidation(txtEmail.Text, "Email") &&
                Validation.textEmptyValidation(gender, "Gender") &&  Validation.textEmptyValidation(txtUsername.Text, "User Name") &&
                Validation.textEmptyValidation(cmbALStream.Text, "A/L Stream") && Validation.textEmptyValidation(cmbBatch.Text, "Batch") &&
                Validation.textEmptyValidation(cmbCourse.Text, "Course") && Validation.textEmptyValidation(cmbDistrict.Text, "District") && 
                Validation.textEmptyValidation(txtMobile.Text, "Mobile Number") && Validation.textEmptyValidation(txtPMobile.Text, "Parent Mobile Number") &&
                Validation.IsPhoneNumber(txtMobile.Text, "Mobile Number") && Validation.IsPhoneNumber(txtPMobile.Text, "Parent Mobile Number") && Validation.nicValidation(txtNic.Text))
            {
                DialogResult result = MessageBox.Show("Are You Sure Want To Add Student", "Add Student", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cn.openConnection();
                        cn.insertData("insert into Addnewstudent values ('" + lblEnrollnumber.Text + "','" + fullName + "','" + nic + "','" + birthday + "','" + address + "','" + email + "','" + mobile + "','" + parentMobile + "','" + gender + "','" + userName + "','" + cmbALStream.Text + "','" + cmbBatch.Text + "','" + cmbCourse.Text + "','" + cmbDistrict.Text + "')");
                        cn.closeConnection();
                        MessageBox.Show("New Student Added Successfully", "Message");
                       
                        cn.openConnection();
                        cn.insertData("insert into LoginInformation values ('" + txtUsername.Text + "','" + "Student" + "','" + int.Parse(lblEnrollnumber.Text) +  "')");
                        cn.closeConnection();

                        this.ClearAll();
                        this.getMaxNumber();
                        this.getTable();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
        }
       

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goToDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentcoordinatorForm s = new StudentcoordinatorForm();
            this.Hide();
            s.Show();
            this.Close();
        }
        public void ClearAll()
        {
            txtFullname.Clear();
            txtNic.Text = "V";
            txtBirthday.Text = "";
            txtAddress.Clear();
            txtEmail.Clear();
            txtMobile.Clear();
            txtPMobile.Clear();
            txtUsername.Clear();
            cmbALStream.Text = "";
            cmbBatch.Text = "";
            cmbCourse.Text = "";
            cmbDistrict.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
        }

        private void lblEnrollnumber_Click(object sender, EventArgs e)
        {
            
        }

        public void getMaxNumber()
        {
            int tot, max = 1;
            cn.openConnection();
            cmd = new MySqlCommand("select max(enrollNumber) from Addnewstudent", cn.getConnection());
            //MessageBox.Show(cmd.ExecuteScalar().ToString());
            string getValue = cmd.ExecuteScalar().ToString();                 

            if (getValue == "")
            {
                lblEnrollnumber.Text = max.ToString();
            }
            else
            {
                max = int.Parse(getValue);
                tot = max + 1;
                lblEnrollnumber.Text = tot.ToString();
            }            
            cn.closeConnection();
        }

        public void getTable()
        {
            try
            {
                cn.openConnection();
                DataTable dt = new DataTable();
                cn.getDataAdaptor("select * from Addnewstudent").Fill(dt);
                dataGridView1.DataSource = dt;
                cn.closeConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtPMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
