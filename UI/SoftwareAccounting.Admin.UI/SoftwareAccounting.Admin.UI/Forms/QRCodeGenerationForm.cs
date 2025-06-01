using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting.Admin.UI.Forms
{
    public partial class QRCodeGenerationForm : Form
    {
        private readonly string _deviceId;

        public QRCodeGenerationForm(string deviceId)
        {
            InitializeComponent();

            _deviceId = deviceId;
        }
    }
}
