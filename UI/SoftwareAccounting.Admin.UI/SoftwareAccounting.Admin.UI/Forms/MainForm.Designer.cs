
namespace SoftwareAccounting.Admin.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ms_Main = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            ts_Action = new ToolStripMenuItem();
            ts_item_Accounting = new ToolStripMenuItem();
            ts_item_Accounting_Once = new ToolStripMenuItem();
            splitContainerMain = new SplitContainer();
            dgv_Main = new DataGridView();
            dgv_Additional = new DataGridView();
            panel1 = new Panel();
            ms_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Main).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Additional).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ms_Main
            // 
            ms_Main.BackColor = SystemColors.ControlLight;
            ms_Main.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, ts_Action });
            ms_Main.Location = new Point(0, 0);
            ms_Main.Name = "ms_Main";
            ms_Main.Size = new Size(1217, 24);
            ms_Main.TabIndex = 0;
            ms_Main.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // ts_Action
            // 
            ts_Action.DropDownItems.AddRange(new ToolStripItem[] { ts_item_Accounting, ts_item_Accounting_Once });
            ts_Action.Name = "ts_Action";
            ts_Action.Size = new Size(70, 20);
            ts_Action.Text = "Действия";
            // 
            // ts_item_Accounting
            // 
            ts_item_Accounting.Name = "ts_item_Accounting";
            ts_item_Accounting.Size = new Size(224, 22);
            ts_item_Accounting.Text = "Сверка ПО всех ПК";
            ts_item_Accounting.Click += ts_item_Accounting_Click;
            // 
            // ts_item_Accounting_Once
            // 
            ts_item_Accounting_Once.Name = "ts_item_Accounting_Once";
            ts_item_Accounting_Once.Size = new Size(224, 22);
            ts_item_Accounting_Once.Text = "Сверка ПО выбранного ПК";
            ts_item_Accounting_Once.Click += ts_item_Accounting_Once_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(dgv_Main);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(dgv_Additional);
            splitContainerMain.Size = new Size(1217, 640);
            splitContainerMain.SplitterDistance = 643;
            splitContainerMain.TabIndex = 1;
            // 
            // dgv_Main
            // 
            dgv_Main.AllowUserToAddRows = false;
            dgv_Main.AllowUserToDeleteRows = false;
            dgv_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Main.Dock = DockStyle.Fill;
            dgv_Main.Location = new Point(0, 0);
            dgv_Main.Name = "dgv_Main";
            dgv_Main.ReadOnly = true;
            dgv_Main.Size = new Size(643, 640);
            dgv_Main.TabIndex = 0;
            dgv_Main.CellClick += dgv_Main_CellClick;
            // 
            // dgv_Additional
            // 
            dgv_Additional.AllowUserToAddRows = false;
            dgv_Additional.AllowUserToDeleteRows = false;
            dgv_Additional.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Additional.Dock = DockStyle.Fill;
            dgv_Additional.Location = new Point(0, 0);
            dgv_Additional.Name = "dgv_Additional";
            dgv_Additional.ReadOnly = true;
            dgv_Additional.Size = new Size(570, 640);
            dgv_Additional.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainerMain);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1217, 640);
            panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 664);
            Controls.Add(panel1);
            Controls.Add(ms_Main);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = ms_Main;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoftwareAccounting";
            FormClosing += MainForm_FormClosing;
            ms_Main.ResumeLayout(false);
            ms_Main.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Main).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Additional).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip ms_Main;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem ts_Action;
        private ToolStripMenuItem ts_item_Accounting;
        private SplitContainer splitContainerMain;
        private Panel panel1;
        private DataGridView dgv_Main;
        private DataGridView dgv_Additional;
        private ToolStripMenuItem ts_item_Accounting_Once;
    }
}
