namespace WindowsFormsApp4
{
    partial class VIEW_SUBJECT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.classBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sCHOOLDataSet1 = new WindowsFormsApp4.SCHOOLDataSet1();
            this.classBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCHOOLDataSet = new WindowsFormsApp4.SCHOOLDataSet();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.aDMINISTRATORBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.aDMIN = new WindowsFormsApp4.ADMIN();
            this.aDMINISTRATORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.classTableAdapter = new WindowsFormsApp4.SCHOOLDataSetTableAdapters.classTableAdapter();
            this.classTableAdapter1 = new WindowsFormsApp4.SCHOOLDataSet1TableAdapters.classTableAdapter();
            this.aDMINISTRATORTableAdapter = new WindowsFormsApp4.SCHOOLDataSetTableAdapters.ADMINISTRATORTableAdapter();
            this.aDMINISTRATORTableAdapter1 = new WindowsFormsApp4.ADMINTableAdapters.ADMINISTRATORTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCHOOLDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCHOOLDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDMINISTRATORBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDMIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDMINISTRATORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(163, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "CLASS ID";
            // 
            // comboBox5
            // 
            this.comboBox5.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.classBindingSource1, "id", true));
            this.comboBox5.DataSource = this.classBindingSource;
            this.comboBox5.DisplayMember = "id";
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(323, 275);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(181, 25);
            this.comboBox5.TabIndex = 23;
            this.comboBox5.ValueMember = "id";
            // 
            // classBindingSource1
            // 
            this.classBindingSource1.DataMember = "class";
            this.classBindingSource1.DataSource = this.sCHOOLDataSet1;
            // 
            // sCHOOLDataSet1
            // 
            this.sCHOOLDataSet1.DataSetName = "SCHOOLDataSet1";
            this.sCHOOLDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // classBindingSource
            // 
            this.classBindingSource.DataMember = "class";
            this.classBindingSource.DataSource = this.sCHOOLDataSet;
            // 
            // sCHOOLDataSet
            // 
            this.sCHOOLDataSet.DataSetName = "SCHOOLDataSet";
            this.sCHOOLDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox4
            // 
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.classBindingSource1, "name", true));
            this.comboBox4.DataSource = this.classBindingSource;
            this.comboBox4.DisplayMember = "name";
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(323, 211);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(181, 25);
            this.comboBox4.TabIndex = 2;
            this.comboBox4.ValueMember = "name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(669, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "ADMIN LAST NAME";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(669, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "ADMIN FIRST NAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(669, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "DEPARTMENT NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(163, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "CLASS NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(163, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "SUBJECT NAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(163, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "SUBJECT ID";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(844, 211);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(181, 25);
            this.comboBox3.TabIndex = 6;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aDMINISTRATORBindingSource1, "Lname", true));
            this.comboBox2.DataSource = this.aDMINISTRATORBindingSource;
            this.comboBox2.DisplayMember = "Lname";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(844, 138);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(181, 25);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.ValueMember = "Lname";
            // 
            // aDMINISTRATORBindingSource1
            // 
            this.aDMINISTRATORBindingSource1.DataMember = "ADMINISTRATOR";
            this.aDMINISTRATORBindingSource1.DataSource = this.aDMIN;
            // 
            // aDMIN
            // 
            this.aDMIN.DataSetName = "ADMIN";
            this.aDMIN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aDMINISTRATORBindingSource
            // 
            this.aDMINISTRATORBindingSource.DataMember = "ADMINISTRATOR";
            this.aDMINISTRATORBindingSource.DataSource = this.sCHOOLDataSet;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aDMINISTRATORBindingSource1, "Fname", true));
            this.comboBox1.DataSource = this.aDMINISTRATORBindingSource;
            this.comboBox1.DisplayMember = "Fname";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(844, 70);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 25);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "Fname";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(323, 138);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(181, 23);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(160)))), ((int)(((byte)(138)))));
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(323, 70);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 23);
            this.textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(160)))), ((int)(((byte)(138)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 407);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1138, 313);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(718, 369);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "REFRESH";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(869, 369);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1021, 369);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 30);
            this.button3.TabIndex = 9;
            this.button3.Text = "DELETE";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // classTableAdapter
            // 
            this.classTableAdapter.ClearBeforeFill = true;
            // 
            // classTableAdapter1
            // 
            this.classTableAdapter1.ClearBeforeFill = true;
            // 
            // aDMINISTRATORTableAdapter
            // 
            this.aDMINISTRATORTableAdapter.ClearBeforeFill = true;
            // 
            // aDMINISTRATORTableAdapter1
            // 
            this.aDMINISTRATORTableAdapter1.ClearBeforeFill = true;
            // 
            // VIEW_SUBJECT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(160)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(1162, 733);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VIEW_SUBJECT";
            this.Text = "VIEW_SUBJECT";
            this.Load += new System.EventHandler(this.VIEW_SUBJECT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCHOOLDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCHOOLDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDMINISTRATORBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDMIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDMINISTRATORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private SCHOOLDataSet sCHOOLDataSet;
        private System.Windows.Forms.BindingSource classBindingSource;
        private SCHOOLDataSetTableAdapters.classTableAdapter classTableAdapter;
        private SCHOOLDataSet1 sCHOOLDataSet1;
        private System.Windows.Forms.BindingSource classBindingSource1;
        private SCHOOLDataSet1TableAdapters.classTableAdapter classTableAdapter1;
        private System.Windows.Forms.BindingSource aDMINISTRATORBindingSource;
        private SCHOOLDataSetTableAdapters.ADMINISTRATORTableAdapter aDMINISTRATORTableAdapter;
        private ADMIN aDMIN;
        private System.Windows.Forms.BindingSource aDMINISTRATORBindingSource1;
        private ADMINTableAdapters.ADMINISTRATORTableAdapter aDMINISTRATORTableAdapter1;
    }
}