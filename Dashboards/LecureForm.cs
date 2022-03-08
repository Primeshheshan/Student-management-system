using StudentManagementSystem.Addnewresults;
using StudentManagementSystem.Records;
using StudentManagementSystem.Updateresult;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem.Dashboards
{
    public partial class LecureForm : Form
    {
        public LecureForm()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AddnewresultForm r = new AddnewresultForm();
            this.Hide();
            r.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LecureForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResultRecordForm re = new ResultRecordForm();
            this.Hide();
            re.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want To Log Out", "Log Out", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateresultForm st = new UpdateresultForm();
            this.Hide();
            st.Show();
            this.Close();
        }
    }
}
