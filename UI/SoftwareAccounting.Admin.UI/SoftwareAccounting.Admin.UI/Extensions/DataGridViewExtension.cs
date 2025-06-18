using SoftwareAccounting.Common.Models.DataGridViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Admin.UI.Extensions
{
    public static class DataGridViewExtensions
    {
        public static void AddButtonColumn(
            this DataGridView dataGridView,
            DgvButtonSettingsModel settings)
        {
            var existingColumn = dataGridView.Columns[settings.ColumnName];
            if (existingColumn != null)
                dataGridView.Columns.Remove(existingColumn);

            dataGridView.AutoGenerateColumns = false;

            var buttonColumn = new DataGridViewButtonColumn
            {
                Name = settings.ColumnName,
                HeaderText = settings.HeaderText,
                Text = settings.ButtonText,
                UseColumnTextForButtonValue = true
            };

            dataGridView.Columns.Add(buttonColumn);
        }

        public static void UploadData<T>(
            this DataGridView dataGridView,
            List<T> data,
            int hideColumns)
        {
            dataGridView.ClearSelection();

            dataGridView.DataSource = null;

            dataGridView.AutoGenerateColumns = true;

            dataGridView.DataSource = data;

            dataGridView.AutoGenerateColumns = false;

            for (int i = 0; i < hideColumns; i++)
                dataGridView.Columns[i].Visible = false;

            dataGridView.ClearSelection();
        }
    }
}
