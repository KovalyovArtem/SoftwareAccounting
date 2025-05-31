using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting.Admin.UI.Forms.PeopleForms
{
    public partial class UserForm : Form
    {
        private readonly IPeopleService _peopleService;

        public UserForm()
        {
            InitializeComponent();

            _peopleService = Program.peopleService;
        }

        private async void UserForm_Load(object sender, System.EventArgs e)
        {
            var users = await _peopleService.GetUsers();
            dgv_Users.DataSource = users;

            if (users == null)
            {
                MessageBox.Show("Ошибка загрузки данных!");
                return;
            }

            dgv_Users.Columns[0].Visible = false;
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            new AddUserForm().ShowDialog();
        }
    }
}
