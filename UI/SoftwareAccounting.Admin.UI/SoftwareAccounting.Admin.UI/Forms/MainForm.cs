using SoftwareAccounting.Admin.UI.Extensions;
using SoftwareAccounting.Admin.UI.Forms;
using SoftwareAccounting.Admin.UI.Forms.PeopleForms;
using SoftwareAccounting.Admin.UI.Forms.PeopleForms.EmployerForms;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.DataGridViewModels;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;
using System.Data.Common;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SoftwareAccounting.Admin.UI
{
    public partial class MainForm : Form
    {
        private readonly IDeviceService _deviceService;

        private int _globalColumnIndex;
        private int _globalRowIndex;

        private List<DeviceInfoModel> _devices;
        private List<SoftwareInfoModel> _softwares;

        public MainForm()
        {
            InitializeComponent();
            splitContainerMain.Panel2Collapsed = true;

            _deviceService = Program.deviceService;

            var devices = Task.Run(() => GetDevicesList());
            _devices = devices.Result;

            RefreshDataGridViewMain(_devices);
        }

        private void RefreshDataGridViewMain<T>(List<T> data)
        {
            dgv_Main.UploadData(data, 2);

            dgv_Main.AddButtonColumn(new DgvButtonSettingsModel
            {
                ButtonText = "Создание",
                ColumnName = "btn_CreateQr",
                HeaderText = "Qr-code"
            });
        }

        private async Task<List<DeviceInfoModel>> GetDevicesList()
        {
            try
            {
                var res = await _deviceService.GetDevices();
                if (res == null)
                {
                    MessageBox.Show($"Ошибка получения данных или данные пусты");
                    return null;
                }
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки устройств: {ex.Message}");
                return null;
            }
        }

        private async void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
                {
                    var rowIndex = dgv_Main.SelectedCells[0].RowIndex;
                    var deviceId = dgv_Main.Rows[rowIndex].Cells[0].Value.ToString();

                    var grid = sender as DataGridView;
                    var clickedColumnName = grid.Columns[e.ColumnIndex].Name;

                    if (clickedColumnName == "btn_CreateQr")
                        return;

                    _globalColumnIndex = e.ColumnIndex;
                    _globalRowIndex = e.RowIndex;

                    splitContainerMain.Panel2Collapsed = false;

                    if (string.IsNullOrEmpty(deviceId))
                    {
                        MessageBox.Show($"Ошибка получения id из ячейки");
                        return;
                    }

                    var res = await _deviceService.GetDeviceSoftwareInfo(deviceId);
                    if (res == null)
                    {
                        MessageBox.Show($"Ошибка получения данных или данные пусты");
                        return;
                    }
                    dgv_Additional.DataSource = res;
                    _softwares = res;
                    dgv_Additional.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Main_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;
            var clickedColumnName = grid.Columns[e.ColumnIndex].Name;

            if (clickedColumnName == "btn_CreateQr")
            {
                CreateQrCodeButtonClick(e);
            }
        }

        private void CreateQrCodeButtonClick(DataGridViewCellEventArgs e)
        {
            try
            {
                new QRCodeGenerationForm(dgv_Main.Rows[e.RowIndex].Cells[0].Value.ToString()).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private async void ts_item_Accounting_Click(object sender, EventArgs e)
        {
            var scanResult = await Task.Run(() => _deviceService.StartDeviceScan());
            if (scanResult == false)
                MessageBox.Show("Сканирование ПО у ПК произошло с ошибкой.");
            else
                MessageBox.Show("Сканирование ПО у ПК завершено успешно.");
        }

        private async void ts_item_Accounting_Once_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Main.SelectedCells.Count > 0 || dgv_Main.SelectedRows.Count > 0)
                {
                    var rowIndex = dgv_Main.SelectedCells[0].RowIndex;
                    if (Convert.ToBoolean(dgv_Main.Rows[rowIndex].Cells[6].Value) == false)
                    {
                        MessageBox.Show($"Данный ПК не в сети!");
                        return;
                    }

                    var deviceId = dgv_Main.Rows[rowIndex].Cells[0].Value.ToString();
                    if (string.IsNullOrEmpty(deviceId))
                    {
                        MessageBox.Show($"Ошибка получения id из ячейки");
                        return;
                    }

                    var scanResult = await Task.Run(() => _deviceService.StartDeviceScan(deviceId));
                    if (scanResult == false)
                        MessageBox.Show("Сканирование ПО у ПК произошло с ошибкой.");
                    else
                        MessageBox.Show("Сканирование ПО у ПК завершено успешно.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ts_item_Users_Click(object sender, EventArgs e)
        {
            new UserForm().ShowDialog();
        }

        private void ts_item_Employers_Click(object sender, EventArgs e)
        {
            new EmployerForm().ShowDialog();
        }

        private void btn_RefreshDevices_Click(object sender, EventArgs e)
        {
            var devices = Task.Run(() => GetDevicesList());
            _devices = devices.Result;

            RefreshDataGridViewMain(_devices);
        }

        private void tbx_SearchDevice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_SearchDevice.Text))
                RefreshDataGridViewMain(_devices);

            var filteredDevices = _devices.Where(x =>
                                                    (x.OsArchitecture?.ToLower().Contains(tbx_SearchDevice.Text) ?? false) ||
                                                    (x.OsName?.ToLower().Contains(tbx_SearchDevice.Text) ?? false) ||
                                                    (x.IpAddress?.ToLower().Contains(tbx_SearchDevice.Text) ?? false) ||
                                                    (x.MacAddress?.ToLower().Contains(tbx_SearchDevice.Text) ?? false) ||
                                                    (x.Synonym?.ToLower().Contains(tbx_SearchDevice.Text) ?? false) ||
                                                    (x.SotrFullName?.ToLower().Contains(tbx_SearchDevice.Text) ?? false)
                                                ).ToList();

            RefreshDataGridViewMain(filteredDevices);
        }

        private void tbx_SearchSoftware_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_SearchSoftware.Text))
                dgv_Additional.DataSource = _softwares;

            var filteredSoftware = _softwares.Where(x =>
                                                    (x.ProgrammName?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false) ||
                                                    (x.ProgrammVersion?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false) ||
                                                    (x.ProgrammDeveloper?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false) ||
                                                    (x.ProgrammLicense?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false) ||
                                                    (x.ProgrammInstalledDate?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false) ||
                                                    (x.ProgrammSize?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false) ||
                                                    (x.ProgrammInstallLocation?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false) ||
                                                    (x.ProgrammPublisher?.ToLower().Contains(tbx_SearchSoftware.Text) ?? false)
                                                ).ToList();

            dgv_Additional.DataSource = filteredSoftware;
        }
    }
}