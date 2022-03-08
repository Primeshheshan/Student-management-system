using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace StudentManagementSystem
{
    class ConnectionClass
    {
        MySqlConnection con;
        MySqlCommand cmd;

        public ConnectionClass()
        {
            try
            {
                con = new MySqlConnection("server=localhost;user id=root;database=studentdb");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return con;
        }
        public void openConnection()
        {
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        public void closeConnection()
        {
            con.Close();
        }
        public void insertData(string query)
        {
            try
            {
                cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        public MySqlDataAdapter getDataAdaptor(string query)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            return da;
        }

    }

    

    public class Validation
    {

        public static bool textEmptyValidation(string textbox, string textboxName)
        {

            if (string.IsNullOrEmpty(textbox))
            {
                MessageBox.Show($"{textboxName} should not be empty", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        public static bool isCharValidation(string textbox, string textboxName)
        {
            if (textbox.Any(char.IsDigit))
            {
                MessageBox.Show($"Please Enter only Characters to {textboxName}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }
        public static bool isDigitValidation(string textbox, string textboxName)
        {
            if (!(textbox.Any(char.IsDigit)))
            {
                MessageBox.Show($"Please Enter only Digits to {textboxName}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }
        public static bool IsPhoneNumber(string number, string textboxName)
        {
            if (!(number.Any(char.IsDigit)) || string.IsNullOrEmpty(number) || number.Length != 10)
            {
                MessageBox.Show($"Please check the {textboxName}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        public static bool emailValidation(string mail)
        {
            if (!(Regex.IsMatch(mail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)))
            {
                MessageBox.Show($"Please check the E-mail", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        public static bool passwordValidation(string pwd)
        {
            if (pwd.Length <= 8)
            {
                MessageBox.Show("Password should be more than 8 Characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        public static bool nicValidation(string nic)
        {

            if (!((nic.Count(char.IsDigit) == 9) && (nic.EndsWith("X", StringComparison.OrdinalIgnoreCase)
      || nic.EndsWith("V", StringComparison.OrdinalIgnoreCase))
     ))
            {
                MessageBox.Show("Please check the nic No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }
    }

}