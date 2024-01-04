namespace SoftwareAccounting.Forms
{
    partial class EmployersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployersForm));
            this.dgv_Employee = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Add = new System.Windows.Forms.ToolStripButton();
            this.btn_Update = new System.Windows.Forms.ToolStripButton();
            this.btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbx_SecondName = new System.Windows.Forms.ToolStripTextBox();
            this.tbx_Name = new System.Windows.Forms.ToolStripTextBox();
            this.tbx_FullName = new System.Windows.Forms.ToolStripTextBox();
            this.tbx_Telephone = new System.Windows.Forms.ToolStripTextBox();
            this.tbx_Date = new System.Windows.Forms.ToolStripTextBox();
            this.tbx_Dolzhnost = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Employee
            // 
            this.dgv_Employee.AllowUserToAddRows = false;
            this.dgv_Employee.AllowUserToDeleteRows = false;
            this.dgv_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Employee.Location = new System.Drawing.Point(0, 27);
            this.dgv_Employee.Name = "dgv_Employee";
            this.dgv_Employee.ReadOnly = true;
            this.dgv_Employee.RowHeadersWidth = 51;
            this.dgv_Employee.RowTemplate.Height = 24;
            this.dgv_Employee.Size = new System.Drawing.Size(1827, 438);
            this.dgv_Employee.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Add,
            this.btn_Update,
            this.btn_Delete,
            this.btn_Refresh,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tbx_SecondName,
            this.tbx_Name,
            this.tbx_FullName,
            this.tbx_Telephone,
            this.tbx_Date,
            this.tbx_Dolzhnost});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1827, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Add
            // 
            this.btn_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 24);
            this.btn_Add.Text = "Добавить";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Update.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.Image")));
            this.btn_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(82, 24);
            this.btn_Update.Text = "Изменить";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(69, 24);
            this.btn_Delete.Text = "Удалить";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(82, 24);
            this.btn_Refresh.Text = "Обновить";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(162, 24);
            this.toolStripLabel1.Text = "Поиск по категориям:";
            // 
            // tbx_SecondName
            // 
            this.tbx_SecondName.Name = "tbx_SecondName";
            this.tbx_SecondName.Size = new System.Drawing.Size(130, 27);
            this.tbx_SecondName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_Name
            // 
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(130, 27);
            this.tbx_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_FullName
            // 
            this.tbx_FullName.Name = "tbx_FullName";
            this.tbx_FullName.Size = new System.Drawing.Size(130, 27);
            this.tbx_FullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_Telephone
            // 
            this.tbx_Telephone.Name = "tbx_Telephone";
            this.tbx_Telephone.Size = new System.Drawing.Size(130, 27);
            this.tbx_Telephone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_Date
            // 
            this.tbx_Date.Name = "tbx_Date";
            this.tbx_Date.Size = new System.Drawing.Size(130, 27);
            this.tbx_Date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // tbx_Dolzhnost
            // 
            this.tbx_Dolzhnost.Name = "tbx_Dolzhnost";
            this.tbx_Dolzhnost.Size = new System.Drawing.Size(130, 27);
            this.tbx_Dolzhnost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxs_KeyDown);
            // 
            // EmployersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 465);
            this.Controls.Add(this.dgv_Employee);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EmployersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сотрудники";
            this.Load += new System.EventHandler(this.EmployersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_Employee;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Add;
        private System.Windows.Forms.ToolStripButton btn_Update;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbx_SecondName;
        private System.Windows.Forms.ToolStripTextBox tbx_Name;
        private System.Windows.Forms.ToolStripTextBox tbx_FullName;
        private System.Windows.Forms.ToolStripTextBox tbx_Telephone;
        private System.Windows.Forms.ToolStripTextBox tbx_Date;
        private System.Windows.Forms.ToolStripTextBox tbx_Dolzhnost;
    }
}