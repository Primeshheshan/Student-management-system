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

namespace StudentManagementSystem.Updateresult
{
    public partial class UpdateresultForm : Form
    {
        public int enrollNumber;
        public string subject;
        public string obtainMarks;
        public string fullMarks;

        ConnectionClass cn = new ConnectionClass();
        MySqlCommand cmd = new MySqlCommand();
        public UpdateresultForm()
        {
            InitializeComponent();
            this.getTable();
        }

        private void txtEnrollnumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtObtainmarks_TextChanged(object sender, EventArgs e)
        {
            
                obtainMarks = txtObtainmarks.Text;
           
        }

        private void txtFullmarks_TextChanged(object sender, EventArgs e)
        {
           
                fullMarks = txtFullmarks.Text;
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                cn.openConnection();
                cmd = new MySqlCommand("update Results set obtainMarks= '" + obtainMarks + "', fullMarks='" + fullMarks +  "'where enrollNumber= '" + lblEnrollnumber.Text+ "' and subject= '" +lblSubject.Text+ "' ", cn.getConnection());
                cmd.ExecuteNonQuery();
                cmd.Dispose();               

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.closeConnection();
            this.getTable();
            this.clearAll();
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
            LecureForm l = new LecureForm();
            this.Hide();
            l.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    cn.openConnection();
            //    cmd = new MySqlCommand("SELECT * FROM Results WHERE enrollNumber=" + enrollNumber, cn.getConnection());
            //    //MessageBox.Show(cmd.ExecuteScalar().ToString());
            //    MySqlDataReader rd = cmd.ExecuteReader();               

            //    while (rd.Read())
            //    {
            //        lblStudentname.Text = (rd["fullName"].ToString());
            //        lblBatch.Text = (rd["batch"].ToString());
            //        cmbSubject.Text = (rd["subject"].ToString());
            //        txtObtainmarks.Text = (rd["obtainMarks"].ToString());
            //        txtFullmarks.Text = (rd["fullMarks"].ToString());
            //    }
            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //cn.closeConnection();

            

        }

        public void clearAll()
        {
            lblEnrollnumber.Text = "";
            lblBatch.Text = "";
            lblStudentname.Text = "";
            txtObtainmarks.Clear();
            txtFullmarks.Clear();
            lblSubject.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                lblEnrollnumber.Text = row.Cells["enrollNumber"].Value.ToString();
                lblStudentname.Text = row.Cells["fullName"].Value.ToString();
                lblSubject.Text = row.Cells["subject"].Value.ToString();
                lblBatch.Text = row.Cells["batch"].Value.ToString();
                txtObtainmarks.Text = row.Cells["obtainMarks"].Value.ToString();
                txtFullmarks.Text = row.Cells["fullMarks"].Value.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblBatch_Click(object sender, EventArgs e)
        {

        }

        public void getTable()
        {
            try
            {
                cn.openConnection();
                DataTable dt = new DataTable();
                cn.getDataAdaptor("select * from Results").Fill(dt);
                dataGridView1.DataSource = dt;
                cn.closeConnection();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblEnrollnumber_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want To Delete Result ", "Delete Result", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    cn.openConnection();
                    cmd = new MySqlCommand("delete from Results where enrollNumber= '" + lblEnrollnumber.Text + "' and subject= '" + lblSubject.Text + "' ", cn.getConnection());
                    cmd.ExecuteNonQuery();                    
                    cmd.Dispose();
                    
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cn.closeConnection();
                this.getTable();
                this.clearAll();
            }
        }

        private void txtObtainmarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtFullmarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
