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
    public partial class VIEW_STUDENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public VIEW_STUDENT()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void VIEW_STUDENT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCHOOLDataSet1._class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.sCHOOLDataSet1._class);
            // TODO: This line of code loads data into the 'sCHOOLDataSet._class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.sCHOOLDataSet._class);
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            cc();
            string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID";
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
                comboBox6.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID";
            SqlDataAdapter SDA = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || textBox9.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || textBox11.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!((textBox2.Text.All(c => Char.IsLetter(c))) && (textBox3.Text.All(c => Char.IsLetter(c))) && (textBox4.Text.All(c => Char.IsLetter(c))) && (textBox5.Text.All(c => Char.IsLetter(c))) && (textBox9.Text.All(c => Char.IsLetter(c))) && (textBox11.Text.All(c => Char.IsLetter(c))) && (textBox6.Text.All(c => Char.IsDigit(c))) && (textBox10.Text.All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE THE FIELD IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "update student set  std_Fname='" + textBox2.Text + "',std_Lname='" + textBox3.Text + "',std_Fathername='" + textBox4.Text + "',std_Mothername='" + textBox5.Text + "',std_gender='" + comboBox1.Text + "',std_phone='" + textBox6.Text + "',std_address='" + textBox7.Text + "',std_email='" + textBox8.Text + "',std_nationality='" + textBox9.Text + "',std_dob='" + dateTimePicker1.Value.ToString() + "',std_age='" + textBox10.Text + "',std_religion='" + textBox11.Text + "',std_admin_id=(select id from ADMINISTRATOR where Fname='" + comboBox2.Text + "'and Lname='" + comboBox3.Text + "'),std_class_id=(select id from class where name='" + comboBox4.Text + "'),std_DEP_ID=(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox6.Text + "') where std_id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("STUDENT INFO UPDATED SUCCESSFULLY");
                    rfrsh();
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
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString().Trim();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString().Trim();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString().Trim();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString().Trim();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString().Trim();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString().Trim();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString().Trim();
            comboBox6.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString().Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || textBox9.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || textBox11.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select The Row");
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "DELETE from student where std_id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("STUDENT INFO DELETED SUCCESSFULLY");
                    rfrsh();
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "STUDENT ID")
            {
                string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID where s.std_id LIKE '%" + textBox12.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox7.Text == "STUDENT FNAME")
            {
                string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID where s.std_Fname LIKE '%" + textBox12.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox7.Text == "STUDENT DEPARTMENT")
            {
                string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID where d.DEPARTMENT_NAME LIKE '%" + textBox12.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        public void rfrsh()
        {
            string q = "select s.std_id,s.std_Fname,s.std_Lname,s.std_Fathername,s.std_Mothername,s.std_gender,s.std_phone,s.std_address,s.std_email,s.std_nationality,s.std_dob,s.std_age,s.std_religion,a.Fname,a.Lname,c.name,c.id,d.DEPARTMENT_NAME from student s inner join ADMINISTRATOR a on a.id=s.std_admin_id inner join class c on c.id=s.std_class_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.std_DEP_ID";
            SqlDataAdapter SDA = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
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
            textBox7.Text = "";
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
