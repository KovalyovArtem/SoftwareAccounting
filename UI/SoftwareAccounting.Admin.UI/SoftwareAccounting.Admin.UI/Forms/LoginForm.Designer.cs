namespace SoftwareAccounting.Admin.UI.Forms
{
    partial class LoginForm
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
            btn_Login = new Button();
            lb_Login = new Label();
            lb_Password = new Label();
            tbx_Login = new TextBox();
            tbx_Password = new TextBox();
            SuspendLayout();
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(126, 123);
            btn_Login.Margin = new Padding(3, 2, 3, 2);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(82, 22);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Вход";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // lb_Login
            // 
            lb_Login.AutoSize = true;
            lb_Login.Location = new Point(10, 36);
            lb_Login.Name = "lb_Login";
            lb_Login.Size = new Size(41, 15);
            lb_Login.TabIndex = 1;
            lb_Login.Text = "Логин";
            // 
            // lb_Password
            // 
            lb_Password.AutoSize = true;
            lb_Password.Location = new Point(10, 74);
            lb_Password.Name = "lb_Password";
            lb_Password.Size = new Size(49, 15);
            lb_Password.TabIndex = 1;
            lb_Password.Text = "Пароль";
            // 
            // tbx_Login
            // 
            tbx_Login.Location = new Point(85, 34);
            tbx_Login.Margin = new Padding(3, 2, 3, 2);
            tbx_Login.Name = "tbx_Login";
            tbx_Login.Size = new Size(230, 23);
            tbx_Login.TabIndex = 1;
            // 
            // tbx_Password
            // 
            tbx_Password.Location = new Point(85, 72);
            tbx_Password.Margin = new Padding(3, 2, 3, 2);
            tbx_Password.Name = "tbx_Password";
            tbx_Password.PasswordChar = '*';
            tbx_Password.Size = new Size(230, 23);
            tbx_Password.TabIndex = 2;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(335, 154);
            Controls.Add(tbx_Password);
            Controls.Add(tbx_Login);
            Controls.Add(lb_Password);
            Controls.Add(lb_Login);
            Controls.Add(btn_Login);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            FormClosing += LoginForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private Label lb_Login;
        private Label lb_Password;
        private TextBox tbx_Login;
        private TextBox tbx_Password;
    }
}