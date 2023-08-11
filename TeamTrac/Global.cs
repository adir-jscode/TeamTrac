using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TeamTrac
{
    internal class Global
    {
        public static string Connection_String()
        {

            return @"Data Source=ADIR\SQLEXPRESS;Initial Catalog=TeamTrac;User Id=Team;password=1234;TrustServerCertificate=True;";
        }

        public static string GenarateHash(int length = 20)
        {
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];



                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return res.ToString();
        }

        public class Get
        {
            public static bool LoginAuth(string username, string password)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT  * FROM [TeamTrac].[dbo].[CompanyDetails] where [Username]='" + username + "' and [Password]='" + password + "'", con))
                    {
                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            con.Close();
                            return true;
                        }
                        else
                        {
                            con.Close();
                            return false;
                        }
                    }

                }
            }

            //Register 

            public static void Register(string Name, string Email, string Password, string Phone)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewUserDetails", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@ID", DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@Phone", Phone);




                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }
        }

    }
}
