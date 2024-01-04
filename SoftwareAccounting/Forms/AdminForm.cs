using SoftwareAccounting.Classes;
using SoftwareAccounting.Forms.Insert;
using SoftwareAccounting.Forms.Update;
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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            new InsertAdminForm(this).ShowDialog();
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            dgv_Admins.DataSource = await TableAdapterDB.AdminsViewAsync();
            dgv_Admins.Columns[0].Visible = false;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_Admins.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rowIndex = dgv_Admins.SelectedCells[0].RowIndex;
            string login = dgv_Admins.Rows[rowIndex].Cells[6].Value.ToString();
            new UpdateAdminsForm(login, this).ShowDialog();
        }

        private async void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_Admins.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Выберите строку или клетку в данной строке для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                var rowIndex = dgv_Admins.SelectedCells[0].RowIndex;
                string rowID = dgv_Admins.Rows[rowIndex].Cells[6].Value.ToString();

                await UpdateDB.DeleteRowAsync("User", "Login", rowID);
            }

            await RefresgDgv();
        }

        private async void btn_Refresh_Click(object sender, EventArgs e)
        {
            await RefresgDgv();
        }

        public async Task RefresgDgv()
        {
            try
            {
                dgv_Admins.DataSource = null;
                dgv_Admins.Rows.Clear();
                dgv_Admins.Columns.Clear();
                dgv_Admins.DataSource = await TableAdapterDB.AdminsViewAsync();
                dgv_Admins.Columns[0].Visible = false;
                dgv_Admins.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при обновлении данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
