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
            if (dataGridView.Columns.Contains(settings.ColumnName))
                return;

            var buttonColumn = new DataGridViewButtonColumn
            {
                Name = settings.ColumnName,
                HeaderText = settings.HeaderText,
                Text = settings.ButtonText,
                UseColumnTextForButtonValue = true
            };

            dataGridView.Columns.Add(buttonColumn);
        }
    }
}
