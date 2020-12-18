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
    public partial class VIEW_CLASS : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public VIEW_CLASS()
        {
            InitializeComponent();
        }

        private void VIEW_CLASS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);
            this.ActiveControl = textBox2;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            cc();
            string q = "SELECT c.id,c.name,c.section,a.Fname,a.Lname,d.DEPARTMENT_NAME FROM class C inner join ADMINISTRATOR a on a.id=c.admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=c.class_DEP_id";
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT c.id,c.name,c.section,a.Fname,a.Lname,d.DEPARTMENT_NAME FROM class C inner join ADMINISTRATOR a on a.id=c.admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=c.class_DEP_id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
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
                    string q = "update class set name='" + textBox2.Text + "',section='" + textBox3.Text + "',admin_id=(select id from ADMINISTRATOR where Fname='" + comboBox1.Text + "' and Lname='" + comboBox2.Text + "'),class_DEP_id=(select DEPARTMENT_ID from DEPARTMENT where DEPARTMENT_NAME='" + comboBox3.Text + "') WHERE id= '" + textBox1.Text + "' ";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("INFORMATION UPDATED SUCCESSFULLY");
                    DRefresh();
                    clear();
                }
                catch (SqlException ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Trim() == string.Empty || textBox1.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Select the row");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete From class where id='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("INFORMATION IS SUCCESSFULLY DELETED!!");
                    DRefresh();
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
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
        }

        public void DRefresh()
        {
            try
            {
                string q = "SELECT c.id,c.name,c.section,a.Fname,a.Lname,d.DEPARTMENT_NAME FROM class C inner join ADMINISTRATOR a on a.id=c.admin_id inner join DEPARTMENT d on d.DEPARTMENT_ID=c.class_DEP_id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
