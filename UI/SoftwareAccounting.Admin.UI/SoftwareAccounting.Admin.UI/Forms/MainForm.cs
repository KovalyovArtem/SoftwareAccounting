using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SoftwareAccounting.Admin.UI
{
    public partial class MainForm : Form
    {
        private readonly IDeviceService _deviceService;

        public MainForm()
        {
            InitializeComponent();
            splitContainerMain.Panel2Collapsed = true;

            _deviceService = Program.deviceService;

            var devices = Task.Run(() => GetDevicesList());
            dgv_Main.DataSource = devices.Result;
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

        private void ts_item_Accounting_Click(object sender, EventArgs e)
        {

        }

        private async void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var rowIndex = dgv_Main.SelectedCells[0].RowIndex;
                    var deviceId = dgv_Main.Rows[rowIndex].Cells[0].Value.ToString();

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}