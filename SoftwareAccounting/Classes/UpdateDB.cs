using SoftwareAccounting.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Classes
{
    public static class UpdateDB
    {
        private static SqlConnection con = Server.getConnection();
        private static SqlCommand updateCmd;

        public static async Task<(bool, string)> DeleteRowAsync(string table, string field, int ID)
        {
            string sID = ID.ToString();
            updateCmd = new SqlCommand("DeleteFromTableProcedure", con);
            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.Parameters.AddWithValue("@TableName", table);
            updateCmd.Parameters.AddWithValue("@FieldName", field);
            updateCmd.Parameters.AddWithValue("@ID", sID);

            try
            {
                await con.OpenAsync();
                await updateCmd.ExecuteNonQueryAsync();
                con.Close();
                return (true, "Запись успешно удалена");
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }

        public static async Task<(bool, string)> DeleteRowAsync(string table, string field, string ID)
        {
            string sID = ID.ToString();
            updateCmd = new SqlCommand("DeleteFromTableProcedure", con);
            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.Parameters.AddWithValue("@TableName", table);
            updateCmd.Parameters.AddWithValue("@FieldName", field);
            updateCmd.Parameters.AddWithValue("@ID", sID);

            try
            {
                await con.OpenAsync();
                await updateCmd.ExecuteNonQueryAsync();
                con.Close();
                return (true, "Запись успешно удалена");
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }

        public static async Task DeleteRowAsync(string ID)
        {
            updateCmd = new SqlCommand("DELETE FROM Installing WHERE SoftwareName = @ID", con);
            updateCmd.Parameters.AddWithValue("@ID", ID);

            try
            {
                await con.OpenAsync();
                await updateCmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public static async Task UpdateSoftwareAsync(ComputerProgrammViewModel model)
        {
            updateCmd = new SqlCommand("UPDATE [dbo].[Installing] SET [InstallDate] = @InstallDate, " +
                "[Version] = @Version WHERE SoftwareName = @SoftwareName", con);
            updateCmd.Parameters.AddWithValue("@InstallDate", model.InstallDate);
            updateCmd.Parameters.AddWithValue("@SoftwareName", model.NamePO);
            updateCmd.Parameters.AddWithValue("@Version", model.VersionPO);

            try
            {
                await con.OpenAsync();
                await updateCmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public static async Task<(bool, string)> UpdateDolzhnostAsync(int ID, string Name)
        {
            updateCmd = new SqlCommand("UpdateDolzhnost", con);
            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.Parameters.AddWithValue("@DolzhnostID", ID);
            updateCmd.Parameters.AddWithValue("@NewName", Name);
            updateCmd.Parameters.Add("@Info", SqlDbType.NVarChar, 100);
            updateCmd.Parameters["@Info"].Direction = ParameterDirection.Output;
            updateCmd.Parameters.Add("@flag", SqlDbType.Bit);
            updateCmd.Parameters["@flag"].Direction = ParameterDirection.Output;

            try
            {
                await con.OpenAsync();
                await updateCmd.ExecuteNonQueryAsync();
                bool result = (bool)updateCmd.Parameters["@flag"].Value;
                string info = updateCmd.Parameters["@Info"].Value.ToString();
                con.Close();
                return (result, info);
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }

        public static async Task<(bool, string)> UpdatePeoplesAsync(int ID, int dolID, string secName, string Name, string fullName, string tel, DateTime birth, string inn, string seria, string num, string kemVidan, DateTime date, string kodPod)
        {
            updateCmd = new SqlCommand("UpdateEmployeeAndPassportTransaction", con);
            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.Parameters.AddWithValue("@EmpID", ID);
            updateCmd.Parameters.AddWithValue("@DolzhnostID", dolID);
            updateCmd.Parameters.AddWithValue("@SecondName", secName);
            updateCmd.Parameters.AddWithValue("@Name", Name);
            updateCmd.Parameters.AddWithValue("@FullName", fullName);
            updateCmd.Parameters.AddWithValue("@Telephone", tel);
            updateCmd.Parameters.AddWithValue("@Birth", birth);
            updateCmd.Parameters.AddWithValue("@INN", inn);
            updateCmd.Parameters.AddWithValue("@Seria", seria);
            updateCmd.Parameters.AddWithValue("@Number", num);
            updateCmd.Parameters.AddWithValue("@KemVidan", kemVidan);
            updateCmd.Parameters.AddWithValue("@DateGives", date);
            updateCmd.Parameters.AddWithValue("@KodPodrazd", kodPod);
            updateCmd.Parameters.Add("@Info", SqlDbType.NVarChar, 100);
            updateCmd.Parameters["@Info"].Direction = ParameterDirection.Output;
            updateCmd.Parameters.Add("@flag", SqlDbType.Bit);
            updateCmd.Parameters["@flag"].Direction = ParameterDirection.Output;

            try
            {
                await con.OpenAsync();
                await updateCmd.ExecuteNonQueryAsync();
                bool result = (bool)updateCmd.Parameters["@flag"].Value;
                string info = updateCmd.Parameters["@Info"].Value.ToString();
                con.Close();
                return (result, info);
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }

        public static async Task<(bool, string)> UpdateAdminsAsync(string oldLogin, string Login, string Password, bool isAdm)
        {
            updateCmd = new SqlCommand("UpdateAdmins", con);
            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.Parameters.AddWithValue("@OldLogin", oldLogin);
            updateCmd.Parameters.AddWithValue("@Login", Login);
            updateCmd.Parameters.AddWithValue("@Password", Password);
            updateCmd.Parameters.AddWithValue("@isAdmin", isAdm);
            updateCmd.Parameters.Add("@Info", SqlDbType.NVarChar, 100);
            updateCmd.Parameters["@Info"].Direction = ParameterDirection.Output;
            updateCmd.Parameters.Add("@flag", SqlDbType.Bit);
            updateCmd.Parameters["@flag"].Direction = ParameterDirection.Output;

            try
            {
                await con.OpenAsync();
                await updateCmd.ExecuteNonQueryAsync();
                bool result = (bool)updateCmd.Parameters["@flag"].Value;
                string info = updateCmd.Parameters["@Info"].Value.ToString();
                con.Close();
                return (result, info);
            }
            catch (Exception ex)
            {
                con.Close();
                return (false, "Ошибка: " + ex.Message);
            }
        }
    }
}
