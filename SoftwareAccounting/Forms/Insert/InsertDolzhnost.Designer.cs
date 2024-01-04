namespace SoftwareAccounting.Forms.Insert
{
    partial class InsertDolzhnost
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
            this.lb_Name = new System.Windows.Forms.Label();
            this.btn_Decline = new System.Windows.Forms.Button();
            this.cbx_Check = new System.Windows.Forms.CheckBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Location = new System.Drawing.Point(8, 16);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(180, 16);
            this.lb_Name.TabIndex = 23;
            this.lb_Name.Text = "Наименование должности";
            // 
            // btn_Decline
            // 
            this.btn_Decline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Decline.Location = new System.Drawing.Point(386, 86);
            this.btn_Decline.Name = "btn_Decline";
            this.btn_Decline.Size = new System.Drawing.Size(104, 30);
            this.btn_Decline.TabIndex = 21;
            this.btn_Decline.Text = "Отмена";
            this.btn_Decline.UseVisualStyleBackColor = true;
            this.btn_Decline.Click += new System.EventHandler(this.btn_Decline_Click);
            // 
            // cbx_Check
            // 
            this.cbx_Check.AutoSize = true;
            this.cbx_Check.Location = new System.Drawing.Point(8, 60);
            this.cbx_Check.Name = "cbx_Check";
            this.cbx_Check.Size = new System.Drawing.Size(414, 20);
            this.cbx_Check.TabIndex = 19;
            this.cbx_Check.Text = "Не закрывать форму после успешного добавления записи";
            this.cbx_Check.UseVisualStyleBackColor = true;
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(8, 41);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(34, 16);
            this.lb_info.TabIndex = 22;
            this.lb_info.Text = "laaa";
            this.lb_info.Visible = false;
            // 
            // tbx_Name
            // 
            this.tbx_Name.Location = new System.Drawing.Point(203, 13);
            this.tbx_Name.MaxLength = 50;
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(296, 22);
            this.tbx_Name.TabIndex = 18;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Add.Location = new System.Drawing.Point(263, 86);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(117, 30);
            this.btn_Add.TabIndex = 20;
            this.btn_Add.Text = "Добавить";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // InsertDolzhnost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 128);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.btn_Decline);
            this.Controls.Add(this.cbx_Check);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.tbx_Name);
            this.Controls.Add(this.btn_Add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsertDolzhnost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InsertDolzhnost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Button btn_Decline;
        private System.Windows.Forms.CheckBox cbx_Check;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.TextBox tbx_Name;
        private System.Windows.Forms.Button btn_Add;
    }
}