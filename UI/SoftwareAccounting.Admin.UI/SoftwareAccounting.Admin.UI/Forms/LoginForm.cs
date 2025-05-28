using SoftwareAccounting.Common.Models.AuthModel;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting.Admin.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;

        public bool IsLoggedIn { get; set; }

        public LoginForm()
        {
            InitializeComponent();

            _authService = Program.authService;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.runApplication = false;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            var user = new RegisterUserRequest
            {
                UserName = tbx_Login.Text,
                Password = tbx_Password.Text,
            };

            var loginTask = Task.Run(() => _authService.AuthenticateAsync(user));
            var login = loginTask.Result;

            if (login == "Unauthorized")
            {
                MessageBox.Show("Ошибка авторизации, не верный логин или пароль!");
                return;
            }
            else if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Ошибка получения доступа к сервису!");
                return;
            }

            Program.SetAuthRefitHandler(new AuthState
            {
                Username = user.UserName,
                Password = user.Password,
                AccessToken = login
            });

            IsLoggedIn = true;
            this.Close();
        }
    }
}
