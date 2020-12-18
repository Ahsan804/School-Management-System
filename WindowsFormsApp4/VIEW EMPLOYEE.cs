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
using WindowsFormsApp4;

namespace WindowsFormsApp1
{
    public partial class VIEW_EMPLOYEE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public VIEW_EMPLOYEE()
        {
            InitializeComponent();
        }

        private void VIEW_EMPLOYEE_Load(object sender, EventArgs e)
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
            String Q = "select e.emp_ID,e.emp_FIRST_NAME,e.emp_LAST_NAME,e.emp_ADDRESS_,e.emp_AGE,e.emp_GENDER,e.emp_PHONE_NUMBER,e.emp_DATE_TIME_EMPLOYMENT,a.Fname,a.Lname,d.DEPARTMENT_NAME from employee e inner join ADMINISTRATOR a on a.id=e.emp_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=e.emp_dep_id";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            String Q = "select e.emp_ID,e.emp_FIRST_NAME,e.emp_LAST_NAME,e.emp_ADDRESS_,e.emp_AGE,e.emp_GENDER,e.emp_PHONE_NUMBER,e.emp_DATE_TIME_EMPLOYMENT,a.Fname,a.Lname,d.DEPARTMENT_NAME from employee e inner join ADMINISTRATOR a on a.id=e.emp_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=e.emp_dep_id";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!((textBox3.Text.All(c => Char.IsLetter(c))) && (textBox2.Text.All(c => Char.IsLetter(c))) && (textBox5.Text.All(c => Char.IsDigit(c))) && (textBox6.Text.All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE NAME OR AGE OR PHONE NUMBER IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "update employee set emp_FIRST_NAME='" + textBox2.Text + "',emp_LAST_NAME='" + textBox3.Text + "',emp_ADDRESS_='" + textBox4.Text + "',emp_AGE='" + textBox5.Text + "',emp_GENDER='" + comboBox1.Text + "',emp_PHONE_NUMBER='" + textBox6.Text + "',emp_DATE_TIME_EMPLOYMENT='" + dateTimePicker1.Value.ToString() + "',emp_admin_id=(select id from ADMINISTRATOR where Fname='" + comboBox2.Text + "'and Lname='" + comboBox3.Text + "'),emp_dep_id=(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox4.Text + "') where emp_ID='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("EMPLOYEE UPDATED SUCCESSFULLY");
                    rfsh();
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Please Select The Row");
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "DELETE from employee where emp_ID='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("EMPLOYEE DELETED SUCCESSFULLY");
                    rfsh();
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString().Trim();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString().Trim();
        }

        public void rfsh()
        {
            String Q = "select e.emp_ID,e.emp_FIRST_NAME,e.emp_LAST_NAME,e.emp_ADDRESS_,e.emp_AGE,e.emp_GENDER,e.emp_PHONE_NUMBER,e.emp_DATE_TIME_EMPLOYMENT,a.Fname,a.Lname,d.DEPARTMENT_NAME from employee e inner join ADMINISTRATOR a on a.id=e.emp_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=e.emp_dep_id";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
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
