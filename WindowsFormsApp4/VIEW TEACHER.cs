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
    public partial class VIEW_TEACHER : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public VIEW_TEACHER()
        {
            InitializeComponent();
        }

        private void VIEW_TEACHER_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sUBJECT.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter1.Fill(this.sUBJECT.subjects);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.sCHOOLDataSet.subjects);
            // TODO: This line of code loads data into the 'sCHOOLDataSet1._class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.sCHOOLDataSet1._class);
            // TODO: This line of code loads data into the 'sCHOOLDataSet._class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.sCHOOLDataSet._class);
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);
            this.ActiveControl = textBox2;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            cc();
            string Q = "select t.tea_id,t.tea_Fname,t.tea_Lname,t.tea_gender,t.tea_phone,t.tea_address,t.tea_email,t.tea_age,t.tea_religion,a.Fname,a.Lname,c.name,c.id,s.sub_name,s.sub_id,t.tea_date_of_employment,d.DEPARTMENT_NAME from teacher t inner join class c on c.id=t.tea_class_id inner join ADMINISTRATOR a on a.id=t.tea_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=t.tea_dep_id inner join subjects s on s.sub_id=t.tea_sub_id";
            SqlDataAdapter SDA = new SqlDataAdapter(Q, con);
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
                comboBox8.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Q = "select t.tea_id,t.tea_Fname,t.tea_Lname,t.tea_gender,t.tea_phone,t.tea_address,t.tea_email,t.tea_age,t.tea_religion,a.Fname,a.Lname,c.name,c.id,s.sub_name,s.sub_id,t.tea_date_of_employment,d.DEPARTMENT_NAME from teacher t inner join class c on c.id=t.tea_class_id inner join ADMINISTRATOR a on a.id=t.tea_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=t.tea_dep_id inner join subjects s on s.sub_id=t.tea_sub_id";
            SqlDataAdapter SDA = new SqlDataAdapter(Q, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty || comboBox7.Text.Trim() == string.Empty || comboBox8.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!((textBox2.Text.All(c => Char.IsLetter(c))) && (textBox3.Text.All(c => Char.IsLetter(c))) && (textBox8.Text.All(c => Char.IsLetter(c))) && (textBox4.Text.All(c => Char.IsDigit(c))) && (textBox7.Text.All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE THE FIELD IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "update teacher set  tea_Fname='" + textBox2.Text + "',tea_Lname='" + textBox3.Text + "',tea_gender='" + comboBox1.Text + "',tea_phone='" + textBox4.Text + "',tea_address='" + textBox5.Text + "',tea_email='" + textBox6.Text + "',tea_age='" + textBox7.Text + "',tea_religion='" + textBox8.Text + "',tea_admin_id=(select id from ADMINISTRATOR where Fname='" + comboBox2.Text + "'and Lname='" + comboBox3.Text + "'),tea_class_id=(select id from class where name='" + comboBox4.Text + "'),tea_sub_id=(select sub_id from subjects where sub_name='" + comboBox6.Text + "'),tea_date_of_employment='" + dateTimePicker1.Value.ToString() + "',tea_dep_id=(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox8.Text + "') where tea_id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("TEACHER INFO UPDATED SUCCESSFULLY");
                    rfrsh();
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
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty || comboBox7.Text.Trim() == string.Empty || comboBox8.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "DELETE from teacher where tea_id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("TEACHER INFO DELETED SUCCESSFULLY");
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString().Trim();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString().Trim();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString().Trim();
            comboBox6.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString().Trim();
            comboBox7.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString().Trim();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString().Trim();
            comboBox8.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString().Trim();

        }

        public void rfrsh()
        {
            string Q = "select t.tea_id,t.tea_Fname,t.tea_Lname,t.tea_gender,t.tea_phone,t.tea_address,t.tea_email,t.tea_age,t.tea_religion,a.Fname,a.Lname,c.name,c.id,s.sub_name,s.sub_id,t.tea_date_of_employment,d.DEPARTMENT_NAME from teacher t inner join class c on c.id=t.tea_class_id inner join ADMINISTRATOR a on a.id=t.tea_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=t.tea_dep_id inner join subjects s on s.sub_id=t.tea_sub_id";
            SqlDataAdapter SDA = new SqlDataAdapter(Q, con);
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
        }
    }
}
