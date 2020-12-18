using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WindowsFormsApp4
{
    public partial class ADD_ADMINISTRATOR : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_ADMINISTRATOR()
        {
            InitializeComponent();
        }

        private void ADD_ADMINISTRATOR_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS");
            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("PLEASE INSERT THE SAME PASSWORD");
            }
            else if (!((textBox1.Text.All(c => Char.IsLetter(c))) && (textBox2.Text.All(c => Char.IsLetter(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE NAME CONTAIN ONLY ALPHABETS");
            }
            else
            {
                try
                {
                    if (ValidatePassword(textBox5.Text.Trim()))
                    {
                        con.Open();
                        String Q = "insert into ADMINISTRATOR(Fname,Lname,PASSWORD_,USERNAME) VALUES ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox3.Text.Trim() + "')";
                        SqlDataAdapter sda = new SqlDataAdapter(Q, con);
                        sda.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("DATA HAS BEEN INSERTED");
                        clear();
                    }
                    else
                    {
                        textBox4.Clear(); textBox5.Clear();
                        MessageBox.Show(" Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException E)
                {
                    MessageBox.Show(E.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        public bool ValidatePassword(string password)
        {
            string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$";
            if (!string.IsNullOrEmpty(password))
            {
                if (!Regex.IsMatch(password, patternPassword))
                {
                    return false;
                }

            }
            return true;
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
