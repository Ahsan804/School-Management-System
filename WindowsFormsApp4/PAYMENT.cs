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
    public partial class PAYMENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public PAYMENT()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void PAYMENT_Load(object sender, EventArgs e)
        {

            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(fees_reciept_no as int)),0)+1 From fees", con);
                DataTable DT = new DataTable();
                sda.Fill(DT);
                textBox1.Text = DT.Rows[0][0].ToString();
                this.ActiveControl = comboBox1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME,d.DEPARTMENTCHARGES from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID";
            SqlDataAdapter SDA = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void cc()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID>2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int integr;
            bool isNum = int.TryParse(textBox3.Text.Trim(), out integr);
            bool isN = int.TryParse(textBox4.Text.Trim(), out integr); bool isN1 = int.TryParse(textBox2.Text.Trim(), out integr);
            if (!isNum)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!isN)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!isN1)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Enter All The Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int A, B, C, d;
                    A = int.Parse(textBox2.Text);
                    B = int.Parse(textBox3.Text);
                    C = int.Parse(textBox4.Text);
                    d = A + B + C;
                    textBox5.Text = d.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "insert into fees(fees_reciept_no,fees_std_id,fees_dep_id,fees_payment) values('" + textBox1.Text + "',(select std_id from student where std_Fname='" + comboBox1.Text + "'and std_Lname='" + comboBox2.Text + "'),(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox3.Text + "'),'" + textBox5.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PAYMENT ADDED SUCCESSFULLY");
                    rfrsh();
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void SEARCHBYNAME(string s)
        {
            con.Open();

            con.Close();
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "STUDENT ID")
            {
                string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME,d.DEPARTMENTCHARGES from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID where s.std_id LIKE '%" + textBox7.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox4.Text == "STUDENT FNAME")
            {
                string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME,d.DEPARTMENTCHARGES from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID where s.std_Fname LIKE '%" + textBox7.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox4.Text == "STUDENT DEPARTMENT")
            {
                string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME,d.DEPARTMENTCHARGES from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID where d.DEPARTMENT_NAME LIKE '%" + textBox7.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        public void rfrsh()
        {
            string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME,d.DEPARTMENTCHARGES from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID";
            SqlDataAdapter SDA = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
