using SoftwareAccounting.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SoftwareAccounting.Classes
{
    public static class InsertDB
    {
        private static SqlConnection con = Server.getConnection();
        private static SqlCommand insertCmd;

        public static async Task InsertComputerAsync(ComputerViewModel model)
        {
            insertCmd = new SqlCommand("INSERT INTO Computers(ComputerName, IPAdress, OSystem, MacAdress, OSVersion) VALUES (@ComputerName, @IPAdress, @OSystem, @MacAdress, @OSVersion)", con);
            insertCmd.Parameters.AddWithValue("@ComputerName", model.ComputerName);
            insertCmd.Parameters.AddWithValue("@IPAdress", model.IPAdress);
            insertCmd.Parameters.AddWithValue("@OSystem", model.OSystem);
            insertCmd.Parameters.AddWithValue("@MacAdress", model.MacAdress);
            insertCmd.Parameters.AddWithValue("@OSVersion", model.OSVersion);

            try
            {
                await con.OpenAsync();
                await insertCmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public static async Task InsertSoftwareAsync(ComputerProgrammViewModel model)
        {
            insertCmd = new SqlCommand("INSERT INTO [dbo].[Installing] ([ComputerID], " +
                "[EmloyeeID], [InstallDate], [SoftwareName], [Version], [Publisher]) VALUES " +
                "(@ComputerID, @EmloyeeID, @InstallDate, @SoftwareName, @Version, @Vendor)", con);
            insertCmd.Parameters.AddWithValue("@ComputerID", Server.ComputerID);
            insertCmd.Parameters.AddWithValue("@EmloyeeID", Server.EmployeeID);
            insertCmd.Parameters.AddWithValue("@InstallDate", model.InstallDate);
            insertCmd.Parameters.AddWithValue("@SoftwareName", model.NamePO);
            insertCmd.Parameters.AddWithValue("@Version", model.VersionPO);
            insertCmd.Parameters.AddWithValue("@Vendor", model.VendorPO);

            try
            {
                await con.OpenAsync();
                await insertCmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public static async Task<(bool, string)> InsertDolzhnostAsync(string Name)
        {
            insertCmd = new SqlCommand("InsertDolzhnost", con);
            insertCmd.CommandType = CommandType.StoredProcedure;
            insertCmd.Parameters.AddWithValue("@Name", Name);
            insertCmd.Parameters.Add("@Info", SqlDbType.NVarChar, 100);
            insertCmd.Parameters["@Info"].Direction = ParameterDirection.Output;
            insertCmd.Parameters.Add("@flag", SqlDbType.Bit);
            insertCmd.Parameters["@flag"].Direction = ParameterDirection.Output;

            try
            {
                await con.OpenAsync();
                await insertCmd.ExecuteNonQueryAsync();
                string text = insertCmd.Parameters["@Info"].Value.ToString();
                bool result = (bool)insertCmd.Parameters["@flag"].Value;
                con.Close();
                return (result, text);
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }

        public static async Task<(bool, string)> InsertPeoplesAsync(int dolID, string SecondName, string Name, string FullName, string Telephone, DateTime birth, string INN, string Seria, string Number, string KemVidan, DateTime DateGive, string KodPodrazd)
        {
            insertCmd = new SqlCommand("InsertEmployeeAndPassportTransaction", con);
            insertCmd.CommandType = CommandType.StoredProcedure;
            insertCmd.Parameters.AddWithValue("@DolzhnostID", dolID);
            insertCmd.Parameters.AddWithValue("@SecondName", SecondName);
            insertCmd.Parameters.AddWithValue("@Name", Name);
            insertCmd.Parameters.AddWithValue("@FullName", FullName);
            insertCmd.Parameters.AddWithValue("@Telephone", Telephone);
            insertCmd.Parameters.AddWithValue("@Birth", birth);
            insertCmd.Parameters.AddWithValue("@INN", INN);
            insertCmd.Parameters.AddWithValue("@Seria", Seria);
            insertCmd.Parameters.AddWithValue("@Number", Number);
            insertCmd.Parameters.AddWithValue("@KemVidan", KemVidan);
            insertCmd.Parameters.AddWithValue("@DateGives", DateGive);
            insertCmd.Parameters.AddWithValue("@KodPodrazd", KodPodrazd);
            insertCmd.Parameters.Add("@Info", SqlDbType.NVarChar, 100);
            insertCmd.Parameters["@Info"].Direction = ParameterDirection.Output;
            insertCmd.Parameters.Add("@flag", SqlDbType.Bit);
            insertCmd.Parameters["@flag"].Direction = ParameterDirection.Output;

            try
            {
                await con.OpenAsync();
                await insertCmd.ExecuteNonQueryAsync();
                string text = insertCmd.Parameters["@Info"].Value.ToString();
                bool result = (bool)insertCmd.Parameters["@flag"].Value;
                con.Close();
                return (result, text);
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }

        public static async Task<(bool, string)> InsertAdminsAsync(int ID, string Login, string Password, bool isAdm)
        {
            insertCmd = new SqlCommand("InsertAdmins", con);
            insertCmd.CommandType = CommandType.StoredProcedure;
            insertCmd.Parameters.AddWithValue("@EmpID", ID);
            insertCmd.Parameters.AddWithValue("@Login", Login);
            insertCmd.Parameters.AddWithValue("@Password", Password);
            insertCmd.Parameters.AddWithValue("@isAdmin", isAdm);
            insertCmd.Parameters.Add("@Info", SqlDbType.NVarChar, 100);
            insertCmd.Parameters["@Info"].Direction = ParameterDirection.Output;
            insertCmd.Parameters.Add("@flag", SqlDbType.Bit);
            insertCmd.Parameters["@flag"].Direction = ParameterDirection.Output;

            try
            {
                await con.OpenAsync();
                await insertCmd.ExecuteNonQueryAsync();
                string text = insertCmd.Parameters["@Info"].Value.ToString();
                bool result = (bool)insertCmd.Parameters["@flag"].Value;
                con.Close();
                return (result, text);
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }
    }
}
