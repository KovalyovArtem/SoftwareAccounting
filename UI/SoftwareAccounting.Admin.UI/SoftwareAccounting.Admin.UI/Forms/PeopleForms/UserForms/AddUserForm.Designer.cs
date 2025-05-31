namespace SoftwareAccounting.Admin.UI.Forms.PeopleForms
{
    partial class AddUserForm
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
            groupBox1 = new GroupBox();
            dgv_Employers = new DataGridView();
            groupBox2 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            cbx_IsWithoutSotr = new CheckBox();
            cbx_IsAfterNotClose = new CheckBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Employers).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_Employers);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 206);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Присвоение учётной записи пользователя к сотруднику";
            // 
            // dgv_Employers
            // 
            dgv_Employers.AllowUserToAddRows = false;
            dgv_Employers.AllowUserToDeleteRows = false;
            dgv_Employers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Employers.Dock = DockStyle.Fill;
            dgv_Employers.Location = new Point(3, 19);
            dgv_Employers.Name = "dgv_Employers";
            dgv_Employers.ReadOnly = true;
            dgv_Employers.Size = new Size(770, 184);
            dgv_Employers.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(cbx_IsWithoutSotr);
            groupBox2.Controls.Add(cbx_IsAfterNotClose);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(15, 236);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(380, 202);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Данные пользователя";
            // 
            // button2
            // 
            button2.Location = new Point(286, 173);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(205, 173);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            // 
            // cbx_IsWithoutSotr
            // 
            cbx_IsWithoutSotr.AutoSize = true;
            cbx_IsWithoutSotr.Location = new Point(10, 123);
            cbx_IsWithoutSotr.Name = "cbx_IsWithoutSotr";
            cbx_IsWithoutSotr.Size = new Size(189, 19);
            cbx_IsWithoutSotr.TabIndex = 3;
            cbx_IsWithoutSotr.Text = "Не привязывать к сотруднику";
            cbx_IsWithoutSotr.UseVisualStyleBackColor = true;
            // 
            // cbx_IsAfterNotClose
            // 
            cbx_IsAfterNotClose.AutoSize = true;
            cbx_IsAfterNotClose.Location = new Point(10, 148);
            cbx_IsAfterNotClose.Name = "cbx_IsAfterNotClose";
            cbx_IsAfterNotClose.Size = new Size(351, 19);
            cbx_IsAfterNotClose.TabIndex = 3;
            cbx_IsAfterNotClose.Text = "Не закрывать форму после успешного добавления записи";
            cbx_IsAfterNotClose.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(83, 61);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(205, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(83, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 64);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 1;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 35);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox8);
            groupBox3.Controls.Add(textBox7);
            groupBox3.Controls.Add(textBox6);
            groupBox3.Controls.Add(textBox5);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(413, 236);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(372, 202);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Поиск по сотрудникам";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(130, 170);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(236, 23);
            textBox8.TabIndex = 1;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(130, 141);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(236, 23);
            textBox7.TabIndex = 1;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(130, 112);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(236, 23);
            textBox6.TabIndex = 1;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(130, 83);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(236, 23);
            textBox5.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(130, 54);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(236, 23);
            textBox4.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(130, 25);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(236, 23);
            textBox3.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(22, 173);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 0;
            label8.Text = "Телефон";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 144);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 0;
            label7.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 115);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 0;
            label6.Text = "Дата рождения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 86);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 0;
            label5.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 57);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 0;
            label4.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 28);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 0;
            label3.Text = "Фамилия";
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление нового пользователя";
            Load += AddUserForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Employers).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgv_Employers;
        private GroupBox groupBox2;
        private Button button2;
        private Button button1;
        private CheckBox cbx_IsAfterNotClose;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private GroupBox groupBox3;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private CheckBox cbx_IsWithoutSotr;
    }
}