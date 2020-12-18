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
    public partial class ADD_EMPLOYEE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_EMPLOYEE()
        {
            InitializeComponent();
        }

        private void ADD_EMPLOYEE_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(emp_ID as int)),0)+1 From employee", con);
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
        public void cc()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID<=2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }
        public void SEARCH(string s)
        {
            con.Open();
            string Query = "select Lname from ADMINISTRATOR where Fname LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox2.Text = dt.ToString();
            con.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!((textBox3.Text.All(c => Char.IsLetter(c))) && (textBox2.Text.All(c => Char.IsLetter(c))) && (textBox5.Text.All(c => Char.IsDigit(c))) && (textBox6.Text.All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE NAME OR AGE OR PHONE NUMBER IN CORRECT FORM","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "insert into employee(emp_ID,emp_FIRST_NAME,emp_LAST_NAME,emp_ADDRESS_,emp_AGE,emp_GENDER,emp_PHONE_NUMBER,emp_DATE_TIME_EMPLOYMENT,emp_admin_id,emp_dep_id) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value.ToString() + "',(select id from ADMINISTRATOR where Fname='" + comboBox2.Text + "'and Lname='" + comboBox3.Text + "'),(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox4.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("EMPLOYEE ADDED SUCCESSFULLY");
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
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
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }
    }
}
