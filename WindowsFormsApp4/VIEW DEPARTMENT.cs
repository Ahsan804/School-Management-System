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
    public partial class VIEW_DEPARTMENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public VIEW_DEPARTMENT()
        {
            InitializeComponent();
        }

        private void VIEW_DEPARTMENT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMIN.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter1.Fill(this.aDMIN.ADMINISTRATOR);
            // TODO: This line of code loads data into the 'sCHOOLDataSet.ADMINISTRATOR' table. You can move, or remove it, as needed.
            this.aDMINISTRATORTableAdapter.Fill(this.sCHOOLDataSet.ADMINISTRATOR);
            this.ActiveControl = textBox2;
            comboBox1.Text = "";
            comboBox2.Text = "";
            string q = "SELECT D.DEPARTMENT_ID,D.DEPARTMENT_NAME,A.Fname,A.Lname,D.DEPARTMENTCHARGES FROM DEPARTMENT D INNER JOIN ADMINISTRATOR A ON A.id=D.DEP_admin_id";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string q = "SELECT D.DEPARTMENT_ID,D.DEPARTMENT_NAME,A.Fname,A.Lname,D.DEPARTMENTCHARGES FROM DEPARTMENT D INNER JOIN ADMINISTRATOR A ON A.id=D.DEP_admin_id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS");
            }
            else if (!((textBox4.Text.All(c => Char.IsDigit(c))) && (textBox2.Text.All(c => Char.IsLetter(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE CHARGES OR DEPARTMENT NAME IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string q = "update DEPARTMENT SET DEPARTMENT_NAME='" + textBox2.Text + "',DEPARTMENTCHARGES='" + textBox4.Text + "',DEP_admin_id=(select id from ADMINISTRATOR where Fname='" + comboBox1.Text + "' and Lname='" + comboBox2.Text + "')where DEPARTMENT_ID='" + textBox1.Text + "'";
                    SqlDataAdapter SDA = new SqlDataAdapter(q, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("DEPARTMENT INFORMATION UPDATED SUCCESSFULLY");
                    DRefresh();
                    clear();
                }
                catch (SqlException ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void DRefresh()
        {
            try
            {
                con.Open();
                string q = "SELECT D.DEPARTMENT_ID,D.DEPARTMENT_NAME,A.Fname,A.Lname,D.DEPARTMENTCHARGES FROM DEPARTMENT D INNER JOIN ADMINISTRATOR A ON A.id=D.DEP_admin_id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }
}
