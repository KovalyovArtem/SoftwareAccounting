using SoftwareAccounting.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoftwareAccounting.Classes
{
    public static class Automatization
    {
        // Добавление ПО
        public static void AutoInsertSoftwareMethod()
        {
            List<ComputerProgrammViewModel> model = new List<ComputerProgrammViewModel>();
            GetInfoAboutProgrammsMethod(ref model);

            CompareData(model);
        }

        // Добаление ПК
        public static async void AutoInsertPCMethod()
        {
            ComputerViewModel model = new ComputerViewModel();
            GetInfoAboutPCMethod(ref model);

            await InsertDB.InsertComputerAsync(model);

            Server.getComputerID(model.MacAdress);
        }

        #region Собирание инфы для добавления в БД ПО компьютера

        private static void CompareData(List<ComputerProgrammViewModel> model)
        {
            DataTable dt = TableAdapterDB.InstallingSELECTView();

            var missingInDataTable = model.Where(obj => !DataTableContains(dt, obj.NamePO)).ToList();

            var differences = model.Join(dt.AsEnumerable(),
                              obj => obj.NamePO,
                              row => row.Field<string>("SoftwareName"),
                              (obj, row) => new { Object = obj, Row = row })
                       .Where(pair => !pair.Object.VersionPO.Equals(pair.Row.Field<string>("Version")) ||
                                     pair.Object.InstallDate != pair.Row.Field<DateTime>("InstallDate"))
                       .ToList();

            var differencesViewModel = differences.Select(pair => new ComputerProgrammViewModel
            {
                NamePO = pair.Object.NamePO,
                VersionPO = pair.Object.VersionPO,
                InstallDate = pair.Object.InstallDate,
                VendorPO = pair.Object.VendorPO
            })
            .ToList();

            if (missingInDataTable.Count > 0)
                InsertMissingsProgramms(missingInDataTable);
            if (differences.Count > 0)
                UpdateDifferenceProgramms(differencesViewModel);
        }

        private static async void InsertMissingsProgramms(List<ComputerProgrammViewModel> model)
        {
            foreach(var item in model)
                await InsertDB.InsertSoftwareAsync(item);
        }

        private static async void UpdateDifferenceProgramms(List<ComputerProgrammViewModel> model)
        {
            foreach (var item in model)
                await UpdateDB.UpdateSoftwareAsync(item);
        }

        static bool DataTableContains(DataTable dataTable, string Name)
        {
            return dataTable.AsEnumerable().Any(row => row.Field<string>("SoftwareName") == Name);
        }

        private static void GetInfoAboutProgrammsMethod(ref List<ComputerProgrammViewModel> model)
        {
            ComputerProgrammViewModel item = new ComputerProgrammViewModel();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\\.\root\cimv2", "SELECT * FROM Win32_Product");
            ManagementObjectCollection queryCollection = searcher.Get();

            DateTime currentDate = new DateTime(2023, 12, 11); //DateTime.Now;

            foreach (ManagementObject m in queryCollection)
            {
                if (m["InstallDate"] != null)
                {
                    string installDateString = m["InstallDate"].ToString();

                    // Попробуйте преобразовать строку в дату
                    if (DateTime.TryParseExact(installDateString, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime InstallDate))
                    {
                        if (InstallDate.Date == currentDate.Date)
                        {
                            //Console.WriteLine("Имя программы: " + m["Name"] + "  " + installDate + "  " + m["Version"] + "  " + m["Vendor"]);
                            item.NamePO = (string)m["Name"];
                            item.InstallDate = InstallDate;
                            item.VersionPO = (string)m["Version"];
                            item.VendorPO = (string)m["Vendor"];
                            model.Add(item);
                        }
                    }
                }
            }
        }

        #endregion

        #region Собирание инфы для автоматического добавления компьютера при входе в ПО

        private static void GetInfoAboutPCMethod(ref ComputerViewModel model)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher($@"\\.\root\cimv2", "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");

            // Получение информации о сетевых адаптерах
            ManagementObjectCollection queryCollection = searcher.Get();

            foreach (ManagementObject m in queryCollection)
            {
                // Вывод информации о сетевом адаптере
                //Console.WriteLine("Имя компьютера: " + Environment.MachineName);
                model.ComputerName = Environment.MachineName;
                //Console.WriteLine("IPv4-адрес: " + GetIPv4Address(m));
                model.IPAdress = GetIPv4Address(m);
                //Console.WriteLine("MAC-адрес: " + m["MACAddress"]);
                model.MacAdress = m["MACAddress"].ToString();
            }

            ManagementObjectSearcher osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectCollection osQueryCollection = osSearcher.Get();

            foreach (ManagementObject osInfo in osQueryCollection)
            {
                //Console.WriteLine("Версия операционной системы: " + osInfo["Version"]);
                model.OSVersion = osInfo["Version"].ToString();
                //Console.WriteLine("Название операционной системы: " + osInfo["Caption"]);
                model.OSystem = osInfo["Caption"].ToString();
            }
        }

        private static string GetIPv4Address(ManagementObject networkAdapter)
        {
            string[] addresses = (string[])networkAdapter["IPAddress"];
            if (addresses != null && addresses.Length > 0)
            {
                foreach (string address in addresses)
                {
                    if (address.Contains(":"))
                        continue;

                    return address;
                }
            }
            return "N/A";
        }

        #endregion

        #region Удаление ПО

        public static async void AutoDeleteSoftwareMethod()
        {
            List<ComputerProgrammViewModel> model = new List<ComputerProgrammViewModel>();
            GetInfoAboutProgrammsMethod(ref model);

            CompareDataToDelete(model);
        }

        private async static void CompareDataToDelete(List<ComputerProgrammViewModel> model)
        {
            DataTable dt = TableAdapterDB.InstallingSELECTView();

            var uniqueNamesInList = model.Select(obj => obj.NamePO).Distinct();

            var namesToDelete = dt.AsEnumerable().Select(row => row.Field<string>("SoftwareName"))
                                    .Except(uniqueNamesInList);

            foreach (var item in namesToDelete)
                await UpdateDB.DeleteRowAsync("Installing", "SoftwareName", item); //await UpdateDB.DeleteRowAsync(item);
        }

        #endregion

    }
}
