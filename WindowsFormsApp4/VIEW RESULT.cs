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

    public partial class VIEW_RESULT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public VIEW_RESULT()
        {
            InitializeComponent();
        }

        private void VIEW_RESULT_Load(object sender, EventArgs e)
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
            this.ActiveControl = comboBox1;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            cc();
            string q = "select r.RES_id,c.name,c.id,s.std_Fname,s.std_Lname,m.tea_Fname,m.tea_Lname,r.RES_maths_marks,r.RES_english_marks,r.RES_urdu_marks,r.RES_islamiat_marks,r.RES_engLIT_marks,r.RES_Science_marks,r.RES_SST_marks,r.RES_activity_marks,r.RES_total_marks,r.RES_percentage,r.RES_grade,r.RES_REmarks,d.DEPARTMENT_NAME from result R inner join class c on c.id=R.RES_class_id inner join teacher m on m.tea_id=R.RES_tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=R.RES_dep_id inner join student s on s.std_id=R.RES_std_id";
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
                comboBox7.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            comboBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString().Trim();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString().Trim();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString().Trim();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString().Trim();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString().Trim();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString().Trim();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString().Trim();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString().Trim();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString().Trim();
            textBox12.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString().Trim();
            textBox13.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString().Trim();
            textBox14.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString().Trim();
            comboBox7.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString().Trim();
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
                    string q = "update result set RES_class_id=(select id from class where name='" + comboBox1.Text + "'),RES_std_id=(select std_id from student where std_Fname='" + comboBox3.Text + "'and std_Lname='" + comboBox4.Text + "'),RES_tea_id=(select tea_id from teacher where tea_Fname='" + comboBox5.Text + "'and tea_Lname='" + comboBox6.Text + "'),RES_maths_marks='" + textBox2.Text + "',RES_english_marks='" + textBox3.Text + "',RES_urdu_marks='" + textBox4.Text + "',RES_islamiat_marks='" + textBox5.Text + "',RES_engLIT_marks='" + textBox6.Text + "',RES_Science_marks='" + textBox7.Text + "',RES_SST_marks='" + textBox8.Text + "',RES_activity_marks='" + textBox9.Text + "',RES_total_marks='" + textBox10.Text + "',RES_percentage='" + textBox11.Text + "',RES_grade='" + textBox12.Text + "',RES_REmarks='" + textBox13.Text + "',RES_dep_id=(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox7.Text + "') where RES_id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("RESULT UPDATED SUCCESSFULLY");
                    rfrsh();
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string q = "select r.RES_id,c.name,c.id,s.std_Fname,s.std_Lname,m.tea_Fname,m.tea_Lname,r.RES_maths_marks,r.RES_english_marks,r.RES_urdu_marks,r.RES_islamiat_marks,r.RES_engLIT_marks,r.RES_Science_marks,r.RES_SST_marks,r.RES_activity_marks,r.RES_total_marks,r.RES_percentage,r.RES_grade,r.RES_REmarks,d.DEPARTMENT_NAME from result R inner join class c on c.id=R.RES_class_id inner join teacher m on m.tea_id=R.RES_tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=R.RES_dep_id inner join student s on s.std_id=R.RES_std_id";
            SqlDataAdapter SDA = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || textBox9.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || textBox11.Text.Trim() == string.Empty || textBox12.Text.Trim() == string.Empty || textBox13.Text.Trim() == string.Empty || textBox14.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty || comboBox7.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select The Row");
            }
            else
            {
                con.Open();
                string q = "delete from result where RES_id = '" + textBox1.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(q, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("RECORD HAS BEEN DELETED");
                rfrsh();
                clear();
            }
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

        public void rfrsh()
        {
            string q = "select r.RES_id,c.name,c.id,s.std_Fname,s.std_Lname,m.tea_Fname,m.tea_Lname,r.RES_maths_marks,r.RES_english_marks,r.RES_urdu_marks,r.RES_islamiat_marks,r.RES_engLIT_marks,r.RES_Science_marks,r.RES_SST_marks,r.RES_activity_marks,r.RES_total_marks,r.RES_percentage,r.RES_grade,r.RES_REmarks,d.DEPARTMENT_NAME from result R inner join class c on c.id=R.RES_class_id inner join teacher m on m.tea_id=R.RES_tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=R.RES_dep_id inner join student s on s.std_id=R.RES_std_id";
            SqlDataAdapter SDA = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "STUDENT ID")
            {
                string q = "select r.RES_id,c.name,c.id,s.std_Fname,s.std_Lname,m.tea_Fname,m.tea_Lname,r.RES_maths_marks,r.RES_english_marks,r.RES_urdu_marks,r.RES_islamiat_marks,r.RES_engLIT_marks,r.RES_Science_marks,r.RES_SST_marks,r.RES_activity_marks,r.RES_total_marks,r.RES_percentage,r.RES_grade,r.RES_REmarks,d.DEPARTMENT_NAME from result R inner join class c on c.id=R.RES_class_id inner join teacher m on m.tea_id=R.RES_tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=R.RES_dep_id inner join student s on s.std_id=R.RES_std_id where s.std_id LIKE '%" + textBox15.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox8.Text == "STUDENT FNAME")
            {
                string q = "select r.RES_id,c.name,c.id,s.std_Fname,s.std_Lname,m.tea_Fname,m.tea_Lname,r.RES_maths_marks,r.RES_english_marks,r.RES_urdu_marks,r.RES_islamiat_marks,r.RES_engLIT_marks,r.RES_Science_marks,r.RES_SST_marks,r.RES_activity_marks,r.RES_total_marks,r.RES_percentage,r.RES_grade,r.RES_REmarks,d.DEPARTMENT_NAME from result R inner join class c on c.id=R.RES_class_id inner join teacher m on m.tea_id=R.RES_tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=R.RES_dep_id inner join student s on s.std_id=R.RES_std_id where s.std_Fname LIKE '%" + textBox15.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox8.Text == "STUDENT DEPARTMENT")
            {
                string q = "select r.RES_id,c.name,c.id,s.std_Fname,s.std_Lname,m.tea_Fname,m.tea_Lname,r.RES_maths_marks,r.RES_english_marks,r.RES_urdu_marks,r.RES_islamiat_marks,r.RES_engLIT_marks,r.RES_Science_marks,r.RES_SST_marks,r.RES_activity_marks,r.RES_total_marks,r.RES_percentage,r.RES_grade,r.RES_REmarks,d.DEPARTMENT_NAME from result R inner join class c on c.id=R.RES_class_id inner join teacher m on m.tea_id=R.RES_tea_id inner join DEPARTMENT d on d.DEPARTMENT_ID=R.RES_dep_id inner join student s on s.std_id=R.RES_std_id where d.DEPARTMENT_NAME LIKE '%" + textBox15.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
