using MySql.Data.MySqlClient;
using StudentManagementSystem.Dashboards;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace StudentManagementSystem.Addnewresults
{
    public partial class AddnewresultForm : Form
    {
        //user Inputs
        public string enrollNumber;
        public string subject;
        public string obtainMarks;
        public string fullMarks;
        public string batch;

        ConnectionClass cn = new ConnectionClass();
        MySqlCommand cmd = new MySqlCommand();
        

        public AddnewresultForm()
        {
            InitializeComponent();
            this.getTable();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEnrollnumber_TextChanged(object sender, EventArgs e)
        {            
            
                enrollNumber = txtEnrollnumber.Text;
                      
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject = cmbSubject.Text;            
        }

        private void txtObtainmarks_TextChanged(object sender, EventArgs e)
        {
            
            
               obtainMarks= txtObtainmarks.Text;
                      
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFullmarks_TextChanged(object sender, EventArgs e)
        {
            
                fullMarks = txtFullmarks.Text;
                     
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
            if (Validation.textEmptyValidation(subject, "Subject Combobox")  && Validation.textEmptyValidation(txtObtainmarks.Text,"Obtain Marks")  && Validation.textEmptyValidation(txtFullmarks.Text, "Ful Marks") &&
                Validation.textEmptyValidation(lblStudentname.Text,"Student Name") )
            {
                DialogResult result = MessageBox.Show("Are You Sure Want To Add Student", "Add Student", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cn.openConnection();
                        cn.insertData("insert into Results values ('" + enrollNumber + "','" + lblStudentname.Text + "','" + subject + "','" + lblBatch.Text + "','" + obtainMarks + "','" + fullMarks + "')");
                        cn.closeConnection();
                        MessageBox.Show("New Result Added Successfully", "Message");
                        this.ClearAll();
                        this.getTable();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

                  
            }         


        }

        private void lecureDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddnewresultForm_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lectureDashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LecureForm lec = new LecureForm();
            this.Hide();
            lec.Show();
            this.Close();
        }

        public void ClearAll()
        {
            txtEnrollnumber.Clear();
            cmbSubject.Text = "";
            lblStudentname.Text = "";
            txtObtainmarks.Clear();
            txtFullmarks.Clear();
            lblBatch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                cn.openConnection();
                cmd = new MySqlCommand("SELECT fullname,batch FROM Addnewstudent WHERE enrollNumber=" + enrollNumber, cn.getConnection());
                //MessageBox.Show(cmd.ExecuteScalar().ToString());
                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lblStudentname.Text = (rd["fullName"].ToString());
                    lblBatch.Text = (rd["batch"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.closeConnection();

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblStudentname_Click(object sender, EventArgs e)
        {

        }

        public void getTable()
        {
            try
            {
                cn.openConnection();
                DataTable dt = new DataTable();
                cn.getDataAdaptor("select * from Results").Fill(dt);
                dataGridView.DataSource = dt;
                cn.closeConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtEnrollnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(! Char.IsDigit(ch) && ch!= 8 && ch!=46)
            {
                e.Handled = true;
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

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
