using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

            public static bool LoginAuthEmployee(string username, string password)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT  * FROM [TeamTrac].[dbo].[EmployeeDetails] where [Username]='" + username + "' and [Password]='" + password + "'", con))
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


            public static bool LoginAuthDelegate(string username, string password)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT  * FROM [TeamTrac].[dbo].[DelegateDetails] where [Username]='" + username + "' and [Password]='" + password + "'", con))
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

        //get all employee details
        //public static List<Model.Employee> GetEmployeeDetails()
        //{
        //    using (SqlConnection con = new SqlConnection(Global.Connection_String()))
        //    {
        //        // MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
        //        using (SqlCommand cmd = new SqlCommand("SELECT  * FROM [TeamTrac].[dbo].[EmployeeDetails]", con))
        //        {
        //            con.Open();

        //            SqlDataReader sdr = cmd.ExecuteReader();

        //            if (sdr.Read())
        //            {
        //                con.Close();
        //                con.Open();

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                DataSet ds = new DataSet();
        //                da.Fill(ds, "DataTable1");
        //                con.Close();

        //                DataTable dt = ds.Tables["DataTable1"];

        //                List<Model.Employee> employees = new List<Model.Employee>();
        //                return employees = (from DataRow dr in dt.Rows
        //                                         select new Model.Employee()
        //                                         {







        //                                             EID = dr["EID"]?.ToString(),
        //                                             EmployeeName = dr["EmployeeName"]?.ToString(),
        //                                             Position = dr["Position"]?.ToString(),
        //                                             Status = dr["Status"]?.ToString()





        //                                         }).ToList();
        //            }
        //            else
        //            {
        //                return new List<Model.Employee>();
        //            }

        //        }
        //    }
        //}

        //get all employee details
        public static DataTable EmployeeDetails()
        {
            using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
            {
                string strQuery = "SELECT *  FROM EmployeeDetails";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                conn.Open();

                DataTable dt = new DataTable();
                
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

                return dt;
            }
        }



    }
}
