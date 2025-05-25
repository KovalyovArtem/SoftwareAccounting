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
            btn_Login.Location = new Point(144, 164);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(94, 29);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Вход";
            btn_Login.UseVisualStyleBackColor = true;
            // 
            // lb_Login
            // 
            lb_Login.AutoSize = true;
            lb_Login.Location = new Point(12, 48);
            lb_Login.Name = "lb_Login";
            lb_Login.Size = new Size(52, 20);
            lb_Login.TabIndex = 1;
            lb_Login.Text = "Логин";
            // 
            // lb_Password
            // 
            lb_Password.AutoSize = true;
            lb_Password.Location = new Point(12, 99);
            lb_Password.Name = "lb_Password";
            lb_Password.Size = new Size(62, 20);
            lb_Password.TabIndex = 1;
            lb_Password.Text = "Пароль";
            // 
            // tbx_Login
            // 
            tbx_Login.Location = new Point(97, 45);
            tbx_Login.Name = "tbx_Login";
            tbx_Login.Size = new Size(262, 27);
            tbx_Login.TabIndex = 1;
            // 
            // tbx_Password
            // 
            tbx_Password.Location = new Point(97, 96);
            tbx_Password.Name = "tbx_Password";
            tbx_Password.PasswordChar = '*';
            tbx_Password.Size = new Size(262, 27);
            tbx_Password.TabIndex = 2;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(383, 205);
            Controls.Add(tbx_Password);
            Controls.Add(tbx_Login);
            Controls.Add(lb_Password);
            Controls.Add(lb_Login);
            Controls.Add(btn_Login);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
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