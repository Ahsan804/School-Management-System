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


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "Select* From ADMINISTRATOR Where USERNAME='" + textBox1.Text.Trim() + "'and PASSWORD_='" + textBox2.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    SMS aDMIN_CONTROL_MENU = new SMS();
                    this.Hide();
                    aDMIN_CONTROL_MENU.Show();
                }
                else
                {
                    MessageBox.Show("CHECK YOUR USERNAME OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com/MUHAHSAN804");
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/ahankhn/");
        }
    }
}
