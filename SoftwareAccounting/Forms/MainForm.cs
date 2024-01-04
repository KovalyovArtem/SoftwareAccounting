using SoftwareAccounting.Classes;
using SoftwareAccounting.Forms;
using SoftwareAccounting.Forms.Insert;
using SoftwareAccounting.Forms.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting
{
    public partial class MainForm : Form
    {
        private int IDTableChoose = 1, rowIndex, rowID;
        public MainForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            lbAdminStatusMenu.Text = Server.Login + " - " + Server.Status;
            
            btn_Admin.Visible = Server.IsAdmin;
            btn_Insert.Visible = btn_Update.Visible = btn_Remove.Visible = btn_ChoosePC.Visible = Server.IsAdmin;

            //ExistOrAlterComputerMethod();
            await RefreshData();
            //Automatization.AutoInsertSoftwareMethod();
            //AutoDeleteSoftwareMethod();
            //Parallel.Invoke(() => { while (true) AutoInsertSoftwareMethod(); },
            //                () => { while (true) AutoDeleteSoftwareMethod(); });
            //new Thread(() => { while (true) AutoInsertSoftwareMethod(); }).Start(); 
        }

        private void AutoInsertSoftwareMethod()
        {
            Automatization.AutoInsertSoftwareMethod();
            Thread.Sleep(60000);
        }

        private void AutoDeleteSoftwareMethod()
        {
            Automatization.AutoDeleteSoftwareMethod();
            //Thread.Sleep(60000);
        }

        private void ExistOrAlterComputerMethod()
        {
            string macAdress = GetMacAdressPC();

            if (macAdress == "" || macAdress == null)
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool existMacAdress = Server.ExistMacAdressAsync(macAdress);
            if (!existMacAdress)
                Automatization.AutoInsertPCMethod();
            else {
                TableAdapterDB.MacAdress = macAdress;
                Server.getComputerID(macAdress);
            }
        }

        private string GetMacAdressPC()
        {
            ManagementObjectCollection queryCollection = 
                new ManagementObjectSearcher($@"\\.\root\cimv2",
                "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'").Get();

            foreach (ManagementObject m in queryCollection)
                return m["MACAddress"].ToString();
            return null;
        }

        private void ClearDataGridView()
        {
            dgv_Main.Columns[0].Visible = false;
            dgv_Main.ClearSelection();
        }

        private void ClearDSAndAllDgv()
        {
            tbx_Search.Clear();
            dgv_Main.DataSource = null;
            dgv_Main.Rows.Clear();
            dgv_Main.Columns.Clear();
        }

        private async void btn_DolzhnostView_Click(object sender, EventArgs e)
        {
            ClearDSAndAllDgv();
            dgv_Main.DataSource = await TableAdapterDB.DolzhnostViewAsync();
            IDTableChoose = 0;
            ClearDataGridView();
        }

        public async Task RefreshData()
        {
            switch (IDTableChoose)
            {
                case 0:
                    ClearDSAndAllDgv();
                    dgv_Main.DataSource = await TableAdapterDB.DolzhnostViewAsync();
                    IDTableChoose = 0;
                    ClearDataGridView();
                    break;
                case 1:
                    ClearDSAndAllDgv();
                    dgv_Main.DataSource = await TableAdapterDB.InstallingView();
                    IDTableChoose = 1;
                    ClearDataGridView();
                    break;
            }
            dgv_Main.Invalidate();
        }

        public async void GetInstallingByFilter(int id)
        {
            ClearDSAndAllDgv();
            dgv_Main.DataSource = await TableAdapterDB.InstallingSELECTByPCView(id);
            IDTableChoose = 1;
            ClearDataGridView();
        }

        private async void btn_SoftwareView_Click(object sender, EventArgs e)
        {
            ClearDSAndAllDgv();
            dgv_Main.DataSource = await TableAdapterDB.InstallingView();
            IDTableChoose = 1;
            ClearDataGridView();
        }

        private async void btn_Refresh_Click(object sender, EventArgs e)
        {
            await RefreshData();
        }

        private void btn_EmployeeViewForm_Click(object sender, EventArgs e)
        {
            new EmployersForm().ShowDialog();
        }

        private void btn_AdminForm_Click(object sender, EventArgs e)
        {
            new AdminForm().ShowDialog();
        }

        private async void btn_Remove_Click(object sender, EventArgs e)
        {
            if (IDTableChoose == -1)
            {
                MessageBox.Show("Выберите таблицу!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgv_Main.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //int selectedIndex = dgv_Main.SelectedRows[0].Index;
                //int rowID = int.Parse(dgv_Main[0, selectedIndex]
                //    .Value.ToString());
                if (dgv_Main.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgv_Main.SelectedRows)
                    {
                        rowID = Convert.ToInt32(row.Cells[0].Value);
                        await DeleteFromDgvDB(rowID);
                    }
                }
                else
                {
                    rowIndex = dgv_Main.SelectedCells[0].RowIndex;
                    rowID = Convert.ToInt32(dgv_Main.Rows[rowIndex].Cells[0].Value);
                    await DeleteFromDgvDB(rowID);
                }
            }
        }

        private async Task DeleteFromDgvDB(int rowID)
        {
            switch (IDTableChoose)
            {
                case 0:
                    await UpdateDB.DeleteRowAsync("Dolzhnost", "DolzhnostID", rowID);
                    break;
                case 1:
                    MessageBox.Show("В данной таблице данные обновляются автоматически.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            await RefreshData();
        }

        private async void tbx_Search_TextChanged(object sender, EventArgs e)
        {
            if (IDTableChoose == -1)
            {
                MessageBox.Show("Выберите таблицу!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbx_Search.Clear();
                return;
            }
            string searchTerm = tbx_Search.Text;
            DataView dv = null;
            DataTable dt = null;
            switch (IDTableChoose)
            {
                case 0:
                    dt = await TableAdapterDB.DolzhnostViewAsync();
                    dv = dt.DefaultView;
                    dv.RowFilter = $"[] LIKE '%{searchTerm}%' " +
                        $"OR [Имя] LIKE '%{searchTerm}%'" +
                        $"OR [Отчество] LIKE '%{searchTerm}%'" +
                        $"OR [Должность] LIKE '%{searchTerm}%'" +
                        $"OR [Категория] LIKE '%{searchTerm}%'" +
                        $"OR [Название имущества] LIKE '%{searchTerm}%'" +
                        $"OR CONVERT([Количество], System.String) LIKE '%{searchTerm}%'" +
                        $"OR [Ед.изм.] LIKE '%{searchTerm}%'" +
                        $"OR CONVERT([Дата выдачи], System.String) LIKE '%{searchTerm}%'" +
                        $"OR [Описание] LIKE '%{searchTerm}%'" +
                        $"OR CONVERT([Цена], System.String) LIKE '%{searchTerm}%'";
                    break;
                case 1:
                    dt = await TableAdapterDB.InstallingView();
                    dv = dt.DefaultView;
                    dv.RowFilter = $"Категория LIKE '%{searchTerm}%' " +
                        $"OR [Название имущества] LIKE '%{searchTerm}%'" +
                        $"OR CONVERT([Общее количество имущества], System.String) LIKE '%{searchTerm}%'" +
                        $"OR CONVERT([На складе], System.String) LIKE '%{searchTerm}%'" +
                        $"OR [Ед.изм.] LIKE '%{searchTerm}%'" +
                        $"OR [Описание] LIKE '%{searchTerm}%'" +
                        $"OR CONVERT([Цена], System.String) LIKE '%{searchTerm}%'";
                    break;
            }
            dgv_Main.DataSource = dv.ToTable();
        }

        private void btn_UnLogin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закончить сессию?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Application.Restart();
        }

        private void btn_ChoosePC_Click(object sender, EventArgs e)
        {
            new ChooseFilterForSortByPC(this).ShowDialog();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            switch (IDTableChoose)
            {
                case 0:
                    new InsertDolzhnost(this).ShowDialog();
                    break;
                case 1:
                    MessageBox.Show("В данную таблицу данные добавляются автоматически.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (IDTableChoose == -1)
            {
                MessageBox.Show("Выберите таблицу!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgv_Main.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rowIndex = dgv_Main.SelectedCells[0].RowIndex;
            rowID = Convert.ToInt32(dgv_Main.Rows[rowIndex].Cells[0].Value);

            switch (IDTableChoose)
            {
                case 0:
                    new UpdateDolzhnost(rowID, this).ShowDialog();
                    break;
                case 1:
                    MessageBox.Show("В данной таблице данные обновляются автоматически.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
