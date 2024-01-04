using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Classes
{
    public static class TableAdapterDB
    {
        private static SqlConnection con = Server.getConnection();
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataTable dataTable;

        public static string MacAdress { get; set; } = "74:12:B3:C5:B2:BB";

        public static async Task<DataTable> InstallingView()
        {
            cmd = new SqlCommand("InstallingViewProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MacAdress", MacAdress);
            //cmd.Parameters.Add(new SqlParameter("@MacAdress", SqlDbType.NVarChar));
            //cmd.Parameters["@MacAdress"].Value = MacAdress;

            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> ComputerView()
        {
            cmd = new SqlCommand("SELECT TOP (1000) [ComputerID], [InventoryNumber] as " +
                "'Инвентарный номер'\r\n      ,[ComputerName] as 'Название компьютера'," +
                "[IPAdress] as 'IP-адресс'\r\n      ,[OSystem] as 'Операционная система'," +
                "[OSVersion] as 'Версия операционной системы', [MacAdress] as 'Mac-адресс' " +
                "FROM [SoftwateAccountingDB].[dbo].[Computers]", con);

            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static DataTable InstallingSELECTView()
        {
            cmd = new SqlCommand("SELECT inst.InstallID, inst.SoftwareName, inst.Version, inst.InstallDate, " +
                "inst.Publisher, emp.SecondName, emp.Name, emp.FullName FROM Installing inst " +
                "JOIN Computers cmp ON cmp.ComputerID = inst.ComputerID JOIN Employee emp ON " +
                "emp.EmployeeID = inst.EmloyeeID WHERE cmp.MacAdress = @MacAdress", con);
            cmd.Parameters.AddWithValue("@MacAdress", MacAdress);

            con.Open();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> InstallingSELECTByPCView(int id)
        {
            cmd = new SqlCommand("ComputersByIDViewProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PCID", id);

            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> DolzhnostViewAsync()
        {
            cmd = new SqlCommand("SELECT DolzhnostID, DolzhnostName as Наименование FROM Dolzhnost", con);
            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> PeoplesViewAsync()
        {
            cmd = new SqlCommand("SELECT * FROM PeoplesViewForAdmins", con);
            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> SelectDolzhnostAsync(int? id = null)
        {
            cmd = new SqlCommand("SELECT DolzhnostID, DolzhnostName FROM Dolzhnost", con);
            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> SelectDolzhnostAsync(int id)
        {
            cmd = new SqlCommand("SELECT DolzhnostID, DolzhnostName FROM Dolzhnost " +
                "WHERE DolzhnostID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> AdminsViewAsync()
        {
            cmd = new SqlCommand("SELECT * FROM AdminsView", con);
            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<string> SelectDolzhnostByIDViewAsync(int id)
        {
            cmd = new SqlCommand("SELECT TOP 1 DolzhnostName FROM Dolzhnost WHERE DolzhnostID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            await con.OpenAsync();
            string answer = (string)await cmd.ExecuteScalarAsync();
            con.Close();
            return answer;
        }

        public static async Task<DataTable> SelectPeoplesByIDViewAsync(int id)
        {
            cmd = new SqlCommand("SELECT TOP 1 [DolzhnostID], [SecondName], [Name], " +
                "[FullName], [Telephone], [BirthDate], [INN], [Number], [Seria], [KemVidan], " +
                "[DateGives], [KodPodrazd] FROM [SoftwateAccountingDB].[dbo].[Employee] e LEFT " +
                "JOIN Passport p ON p.EmployeeID = e.EmployeeID WHERE e.EmployeeID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }

        public static async Task<DataTable> SelectUserByLoginViewAsync(string login)
        {
            cmd = new SqlCommand("SELECT TOP 1 [Login], [Password], [IsAdmin], [EmployeeID] " +
                "FROM[SoftwateAccountingDB].[dbo].[User] WHERE Login = @Login", con);
            cmd.Parameters.AddWithValue("@Login", login);
            await con.OpenAsync();
            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            con.Close();
            return dataTable;
        }
    }
}
