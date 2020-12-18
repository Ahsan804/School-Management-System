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

namespace WindowsFormsApp1
{
    public partial class ADMIN_LOGIN : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KUGQ0KF\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADMIN_LOGIN()
        {
            InitializeComponent();
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
                    ADMIN_CONTROL_MENU aDMIN_CONTROL_MENU = new ADMIN_CONTROL_MENU();
                    this.Hide();
                    aDMIN_CONTROL_MENU.Show();
            }
            else
            {
                MessageBox.Show("CHECK YOUR USERNAME OR PASSWORD");
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

        private void ADMIN_LOGIN_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
        }
    }
}
