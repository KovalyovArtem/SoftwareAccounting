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
    public partial class ChooseFilterForSortByPC : Form
    {
        private MainForm mainForm;
        private int id;

        public ChooseFilterForSortByPC(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private async void ChooseFilterForSortByPC_Load(object sender, EventArgs e)
        {
            dgvChoose.DataSource = await TableAdapterDB.ComputerView();
            dgvChoose.Columns[0].Visible = false;
        }

        private void btn_Decline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            if (dgvChoose.SelectedRows.Count < 0)
            {
                MessageBox.Show("Выберите компьютер!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rowIndex = dgvChoose.SelectedCells[0].RowIndex;
            id = Convert.ToInt32(dgvChoose.Rows[rowIndex].Cells[0].Value);


            mainForm.GetInstallingByFilter(id);

            Close();
        }
    }
}
