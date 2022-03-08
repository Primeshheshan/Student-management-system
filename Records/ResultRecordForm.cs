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

namespace StudentManagementSystem.Records
{
    public partial class ResultRecordForm : Form
    {
       
        ConnectionClass cn = new ConnectionClass();
        MySqlCommand cmd = new MySqlCommand();
        public ResultRecordForm()
        {
            InitializeComponent();
            this.getTable();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResultRecordForm_Load(object sender, EventArgs e)
        {

        }

        private void goToDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LecureForm s = new LecureForm();
            this.Hide();
            s.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                cn.openConnection();
                DataTable dt = new DataTable();
                cn.getDataAdaptor("select * from Results").Fill(dt);
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("batch like '%{0}%'", cmbBatch.Text);
                dataGridView1.DataSource = dv;
                cn.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
