using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTrac
{
    internal class Model
    {
        public class Employee
        {
            public string EID { get; set; }
            public string EmployeeName { get; set; }
            public string Position { get; set; }
            public string Status { get; set; }
           
        }

        public class CompanyDetails
        {
            public string ID { get; set; }
            public string CompanyName { get; set; }
            public string CompanyAddress { get; set; }
            public string CompnayBin { get; set; }
            public string TradeLicenceNo { get; set; }
            public string ContactNo { get; set; }
            public string OwnerFullName { get; set; }
            public string CompanyEmail { get; set; }
            public string OwnerEmail { get; set; }
            public string NID { get; set; }
            public string PhoneNo { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Status { get; set; }
            public byte[] Image { get; set; }

      
        }

        public class DelegateDetails
        {
            public string DelegateID { get; set; }
            public string DelegateName { get; set; }
            public string PhoneNo { get; set; }
            public string Email { get; set; }
            public string NID { get; set; }
            public string DOB { get; set; }
            public byte[] Image { get; set; }
            public string OnBoardDateTime { get; set; }
            public string DelegateAddress { get; set; }
            public string DelegateDistrict { get; set; }
            public string DelegateArea { get; set; }
            public string DelegateZipCode { get; set; }
            public string Status { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
