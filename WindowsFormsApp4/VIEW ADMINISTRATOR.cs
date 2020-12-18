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
using System.Text.RegularExpressions;

namespace WindowsFormsApp4
{
    public partial class VIEW_ADMINISTRATOR : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=SCHOOL;Persist Security Info=True;User ID=sa;Password=KALILINUX");
        public VIEW_ADMINISTRATOR()
        {
            InitializeComponent();
        }

        private void VIEW_ADMINISTRATOR_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = "Select* From ADMINISTRATOR";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS");
            }
            else if (textBox7.Text != textBox5.Text)
            {
                MessageBox.Show("PLEASE INSERT THE SAME PASSWORD");
            }
            else if (!((textBox1.Text.All(c => Char.IsLetter(c))) && (textBox2.Text.All(c => Char.IsLetter(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE NAME CONTAIN ONLY ALPHABETS");
            }
            else
            {
                try
                {
                    if (ValidatePassword(textBox7.Text))
                    {
                        con.Open();
                        string Query = "Update ADMINISTRATOR set Fname='" + textBox1.Text.Trim() + "',Lname='" + textBox2.Text.Trim() + "',PASSWORD_='" + textBox5.Text.Trim() + "',USERNAME='" + textBox3.Text.Trim() + "' where id='" + textBox6.Text + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                        sda.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("INFORMATION SUCCESSFULLY UPDATED");
                        Drefresh();
                        clear();
                    }
                    else
                    {
                        textBox7.Clear(); textBox5.Clear();
                        MessageBox.Show(" Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "Select* From ADMINISTRATOR";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool ValidatePassword(string password)
        {
            string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$";
            if (!string.IsNullOrEmpty(password))
            {
                if (!Regex.IsMatch(password, patternPassword))
                {
                    return false;
                }

            }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void Drefresh()
        {
            try
            {
                string Query = "Select* From ADMINISTRATOR";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

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
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
