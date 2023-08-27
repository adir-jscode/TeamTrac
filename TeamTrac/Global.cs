using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

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
                        

                        connec.Close();
                    }
                }
            }

            //Add new Employee

            public static void AddNewEmployee(string EmployeeName,string EmployeePhone,string Address,string Position, DateTime JoinDate, string Username, string Password, string Email, byte[] imageBytes)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewEmployeeDetails", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@EID", "EMP"+ DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                        cmd.Parameters.AddWithValue("@Position", Position);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@Status", "1");
                        cmd.Parameters.AddWithValue("@Image", imageBytes);
                        cmd.Parameters.AddWithValue("@OnBoardDate", JoinDate);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Phone", EmployeePhone);




                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }


            public static void AssignProduct(string ProductID, string DelegateID,int Quantity)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewDelegateProductAssignment", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@AssignmentID", "ASSIGN" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@DelegateID", DelegateID);
                        cmd.Parameters.AddWithValue("@ProductID", ProductID); 
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Status", "1");




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

            //Add new Shop
            public static void AddShop(string shopName, string address, string area, string zipCode, string ownerName, string nid, byte[] image, string tradeLicense)
            {
                using (SqlConnection connection = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertNewShopDetails", connection))
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ShopID","SHP" +  DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ShopName", shopName);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Area", area);
                        cmd.Parameters.AddWithValue("@ZipCode", zipCode);
                        cmd.Parameters.AddWithValue("@OwnerName", ownerName);
                        cmd.Parameters.AddWithValue("@NID", nid);
                        cmd.Parameters.AddWithValue("@Image", image);
                        cmd.Parameters.AddWithValue("@TradeLicense", tradeLicense);
                        cmd.Parameters.AddWithValue("@Status", "1");

                        cmd.ExecuteNonQuery();

                        connection.Close();
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

            //create Support Ticket

            public static void CreateSupportTicket(string DelegateID,string Description)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewSupportTicket", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@TicketID", "SPT" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@DelegateID", DelegateID);
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Description", Description);
                        cmd.Parameters.AddWithValue("@Status", "1");





                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }


            public static void CreateStockRequest(string ProductID, string DelegateID, int Quantity)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewStockRequest", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@StockReqID", "STOCK" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@ProductID", ProductID);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@DelegateID", DelegateID);
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Status", "1");





                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }

            public static void NewSell(string ProductID, string DelegateID, string ShopID, int Quantity)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewSalesDetails", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;





                        cmd.Parameters.AddWithValue("@SalesID", "SALES" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@ProductID", ProductID);
                        cmd.Parameters.AddWithValue("@ShopID", ShopID);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@DelegateID", DelegateID);
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Status", "1");





                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();

                    }

                }
            }

            public static DataTable SalesReport()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT SalesID,SaleDateTime,ProductName,DelegateName,UnitPrice,TotalSalesAmount  FROM SalesReportView";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }




            public static DataTable EmployeeDetails()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT EID, EmployeeName,Email,Phone,Address,Position,Status,Image  FROM EmployeeDetails";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }


            public static DataTable ProductDetails()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT *  FROM Product";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }

            //count total products
            public static int CountTotalProducts()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT COUNT(*) FROM Product";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    int count = (int)cmd.ExecuteScalar();

                    return count;
                }
            }

            //count total delegates
            public static int CountTotalDelegates()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT COUNT(*) FROM DelegateDetails";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    int count = (int)cmd.ExecuteScalar();

                    return count;
                }
            }

            //count total Employees
            public static int CountTotalEmployees()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT COUNT(*) FROM EmployeeDetails";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    int count = (int)cmd.ExecuteScalar();

                    return count;
                }
            }

            //count total shops
            public static int CountTotalShops()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT COUNT(*) FROM ShopDetails";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    int count = (int)cmd.ExecuteScalar();

                    return count;
                }
            }

            //count total assigned products by delegate id
            public static int CountTotalAssignedProducts(string DelegateID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT COUNT(*) FROM DelegateProductAssignment WHERE DelegateID = @DelegateID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@DelegateID", DelegateID);

                    int count = (int)cmd.ExecuteScalar();

                    return count;
                }
            }

            //count total sales by delegate id
            public static int CountTotalSales(string DelegateID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT COUNT(*) FROM SalesReportView WHERE DelegateID = @DelegateID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@DelegateID", DelegateID);

                    int count = (int)cmd.ExecuteScalar();

                    return count;
                }
            }

            




            public static DataTable DelegateDetails()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT DelegateID,DelegateName,PhoneNo,Email,NID,DelegateArea,DelegateDistrict,Username,Logo  FROM DelegateDetails";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }

            public static DataTable ShopDetails()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT *  FROM ShopDetails";

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

            public static DataTable SupportTickets()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT *  FROM SupportTicket";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }


            public static DataTable StockRequest(string ID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT  StockReqID,Quantity,DateTime,Status FROM [TeamTrac].[dbo].[StockRequest] where [DelegateID]='" + ID + "'";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }

            public static DataTable AllStockRequest()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT  StockReqID,DelegateID,Quantity,DateTime,Status FROM [TeamTrac].[dbo].[StockRequest]";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }

            public static DataTable AllShops()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT ShopID,ShopName,Address,OwnerName,TradeLicense FROM [TeamTrac].[dbo].[ShopDetails]";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }


            public static DataTable DelegateProductView()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT *  FROM DelegateProductAssignment";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }

            public static DataTable Sales()
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT *  FROM SalesDetails";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    DataTable dt = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                    return dt;
                }
            }


            //by id
            public static DataTable AssignedProductDelegate(string ID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "SELECT  * FROM [TeamTrac].[dbo].[DelegateProductView] where [DelegateID]='" + ID + "'";

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

            public static void DeleteProduct(string ProductID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "DELETE FROM Product WHERE ProductID = @ProductID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@ProductID", ProductID);

                    cmd.ExecuteNonQuery();
                }
            }


            public static void DeleteShop(string ShopID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "DELETE FROM ShopDetails WHERE ShopID = @ShopID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@ShopID", ShopID);

                    cmd.ExecuteNonQuery();
                }
            }

            public static void DeleteDelegate(string DelegateID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "DELETE FROM DelegateDetails WHERE DelegateID = @DelegateID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@DelegateID", DelegateID);

                    cmd.ExecuteNonQuery();
                }
            }

            public static void DeleteEmployee(string EID)
            {
                using (SqlConnection conn = new SqlConnection(Global.Connection_String()))
                {
                    string strQuery = "DELETE FROM EmployeeDetails WHERE EID = @EID";

                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@EID", EID);

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

            //Register Company
            public static void RegisterCompnay(string CompanyName, string CompanyAddress, string CompanyBin, string TradeLicenceNo,string ContactNo,string OwnerFullName,string CompanyEmail,string OwnerEmail,string NID,string PhoneNo,string Username,string Password, byte[] Image)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("InsertNewCompanyDetails", connec))
                    {

                        connec.Open();

                        cmd.CommandType = CommandType.StoredProcedure;




                        cmd.Parameters.AddWithValue("@ID", "CM" + DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyAddress", CompanyAddress);
                        cmd.Parameters.AddWithValue("@CompnayBin", CompanyBin);
                        cmd.Parameters.AddWithValue("@TradeLicenceNo", TradeLicenceNo);
                        cmd.Parameters.AddWithValue("@ContactNo", ContactNo);

                        cmd.Parameters.AddWithValue("@OwnerFullName", OwnerFullName);
                        cmd.Parameters.AddWithValue("@CompanyEmail", CompanyEmail);
                        cmd.Parameters.AddWithValue("@OwnerEmail", OwnerEmail);
                        cmd.Parameters.AddWithValue("@NID", NID);
                        cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                        cmd.Parameters.AddWithValue("@Username", Username);


                        cmd.Parameters.AddWithValue("@Password", Password);

                        cmd.Parameters.AddWithValue("@Status", "1");

                        cmd.Parameters.AddWithValue("@Image", Image);




                        cmd.ExecuteNonQuery();
                        // ID = cmd.ExecuteScalar().ToString();

                        connec.Close();
                    }
                }
            }



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

            public static bool DelegateExist(string Value)
            {
                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [TeamTrac].[dbo].[DelegateDetails] where [Email]='" + Value + "' OR [Username]='" + Value + "'", con))
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

            public static void UpdatePasswordDel(string Email, string Password)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {


                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[DelegateDetails] SET [Password] = '" + Password + "' WHERE [Email] ='" + Email + "'", connec))
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

            public static string GetDelID(string Username)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT DelegateID FROM [TeamTrac].[dbo].[DelegateDetails] where [Username]='" + Username + "'", con))
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


            public static string GetProductID(string ProductName)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT ProductID FROM [TeamTrac].[dbo].[Product] where [ProductName]='" + ProductName + "'", con))
                    {
                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            string ProductID = sdr.GetValue(0).ToString();

                            return ProductID;
                        }
                        else
                        {
                            string ProductID = "";

                            return ProductID;
                        }

                    }
                }

            }

            public static string GetShopID(string ShopName)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT ShopID FROM [TeamTrac].[dbo].[ShopDetails] where [ShopName]='" + ShopName + "'", con))
                    {
                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            string ProductID = sdr.GetValue(0).ToString();

                            return ProductID;
                        }
                        else
                        {
                            string ProductID = "";

                            return ProductID;
                        }

                    }
                }

            }

            public static string GetDelegateID(string DelegateName)
            {

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT DelegateID FROM [TeamTrac].[dbo].[DelegateDetails] where [DelegateName]='" + DelegateName + "'", con))
                    {
                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            string DelegateID = sdr.GetValue(0).ToString();

                            return DelegateID;
                        }
                        else
                        {
                            string DelegateID = "";

                            return DelegateID;
                        }

                    }
                }

            }


            public static int GetProductQuantity(string productName)
            {
                int quantity = 0;

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    string query = "SELECT Quantity FROM [TeamTrac].[dbo].[Product] WHERE ProductName = @ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            quantity = Convert.ToInt32(reader["Quantity"]);
                        }
                    }
                }

                return quantity;
            }

            public static int GetAssignedQuantity(string productName)
            {
                int quantity = 0;

                using (SqlConnection con = new SqlConnection(Global.Connection_String()))
                {
                    string query = "SELECT Quantity FROM [TeamTrac].[dbo].[DelegateProductView] WHERE ProductName = @ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            quantity = Convert.ToInt32(reader["Quantity"]);
                        }
                    }
                }

                return quantity;
            }





            public static void UpdateCompnayDetails(string ID, string CompanyName,string CompanyAddress,string CompnayBin, string TradeLicenceNo, string ContactNo, string CompanyEmail,string Username,string OwnerFullName,string OwnerEmail,string NID,string PhoneNo,byte[] Logo)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[CompanyDetails] SET ID = @ID,CompanyName=@CompanyName,CompanyAddress=@CompanyAddress,CompnayBin=@CompnayBin,TradeLicenceNo=@TradeLicenceNo,ContactNo=@ContactNo,CompanyEmail=@CompanyEmail,Username=@Username,OwnerFullName=@OwnerFullName,OwnerEmail=@OwnerEmail,NID=@NID,PhoneNo=@PhoneNo,Image=@Logo WHERE ID = @ID", connec))
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
                        cmd.Parameters.AddWithValue("@Logo", Logo);



                        cmd.ExecuteNonQuery();
                        connec.Close();
                    }
                }
            }


            public static void UpdateDelegateDetails(string DelegateID, string DelegateName, string Email, string NID, string DelegateArea, string Username, string DelegateDistrict, byte[] Image)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[DelegateDetails] SET DelegateName=@DelegateName,Email=@Email,NID=@NID,DelegateArea=@DelegateArea,Username=@Username,DelegateDistrict=@DelegateDistrict,Logo=@Image WHERE DelegateID = @DelegateID", connec))
                    {
                        connec.Open();

                        cmd.Parameters.AddWithValue("@DelegateID", DelegateID);
                        cmd.Parameters.AddWithValue("@DelegateName", DelegateName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@NID", NID);
                        cmd.Parameters.AddWithValue("@DelegateArea", DelegateArea);
                        cmd.Parameters.AddWithValue("@DelegateDistrict", DelegateDistrict);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        
                        
                        cmd.Parameters.AddWithValue("@Image", Image);
                        





                        cmd.ExecuteNonQuery();
                        connec.Close();
                    }
                }
            }


            public static void UpdateEmployeeDetails(string EID, string EmployeeName, string Email, string Phone, string Address, string Position, byte[] Image)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {
                    try
                    {
                        string strQuery = "UPDATE [TeamTrac].[dbo].[EmployeeDetails] SET EID=@EID, EmployeeName=@EmployeeName, Email=@Email, Phone=@Phone, Address=@Address, Position=@Position, Image=@Image WHERE EID=@EID";

                        SqlCommand cmd = new SqlCommand(strQuery, connec);

                        connec.Open();
                        cmd.Parameters.AddWithValue("@EID", EID);
                        cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Position", Position);
                        cmd.Parameters.AddWithValue("@Image", Image);

                        
                        cmd.ExecuteNonQuery();
                        connec.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception here (print/log the error, etc.)
                    }
                }
            }



            public static void UpdateProductDetails(string ProductID, string ProductName, string Category, int Price, int Quantity, string Status,  byte[] Image)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[Product] SET ProductID = @ProductID,ProductName=@ProductName,Category=@Category,Price=@Price,Quantity=@Quantity,Status=@Status,Image=@Image WHERE ProductID = @ProductID", connec))
                    {
                        connec.Open();

                        cmd.Parameters.AddWithValue("@ProductID", ProductID);
                        cmd.Parameters.AddWithValue("@ProductName", ProductName);
                        cmd.Parameters.AddWithValue("@Category", Category);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@Image", Image);





                        cmd.ExecuteNonQuery();
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


            public static void UpdateTicket(string TicketID)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {


                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[SupportTicket] SET [Status] = '2' WHERE [TicketID] ='" + TicketID + "'", connec))
                    {



                        connec.Open();


                        cmd.Parameters.AddWithValue("@Status", "2");


                        cmd.ExecuteNonQuery();
                        connec.Close();


                    }
                }
            }//Func End


            public static void ApproveStock(string StockReqID)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {


                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[StockRequest] SET [Status] = '2' WHERE [StockReqID] ='" + StockReqID + "'", connec))
                    {



                        connec.Open();


                        cmd.Parameters.AddWithValue("@Status", "2");


                        cmd.ExecuteNonQuery();
                        connec.Close();


                    }
                }
            }//Func End


            public static void UpdateTask(string ProductID)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {


                    using (SqlCommand cmd = new SqlCommand("UPDATE [TeamTrac].[dbo].[DelegateProductAssignment] SET [Status] = '2' WHERE [ProductID] ='" + ProductID + "'", connec))
                    {



                        connec.Open();


                        cmd.Parameters.AddWithValue("@Status", "2");


                        cmd.ExecuteNonQuery();
                        connec.Close();


                    }
                }
            }//Func End

            //Update Quantity in Product Table
            public static void UpdateQuantity(string ProductID, int Quantity)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {
                    connec.Open();

                    string query = "UPDATE [TeamTrac].[dbo].[Product] SET  ProductID = @ProductID, [Quantity] = @Quantity WHERE [ProductID] = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, connec))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", ProductID);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                       

                        cmd.ExecuteNonQuery();
                    }

                    connec.Close();
                }
            }

            public static void UpdateAssignedQuantity(string ProductID, int Quantity)
            {
                using (SqlConnection connec = new SqlConnection(Global.Connection_String()))
                {
                    connec.Open();

                    string query = "UPDATE [TeamTrac].[dbo].[DelegateProductAssignment] SET  ProductID = @ProductID, [Quantity] = @Quantity WHERE [ProductID] = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, connec))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", ProductID);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);


                        cmd.ExecuteNonQuery();
                    }

                    connec.Close();
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
