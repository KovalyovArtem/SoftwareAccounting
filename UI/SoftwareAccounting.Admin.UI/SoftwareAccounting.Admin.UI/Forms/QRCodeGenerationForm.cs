using SkiaSharp.QrCode;
using SoftwareAccounting.Common.Utils;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting.Admin.UI.Forms
{
    public partial class QRCodeGenerationForm : Form
    {
        private readonly IDeviceService _deviceService;

        private readonly string _deviceId;

        private string _webUiFullPath;

        public QRCodeGenerationForm(string deviceId)
        {
            InitializeComponent();

            _deviceService = Program.deviceService;

            _deviceId = deviceId;
        }

        private async void QRCodeGenerationForm_Load(object sender, EventArgs e)
        {
            _webUiFullPath = await Task.Run(() => _deviceService.GetWebUrlForQrCode(_deviceId));

            try
            {
                var content = _webUiFullPath;
                var qrCodeBytes = new QrCodeHelper().QrCodeGenerate(content);

                using var ms = new MemoryStream(qrCodeBytes);
                var image = Image.FromStream(ms);
                pbx_QrCode.Image?.Dispose();
                pbx_QrCode.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации QR-кода: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                var content = _webUiFullPath + "\n\n" + tbx_AdditionalInfo.Text;
                var qrCodeBytes = new QrCodeHelper().QrCodeGenerate(content);

                using var ms = new MemoryStream(qrCodeBytes);
                var image = Image.FromStream(ms);
                pbx_QrCode.Image?.Dispose();
                pbx_QrCode.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации QR-кода: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
            save.FileName = _deviceId + "_QRCode";
            if (save.ShowDialog() == DialogResult.OK)
                pbx_QrCode.Image.Save(save.FileName);
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            if (load.ShowDialog() == DialogResult.OK)
                pbx_QrCode.ImageLocation = load.FileName;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.DefaultPageSettings.PaperSize =
                    new PaperSize("A7", 298, 420);
                printDocument.Print();
            }
        }
    }
}
