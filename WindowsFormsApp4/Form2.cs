using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 1;
            if (panel2.Width>=399)
            {
                timer1.Stop();
                SMS form3 = new SMS();
                form3.Show();
                this.Hide();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        
        }
    }
}
