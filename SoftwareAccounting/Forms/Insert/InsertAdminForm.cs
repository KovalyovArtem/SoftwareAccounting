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

namespace SoftwareAccounting.Forms.Insert
{
    public partial class InsertAdminForm : Form
    {
        private AdminForm adminForm;
        DataView dv = null;

        public InsertAdminForm(AdminForm adminForm)
        {
            InitializeComponent();
            this.adminForm = adminForm;
        }

        private async void InsertAdminForm_Load(object sender, EventArgs e)
        {
            dgv_Main.DataSource = await TableAdapterDB.PeoplesViewAsync();
            dgv_Main.Columns[0].Visible = false;
        }

        private void tbxs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSearch();
        }

        private async void PerformSearch()
        {
            StringBuilder filter = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(tbx_SecondName.Text))
                filter.AppendFormat("Фамилия LIKE '%{0}%' AND ", tbx_SecondName.Text);
            if (!string.IsNullOrWhiteSpace(tbx_Name.Text))
                filter.AppendFormat("Имя LIKE '%{0}%' AND ", tbx_Name.Text);
            if (!string.IsNullOrWhiteSpace(tbx_FullName.Text))
                filter.AppendFormat("Отчество LIKE '%{0}%' AND ", tbx_FullName.Text);
            if (!string.IsNullOrWhiteSpace(tbx_Date.Text))
                filter.AppendFormat("CONVERT([Дата рождения], System.String) LIKE '%{0}%' AND ", tbx_Date.Text);
            if (!string.IsNullOrWhiteSpace(tbx_Dol.Text))
                filter.AppendFormat("Должность LIKE '%{0}%' AND ", tbx_Dol.Text);
            if (!string.IsNullOrWhiteSpace(tbx_Tel.Text))
                filter.AppendFormat("Телефон LIKE '%{0}%' AND ", tbx_Tel.Text);

            if (filter.Length >= 5)
                filter.Length -= 5;

            DataTable dt = await TableAdapterDB.PeoplesViewAsync();
            dv = dt.DefaultView;
            dv.RowFilter = filter.ToString();

            dgv_Main.DataSource = dv.ToTable();
        }

        private void btn_Decline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_Add_Click(object sender, EventArgs e)
        {
            if (lb_info.Visible)
                lb_info.Visible = false;

            var rowIndex = dgv_Main.SelectedCells[0].RowIndex;
            var rowID = Convert.ToInt32(dgv_Main.Rows[rowIndex].Cells[0].Value);

            (bool result, string text) = await InsertDB.InsertAdminsAsync(
                                            rowID, tbx_Login.Text,
                                            tbx_Pass.Text,
                                            cbx_isAdmin.Checked);

            if (!result)
            {
                MessageBox.Show(text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lb_info.Text = text;
            lb_info.ForeColor = Color.Green;
            lb_info.Visible = true;
            tbx_Login.Clear();
            tbx_Pass.Clear();

            await adminForm.RefresgDgv();

            if (!cbx_Check.Checked)
                this.Close();
        }
    }
}
