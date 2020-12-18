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
    public partial class VIEW_SUBJECT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");

        public VIEW_SUBJECT()
        {
            InitializeComponent();
        }

        private void VIEW_SUBJECT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet1._class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.sCHOOLDataSet1._class);
            // TODO: This line of code loads data into the 'sCHOOLDataSet._class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.sCHOOLDataSet._class);
            this.ActiveControl = textBox2;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            cc();
            string q = "select s.sub_id 'Subject ID',s.sub_name 'Subject Name',c.name 'Class name',c.id'Class ID',a.Fname 'Admin Fname',a.Lname 'Admin Lname',d.DEPARTMENT_NAME from subjects s inner join class c on c.id=s.class_id inner join ADMINISTRATOR a on a.id=s.sub_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.sub_dep_id";
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
                comboBox3.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else if (!(textBox2.Text.All(c => Char.IsLetter(c))))
            {
                MessageBox.Show("PLEASE THE FIELD IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "UPDATE subjects SET sub_name='" + textBox2.Text + "',class_id=(select id from class where name='" + comboBox4.Text + "'),sub_admin_id=(select id from ADMINISTRATOR where Fname='" + comboBox1.Text + "'and Lname='" + comboBox2.Text + "'),sub_dep_id=(select DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME='" + comboBox3.Text + "') where sub_id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("SUBJECT UPDATED SUCCESSFULLY");
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
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string q = "select s.sub_id 'Subject ID',s.sub_name 'Subject Name',c.name 'Class name',c.id'Class ID',a.Fname 'Admin Fname',a.Lname 'Admin Lname',d.DEPARTMENT_NAME from subjects s inner join class c on c.id=s.class_id inner join ADMINISTRATOR a on a.id=s.sub_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.sub_dep_id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || comboBox5.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter All The Fields");
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "delete From subjects where sub_id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("SUBJECT DELETED SUCCESSFULLY");
                    rfrsh();
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        public void rfrsh()
        {
            try
            {
                con.Open();
                string q = "select s.sub_id 'Subject ID',s.sub_name 'Subject Name',c.name 'Class name',c.id'Class ID',a.Fname 'Admin Fname',a.Lname 'Admin Lname',d.DEPARTMENT_NAME from subjects s inner join class c on c.id=s.class_id inner join ADMINISTRATOR a on a.id=s.sub_admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=s.sub_dep_id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        }
    }
}
