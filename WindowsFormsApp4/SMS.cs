using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuScrollBar.Transitions;
using WindowsFormsApp1;
using WindowsFormsApp4.Properties;

namespace WindowsFormsApp4
{
    public partial class SMS : Form
    {

        public SMS()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void hideSubMenu()
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;

        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD ADMINISTRATOR";
            openChildForm(new ADD_ADMINISTRATOR());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW ADMINISTRATOR";
            openChildForm(new VIEW_ADMINISTRATOR());
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(panel5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD DEPARTMENT";
            openChildForm(new ADD_DEPARTMENT());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW DEPARTMENT";
            openChildForm(new VIEW_DEPARTMENT());
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(panel6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD CLASS";
            openChildForm(new ADD_CLASS());
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW CLASS";
            openChildForm(new VIEW_CLASS());
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            showSubMenu(panel7);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD SUBJECT";
            openChildForm(new ADD_SUBJECT());
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW SUBJECT";
            openChildForm(new VIEW_SUBJECT());
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            showSubMenu(panel8);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD TEACHER";
            openChildForm(new ADD_TEACHER());
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW TEACHER";
            openChildForm(new VIEW_TEACHER());
            hideSubMenu();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            showSubMenu(panel9);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD EMPLOYEE";
            openChildForm(new ADD_EMPLOYEE());
            hideSubMenu();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW  EMPLOYEE";
            openChildForm(new VIEW_EMPLOYEE());
            hideSubMenu();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            showSubMenu(panel10);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD STUDENT";
            openChildForm(new ADD_STUDENT());
            hideSubMenu();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW STUDENT";
            openChildForm(new VIEW_STUDENT());
            hideSubMenu();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            showSubMenu(panel11);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD TIMETABELE";
            openChildForm(new ADD_TIMETABLE());
            hideSubMenu();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW TIMETABELE";
            openChildForm(new VIEW_TIMETABLE());
            hideSubMenu();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            showSubMenu(panel12);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            label1.Text = "ADD RESULT";
            openChildForm(new ADD_RESULT());
            hideSubMenu();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            label1.Text = "VIEW RESULT";
            openChildForm(new VIEW_RESULT());
            hideSubMenu();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            label1.Text = "MAKE PAYMENT";
            openChildForm(new PAYMENT());
            hideSubMenu();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void SMS_Load(object sender, EventArgs e)
        {

        }

        private void s_Click(object sender, EventArgs e)
        {

        }
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button1.Image = Resources.Collapse_Arrow_20px;
        //        panel2.Height += 10;
        //        if (panel2.Size == panel2.MaximumSize)
        //        {
        //            timer1.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button1.Image = Resources.Expand_Arrow_20px;
        //        panel2.Height -= 10;
        //        if (panel2.Size == panel2.MinimumSize)
        //        {
        //            timer1.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    timer1.Start();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_ADMINISTRATOR  form2 = new ADD_ADMINISTRATOR() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD ADMINISTRATOR";
        //    form2.Show();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_ADMINISTRATOR form2 = new VIEW_ADMINISTRATOR() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW ADMINISTRATOR";
        //    form2.Show();
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_DEPARTMENT  form2 = new ADD_DEPARTMENT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD DEPARTMENT";
        //    form2.Show();
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_DEPARTMENT form2 = new VIEW_DEPARTMENT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW DEPARTMENT";
        //    form2.Show();
        //}

        //private void button14_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_CLASS form2 = new ADD_CLASS() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD CLASS";
        //    form2.Show();
        //}

        //private void button13_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_CLASS form2 = new VIEW_CLASS() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW CLASS";
        //    form2.Show();
        //}

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_SUBJECT form2 = new ADD_SUBJECT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD SUBJECT";
        //    form2.Show();
        //}

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_SUBJECT form2 = new VIEW_SUBJECT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW SUBJECT";
        //    form2.Show();
        //}

        //private void button11_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_TEACHER form2 = new ADD_TEACHER() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD TEACHER";
        //    form2.Show();
        //}

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_TEACHER form2 = new VIEW_TEACHER() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW TEACHER";
        //    form2.Show();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    timer2.Start();
        //}

        //private void button15_Click(object sender, EventArgs e)
        //{
        //    timer5.Start();
        //}

        //private void button12_Click(object sender, EventArgs e)
        //{
        //    timer4.Start();
        //}

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    timer3.Start();
        //}

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button4.Image = Resources.Collapse_Arrow_20px;
        //        panel4.Height += 10;
        //        if (panel4.Size == panel4.MaximumSize)
        //        {
        //            timer2.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button4.Image = Resources.Expand_Arrow_20px;
        //        panel4.Height -= 10;
        //        if (panel4.Size == panel4.MinimumSize)
        //        {
        //            timer2.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void timer3_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button9.Image = Resources.Collapse_Arrow_20px;
        //        panel5.Height += 10;
        //        if (panel5.Size == panel5.MaximumSize)
        //        {
        //            timer3.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button9.Image = Resources.Expand_Arrow_20px;
        //        panel5.Height -= 10;
        //        if (panel5.Size == panel5.MinimumSize)
        //        {
        //            timer3.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void timer4_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button12.Image = Resources.Collapse_Arrow_20px;
        //        panel6.Height += 10;
        //        if (panel6.Size == panel6.MaximumSize)
        //        {
        //            timer4.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button12.Image = Resources.Expand_Arrow_20px;
        //        panel6.Height -= 10;
        //        if (panel6.Size == panel6.MinimumSize)
        //        {
        //            timer4.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void timer5_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button15.Image = Resources.Collapse_Arrow_20px;
        //        panel7.Height += 10;
        //        if (panel7.Size == panel7.MaximumSize)
        //        {
        //            timer5.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button15.Image = Resources.Expand_Arrow_20px;
        //        panel7.Height -= 10;
        //        if (panel7.Size == panel7.MinimumSize)
        //        {
        //            timer5.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}


        //private void button18_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_EMPLOYEE form2 = new ADD_EMPLOYEE() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD EMPLOYEE";
        //    form2.Show();
        //}

        //private void button19_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_EMPLOYEE form2 = new VIEW_EMPLOYEE() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW EMPLOYEE";
        //    form2.Show();
        //}

        //private void button17_Click(object sender, EventArgs e)
        //{
        //    timer6.Start();
        //}

        //private void timer6_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button17.Image = Resources.Collapse_Arrow_20px;
        //        panel8.Height += 10;
        //        if (panel8.Size == panel8.MaximumSize)
        //        {
        //            timer6.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button17.Image = Resources.Expand_Arrow_20px;
        //        panel8.Height -= 10;
        //        if (panel8.Size == panel8.MinimumSize)
        //        {
        //            timer6.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void button22_Click(object sender, EventArgs e)
        //{
        //    timer7.Start();
        //}

        //private void button21_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_STUDENT form2 = new ADD_STUDENT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD STUDENT";
        //    form2.Show();
        //}

        //private void button20_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_STUDENT form2 = new VIEW_STUDENT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW STUDENT";
        //    form2.Show();
        //}

        //private void button24_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_RESULT form2 = new ADD_RESULT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD RESULT";
        //    form2.Show();
        //}

        //private void button23_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_RESULT form2 = new VIEW_RESULT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW RESULT";
        //    form2.Show();
        //}

        //private void button27_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    ADD_TIMETABLE form2 = new ADD_TIMETABLE() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "ADD TIMETABLE";
        //    form2.Show();
        //}

        //private void timer7_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button22.Image = Resources.Collapse_Arrow_20px;
        //        panel9.Height += 10;
        //        if (panel9.Size == panel9.MaximumSize)
        //        {
        //            timer7.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button22.Image = Resources.Expand_Arrow_20px;
        //        panel9.Height -= 10;
        //        if (panel9.Size == panel9.MinimumSize)
        //        {
        //            timer7.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void timer8_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button25.Image = Resources.Collapse_Arrow_20px;
        //        panel10.Height += 10;
        //        if (panel10.Size == panel10.MaximumSize)
        //        {
        //            timer8.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button25.Image = Resources.Expand_Arrow_20px;
        //        panel10.Height -= 10;
        //        if (panel10.Size == panel10.MinimumSize)
        //        {
        //            timer8.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void button25_Click(object sender, EventArgs e)
        //{
        //    timer8.Start();
        //}

        //private void button28_Click(object sender, EventArgs e)
        //{
        //    timer9.Start();
        //}

        //private void timer9_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        button28.Image = Resources.Collapse_Arrow_20px;
        //        panel11.Height += 10;
        //        if (panel11.Size == panel11.MaximumSize)
        //        {
        //            timer9.Stop();
        //            isCollapsed = false;
        //        }
        //    }
        //    else
        //    {
        //        button28.Image = Resources.Expand_Arrow_20px;
        //        panel11.Height -= 10;
        //        if (panel11.Size == panel11.MinimumSize)
        //        {
        //            timer9.Stop();
        //            isCollapsed = true;
        //        }
        //    }
        //}

        //private void button26_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    VIEW_TIMETABLE form2 = new VIEW_TIMETABLE() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "VIEW TIMETABLE";
        //    form2.Show();
        //}

        //private void button31_Click(object sender, EventArgs e)
        //{
        //    this.panel3.Controls.Clear();
        //    PAYMENT form2 = new PAYMENT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    this.panel3.Controls.Add(form2);
        //    label1.Text = "PAYMENT";
        //    form2.Show();
        //}

        //private void Form3_Load(object sender, EventArgs e)
        //{
        //    metroPanel1.BackColor = Color.DarkSlateGray;
        //}

        //private void panel3_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
}
