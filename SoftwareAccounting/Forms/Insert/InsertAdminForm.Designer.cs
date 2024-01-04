namespace SoftwareAccounting.Forms.Insert
{
    partial class InsertAdminForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Tel = new System.Windows.Forms.TextBox();
            this.tbx_Dol = new System.Windows.Forms.TextBox();
            this.tbx_Date = new System.Windows.Forms.TextBox();
            this.tbx_FullName = new System.Windows.Forms.TextBox();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_SecondName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_Name = new System.Windows.Forms.Label();
            this.tbx_Pass = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lb_info = new System.Windows.Forms.Label();
            this.cbx_Check = new System.Windows.Forms.CheckBox();
            this.cbx_isAdmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Login = new System.Windows.Forms.TextBox();
            this.btn_Decline = new System.Windows.Forms.Button();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Дата рождения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Отчество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия";
            // 
            // tbx_Tel
            // 
            this.tbx_Tel.Location = new System.Drawing.Point(124, 167);
            this.tbx_Tel.Name = "tbx_Tel";
            this.tbx_Tel.Size = new System.Drawing.Size(284, 22);
            this.tbx_Tel.TabIndex = 0;
            this.tbx_Tel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_Dol
            // 
            this.tbx_Dol.Location = new System.Drawing.Point(124, 139);
            this.tbx_Dol.Name = "tbx_Dol";
            this.tbx_Dol.Size = new System.Drawing.Size(284, 22);
            this.tbx_Dol.TabIndex = 0;
            this.tbx_Dol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_Date
            // 
            this.tbx_Date.Location = new System.Drawing.Point(124, 111);
            this.tbx_Date.Name = "tbx_Date";
            this.tbx_Date.Size = new System.Drawing.Size(284, 22);
            this.tbx_Date.TabIndex = 0;
            this.tbx_Date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_FullName
            // 
            this.tbx_FullName.Location = new System.Drawing.Point(124, 85);
            this.tbx_FullName.Name = "tbx_FullName";
            this.tbx_FullName.Size = new System.Drawing.Size(284, 22);
            this.tbx_FullName.TabIndex = 0;
            this.tbx_FullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_Name
            // 
            this.tbx_Name.Location = new System.Drawing.Point(124, 57);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(284, 22);
            this.tbx_Name.TabIndex = 0;
            this.tbx_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Телефон";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Должность";
            // 
            // tbx_SecondName
            // 
            this.tbx_SecondName.Location = new System.Drawing.Point(124, 29);
            this.tbx_SecondName.Name = "tbx_SecondName";
            this.tbx_SecondName.Size = new System.Drawing.Size(284, 22);
            this.tbx_SecondName.TabIndex = 0;
            this.tbx_SecondName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbx_Tel);
            this.groupBox3.Controls.Add(this.tbx_Dol);
            this.groupBox3.Controls.Add(this.tbx_Date);
            this.groupBox3.Controls.Add(this.tbx_FullName);
            this.groupBox3.Controls.Add(this.tbx_Name);
            this.groupBox3.Controls.Add(this.tbx_SecondName);
            this.groupBox3.Location = new System.Drawing.Point(535, 332);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 211);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск по сотрудникам";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_Name);
            this.groupBox2.Controls.Add(this.tbx_Pass);
            this.groupBox2.Controls.Add(this.btn_Add);
            this.groupBox2.Controls.Add(this.lb_info);
            this.groupBox2.Controls.Add(this.cbx_Check);
            this.groupBox2.Controls.Add(this.cbx_isAdmin);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbx_Login);
            this.groupBox2.Controls.Add(this.btn_Decline);
            this.groupBox2.Location = new System.Drawing.Point(8, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 212);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заполнение данных";
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Location = new System.Drawing.Point(9, 27);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(46, 16);
            this.lb_Name.TabIndex = 23;
            this.lb_Name.Text = "Логин";
            // 
            // tbx_Pass
            // 
            this.tbx_Pass.Location = new System.Drawing.Point(170, 52);
            this.tbx_Pass.MaxLength = 50;
            this.tbx_Pass.Name = "tbx_Pass";
            this.tbx_Pass.Size = new System.Drawing.Size(321, 22);
            this.tbx_Pass.TabIndex = 2;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Add.Location = new System.Drawing.Point(264, 163);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(117, 30);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "Добавить";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(9, 118);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(34, 16);
            this.lb_info.TabIndex = 22;
            this.lb_info.Text = "laaa";
            this.lb_info.Visible = false;
            // 
            // cbx_Check
            // 
            this.cbx_Check.AutoSize = true;
            this.cbx_Check.Location = new System.Drawing.Point(9, 137);
            this.cbx_Check.Name = "cbx_Check";
            this.cbx_Check.Size = new System.Drawing.Size(414, 20);
            this.cbx_Check.TabIndex = 4;
            this.cbx_Check.Text = "Не закрывать форму после успешного добавления записи";
            this.cbx_Check.UseVisualStyleBackColor = true;
            // 
            // cbx_isAdmin
            // 
            this.cbx_isAdmin.AutoSize = true;
            this.cbx_isAdmin.Location = new System.Drawing.Point(9, 80);
            this.cbx_isAdmin.Name = "cbx_isAdmin";
            this.cbx_isAdmin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbx_isAdmin.Size = new System.Drawing.Size(465, 20);
            this.cbx_isAdmin.TabIndex = 3;
            this.cbx_isAdmin.Text = "Будет ли пользователь обладать всеми правами администратора";
            this.cbx_isAdmin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Пароль";
            // 
            // tbx_Login
            // 
            this.tbx_Login.Location = new System.Drawing.Point(170, 24);
            this.tbx_Login.MaxLength = 30;
            this.tbx_Login.Name = "tbx_Login";
            this.tbx_Login.Size = new System.Drawing.Size(321, 22);
            this.tbx_Login.TabIndex = 1;
            // 
            // btn_Decline
            // 
            this.btn_Decline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Decline.Location = new System.Drawing.Point(387, 163);
            this.btn_Decline.Name = "btn_Decline";
            this.btn_Decline.Size = new System.Drawing.Size(104, 30);
            this.btn_Decline.TabIndex = 6;
            this.btn_Decline.Text = "Отмена";
            this.btn_Decline.UseVisualStyleBackColor = true;
            this.btn_Decline.Click += new System.EventHandler(this.btn_Decline_Click);
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(3, 18);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            this.dgv_Main.RowHeadersWidth = 51;
            this.dgv_Main.RowTemplate.Height = 24;
            this.dgv_Main.Size = new System.Drawing.Size(945, 296);
            this.dgv_Main.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Main);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 317);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Присвоение учётной записи пользователя к сотруднику";
            // 
            // InsertAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 551);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "InsertAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InsertAdminForm";
            this.Load += new System.EventHandler(this.InsertAdminForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Tel;
        private System.Windows.Forms.TextBox tbx_Dol;
        private System.Windows.Forms.TextBox tbx_Date;
        private System.Windows.Forms.TextBox tbx_FullName;
        private System.Windows.Forms.TextBox tbx_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_SecondName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.TextBox tbx_Pass;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.CheckBox cbx_Check;
        private System.Windows.Forms.CheckBox cbx_isAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Login;
        private System.Windows.Forms.Button btn_Decline;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}