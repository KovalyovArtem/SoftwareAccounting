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
    public partial class InsertDolzhnost : Form
    {
        private MainForm mainForm;

        public InsertDolzhnost(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btn_Decline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_Add_Click(object sender, EventArgs e)
        {
            if (lb_info.Visible)
                lb_info.Visible = false;

            (bool result, string text) = await InsertDB.InsertDolzhnostAsync(tbx_Name.Text);

            if (!result)
            {
                MessageBox.Show(text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lb_info.Text = text;
            lb_info.Visible = true;
            lb_info.ForeColor = Color.Green;
            tbx_Name.Clear();

            await mainForm.RefreshData();

            if (!cbx_Check.Checked)
                this.Close();
        }
    }
}
