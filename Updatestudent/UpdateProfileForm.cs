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

namespace StudentManagementSystem.Updatestudent
{
    public partial class UpdateProfileForm : Form
    {
        public UpdateProfileForm()
        {
            InitializeComponent();
        }
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
        public string birthday;
        public string enrollNumber;
        


        ConnectionClass cn = new ConnectionClass();
        MySqlCommand cmd = new MySqlCommand();
        private void txtEnrollnumber_TextChanged(object sender, EventArgs e)
        {
            
                enrollNumber = txtEnrollnumber.Text;
           
        }

        private void txtFullname_TextChanged(object sender, EventArgs e)
        {
            fullName = txtFullname.Text;
        }

        private void txtNic_TextChanged(object sender, EventArgs e)
        {
            nic = txtNic.Text;
        }

        private void txtBirthday_ValueChanged(object sender, EventArgs e)
        {
            birthday = txtBirthday.Value.ToShortDateString();
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

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            userName = txtUsername.Text;
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            district = cmbDistrict.Text;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want To Clear All", "Clear All", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.clearAll();
            }
        }

        private void goToDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentdashboardForm st = new StudentdashboardForm();
            this.Hide();
            st.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                cn.openConnection();
                cmd = new MySqlCommand("SELECT * FROM Addnewstudent WHERE enrollNumber=" + enrollNumber, cn.getConnection());
                //MessageBox.Show(cmd.ExecuteScalar().ToString());
                MySqlDataReader rd = cmd.ExecuteReader();
                RadioButton rb = new RadioButton();

                while (rd.Read())
                {
                    txtFullname.Text = (rd["fullName"].ToString());
                    txtNic.Text = (rd["nic"].ToString());
                    txtBirthday.Text = (rd["birthday"].ToString());
                    txtAddress.Text = (rd["address"].ToString());
                    txtEmail.Text = (rd["email"].ToString());
                    txtMobile.Text = (rd["mobile"].ToString());
                    txtPMobile.Text = (rd["parentMobile"].ToString());
                    txtUsername.Text = (rd["username"].ToString());
                    cmbDistrict.Text = (rd["district"].ToString());
                    string checkGender = (rd["gender"].ToString());
                    
                    if ( checkGender == "Male")
                    {
                        rbMale.Checked = true;
                    }
                    else if( checkGender == "Female")
                    {
                        rbFemale.Checked = true;
                    }
                   
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.closeConnection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (Validation.textEmptyValidation(txtFullname.Text, "Full Name") && Validation.textEmptyValidation(txtNic.Text, "National Id") && Validation.textEmptyValidation(birthday, "Birthday") && 
                Validation.textEmptyValidation(txtAddress.Text,"Address") && Validation.textEmptyValidation(txtEmail.Text,"Email") && 
                Validation.textEmptyValidation(txtMobile.Text,"Mobile") && Validation.textEmptyValidation(txtPMobile.Text,"Parent Mobile") &&
                Validation.textEmptyValidation(gender, "Gender") && Validation.textEmptyValidation(txtUsername.Text, "User Name") && 
                Validation.textEmptyValidation(cmbDistrict.Text,"District") && Validation.IsPhoneNumber(txtMobile.Text,"Mobile Number") &&
                Validation.IsPhoneNumber(txtPMobile.Text, "Parent Mobile Number") && Validation.nicValidation(txtNic.Text))
            {
                DialogResult result = MessageBox.Show("Are You Sure Want To Update Profile Informations", "Profile Infromation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cn.openConnection();
                        cmd = new MySqlCommand("update Addnewstudent set fullname='" + txtFullname.Text + "', nic='" + nic + "', birthday= '" + birthday + "', address= '" + address + "', email= '" + email + "', mobile= '" + mobile + "', parentMobile= '" + parentMobile + "', gender= '" + gender + "', username= '" + userName + "', district= '" + district + "'where enrollNumber='" + txtEnrollnumber.Text + "'", cn.getConnection());
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        this.clearAll();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    cn.closeConnection();

                }

            }
            
        }

        public void clearAll()
        {
            txtFullname.Clear();
            txtNic.Text = "V";
            txtBirthday.Text = "";
            txtAddress.Clear();
            txtEmail.Clear();
            txtMobile.Clear();
            txtPMobile.Clear();
            txtUsername.Clear();
            cmbDistrict.Text = "";
            txtEnrollnumber.Clear();
            rbFemale.Checked = false;
            rbMale.Checked = false;
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

        private void txtEnrollnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
