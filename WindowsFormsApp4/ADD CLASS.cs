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
    public partial class ADD_CLASS : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_CLASS()
        {
            InitializeComponent();
        }

        private void ADD_CLASS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(id as int)),0)+1 From class", con);
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
                comboBox3.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == string.Empty || textBox1.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!((textBox2.Text.All(c => Char.IsDigit(c))) && (textBox3.Text.All(c => Char.IsLetter(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE CLASS NAME OR SECTION IN CORRECT FORM");
            }
            else
            {
                try
                {
                    con.Open();
                    String Q = "insert into class(id,name,section,admin_id,class_DEP_id)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',(select id from ADMINISTRATOR where Fname='" + comboBox1.Text + "'and Lname='" + comboBox2.Text + "'),(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox3.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(Q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("CLASS ADDED SUCCESSFULLY");
                    clear();
                }
                catch (SqlException ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox1.Text);
        }
        public void SEARCH(string s)
        {
            con.Open();
            string Query = "select Lname from ADMINISTRATOR where Fname LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.Text = dt.ToString();
            con.Close();
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }
    }
}
