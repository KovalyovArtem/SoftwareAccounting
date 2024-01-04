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
    public partial class UpdateAdminsForm : Form
    {
        private string Login;
        private AdminForm admForm;

        public UpdateAdminsForm(string _Login, AdminForm admForm)
        {
            InitializeComponent();
            
            Login = _Login;
            this.admForm = admForm;
        }

        private async void UpdateAdminsForm_Load(object sender, EventArgs e)
        {
            DataTable dt = await TableAdapterDB.SelectUserByLoginViewAsync(Login);
            tbx_Login.Text = dt.Rows[0][0].ToString();
            tbx_Pass.Text = dt.Rows[0][1].ToString();
            cbx_isAdmin.Checked = (bool)dt.Rows[0][2];
        }

        private void btn_Decline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_Edit_Click(object sender, EventArgs e)
        {
            if (lb_info.Visible)
                lb_info.Visible = false;
            (bool result, string text) = await UpdateDB.UpdateAdminsAsync(
                                                    Login, tbx_Login.Text,
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

            await admForm.RefresgDgv();

            if (!cbx_Check.Checked)
                this.Close();
        }
    }
}
