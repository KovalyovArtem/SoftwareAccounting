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

namespace SoftwareAccounting.Admin.UI.Forms.PeopleForms.EmployerForms
{
    public partial class EmployerForm : Form
    {
        private readonly IPeopleService _peopleService;

        public EmployerForm()
        {
            InitializeComponent();

            _peopleService = Program.peopleService;
        }

        private async void EmployerForm_Load(object sender, EventArgs e)
        {
            var employers = await _peopleService.GetEmployers();
            dgv_Employers.DataSource = employers;

            if (employers == null)
            {
                MessageBox.Show("Ошибка загрузки данных!");
                return;
            }

            dgv_Employers.Columns[0].Visible = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            new AddEmployerForm().ShowDialog();
        }
    }
}
