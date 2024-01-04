namespace SoftwareAccounting.Forms.Insert
{
    partial class InsertPeopleForm
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
            this.tbx_Number = new System.Windows.Forms.MaskedTextBox();
            this.tbx_Seria = new System.Windows.Forms.MaskedTextBox();
            this.tbx_KodPodrazd = new System.Windows.Forms.MaskedTextBox();
            this.dtp_DateGive = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_KemVidan = new System.Windows.Forms.TextBox();
            this.tbx_INN = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_Telephone = new System.Windows.Forms.MaskedTextBox();
            this.dtp_BirthDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_DolzhnostName = new System.Windows.Forms.ComboBox();
            this.tbx_FullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_SecondName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.btn_Decline = new System.Windows.Forms.Button();
            this.cbx_Check = new System.Windows.Forms.CheckBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_Number
            // 
            this.tbx_Number.Location = new System.Drawing.Point(149, 91);
            this.tbx_Number.Mask = "000000";
            this.tbx_Number.Name = "tbx_Number";
            this.tbx_Number.Size = new System.Drawing.Size(286, 22);
            this.tbx_Number.TabIndex = 11;
            // 
            // tbx_Seria
            // 
            this.tbx_Seria.Location = new System.Drawing.Point(149, 63);
            this.tbx_Seria.Mask = "0000";
            this.tbx_Seria.Name = "tbx_Seria";
            this.tbx_Seria.Size = new System.Drawing.Size(286, 22);
            this.tbx_Seria.TabIndex = 10;
            // 
            // tbx_KodPodrazd
            // 
            this.tbx_KodPodrazd.Location = new System.Drawing.Point(149, 177);
            this.tbx_KodPodrazd.Mask = "000-000";
            this.tbx_KodPodrazd.Name = "tbx_KodPodrazd";
            this.tbx_KodPodrazd.Size = new System.Drawing.Size(286, 22);
            this.tbx_KodPodrazd.TabIndex = 14;
            // 
            // dtp_DateGive
            // 
            this.dtp_DateGive.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateGive.Location = new System.Drawing.Point(149, 148);
            this.dtp_DateGive.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.dtp_DateGive.Name = "dtp_DateGive";
            this.dtp_DateGive.Size = new System.Drawing.Size(286, 22);
            this.dtp_DateGive.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 16);
            this.label12.TabIndex = 37;
            this.label12.Text = "Дата выдачи";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Код подразделения";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 16);
            this.label11.TabIndex = 34;
            this.label11.Text = "Кем выдан";
            // 
            // tbx_KemVidan
            // 
            this.tbx_KemVidan.Location = new System.Drawing.Point(149, 119);
            this.tbx_KemVidan.MaxLength = 50;
            this.tbx_KemVidan.Name = "tbx_KemVidan";
            this.tbx_KemVidan.Size = new System.Drawing.Size(286, 22);
            this.tbx_KemVidan.TabIndex = 12;
            // 
            // tbx_INN
            // 
            this.tbx_INN.Location = new System.Drawing.Point(149, 35);
            this.tbx_INN.Mask = "0000000000";
            this.tbx_INN.Name = "tbx_INN";
            this.tbx_INN.Size = new System.Drawing.Size(286, 22);
            this.tbx_INN.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Номер";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "ИНН";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Серия";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_Telephone);
            this.groupBox1.Controls.Add(this.dtp_BirthDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbx_DolzhnostName);
            this.groupBox1.Controls.Add(this.tbx_FullName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_SecondName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbx_Name);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 219);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Регистрация пользователя";
            // 
            // tbx_Telephone
            // 
            this.tbx_Telephone.Location = new System.Drawing.Point(166, 150);
            this.tbx_Telephone.Mask = "+7(000)-000-0000";
            this.tbx_Telephone.Name = "tbx_Telephone";
            this.tbx_Telephone.Size = new System.Drawing.Size(268, 22);
            this.tbx_Telephone.TabIndex = 5;
            // 
            // dtp_BirthDate
            // 
            this.dtp_BirthDate.CustomFormat = "";
            this.dtp_BirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_BirthDate.Location = new System.Drawing.Point(166, 177);
            this.dtp_BirthDate.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.dtp_BirthDate.Name = "dtp_BirthDate";
            this.dtp_BirthDate.Size = new System.Drawing.Size(268, 22);
            this.dtp_BirthDate.TabIndex = 6;
            this.dtp_BirthDate.Value = new System.DateTime(2023, 10, 5, 20, 28, 37, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Дата рождения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Телефон";
            // 
            // cbx_DolzhnostName
            // 
            this.cbx_DolzhnostName.DisplayMember = "DolzhnostName";
            this.cbx_DolzhnostName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DolzhnostName.FormattingEnabled = true;
            this.cbx_DolzhnostName.Location = new System.Drawing.Point(166, 35);
            this.cbx_DolzhnostName.Name = "cbx_DolzhnostName";
            this.cbx_DolzhnostName.Size = new System.Drawing.Size(268, 24);
            this.cbx_DolzhnostName.TabIndex = 1;
            this.cbx_DolzhnostName.ValueMember = "DolzhnostID";
            // 
            // tbx_FullName
            // 
            this.tbx_FullName.Location = new System.Drawing.Point(166, 121);
            this.tbx_FullName.MaxLength = 50;
            this.tbx_FullName.Name = "tbx_FullName";
            this.tbx_FullName.Size = new System.Drawing.Size(268, 22);
            this.tbx_FullName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Название должности";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Отчество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Фамилия";
            // 
            // tbx_SecondName
            // 
            this.tbx_SecondName.Location = new System.Drawing.Point(166, 65);
            this.tbx_SecondName.MaxLength = 50;
            this.tbx_SecondName.Name = "tbx_SecondName";
            this.tbx_SecondName.Size = new System.Drawing.Size(268, 22);
            this.tbx_SecondName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Имя";
            // 
            // tbx_Name
            // 
            this.tbx_Name.Location = new System.Drawing.Point(166, 93);
            this.tbx_Name.MaxLength = 50;
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(268, 22);
            this.tbx_Name.TabIndex = 3;
            // 
            // btn_Decline
            // 
            this.btn_Decline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Decline.Location = new System.Drawing.Point(817, 246);
            this.btn_Decline.Name = "btn_Decline";
            this.btn_Decline.Size = new System.Drawing.Size(104, 30);
            this.btn_Decline.TabIndex = 29;
            this.btn_Decline.Text = "Отмена";
            this.btn_Decline.UseVisualStyleBackColor = true;
            this.btn_Decline.Click += new System.EventHandler(this.btn_Decline_Click);
            // 
            // cbx_Check
            // 
            this.cbx_Check.AutoSize = true;
            this.cbx_Check.Location = new System.Drawing.Point(12, 253);
            this.cbx_Check.Name = "cbx_Check";
            this.cbx_Check.Size = new System.Drawing.Size(414, 20);
            this.cbx_Check.TabIndex = 27;
            this.cbx_Check.Text = "Не закрывать форму после успешного добавления записи";
            this.cbx_Check.UseVisualStyleBackColor = true;
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(13, 234);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(34, 16);
            this.lb_info.TabIndex = 30;
            this.lb_info.Text = "laaa";
            this.lb_info.Visible = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Add.Location = new System.Drawing.Point(694, 246);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(117, 30);
            this.btn_Add.TabIndex = 28;
            this.btn_Add.Text = "Добавить";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbx_Number);
            this.groupBox2.Controls.Add(this.tbx_Seria);
            this.groupBox2.Controls.Add(this.tbx_KodPodrazd);
            this.groupBox2.Controls.Add(this.dtp_DateGive);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbx_KemVidan);
            this.groupBox2.Controls.Add(this.tbx_INN);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(468, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 219);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительные данные";
            // 
            // InsertPeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 289);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Decline);
            this.Controls.Add(this.cbx_Check);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsertPeopleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление сотрудника";
            this.Load += new System.EventHandler(this.InsertPeopleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbx_Number;
        private System.Windows.Forms.MaskedTextBox tbx_Seria;
        private System.Windows.Forms.MaskedTextBox tbx_KodPodrazd;
        private System.Windows.Forms.DateTimePicker dtp_DateGive;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbx_KemVidan;
        private System.Windows.Forms.MaskedTextBox tbx_INN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox tbx_Telephone;
        private System.Windows.Forms.DateTimePicker dtp_BirthDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_DolzhnostName;
        private System.Windows.Forms.TextBox tbx_FullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_SecondName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_Name;
        private System.Windows.Forms.Button btn_Decline;
        private System.Windows.Forms.CheckBox cbx_Check;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}