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
    public partial class ADD_STUDENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_STUDENT()
        {
            InitializeComponent();
        }

        private void ADD_STUDENT_Load(object sender, EventArgs e)
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
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(std_id as int)),0)+1 From student", con);
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
                comboBox6.Items.Add(dr["DEPARTMENT_NAME"].ToString());
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

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCHID(comboBox4.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || textBox9.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || textBox11.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!((textBox2.Text.All(c => Char.IsLetter(c))) && (textBox3.Text.All(c => Char.IsLetter(c))) && (textBox4.Text.All(c => Char.IsLetter(c)))&& (textBox5.Text.All(c => Char.IsLetter(c)))&& (textBox9.Text.All(c => Char.IsLetter(c)))&& (textBox11.Text.All(c => Char.IsLetter(c)))&& (textBox6.Text.All(c => Char.IsDigit(c)))&& (textBox10.Text.All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE THE FIELD IN CORRECT FORM","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "insert into student(std_id,std_Fname,std_Lname,std_Fathername,std_Mothername,std_gender,std_phone,std_address,std_email,std_nationality,std_dob,std_age,std_religion,std_admin_id,std_class_id,std_DEP_ID) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox10.Text + "','" + textBox11.Text + "',(select id from ADMINISTRATOR where Fname='" + comboBox2.Text + "'and Lname='" + comboBox3.Text + "'),(select id from class where name='" + comboBox4.Text + "'),(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox6.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("STUDENT ADDED SUCCESSFULLY");
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
    }
}
