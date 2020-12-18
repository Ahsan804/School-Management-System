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
    public partial class ADD_TIMETABLE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");

        public ADD_TIMETABLE()
        {
            InitializeComponent();
        }

        private void ADD_TIMETABLE_Load(object sender, EventArgs e)
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(rou_id as int)),0)+1 From class_routine", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                textBox2.Text = dt.Rows[0][0].ToString();
                this.ActiveControl = dateTimePicker1;
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
        public void SEARCHID(string s)
        {
            con.Open();
            string Query = "select id from class where name LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.Text = dt.ToString();
            con.Close();
        }
        public void SEARCHSUBID(string s)
        {
            con.Open();
            string Query = "select sub_id from subjects where sub_name LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox3.Text = dt.ToString();
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCHID(comboBox1.Text);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCHSUBID(comboBox3.Text);
        }
        public void SEARCH(string s)
        {
            con.Open();
            string Query = "select tea_Lname from teacher where tea_Fname LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox5.Text = dt.ToString();
            con.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox5.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty || comboBox7.Text.Trim() == string.Empty || groupBox1.Text.Trim() == string.Empty)
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
                    string q = "insert into class_routine(rou_id,rou_day,class_id,sub_id,tea_id,slot,dep_id) values('" + textBox2.Text + "','" + dateTimePicker1.Value.ToString() + "',(select id from class where name='" + comboBox1.Text + "'),(select sub_id from subjects where sub_name='" + comboBox3.Text + "'),(select tea_id from teacher where tea_Fname='" + comboBox5.Text + "'and tea_Lname='" + comboBox6.Text + "'),'" + textBox1.Text + "',(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox7.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("TIME-TABLE ADDED SUCCESSFULLY");
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
            con.Open();
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
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Clear();
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
