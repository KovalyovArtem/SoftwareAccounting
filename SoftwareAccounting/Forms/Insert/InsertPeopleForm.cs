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
    public partial class InsertPeopleForm : Form
    {
        private EmployersForm employers;

        public InsertPeopleForm(EmployersForm employers)
        {
            InitializeComponent();

            dtp_BirthDate.Value = DateTime.Now;
            dtp_BirthDate.MaxDate = DateTime.Now;
            this.employers = employers;
        }

        private async void InsertPeopleForm_Load(object sender, EventArgs e)
        {
            cbx_DolzhnostName.DataSource = await TableAdapterDB.SelectDolzhnostAsync(null);
        }

        private void btn_Decline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_Add_Click(object sender, EventArgs e)
        {
            if (lb_info.Visible)
                lb_info.Visible = false;

            (bool result, string text) = await InsertDB.InsertPeoplesAsync((int)cbx_DolzhnostName.SelectedValue,
                                                     tbx_SecondName.Text,
                                                     tbx_Name.Text,
                                                     tbx_FullName.Text,
                                                     tbx_Telephone.Text,
                                                     dtp_BirthDate.Value.Date,
                                                     tbx_INN.Text,
                                                     tbx_Seria.Text,
                                                     tbx_Number.Text,
                                                     tbx_KemVidan.Text,
                                                     dtp_DateGive.Value.Date,
                                                     tbx_KodPodrazd.Text);

            if (!result)
            {
                MessageBox.Show(text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lb_info.Text = text;
            lb_info.Visible = true;
            lb_info.ForeColor = Color.Green;
            tbx_SecondName.Clear();
            tbx_Name.Clear();
            tbx_FullName.Clear();
            tbx_Telephone.Clear();
            tbx_INN.Clear();
            tbx_Seria.Clear();
            tbx_Number.Clear();
            tbx_KemVidan.Clear();
            tbx_KodPodrazd.Clear();

            await employers.RefreshData();

            if (!cbx_Check.Checked)
                this.Close();
        }
    }
}
