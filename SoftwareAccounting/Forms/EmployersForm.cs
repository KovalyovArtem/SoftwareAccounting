using SoftwareAccounting.Classes;
using SoftwareAccounting.Forms.Insert;
using SoftwareAccounting.Forms.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SoftwareAccounting.Forms
{
    public partial class EmployersForm : Form
    {
        private int rowID, rowIndex;
        DataView dv = null;
        #region DLL PlaceHolder для TextBoxes
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd,
                                                int msg,
                                                int wParam,
                                                [MarshalAs(
                                                UnmanagedType.LPWStr)]
                                                string lParam);
        #endregion

        public EmployersForm()
        {
            InitializeComponent();
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
            if (!string.IsNullOrWhiteSpace(tbx_Dolzhnost.Text))
                filter.AppendFormat("Должность LIKE '%{0}%' AND ", tbx_Dolzhnost.Text);

            if (filter.Length >= 5)
                filter.Length -= 5;

            DataTable dt = await TableAdapterDB.PeoplesViewAsync();
            dv = dt.DefaultView;
            dv.RowFilter = filter.ToString();

            dgv_Employee.DataSource = dv.ToTable();
        }

        private async void EmployersForm_Load(object sender, EventArgs e)
        {
            dgv_Employee.DataSource = await TableAdapterDB.PeoplesViewAsync();
            dgv_Employee.Columns[0].Visible = false;

            SendMessage(this.tbx_Date.Control.Handle, EM_SETCUEBANNER,
               0, "Дата рождения");
            SendMessage(this.tbx_Dolzhnost.Control.Handle, EM_SETCUEBANNER,
               0, "Должность");
            SendMessage(this.tbx_FullName.Control.Handle, EM_SETCUEBANNER,
               0, "Отчество");
            SendMessage(this.tbx_Name.Control.Handle, EM_SETCUEBANNER,
               0, "Имя");
            SendMessage(this.tbx_SecondName.Control.Handle, EM_SETCUEBANNER,
               0, "Фамилия");
            SendMessage(this.tbx_Telephone.Control.Handle, EM_SETCUEBANNER,
               0, "Телефон");
        }

        private void btn_Add_Click(object sender, EventArgs e)
            => new InsertPeopleForm(this).ShowDialog();

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dgv_Employee.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Выберите строку для измнения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rowIndex = dgv_Employee.SelectedCells[0].RowIndex;
            rowID = Convert.ToInt32(dgv_Employee.Rows[rowIndex].Cells[0].Value);
            new UpdatePeopleForm(rowID, this).ShowDialog();
        }

        private async void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_Employee.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (dgv_Employee.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgv_Employee.SelectedRows)
                    {
                        rowID = Convert.ToInt32(row.Cells[0].Value);
                        await DeleteFromDgvDB(rowID);
                    }
                }
                else
                {
                    rowIndex = dgv_Employee.SelectedCells[0].RowIndex;
                    rowID = Convert.ToInt32(dgv_Employee.Rows[rowIndex].Cells[0].Value);
                    await DeleteFromDgvDB(rowID);
                }
            }

            await this.RefreshData();
        }

        public async Task RefreshData()
        {
            if(dv != null) dv.RowFilter = null;
            dgv_Employee.DataSource = await TableAdapterDB.PeoplesViewAsync();
            dgv_Employee.Invalidate();
        }

        private async Task DeleteFromDgvDB(int rowID)
            => await UpdateDB.DeleteRowAsync("Employee", "EmployeeID", rowID);

        private async void btn_Refresh_Click(object sender, EventArgs e)
            => await RefreshData();
    }
}
