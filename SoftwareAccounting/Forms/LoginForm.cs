using SoftwareAccounting.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting.Forms
{
    public partial class LoginForm : Form
    {
        public bool IsLoggedIn { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            tbx_Password.UseSystemPasswordChar = true;
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            string login = tbx_Login.Text, pass = tbx_Password.Text;

            if (login == "" || pass == "")
            {
                MessageBox.Show("Введите логин и пароль!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool authentification = await Server.LoginIsCorrectAsync(login, pass);
            if (authentification)
            {
                await Server.getStatusAsync(login, pass);
                await Server.getEmployeeIDAsync(login, pass);
                IsLoggedIn = true;
                Close();
            }
            else
            {
                MessageBox.Show("Логин и пароль указаны не верно!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbx_Login.Focus();
                tbx_Password.Clear();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.runApplication = false;
        }
    }
}
