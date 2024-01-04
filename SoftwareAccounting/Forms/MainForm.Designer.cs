namespace SoftwareAccounting
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ts_DownStatus = new System.Windows.Forms.ToolStrip();
            this.lbAdminStatusMenu = new System.Windows.Forms.ToolStripLabel();
            this.lb_StatusWord = new System.Windows.Forms.ToolStripLabel();
            this.ms_AdminHelpBtn = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_UnLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Admin = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_DolzhnostView = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_EmployeeViewForm = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AdminForm = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SoftwareView = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_DBButtons = new System.Windows.Forms.ToolStrip();
            this.btn_Insert = new System.Windows.Forms.ToolStripButton();
            this.btn_Update = new System.Windows.Forms.ToolStripButton();
            this.btn_Remove = new System.Windows.Forms.ToolStripButton();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lb_SearchWord = new System.Windows.Forms.ToolStripLabel();
            this.tbx_Search = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_ChoosePC = new System.Windows.Forms.ToolStripButton();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.ts_DownStatus.SuspendLayout();
            this.ms_AdminHelpBtn.SuspendLayout();
            this.ts_DBButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // ts_DownStatus
            // 
            this.ts_DownStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_DownStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_DownStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbAdminStatusMenu,
            this.lb_StatusWord});
            this.ts_DownStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ts_DownStatus.Location = new System.Drawing.Point(0, 470);
            this.ts_DownStatus.Name = "ts_DownStatus";
            this.ts_DownStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ts_DownStatus.Size = new System.Drawing.Size(1033, 23);
            this.ts_DownStatus.TabIndex = 5;
            // 
            // lbAdminStatusMenu
            // 
            this.lbAdminStatusMenu.Name = "lbAdminStatusMenu";
            this.lbAdminStatusMenu.Size = new System.Drawing.Size(0, 0);
            // 
            // lb_StatusWord
            // 
            this.lb_StatusWord.Name = "lb_StatusWord";
            this.lb_StatusWord.Size = new System.Drawing.Size(52, 20);
            this.lb_StatusWord.Text = ":Status";
            // 
            // ms_AdminHelpBtn
            // 
            this.ms_AdminHelpBtn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms_AdminHelpBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.btn_Admin});
            this.ms_AdminHelpBtn.Location = new System.Drawing.Point(0, 0);
            this.ms_AdminHelpBtn.Name = "ms_AdminHelpBtn";
            this.ms_AdminHelpBtn.Size = new System.Drawing.Size(1033, 30);
            this.ms_AdminHelpBtn.TabIndex = 6;
            this.ms_AdminHelpBtn.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_UnLogin,
            this.btn_Exit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // btn_UnLogin
            // 
            this.btn_UnLogin.Name = "btn_UnLogin";
            this.btn_UnLogin.Size = new System.Drawing.Size(219, 26);
            this.btn_UnLogin.Text = "Выход из системы";
            this.btn_UnLogin.Click += new System.EventHandler(this.btn_UnLogin_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(219, 26);
            this.btn_Exit.Text = "Выход";
            // 
            // btn_Admin
            // 
            this.btn_Admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_DolzhnostView,
            this.btn_EmployeeViewForm,
            this.btn_AdminForm,
            this.btn_SoftwareView});
            this.btn_Admin.Name = "btn_Admin";
            this.btn_Admin.Size = new System.Drawing.Size(170, 26);
            this.btn_Admin.Text = "Администрирование";
            // 
            // btn_DolzhnostView
            // 
            this.btn_DolzhnostView.Name = "btn_DolzhnostView";
            this.btn_DolzhnostView.Size = new System.Drawing.Size(288, 26);
            this.btn_DolzhnostView.Text = "Должности";
            this.btn_DolzhnostView.Click += new System.EventHandler(this.btn_DolzhnostView_Click);
            // 
            // btn_EmployeeViewForm
            // 
            this.btn_EmployeeViewForm.Name = "btn_EmployeeViewForm";
            this.btn_EmployeeViewForm.Size = new System.Drawing.Size(288, 26);
            this.btn_EmployeeViewForm.Text = "Сотрудники";
            this.btn_EmployeeViewForm.Click += new System.EventHandler(this.btn_EmployeeViewForm_Click);
            // 
            // btn_AdminForm
            // 
            this.btn_AdminForm.Name = "btn_AdminForm";
            this.btn_AdminForm.Size = new System.Drawing.Size(288, 26);
            this.btn_AdminForm.Text = "Пользователи";
            this.btn_AdminForm.Click += new System.EventHandler(this.btn_AdminForm_Click);
            // 
            // btn_SoftwareView
            // 
            this.btn_SoftwareView.Name = "btn_SoftwareView";
            this.btn_SoftwareView.Size = new System.Drawing.Size(288, 26);
            this.btn_SoftwareView.Text = "Программное обеспечение";
            this.btn_SoftwareView.Click += new System.EventHandler(this.btn_SoftwareView_Click);
            // 
            // ts_DBButtons
            // 
            this.ts_DBButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ts_DBButtons.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_DBButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Insert,
            this.btn_Update,
            this.btn_Remove,
            this.btn_Refresh,
            this.toolStripSeparator1,
            this.lb_SearchWord,
            this.tbx_Search,
            this.toolStripSeparator2,
            this.btn_ChoosePC});
            this.ts_DBButtons.Location = new System.Drawing.Point(0, 30);
            this.ts_DBButtons.Name = "ts_DBButtons";
            this.ts_DBButtons.Size = new System.Drawing.Size(1033, 31);
            this.ts_DBButtons.TabIndex = 7;
            this.ts_DBButtons.Text = "toolStrip1";
            // 
            // btn_Insert
            // 
            this.btn_Insert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Insert.Image = ((System.Drawing.Image)(resources.GetObject("btn_Insert.Image")));
            this.btn_Insert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(80, 28);
            this.btn_Insert.Text = "Добавить";
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Update.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.Image")));
            this.btn_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(82, 28);
            this.btn_Update.Text = "Изменить";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Remove.Image = ((System.Drawing.Image)(resources.GetObject("btn_Remove.Image")));
            this.btn_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(69, 28);
            this.btn_Remove.Text = "Удалить";
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(82, 28);
            this.btn_Refresh.Text = "Обновить";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // lb_SearchWord
            // 
            this.lb_SearchWord.Name = "lb_SearchWord";
            this.lb_SearchWord.Size = new System.Drawing.Size(52, 28);
            this.lb_SearchWord.Text = "Поиск";
            // 
            // tbx_Search
            // 
            this.tbx_Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbx_Search.Name = "tbx_Search";
            this.tbx_Search.Size = new System.Drawing.Size(100, 31);
            this.tbx_Search.TextChanged += new System.EventHandler(this.tbx_Search_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_ChoosePC
            // 
            this.btn_ChoosePC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_ChoosePC.Image = ((System.Drawing.Image)(resources.GetObject("btn_ChoosePC.Image")));
            this.btn_ChoosePC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ChoosePC.Name = "btn_ChoosePC";
            this.btn_ChoosePC.Size = new System.Drawing.Size(97, 28);
            this.btn_ChoosePC.Text = "Выбрать ПК";
            this.btn_ChoosePC.Click += new System.EventHandler(this.btn_ChoosePC_Click);
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 61);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            this.dgv_Main.RowHeadersWidth = 51;
            this.dgv_Main.RowTemplate.Height = 24;
            this.dgv_Main.Size = new System.Drawing.Size(1033, 409);
            this.dgv_Main.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 493);
            this.Controls.Add(this.dgv_Main);
            this.Controls.Add(this.ts_DBButtons);
            this.Controls.Add(this.ms_AdminHelpBtn);
            this.Controls.Add(this.ts_DownStatus);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инвентаризация ПО";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ts_DownStatus.ResumeLayout(false);
            this.ts_DownStatus.PerformLayout();
            this.ms_AdminHelpBtn.ResumeLayout(false);
            this.ms_AdminHelpBtn.PerformLayout();
            this.ts_DBButtons.ResumeLayout(false);
            this.ts_DBButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_DownStatus;
        private System.Windows.Forms.ToolStripLabel lbAdminStatusMenu;
        private System.Windows.Forms.ToolStripLabel lb_StatusWord;
        private System.Windows.Forms.MenuStrip ms_AdminHelpBtn;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btn_UnLogin;
        private System.Windows.Forms.ToolStripMenuItem btn_Exit;
        private System.Windows.Forms.ToolStripMenuItem btn_Admin;
        private System.Windows.Forms.ToolStripMenuItem btn_AdminForm;
        private System.Windows.Forms.ToolStripMenuItem btn_DolzhnostView;
        private System.Windows.Forms.ToolStripMenuItem btn_EmployeeViewForm;
        private System.Windows.Forms.ToolStrip ts_DBButtons;
        private System.Windows.Forms.ToolStripButton btn_Insert;
        private System.Windows.Forms.ToolStripButton btn_Update;
        private System.Windows.Forms.ToolStripButton btn_Remove;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lb_SearchWord;
        private System.Windows.Forms.ToolStripTextBox tbx_Search;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.ToolStripMenuItem btn_SoftwareView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_ChoosePC;
    }
}

