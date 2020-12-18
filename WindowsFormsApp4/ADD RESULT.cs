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
    public partial class ADD_RESULT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_RESULT()
        {
            InitializeComponent();
        }

        private void ADD_RESULT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tEACHER.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter1.Fill(this.tEACHER.teacher);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.Fill(this.sCHOOLDataSet.teacher);
            // TODO: This line of code loads data into the 'sTUDENT.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.sTUDENT.student);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.sCHOOLDataSet.student);
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
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(RES_id as int)),0)+1 From result", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                textBox1.Text = dt.Rows[0][0].ToString();
                this.ActiveControl = comboBox1;
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
        public void stud(string s)
        {
            con.Open();
            string Query = "select std_Lname from student where std_Fname LIKE '%" + s + "%'";
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

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox5.Text);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            stud(comboBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float integr;
            bool isN = float.TryParse(textBox2.Text.Trim(), out integr);
            bool isN1 = float.TryParse(textBox3.Text.Trim(), out integr);
            bool isN2 = float.TryParse(textBox4.Text.Trim(), out integr);
            bool isN3 = float.TryParse(textBox5.Text.Trim(), out integr);
            bool isN4 = float.TryParse(textBox6.Text.Trim(), out integr);
            bool isN5 = float.TryParse(textBox7.Text.Trim(), out integr);
            bool isN6 = float.TryParse(textBox8.Text.Trim(), out integr);
            bool isN7 = float.TryParse(textBox9.Text.Trim(), out integr);
            bool isN8 = float.TryParse(textBox10.Text.Trim(), out integr);
            if (!((isN) && (isN1) && (isN2) && (isN3) && (isN4) && (isN5) && (isN6) && (isN7) && (isN8)))
            {
                MessageBox.Show("Please enter the marks in correct form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || textBox9.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty || comboBox7.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Enter All The Fields");
                }
                else
                {
                    float a, b, c, d, ei, f, g, h, k; float i, j;
                    a = float.Parse(textBox2.Text);
                    b = float.Parse(textBox3.Text);
                    c = float.Parse(textBox4.Text);
                    d = float.Parse(textBox5.Text);
                    ei = float.Parse(textBox6.Text);
                    f = float.Parse(textBox7.Text);
                    g = float.Parse(textBox8.Text);
                    h = float.Parse(textBox9.Text);
                    i = float.Parse(textBox10.Text);
                    k = (a + b + c + d + ei + f + g + h);
                    textBox14.Text = k.ToString();
                    j = ((a + b + c + d + ei + f + g + h) / i) * 100;
                    textBox11.Text = j + "%".ToString();
                    if (j >= 85)
                    {

                        textBox12.Text = "A-1  GRADE";
                    }
                    else if (j < 85 && j >= 75)
                    {
                        textBox12.Text = "A GRADE";
                    }
                    else if (j < 75 && j >= 65)
                    {
                        textBox12.Text = "B GRADE";
                    }
                    else if (j < 65 && j >= 55)
                    {
                        textBox12.Text = "C GRADE";
                    }
                    else if (j < 55 && j >= 45)
                    {
                        textBox12.Text = "D GRADE";
                    }
                    else
                    {
                        textBox12.Text = "FAILED";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float integr;
            bool isN = float.TryParse(textBox2.Text.Trim(), out integr);
            bool isN1 = float.TryParse(textBox3.Text.Trim(), out integr);
            bool isN2 = float.TryParse(textBox4.Text.Trim(), out integr);
            bool isN3 = float.TryParse(textBox5.Text.Trim(), out integr);
            bool isN4 = float.TryParse(textBox6.Text.Trim(), out integr);
            bool isN5 = float.TryParse(textBox7.Text.Trim(), out integr);
            bool isN6 = float.TryParse(textBox8.Text.Trim(), out integr);
            bool isN7 = float.TryParse(textBox9.Text.Trim(), out integr);
            bool isN8 = float.TryParse(textBox10.Text.Trim(), out integr);
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || textBox9.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || textBox11.Text.Trim() == string.Empty || textBox12.Text.Trim() == string.Empty || textBox13.Text.Trim() == string.Empty || textBox14.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty || comboBox7.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!((isN) && (isN1) && (isN2) && (isN3) && (isN4) && (isN5) && (isN6) && (isN7) && (isN8)))
            {
                MessageBox.Show("PLEASE INSERT THE NAME OR AGE OR PHONE NUMBER IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "insert into result(RES_id,RES_class_id,RES_std_id,RES_tea_id,RES_maths_marks,RES_english_marks,RES_urdu_marks,RES_islamiat_marks,RES_engLIT_marks,RES_Science_marks,RES_SST_marks,RES_activity_marks,RES_total_marks,RES_percentage,RES_grade,RES_REmarks,RES_dep_id) values('" + textBox1.Text + "',(select id from class where name='" + comboBox1.Text + "'),(select std_id from student where std_Fname='" + comboBox3.Text + "'and std_Lname='" + comboBox4.Text + "'),(select tea_id from teacher where tea_Fname='" + comboBox5.Text + "'and tea_Lname='" + comboBox6.Text + "'),'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "',(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox7.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("RESULT ADDED SUCCESSFULLY");
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
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
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
