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

namespace StudentManagementSystem.Resultsheet
{
    public partial class ResultsheetForm : Form
    {
        
        public ResultsheetForm()
        {
            InitializeComponent();
        }
        ConnectionClass cn = new ConnectionClass();
       // MySqlCommand cmd = new MySqlCommand();
        private void txtEnrollnumber_TextChanged(object sender, EventArgs e)
        {
            
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
            if(Validation.textEmptyValidation(txtEnrollnumber.Text, "Enroll Number"))
            {
                try
                {
                    cn.openConnection();
                    DataTable dt = new DataTable();
                    cn.getDataAdaptor("SELECT * FROM `Results` WHERE enrollNumber=" + txtEnrollnumber.Text).Fill(dt);
                    dataGridView1.DataSource = dt;
                    cn.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
                         
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    

