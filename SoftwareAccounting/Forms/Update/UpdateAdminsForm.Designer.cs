namespace SoftwareAccounting.Forms.Update
{
    partial class UpdateAdminsForm
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
            this.cbx_isAdmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Pass = new System.Windows.Forms.TextBox();
            this.lb_Name = new System.Windows.Forms.Label();
            this.btn_Decline = new System.Windows.Forms.Button();
            this.cbx_Check = new System.Windows.Forms.CheckBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.tbx_Login = new System.Windows.Forms.TextBox();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbx_isAdmin
            // 
            this.cbx_isAdmin.AutoSize = true;
            this.cbx_isAdmin.Location = new System.Drawing.Point(98, 68);
            this.cbx_isAdmin.Name = "cbx_isAdmin";
            this.cbx_isAdmin.Size = new System.Drawing.Size(465, 20);
            this.cbx_isAdmin.TabIndex = 38;
            this.cbx_isAdmin.Text = "Будет ли пользователь обладать всеми правами администратора";
            this.cbx_isAdmin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Пароль";
            // 
            // tbx_Pass
            // 
            this.tbx_Pass.Location = new System.Drawing.Point(98, 40);
            this.tbx_Pass.MaxLength = 50;
            this.tbx_Pass.Name = "tbx_Pass";
            this.tbx_Pass.Size = new System.Drawing.Size(465, 22);
            this.tbx_Pass.TabIndex = 37;
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Location = new System.Drawing.Point(13, 15);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(46, 16);
            this.lb_Name.TabIndex = 43;
            this.lb_Name.Text = "Логин";
            // 
            // btn_Decline
            // 
            this.btn_Decline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Decline.Location = new System.Drawing.Point(459, 156);
            this.btn_Decline.Name = "btn_Decline";
            this.btn_Decline.Size = new System.Drawing.Size(104, 30);
            this.btn_Decline.TabIndex = 41;
            this.btn_Decline.Text = "Отмена";
            this.btn_Decline.UseVisualStyleBackColor = true;
            this.btn_Decline.Click += new System.EventHandler(this.btn_Decline_Click);
            // 
            // cbx_Check
            // 
            this.cbx_Check.AutoSize = true;
            this.cbx_Check.Location = new System.Drawing.Point(13, 125);
            this.cbx_Check.Name = "cbx_Check";
            this.cbx_Check.Size = new System.Drawing.Size(407, 20);
            this.cbx_Check.TabIndex = 39;
            this.cbx_Check.Text = "Не закрывать форму после успешного изменения записи";
            this.cbx_Check.UseVisualStyleBackColor = true;
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(13, 106);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(34, 16);
            this.lb_info.TabIndex = 42;
            this.lb_info.Text = "laaa";
            this.lb_info.Visible = false;
            // 
            // tbx_Login
            // 
            this.tbx_Login.Location = new System.Drawing.Point(98, 12);
            this.tbx_Login.MaxLength = 30;
            this.tbx_Login.Name = "tbx_Login";
            this.tbx_Login.Size = new System.Drawing.Size(465, 22);
            this.tbx_Login.TabIndex = 36;
            // 
            // btn_Edit
            // 
            this.btn_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Edit.Location = new System.Drawing.Point(336, 156);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(117, 30);
            this.btn_Edit.TabIndex = 40;
            this.btn_Edit.Text = "Изменить";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // UpdateAdminsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 199);
            this.Controls.Add(this.cbx_isAdmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Pass);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.btn_Decline);
            this.Controls.Add(this.cbx_Check);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.tbx_Login);
            this.Controls.Add(this.btn_Edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateAdminsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateAdminsForm";
            this.Load += new System.EventHandler(this.UpdateAdminsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbx_isAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Pass;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Button btn_Decline;
        private System.Windows.Forms.CheckBox cbx_Check;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.TextBox tbx_Login;
        private System.Windows.Forms.Button btn_Edit;
    }
}