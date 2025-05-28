using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;
using System.Threading.Tasks;
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
                    MessageBox.Show($"������ ��������� ������ ��� ������ �����");
                    return null;
                }
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� ���������: {ex.Message}");
                return null;
            }
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
                        MessageBox.Show($"������ ��������� id �� ������");
                        return;
                    }

                    var res = await _deviceService.GetDeviceSoftwareInfo(deviceId);
                    if (res == null)
                    {
                        MessageBox.Show($"������ ��������� ������ ��� ������ �����");
                        return;
                    }
                    dgv_Additional.DataSource = res;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            if (MessageBox.Show("�� ������������� ������ �����?", "�����", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private async void ts_item_Accounting_Click(object sender, EventArgs e)
        {
            var scanResult = await Task.Run(() => _deviceService.StartDeviceScan());
            if (scanResult == false)
                MessageBox.Show("������������ �� � �� ��������� � �������.");
            else
                MessageBox.Show("������������ �� � �� ��������� �������.");
        }

        private async void ts_item_Accounting_Once_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Main.SelectedCells.Count > 0 || dgv_Main.SelectedRows.Count > 0)
                {
                    var rowIndex = dgv_Main.SelectedCells[0].RowIndex;
                    if(Convert.ToBoolean(dgv_Main.Rows[rowIndex].Cells[5].Value) == false)
                    {
                        MessageBox.Show($"������ �� �� � ����!");
                        return;
                    }

                    var deviceId = dgv_Main.Rows[rowIndex].Cells[0].Value.ToString();
                    if (string.IsNullOrEmpty(deviceId))
                    {
                        MessageBox.Show($"������ ��������� id �� ������");
                        return;
                    }

                    var scanResult = await Task.Run(() => _deviceService.StartDeviceScan(deviceId));
                    if (scanResult == false)
                        MessageBox.Show("������������ �� � �� ��������� � �������.");
                    else
                        MessageBox.Show("������������ �� � �� ��������� �������.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}