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
    public partial class AddUserForm : Form
    {
        private readonly IPeopleService _peopleService;

        public AddUserForm()
        {
            InitializeComponent();

            _peopleService = Program.peopleService;
        }

        private async void AddUserForm_Load(object sender, EventArgs e)
        {
            var users = await _peopleService.GetEmployers();
            dgv_Employers.DataSource = users;

            if (users == null)
            {
                MessageBox.Show("Ошибка загрузки данных!");
                return;
            }

            dgv_Employers.Columns[0].Visible = false;
        }
    }
}
