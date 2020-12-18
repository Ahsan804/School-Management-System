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
    public partial class ADD_TEACHER : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_TEACHER()
        {
            InitializeComponent();
        }

        private void ADD_TEACHER_Load(object sender, EventArgs e)
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


            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(tea_id as int)),0)+1 From teacher", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
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
                    string q = "insert into teacher(tea_id,tea_Fname,tea_Lname,tea_gender,tea_phone,tea_address,tea_email,tea_age,tea_religion,tea_admin_id,tea_class_id,tea_sub_id,tea_date_of_employment,tea_dep_id) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "',(select id from ADMINISTRATOR where Fname='" + comboBox2.Text + "'and Lname='" + comboBox3.Text + "'),(select id from class where name='" + comboBox4.Text + "'),(select sub_id from subjects where sub_name='" + comboBox6.Text + "'),'" + dateTimePicker1.Value.ToString() + "',(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox8.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("TEACHER ADDED SUCCESSFULLY");
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void SEARCHID(string s)
        {
            con.Open();
            string Query = "select id from class where name LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox4.Text = dt.ToString();
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
        public void SEARCHSUBID(string s)
        {
            con.Open();
            string Query = "select sub_id from subjects where sub_name LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox6.Text = dt.ToString();
            con.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCHID(comboBox4.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox2.Text);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCHSUBID(comboBox6.Text);
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
