using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting.Classes
{
    public static class Server
    {
        private static SqlConnection con = new
            SqlConnection(ConfigurationManager.ConnectionStrings["InventoryString"].ConnectionString);
        private static SqlCommand cmd;
        private static int count;

        public static string Login { get; set; }
        public static string Status { get; set; } // Текстовое представление (User : Admin) для вывода на форму
        public static bool IsAdmin { get; set; }  // Булевое представление (0 : 1) для внутреннего взаимодействия
        public static int EmployeeID { get; set; }
        public static int ComputerID { get; set; }


        public static SqlConnection getConnection() => con;

        public static void CloseConnection() => con.Close();
        public static string GetConnectionState() => con.State.ToString();

        public static async Task getStatusAsync(string login, string password)
        {
            cmd = new SqlCommand("SELECT TOP 1 IsAdmin FROM [SoftwateAccountingDB].[dbo].[User] WHERE Login = @Login AND Password = @Password", con);
            cmd.Parameters.AddWithValue("@Login", login);
            cmd.Parameters.AddWithValue("@Password", password);

            con.Open();
            Login = login;
            IsAdmin = (bool)await cmd.ExecuteScalarAsync();
            Status = IsAdmin ? "Admin" : "User";
            con.Close();
        }

        public static async Task getEmployeeIDAsync(string login, string password)
        {
            cmd = new SqlCommand("SELECT TOP 1 EmployeeID FROM [SoftwateAccountingDB].[dbo].[User] WHERE Login = @Login AND Password = @Password", con);
            cmd.Parameters.AddWithValue("@Login", login);
            cmd.Parameters.AddWithValue("@Password", password);

            con.Open();
            EmployeeID = (int)await cmd.ExecuteScalarAsync();
            con.Close();
        }

        public static async Task<bool> LoginIsCorrectAsync(string Login, string Password)
        {
            cmd = new SqlCommand("prLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Login", Login);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                con.Open();
                count = (int)await cmd.ExecuteScalarAsync();
                con.Close();
                return count == 0 ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
        }

        public static void getComputerID(string macAdress)
        {
            cmd = new SqlCommand("SELECT TOP 1 cmp.ComputerID FROM Computers cmp WHERE cmp.MacAdress = @MacAdress", con);
            cmd.Parameters.AddWithValue("@MacAdress", macAdress);

            con.Open();
            ComputerID = (int)cmd.ExecuteScalar();
            con.Close();
        }

        public static bool ExistMacAdressAsync(string macAdress)
        {
            cmd = new SqlCommand("SELECT TOP 1 COUNT(*) FROM Computers cmp WHERE cmp.MacAdress = @MacAdress", con);
            cmd.Parameters.AddWithValue("@MacAdress", macAdress);

            try
            {
                con.Open();
                count = (int)cmd.ExecuteScalar();
                con.Close();
                return count == 0 ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
        }


    }
}
