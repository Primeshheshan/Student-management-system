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

namespace StudentManagementSystem.Login
{
    public partial class LoginForm : Form
    {
        ConnectionClass cn = new ConnectionClass();
        MySqlCommand cmd = new MySqlCommand();

        public LoginForm()
        {
            InitializeComponent();
        }
        public string userName;
        public string password;
        public string dbUsername;
        public string dbPassword;
        public string dbUsertype;

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Want To Clear All", "Clear All", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                txtPassword.Clear();
                txtUsername.Clear();
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userName = txtUsername.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = txtPassword.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            
            if(Validation.textEmptyValidation(txtUsername.Text,"User Name") && Validation.textEmptyValidation(txtPassword.Text, "Password"))
            {
                cn.openConnection();
                cmd = new MySqlCommand("SELECT * FROM LoginInformation WHERE password=" + password, cn.getConnection());
                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    dbUsername = (rd["userName"].ToString());
                    dbPassword = (rd["password"].ToString());
                    dbUsertype = (rd["userType"].ToString());
                }
                cn.closeConnection();
                if (userName == dbUsername && password == dbPassword)
                {
                    if (dbUsertype == "Student Coordinator")
                    {
                        StudentcoordinatorForm sc = new StudentcoordinatorForm();
                        sc.Show();
                        this.clearAll();
                    }
                    else if (dbUsertype == "Student")
                    {
                        StudentdashboardForm st = new StudentdashboardForm();
                        st.Show();
                        this.clearAll();
                    }
                    else if (dbUsertype == "Lecture")
                    {
                        LecureForm l = new LecureForm();
                        l.Show();
                        this.clearAll();
                    }


                }
                else
                {
                    MessageBox.Show("Username Password Incorrect, Please Try Again!", "Login Incorrect");
                    txtPassword.Clear();
                    txtUsername.Clear();
                }

            }
            else
            {
                MessageBox.Show("Username Password Incorrect, Please Try Again!", "Login Incorrect");
                txtPassword.Clear();
                txtUsername.Clear();
            }

        }

        public void clearAll()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
