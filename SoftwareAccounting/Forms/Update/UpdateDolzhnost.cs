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

namespace SoftwareAccounting.Forms.Update
{
    public partial class UpdateDolzhnost : Form
    {
        private int ID;
        private MainForm mainForm;

        public UpdateDolzhnost(int id, MainForm mainForm)
        {
            InitializeComponent();
            ID = id;
            this.mainForm = mainForm;
        }

        private async void UpdateDolzhnost_Load(object sender, EventArgs e)
        {
            tbx_Name.Text = await TableAdapterDB.SelectDolzhnostByIDViewAsync(ID);
        }

        private void btn_Decline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_Update_Click(object sender, EventArgs e)
        {
            if (lb_info.Visible)
                lb_info.Visible = false;
            (bool result, string text) =
                await UpdateDB.UpdateDolzhnostAsync(ID, tbx_Name.Text);

            if (!result)
            {
                MessageBox.Show(text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lb_info.Text = text;
            lb_info.ForeColor = Color.Green;
            lb_info.Visible = true;

            await mainForm.RefreshData();

            if (!cbx_Check.Checked)
                this.Close();
        }
    }
}
