namespace SoftwareAccounting.Admin.UI.Forms.PeopleForms
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            toolStrip1 = new ToolStrip();
            btn_AddUser = new ToolStripButton();
            btn_ChangePassword = new ToolStripButton();
            btn_Delete = new ToolStripButton();
            btn_Refresh = new ToolStripButton();
            dgv_Users = new DataGridView();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Users).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ControlLight;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btn_AddUser, btn_ChangePassword, btn_Delete, btn_Refresh });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btn_AddUser
            // 
            btn_AddUser.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_AddUser.Image = (Image)resources.GetObject("btn_AddUser.Image");
            btn_AddUser.ImageTransparentColor = Color.Magenta;
            btn_AddUser.Name = "btn_AddUser";
            btn_AddUser.Size = new Size(63, 22);
            btn_AddUser.Text = "Добавить";
            btn_AddUser.Click += btn_AddUser_Click;
            // 
            // btn_ChangePassword
            // 
            btn_ChangePassword.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_ChangePassword.Image = (Image)resources.GetObject("btn_ChangePassword.Image");
            btn_ChangePassword.ImageTransparentColor = Color.Magenta;
            btn_ChangePassword.Name = "btn_ChangePassword";
            btn_ChangePassword.Size = new Size(108, 22);
            btn_ChangePassword.Text = "Изменить пароль";
            // 
            // btn_Delete
            // 
            btn_Delete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_Delete.Image = (Image)resources.GetObject("btn_Delete.Image");
            btn_Delete.ImageTransparentColor = Color.Magenta;
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(55, 22);
            btn_Delete.Text = "Удалить";
            // 
            // btn_Refresh
            // 
            btn_Refresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_Refresh.Image = (Image)resources.GetObject("btn_Refresh.Image");
            btn_Refresh.ImageTransparentColor = Color.Magenta;
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(65, 22);
            btn_Refresh.Text = "Обновить";
            // 
            // dgv_Users
            // 
            dgv_Users.AllowUserToAddRows = false;
            dgv_Users.AllowUserToDeleteRows = false;
            dgv_Users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Users.Dock = DockStyle.Fill;
            dgv_Users.Location = new Point(0, 25);
            dgv_Users.Name = "dgv_Users";
            dgv_Users.ReadOnly = true;
            dgv_Users.Size = new Size(800, 425);
            dgv_Users.TabIndex = 1;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_Users);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Работа с пользователями системы";
            Load += UserForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Users).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btn_AddUser;
        private ToolStripButton btn_ChangePassword;
        private ToolStripButton btn_Delete;
        private DataGridView dgv_Users;
        private ToolStripButton btn_Refresh;
    }
}