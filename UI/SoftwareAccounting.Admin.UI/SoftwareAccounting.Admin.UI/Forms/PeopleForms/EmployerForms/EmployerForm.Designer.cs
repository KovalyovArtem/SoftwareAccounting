namespace SoftwareAccounting.Admin.UI.Forms.PeopleForms.EmployerForms
{
    partial class EmployerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployerForm));
            toolStrip1 = new ToolStrip();
            btn_Add = new ToolStripButton();
            btn_Edit = new ToolStripButton();
            btn_Delete = new ToolStripButton();
            btn_Refresh = new ToolStripButton();
            dgv_Employers = new DataGridView();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Employers).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btn_Add, btn_Edit, btn_Delete, btn_Refresh });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btn_Add
            // 
            btn_Add.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_Add.Image = (Image)resources.GetObject("btn_Add.Image");
            btn_Add.ImageTransparentColor = Color.Magenta;
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(63, 22);
            btn_Add.Text = "Добавить";
            btn_Add.Click += btn_Add_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_Edit.Image = (Image)resources.GetObject("btn_Edit.Image");
            btn_Edit.ImageTransparentColor = Color.Magenta;
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(65, 22);
            btn_Edit.Text = "Изменить";
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
            // dgv_Employers
            // 
            dgv_Employers.AllowUserToAddRows = false;
            dgv_Employers.AllowUserToDeleteRows = false;
            dgv_Employers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Employers.Dock = DockStyle.Fill;
            dgv_Employers.Location = new Point(0, 25);
            dgv_Employers.Name = "dgv_Employers";
            dgv_Employers.ReadOnly = true;
            dgv_Employers.Size = new Size(800, 425);
            dgv_Employers.TabIndex = 1;
            // 
            // EmployerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_Employers);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EmployerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сотрудники";
            Load += EmployerForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Employers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btn_Add;
        private ToolStripButton btn_Edit;
        private ToolStripButton btn_Delete;
        private ToolStripButton btn_Refresh;
        private DataGridView dgv_Employers;
    }
}