namespace SoftwareAccounting.Forms.Update
{
    partial class UpdatePeopleForm
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
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbx_Telephone = new System.Windows.Forms.MaskedTextBox();
            this.dtp_BirthDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cbx_DolzhnostName = new System.Windows.Forms.ComboBox();
            this.tbx_FullName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbx_SecondName = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbx_INN = new System.Windows.Forms.TextBox();
            this.tbx_KodPodrazd = new System.Windows.Forms.MaskedTextBox();
            this.dtp_DateGive = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbx_KemVidan = new System.Windows.Forms.TextBox();
            this.tbx_Number = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbx_Seria = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbx_Check = new System.Windows.Forms.CheckBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.SystemColors.Control;
            this.label27.Location = new System.Drawing.Point(348, 237);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 16);
            this.label27.TabIndex = 43;
            this.label27.Text = "label13";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbx_Telephone);
            this.groupBox5.Controls.Add(this.dtp_BirthDate);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.cbx_DolzhnostName);
            this.groupBox5.Controls.Add(this.tbx_FullName);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.tbx_SecondName);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.tbx_Name);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(450, 219);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Регистрация пользователя";
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
            this.dtp_BirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_BirthDate.Location = new System.Drawing.Point(166, 177);
            this.dtp_BirthDate.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.dtp_BirthDate.Name = "dtp_BirthDate";
            this.dtp_BirthDate.Size = new System.Drawing.Size(268, 22);
            this.dtp_BirthDate.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 180);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 16);
            this.label21.TabIndex = 28;
            this.label21.Text = "Дата рождения";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 152);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 26;
            this.label22.Text = "Телефон";
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
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(5, 38);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(147, 16);
            this.label23.TabIndex = 15;
            this.label23.Text = "Название должности";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(5, 124);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 16);
            this.label24.TabIndex = 24;
            this.label24.Text = "Отчество";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 68);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 16);
            this.label25.TabIndex = 17;
            this.label25.Text = "Фамилия";
            // 
            // tbx_SecondName
            // 
            this.tbx_SecondName.Location = new System.Drawing.Point(166, 65);
            this.tbx_SecondName.MaxLength = 50;
            this.tbx_SecondName.Name = "tbx_SecondName";
            this.tbx_SecondName.Size = new System.Drawing.Size(268, 22);
            this.tbx_SecondName.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 96);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 16);
            this.label26.TabIndex = 20;
            this.label26.Text = "Имя";
            // 
            // tbx_Name
            // 
            this.tbx_Name.Location = new System.Drawing.Point(166, 93);
            this.tbx_Name.MaxLength = 50;
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(268, 22);
            this.tbx_Name.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbx_INN);
            this.groupBox4.Controls.Add(this.tbx_KodPodrazd);
            this.groupBox4.Controls.Add(this.dtp_DateGive);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.tbx_KemVidan);
            this.groupBox4.Controls.Add(this.tbx_Number);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.tbx_Seria);
            this.groupBox4.Location = new System.Drawing.Point(468, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(449, 219);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Дополнительные данные";
            // 
            // tbx_INN
            // 
            this.tbx_INN.Location = new System.Drawing.Point(149, 37);
            this.tbx_INN.MaxLength = 10;
            this.tbx_INN.Name = "tbx_INN";
            this.tbx_INN.Size = new System.Drawing.Size(286, 22);
            this.tbx_INN.TabIndex = 38;
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 16);
            this.label15.TabIndex = 37;
            this.label15.Text = "Дата выдачи";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 16);
            this.label16.TabIndex = 35;
            this.label16.Text = "Код подразделения";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 122);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 16);
            this.label17.TabIndex = 34;
            this.label17.Text = "Кем выдан";
            // 
            // tbx_KemVidan
            // 
            this.tbx_KemVidan.Location = new System.Drawing.Point(149, 119);
            this.tbx_KemVidan.MaxLength = 50;
            this.tbx_KemVidan.Name = "tbx_KemVidan";
            this.tbx_KemVidan.Size = new System.Drawing.Size(286, 22);
            this.tbx_KemVidan.TabIndex = 12;
            // 
            // tbx_Number
            // 
            this.tbx_Number.Location = new System.Drawing.Point(149, 91);
            this.tbx_Number.MaxLength = 6;
            this.tbx_Number.Name = "tbx_Number";
            this.tbx_Number.Size = new System.Drawing.Size(286, 22);
            this.tbx_Number.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 16);
            this.label18.TabIndex = 30;
            this.label18.Text = "Номер";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 16);
            this.label19.TabIndex = 28;
            this.label19.Text = "ИНН";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 16);
            this.label20.TabIndex = 29;
            this.label20.Text = "Серия";
            // 
            // tbx_Seria
            // 
            this.tbx_Seria.Location = new System.Drawing.Point(149, 63);
            this.tbx_Seria.MaxLength = 4;
            this.tbx_Seria.Name = "tbx_Seria";
            this.tbx_Seria.Size = new System.Drawing.Size(286, 22);
            this.tbx_Seria.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(799, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 30);
            this.button2.TabIndex = 39;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbx_Check
            // 
            this.cbx_Check.AutoSize = true;
            this.cbx_Check.Location = new System.Drawing.Point(16, 256);
            this.cbx_Check.Name = "cbx_Check";
            this.cbx_Check.Size = new System.Drawing.Size(414, 20);
            this.cbx_Check.TabIndex = 37;
            this.cbx_Check.Text = "Не закрывать форму после успешного добавления записи";
            this.cbx_Check.UseVisualStyleBackColor = true;
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(17, 237);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(34, 16);
            this.lb_info.TabIndex = 40;
            this.lb_info.Text = "laaa";
            this.lb_info.Visible = false;
            // 
            // btn_Edit
            // 
            this.btn_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Edit.Location = new System.Drawing.Point(676, 246);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(117, 30);
            this.btn_Edit.TabIndex = 38;
            this.btn_Edit.Text = "Изменить";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // UpdatePeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 296);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbx_Check);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.btn_Edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdatePeopleForm";
            this.Text = "UpdatePeopleForm";
            this.Load += new System.EventHandler(this.UpdatePeopleForm_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MaskedTextBox tbx_Telephone;
        private System.Windows.Forms.DateTimePicker dtp_BirthDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbx_DolzhnostName;
        private System.Windows.Forms.TextBox tbx_FullName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbx_SecondName;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbx_Name;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbx_INN;
        private System.Windows.Forms.MaskedTextBox tbx_KodPodrazd;
        private System.Windows.Forms.DateTimePicker dtp_DateGive;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbx_KemVidan;
        private System.Windows.Forms.TextBox tbx_Number;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbx_Seria;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbx_Check;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.Button btn_Edit;
    }
}