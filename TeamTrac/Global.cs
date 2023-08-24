﻿using System;
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

            public static void AddNewProduct(string ProductName, string Category,int Price,int Quantity,byte[] Image)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewProduct", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@ProductID","PRO" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@ProductName", ProductName);
                        cmd.Parameters.AddWithValue("@Category", Category);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@Image", Image);
                        cmd.Parameters.AddWithValue("@IsAvailableStock", "1");
                        cmd.Parameters.AddWithValue("@Status", "1");





                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }


            public static void OnboardDelegate(string Name,string Phone,string Email,string DelegateAddress,string NID,string DOB,string JoiningDate,string Username,string Password,string DelegatingArea,string DelegatingDistrict,byte[] Image,string ZipCode)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewDelegateDetails", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@DelegateID", "DEL" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@DelegateName", Name);
                        cmd.Parameters.AddWithValue("@PhoneNo", Phone);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@DelegateAddress", DelegateAddress);
                        cmd.Parameters.AddWithValue("@NID", NID);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@OnBoardDateTime", JoiningDate);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@DelegateArea", DelegatingArea);
                        cmd.Parameters.AddWithValue("@DelegateDistrict", DelegatingDistrict);
                        cmd.Parameters.AddWithValue("@DelegateZipCode", ZipCode);
                        cmd.Parameters.AddWithValue("@Logo", Image);
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
            public static List<Model.CompanyDetails> LoginCompany(string Username, string password)
            {
                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    // MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM [TeamTrac].[dbo].[CompanyDetails] where [Username]='" + Username + "' and [Password]='" + password + "'", con))
                    {
                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            con.Close();
                            con.Open();

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "DataTable1");
                            con.Close();

                            DataTable dt = ds.Tables["DataTable1"];


                            List<Model.CompanyDetails> compnay = new List<Model.CompanyDetails>();

                            return compnay = (from DataRow dr in dt.Rows
                                           select new Model.CompanyDetails()
                                           {

                                               ID = dr["ID"].ToString(),
                                               CompanyName = dr["CompanyName"].ToString(),
                                               CompanyAddress = dr["CompanyAddress"].ToString(),
                                               CompnayBin = dr["CompnayBin"].ToString(),
                                               TradeLicenceNo = dr["TradeLicenceNo"].ToString(),
                                               ContactNo = dr["ContactNo"].ToString(),
                                                OwnerFullName = dr["OwnerFullName"].ToString(),
                                                CompanyEmail = dr["CompanyEmail"].ToString(),
                                                OwnerEmail = dr["OwnerEmail"].ToString(),
                                                NID = dr["NID"].ToString(),
                                                PhoneNo = dr["PhoneNo"].ToString(),
                                                Username = dr["Username"].ToString(),
                                                Password = dr["Password"].ToString(),
                                                Status = dr["Status"].ToString(),
                                                Image = (byte[])dr["Image"],




        }).ToList();
                        }
                        else
                        {
                            return new List<Model.CompanyDetails>();
                        }

                    }
                }

            }
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



            public static void UpdatePassword(string Email,string Password)
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

            public static string GetID(string Username)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT ID FROM [TeamTrac].[dbo].[CompanyDetails] where [Username]='" + Username + "'", con))
                    {
                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            string ID = sdr.GetValue(0).ToString();

                            return ID;
                        }
                        else
                        {
                            string ID = "";

                            return ID;
                        }

                    }
                }

            }

            //string CompanyName = textBox1.Text;
            //string CompanyAddress = textBox2.Text;
            //string CompnayBin = textBox3.Text;
            //

            public static void UpdateCompnayDetails(string ID, string CompanyName,string CompanyAddress,string CompnayBin, string TradeLicenceNo, string ContactNo, string CompanyEmail,string Username,string OwnerFullName,string OwnerEmail,string NID,string PhoneNo,byte[] Logo)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[CompanyDetails] SET ID = @ID,CompanyName=@CompanyName,CompanyAddress=@CompanyAddress,CompnayBin=@CompnayBin,TradeLicenceNo=@TradeLicenceNo,ContactNo=@ContactNo,CompanyEmail=@CompanyEmail,Username=@Username,OwnerFullName=@OwnerFullName,OwnerEmail=@OwnerEmail,NID=@NID,PhoneNo=@PhoneNo,Logo=@Logo WHERE ID = @ID", connec))
                    {
                        connec.Open();

                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyAddress", CompanyAddress);
                        cmd.Parameters.AddWithValue("@CompnayBin", CompnayBin);
                        cmd.Parameters.AddWithValue("@TradeLicenceNo", TradeLicenceNo);
                        cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
                        cmd.Parameters.AddWithValue("@CompanyEmail", CompanyEmail);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@OwnerFullName", OwnerFullName);
                        cmd.Parameters.AddWithValue("@OwnerEmail", OwnerEmail);
                        cmd.Parameters.AddWithValue("@NID", NID);
                        cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                        cmd.Parameters.AddWithValue("@Image", Logo);

                        


                        connec.Close();
                    }
                }
            }




            public static List<Model.DelegateDetails> LoginDelegate(string Username, string password)
            {
                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                   
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM [TeamTrac].[dbo].[DelegateDetails] where [Username]='" + Username + "' and [Password]='" + password + "'", con))
                    {
                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            con.Close();
                            con.Open();

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "DataTable1");
                            con.Close();

                            DataTable dt = ds.Tables["DataTable1"];


                            List<Model.DelegateDetails> del = new List<Model.DelegateDetails>();

                            return del = (from DataRow dr in dt.Rows
                                          select new Model.DelegateDetails()
                                          {


                                              DelegateID = dr["DelegateID"].ToString(),
                                              DelegateName = dr["DelegateName"].ToString(),
                                              PhoneNo = dr["PhoneNo"].ToString(),
                                              Email = dr["Email"].ToString(),
                                              NID = dr["NID"].ToString(),
                                              DOB = dr["DOB"].ToString(),
                                              Image = (byte[])dr["Logo"],
                                              OnBoardDateTime = dr["OnBoardDateTime"].ToString(),
                                              DelegateAddress = dr["DelegateAddress"].ToString(),
                                              DelegateDistrict = dr["DelegateDistrict"].ToString(),
                                              DelegateArea = dr["DelegateArea"].ToString(),
                                              DelegateZipCode = dr["DelegateZipCode"].ToString(),
                                              Status = dr["Status"].ToString(),
                                              Username = dr["Username"].ToString(),
                                              Password = dr["Password"].ToString(),






                                          }).ToList();
                        }
                        else
                        {
                            return new List<Model.DelegateDetails>();
                        }

                    }
                }

            }



            //public static void UpdateDelegateDetails(string ID, string DelegateName, string CompanyAddress, string CompnayBin, string TradeLicenceNo, string ContactNo, string CompanyEmail, string Username, string OwnerFullName, string OwnerEmail, string NID, string PhoneNo, byte[] Logo)
            //{
            //    using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
            //    {
            //        using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[DelegateDetails] SET ID = @ID,CompanyName=@CompanyName,CompanyAddress=@CompanyAddress,CompnayBin=@CompnayBin,TradeLicenceNo=@TradeLicenceNo,ContactNo=@ContactNo,CompanyEmail=@CompanyEmail,Username=@Username,OwnerFullName=@OwnerFullName,OwnerEmail=@OwnerEmail,NID=@NID,PhoneNo=@PhoneNo,Logo=@Logo WHERE ID = @ID", connec))
            //        {
            //            connec.Open();

            //            cmd.Parameters.AddWithValue("@ID", ID);
            //            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            //            cmd.Parameters.AddWithValue("@CompanyAddress", CompanyAddress);
            //            cmd.Parameters.AddWithValue("@CompnayBin", CompnayBin);
            //            cmd.Parameters.AddWithValue("@TradeLicenceNo", TradeLicenceNo);
            //            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            //            cmd.Parameters.AddWithValue("@CompanyEmail", CompanyEmail);
            //            cmd.Parameters.AddWithValue("@Username", Username);
            //            cmd.Parameters.AddWithValue("@OwnerFullName", OwnerFullName);
            //            cmd.Parameters.AddWithValue("@OwnerEmail", OwnerEmail);
            //            cmd.Parameters.AddWithValue("@NID", NID);
            //            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            //            cmd.Parameters.AddWithValue("@Image", Logo);




            //            connec.Close();
            //        }
            //    }
            //}
        }






    }
}
