using Habanero.DB;
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

namespace StudentManagementSystem.Records
{
    public partial class StudentrecordForm : Form
    {
         ConnectionClass cn = new ConnectionClass();
        public StudentrecordForm()
        {
            InitializeComponent();
            this.getTabele();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StudentrecordForm_Load(object sender, EventArgs e)
        {

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
                DataTable dt = new DataTable();
                cn.getDataAdaptor("select * from Addnewstudent").Fill(dt);
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void getTabele()
        {
            try
            {
                cn.openConnection();
                DataTable dt = new DataTable();
                cn.getDataAdaptor("select * from Addnewstudent").Fill(dt);                
                dataGridView1.DataSource = dt;
                cn.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
