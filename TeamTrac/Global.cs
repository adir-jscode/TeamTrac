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

            //Add Category

            public static void AddCategory(string MainCategory,string SubCategory)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewProductCategory", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@ProductCategoryID", DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@MainCategory", MainCategory);
                        cmd.Parameters.AddWithValue("@SubCategory", SubCategory);
                        cmd.Parameters.AddWithValue("@Status", "1");
                        




                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }


            public static void OnboardDelegate(string Name,string Phone,string Email,string NID,string DOB,string JoiningDate,string Username,string Password,string DelegatingArea,string DelegatingDistrict,string Image)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewDelegateDetails", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@DelegateID","DEL" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@DelegateName", Name);
                        cmd.Parameters.AddWithValue("@PhoneNo", Phone);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@NID", NID);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@OnBoardDateTime", JoiningDate);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@passsword", Password);
                        cmd.Parameters.AddWithValue("@DelegatingArea", DelegatingArea);
                        cmd.Parameters.AddWithValue("@DelegatingDistrict", DelegatingDistrict);
                        cmd.Parameters.AddWithValue("@Image", Image);
                        cmd.Parameters.AddWithValue("@Status", "1");





                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }





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


            public static DataTable ProductCategory()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT *  FROM ProductCategory";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }

            //delete product category by id
            public static void DeleteProductCategory(string ProductCategoryID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "DELETE FROM ProductCategory WHERE ProductCategoryID = @ProductCategoryID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);

                    cmd.ExecuteNonQuery();
                }
            }

            //Update Product Category by ID
            public static void UpdateProductCategory(string ProductCategoryID, string MainCategory, string SubCategory)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "UPDATE ProductCategory SET MainCategory = @MainCategory, SubCategory = @SubCategory WHERE ProductCategoryID = @ProductCategoryID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
                    cmd.Parameters.AddWithValue("@MainCategory", MainCategory);
                    cmd.Parameters.AddWithValue("@SubCategory", SubCategory);

                    cmd.ExecuteNonQuery();
                }
            }

            //new login auth

            //Function start
            //public static List<Model.User> LoginAuth(string phone, string password)
            //{
            //    using (SqlConnection con = new SqlConnection(db.ConnectionString()))
            //    {
            //        // MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
            //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [GoruKhasi].[dbo].[UserDetails] where [PhoneNumber]='" + phone + "' and [Password]='" + password + "'", con))
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


            //                List<Model.User> user = new List<Model.User>();

            //                return user = (from DataRow dr in dt.Rows
            //                               select new Model.User()
            //                               {
            //                                   UserID = dr["ID"].ToString(),
            //                                   FullName = dr["FullName"].ToString(),
            //                                   Email = dr["Email"].ToString(),
            //                                   PhoneNumber = dr["PhoneNumber"].ToString(),
            //                                   Password = dr["Password"].ToString(),



            //                               }).ToList();
            //            }
            //            else
            //            {
            //                return new List<Model.User>();
            //            }

            //        }
            //    }

            //}
            //Function END


            //User Exists

            public static bool UserExist(string Value)
            {
                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [TeamTrac].[dbo].[CompanyDetails] where [CompanyEmail]='" + Value + "' OR [Username]='" + Value + "'", con))
                    {
                        cmd.Parameters.AddWithValue("@CompnayEmail", Value);
                        cmd.Parameters.AddWithValue("@Username", Value);

                        con.Open();

                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                }
            }



            public static void UpdatePassword(
            string Email,
            string Password


       )
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {


                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[CompanyDetails] SET [Password] = '" + Password + "' WHERE [CompanyEmail] ='" + Email + "'", connec))
                    {



                        connec.Open();


                        cmd.Parameters.AddWithValue("@Password", Password);


                        cmd.ExecuteNonQuery();
                        connec.Close();


                    }
                }
            }//Func End

        }






    }
}
