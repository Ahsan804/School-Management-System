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
    public partial class ADD_DEPARTMENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_DEPARTMENT()
        {
            InitializeComponent();
        }

        private void ADD_DEPARTMENT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);

            this.ActiveControl = textBox2;
            comboBox1.Text = "";
            comboBox2.Text = "";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(DEPARTMENT_ID as int)),0)+1 From DEPARTMENT", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                textBox1.Text = dt.Rows[0][0].ToString();
                this.ActiveControl = textBox2;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void SEARCH(string s)
        {
            con.Open();
            string Query = "select Lname from ADMINISTRATOR where Fname LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.Text = dt.ToString();
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS");
            }
            else if (!((textBox4.Text.All(c => Char.IsDigit(c))) && (textBox2.Text.All(c => Char.IsLetter(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE DEPART NAME OR CHARGES IN CORRECT FORM");
            }
            else
            {
                try
                {
                    con.Open();
                    string Q = "INSERT INTO DEPARTMENT(DEPARTMENT_ID,DEPARTMENT_NAME,DEP_admin_id,DEPARTMENTCHARGES) VALUES('" + textBox1.Text + "','" + textBox2.Text + "',(select id from ADMINISTRATOR where Fname='" + comboBox1.Text + "'and Lname='" + comboBox2.Text + "'),'" + textBox4.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(Q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("DATA INSERTED SUCCESSFULLY");
                    clear();
                }
                catch (SqlException eA)
                {
                    MessageBox.Show(eA.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }
}
