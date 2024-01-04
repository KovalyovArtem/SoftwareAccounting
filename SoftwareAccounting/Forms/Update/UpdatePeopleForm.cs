using SoftwareAccounting.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting.Forms.Update
{
    public partial class UpdatePeopleForm : Form
    {
        private int ID;
        private EmployersForm employersForm;

        public UpdatePeopleForm(int iD, EmployersForm employersForm)
        {
            InitializeComponent();

            ID = iD;
            this.employersForm = employersForm;
        }

        private async void UpdatePeopleForm_Load(object sender, EventArgs e)
        {
            DataTable dt = await TableAdapterDB.SelectPeoplesByIDViewAsync(ID);
            tbx_SecondName.Text = dt.Rows[0][1].ToString();
            tbx_Name.Text = dt.Rows[0][2].ToString();
            tbx_FullName.Text = dt.Rows[0][3].ToString();
            tbx_Telephone.Text = dt.Rows[0][4].ToString();
            dtp_BirthDate.Text = dt.Rows[0][5].ToString();
            tbx_INN.Text = dt.Rows[0][6].ToString();
            tbx_Number.Text = dt.Rows[0][7].ToString();
            tbx_Seria.Text = dt.Rows[0][8].ToString();
            tbx_KemVidan.Text = dt.Rows[0][9].ToString();
            dtp_DateGive.Text = dt.Rows[0][10].ToString();
            tbx_KodPodrazd.Text = dt.Rows[0][11].ToString();

            cbx_DolzhnostName.DataSource = await TableAdapterDB.SelectDolzhnostAsync();
            var selectedRow = cbx_DolzhnostName.Items.Cast<DataRowView>()
                .FirstOrDefault(rowView => (int)rowView["DolzhnostID"] == (int)dt.Rows[0][0]);
            cbx_DolzhnostName.SelectedIndex = cbx_DolzhnostName.Items.IndexOf(selectedRow);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_Edit_Click(object sender, EventArgs e)
        {
            (bool result, string text) = await UpdateDB.UpdatePeoplesAsync(
                                                     ID,
                                                     (int)cbx_DolzhnostName.SelectedValue,
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
            lb_info.ForeColor = Color.Green;
            lb_info.Visible = true;

            if (employersForm != null)
                await employersForm.RefreshData();
            if (!cbx_Check.Checked)
                this.Close();
        }
    }
}
