namespace SoftwareAccounting.Admin.UI.Forms
{
    partial class QRCodeGenerationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRCodeGenerationForm));
            groupBox1 = new GroupBox();
            pbx_QrCode = new PictureBox();
            btn_Save = new Button();
            btn_Load = new Button();
            btn_Print = new Button();
            tbx_AdditionalInfo = new RichTextBox();
            btn_Generate = new Button();
            printDocument = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            printDialog = new PrintDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbx_QrCode).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pbx_QrCode);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 230);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "QR-code";
            // 
            // pbx_QrCode
            // 
            pbx_QrCode.Dock = DockStyle.Fill;
            pbx_QrCode.Location = new Point(3, 19);
            pbx_QrCode.Name = "pbx_QrCode";
            pbx_QrCode.Size = new Size(269, 208);
            pbx_QrCode.SizeMode = PictureBoxSizeMode.StretchImage;
            pbx_QrCode.TabIndex = 0;
            pbx_QrCode.TabStop = false;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(308, 28);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(94, 23);
            btn_Save.TabIndex = 1;
            btn_Save.Text = "Сохранить";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Load
            // 
            btn_Load.Location = new Point(408, 28);
            btn_Load.Name = "btn_Load";
            btn_Load.Size = new Size(94, 23);
            btn_Load.TabIndex = 1;
            btn_Load.Text = "Загрузить";
            btn_Load.UseVisualStyleBackColor = true;
            btn_Load.Click += btn_Load_Click;
            // 
            // btn_Print
            // 
            btn_Print.Location = new Point(308, 57);
            btn_Print.Name = "btn_Print";
            btn_Print.Size = new Size(94, 23);
            btn_Print.TabIndex = 1;
            btn_Print.Text = "Печать";
            btn_Print.UseVisualStyleBackColor = true;
            btn_Print.Click += btn_Print_Click;
            // 
            // tbx_AdditionalInfo
            // 
            tbx_AdditionalInfo.Location = new Point(308, 86);
            tbx_AdditionalInfo.Name = "tbx_AdditionalInfo";
            tbx_AdditionalInfo.Size = new Size(195, 153);
            tbx_AdditionalInfo.TabIndex = 2;
            tbx_AdditionalInfo.Text = "";
            // 
            // btn_Generate
            // 
            btn_Generate.Location = new Point(408, 57);
            btn_Generate.Name = "btn_Generate";
            btn_Generate.Size = new Size(94, 23);
            btn_Generate.TabIndex = 1;
            btn_Generate.Text = "Генерация";
            btn_Generate.UseVisualStyleBackColor = true;
            btn_Generate.Click += btn_Generate_Click;
            // 
            // printPreviewDialog
            // 
            printPreviewDialog.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Enabled = true;
            printPreviewDialog.Icon = (Icon)resources.GetObject("printPreviewDialog.Icon");
            printPreviewDialog.Name = "printPreviewDialog";
            printPreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            printDialog.UseEXDialog = true;
            // 
            // QRCodeGenerationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 265);
            Controls.Add(tbx_AdditionalInfo);
            Controls.Add(btn_Generate);
            Controls.Add(btn_Print);
            Controls.Add(btn_Load);
            Controls.Add(btn_Save);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "QRCodeGenerationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Генерация QR-code";
            Load += QRCodeGenerationForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbx_QrCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pbx_QrCode;
        private Button btn_Save;
        private Button btn_Load;
        private Button btn_Print;
        private RichTextBox tbx_AdditionalInfo;
        private Button btn_Generate;
        private System.Drawing.Printing.PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private PrintDialog printDialog;
    }
}