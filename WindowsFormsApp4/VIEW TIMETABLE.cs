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
    public partial class VIEW_TIMETABLE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");

        public VIEW_TIMETABLE()
        {
            InitializeComponent();
        }

        private void VIEW_TIMETABLE_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tEACHER.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter1.Fill(this.tEACHER.teacher);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.Fill(this.sCHOOLDataSet.teacher);
            // TODO: This line of code loads data into the 'sUBJECT.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter1.Fill(this.sUBJECT.subjects);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.sCHOOLDataSet.subjects);
            // TODO: This line of code loads data into the 'sCHOOLDataSet1._class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.sCHOOLDataSet1._class);
            // TODO: This line of code loads data into the 'sCHOOLDataSet._class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.sCHOOLDataSet._class);
            this.ActiveControl = dateTimePicker1;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            cc();
            string q = "select t.rou_id,t.rou_day,c.name,c.section,s.sub_name,s.sub_id,m.tea_Fname,m.tea_Lname,t.slot,d.DEPARTMENT_NAME from class_routine t inner join class c on c.id=t.class_id inner join subjects s on s.sub_id=t.sub_id inner join teacher m on m.tea_id=t.tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=t.dep_id";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
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
                comboBox7.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select t.rou_id,t.rou_day,c.name,c.section,s.sub_name,s.sub_id,m.tea_Fname,m.tea_Lname,t.slot,d.DEPARTMENT_NAME from class_routine t inner join class c on c.id=t.class_id inner join subjects s on s.sub_id=t.sub_id inner join teacher m on m.tea_id=t.tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=t.dep_id";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty || comboBox7.Text.Trim() == string.Empty || groupBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Click on insterted to insert time table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true))
            {
                MessageBox.Show("Please Assign Sections to the Teacher", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "update class_routine set rou_day='" + dateTimePicker1.Value.ToString() + "', class_id=(select id from class where name='" + comboBox1.Text + "'),sub_id=(select sub_id from subjects where sub_name='" + comboBox3.Text + "'),tea_id=(select tea_id from teacher where tea_Fname='" + comboBox5.Text + "'and tea_Lname='" + comboBox6.Text + "'),dep_id=(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox7.Text + "'),slot='" + textBox1.Text + "' where rou_id='" + textBox3.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("TIME-TABLE UPDATED SUCCESSFULLY");
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
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
            comboBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString().Trim();
            comboBox7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString().Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text += "1st Period" + Environment.NewLine + "";
            }
            if (checkBox2.Checked)
            {
                textBox1.Text += "2nd Period" + Environment.NewLine + "";
            }
            if (checkBox3.Checked)
            {
                textBox1.Text += "3rd Period" + Environment.NewLine + "";
            }
            if (checkBox4.Checked)
            {
                textBox1.Text += "4th Period" + Environment.NewLine + "";
            }
            if (checkBox5.Checked)
            {
                textBox1.Text += "5th Period" + Environment.NewLine + "";
            }
            if (checkBox6.Checked)
            {
                textBox1.Text += "6th Period" + Environment.NewLine + "";
            }
            if (checkBox7.Checked)
            {
                textBox1.Text += "7th Period" + Environment.NewLine + "";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string q = "delete from class_routine where rou_id='" + textBox3.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("TIME-TABLE DELETED SUCCESSFULLY");
                rfrsh();
                clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void rfrsh()
        {
            string q = "select t.rou_id,t.rou_day,c.name,c.section,s.sub_name,s.sub_id,m.tea_Fname,m.tea_Lname,t.slot,d.DEPARTMENT_NAME from class_routine t inner join class c on c.id=t.class_id inner join subjects s on s.sub_id=t.sub_id inner join teacher m on m.tea_id=t.tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=t.dep_id";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";

        }
    }
}
