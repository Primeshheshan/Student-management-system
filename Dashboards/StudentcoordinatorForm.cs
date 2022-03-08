using StudentManagementSystem.Addnewstudent;
using StudentManagementSystem.Adduser;
using StudentManagementSystem.Records;
using StudentManagementSystem.Updatestudent;
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
    public partial class StudentcoordinatorForm : Form
    {
        public StudentcoordinatorForm()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AddnewstudentForm newStudent = new AddnewstudentForm();
            this.Hide();
            newStudent.Show();
            this.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent();
            this.Hide();
            updateStudent.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentrecordForm studentrecord = new StudentrecordForm();
            this.Hide();
            studentrecord.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResultRecordForm resultRecord = new ResultRecordForm();
            this.Hide();
            resultRecord.Show();
            this.Close();
        }

        private void StudentcoordinatorForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want To Log Out", "Log Out", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AdduserForm ad = new AdduserForm();
            this.Hide();
            ad.Show();
            this.Close();
        }
    }
}
