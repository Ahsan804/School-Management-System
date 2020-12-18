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
    public partial class ADD_SUBJECT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public ADD_SUBJECT()
        {
            InitializeComponent();
        }

        private void ADD_SUBJECT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet1._class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.sCHOOLDataSet1._class);
            // TODO: This line of code loads data into the 'sCHOOLDataSet._class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.sCHOOLDataSet._class);

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox6.Text = "";
            cc();
            bind();
            bindc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(sub_id as int)),0)+1 From subjects", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox6.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!(textBox2.Text.All(c => Char.IsLetter(c))))
            {
                MessageBox.Show("PLEASE THE FIELD IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select c.name,c.section,d.DEPARTMENT_NAME from class c inner join DEPARTMENT d on d.DEPARTMENT_ID=c.class_DEP_id where c.name='" + comboBox4.Text + "'and c.section='" + comboBox6.Text + "' and d.DEPARTMENT_NAME='" + comboBox3.Text + "'", con);
                //DataTable dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);
                //if (dataTable.Rows.Count >= 1)
                //{
                //    MessageBox.Show("Not Exist");
                //}
                //else
                //{
                try
                {
                    con.Open();
                    string q = "insert into subjects(sub_id,sub_name,class_id,sub_admin_id,sub_dep_id) values('" + textBox1.Text + "','" + textBox2.Text + "',(select id from class where name LIKE '%" + comboBox4.Text + "%' and section like '%" + comboBox6.Text + "%'),(select id from ADMINISTRATOR where Fname='" + comboBox1.Text + "'and Lname='" + comboBox2.Text + "'),(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox3.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("SUBJECT ADDED SUCCESSFULLY");
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //}
        //public void SEARCHID(string s,string b)
        //{
        //    con.Open();
        //    string Query = "select id from class where name LIKE '%" + s + "%' and section like '%" + b + "%'";
        //    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    comboBox4.Text = dt.ToString();
        //    con.Close();
        //}
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox1.Text);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SEARCHID(comboBox4.Text,comboBox6.Text);
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
            comboBox6.Text = "";
        }

        void bind()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select distinct name from class";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr["name"].ToString());
            }
            con.Close();
        }
        void bindc()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select distinct section from class";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox6.Items.Add(dr["section"].ToString());
            }
            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //private void fillByToolStripButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.classTableAdapter1.FillBy(this.sCHOOLDataSet1._class);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}

        //private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.classTableAdapter1.FillBy(this.sCHOOLDataSet1._class);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}
    }
}
