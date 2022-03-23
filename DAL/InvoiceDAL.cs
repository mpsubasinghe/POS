using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
using I_DAL;
using System.Data.SqlClient;
using FactoryMiddleLayer;
namespace DAL
{
public class InvoiceDAL : CommonDAL, Interface_DAL<IInvoice>
{
        public void Add(IInvoice obj)
        {
             objCommand = new SqlCommand();
            objCommand.CommandText = @"
                INSERT INTO Invoice 
                VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7, @Parameter8,
                @Parameter9, @Parameter10, @Parameter11, @Parameter12, @Parameter13, @Parameter14)";

            objCommand.Parameters.AddWithValue("@Parameter1", obj.invocieID);
            objCommand.Parameters.AddWithValue("@Parameter2", "1");
            objCommand.Parameters.AddWithValue("@Parameter3", "1"); 
            objCommand.Parameters.AddWithValue("@Parameter4", DateTime.Now.Date.ToString("yyyyMMdd"));
            objCommand.Parameters.AddWithValue("@Parameter5", DateTime.Now);
            objCommand.Parameters.AddWithValue("@Parameter6", obj.CalculateGrossTotal());
            objCommand.Parameters.AddWithValue("@Parameter7", obj.CalculateTotalDiscount());
            objCommand.Parameters.AddWithValue("@Parameter8", obj.CalculateNetTotal());
            objCommand.Parameters.AddWithValue("@Parameter9", "YES");
            objCommand.Parameters.AddWithValue("@Parameter10", "Print");
            objCommand.Parameters.AddWithValue("@Parameter11", obj.Type);
            objCommand.Parameters.AddWithValue("@Parameter12", 0);
            objCommand.Parameters.AddWithValue("@Parameter13", "");
            objCommand.Parameters.AddWithValue("@Parameter14", "");

            objCommand.Connection = objConn;
            objCommand.ExecuteNonQuery();
           
            InvoiceProductDAL a = new InvoiceProductDAL();
        }

        public void Update(IInvoice obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(IInvoice obj)
        {
            throw new NotImplementedException();
        }

        public IInvoice SearchLast()
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select MAX(InvID) AS InvID from  Invoice  ";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;
          
            dr = objCommand.ExecuteReader();
      
            IInvoice icust = FactoryML<IInvoice>.Create<IInvoice>("Invoice");
            while (dr.Read())
            {
                var value = dr["InvID"];
                if (value != DBNull.Value)
                {
                    icust.invocieID = Convert.ToInt32(dr["InvID"]);
                    //icust.Discount = Convert.ToDouble(dr["Discount"]);
                    //icust.GrossTotal = Convert.ToDouble(dr["GrossTot"]);
                    //icust.InvDate = Convert.ToDouble(dr["InvDate"]);
                    //icust.InvDateTime = Convert.ToDateTime(dr["InvTime"]);
                    //icust.NetTotal = Convert.ToDouble(dr["Total"]);
                    //icust.Valid = (dr["Valid"].ToString());
                    ////icust.InvDateTime = Convert.ToDouble(dr["CPrice"]);
                    //icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                    //icust.PhoneNumber = dr["PhoneNumber"].ToString();
                    //icust.Address = dr["Address"].ToString();
                }
              
                
            }
            dr.Close();
            return icust;
        }

        public IEnumerable<IInvoice> Search()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoice> Search(int Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoice> Search(string Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoice> Search(string Index1, string Index2, string Index3)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoice> SearchAny(string Index)
        {
            throw new NotImplementedException();
        }

        public IInvoice SearchOne(string Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from  Invoice WHERE InvID ='"+ Index + "' ";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;

            dr = objCommand.ExecuteReader();

            IInvoice icust = FactoryML<IInvoice>.Create<IInvoice>("Invoice");
            while (dr.Read())
            {
                var value = dr["InvID"];
                if (value != DBNull.Value)
                {
                    icust.invocieID = Convert.ToInt32(dr["InvID"]);
                    icust.CustomerID = Convert.ToString(dr["CustID"]);
                    icust.UserID = Convert.ToString(dr["UserID"]);
                    icust.InvDate = Convert.ToDouble(dr["Date"]);
                    icust.InvDateTime = Convert.ToDateTime(dr["Time"]);
                    icust.GrossTotal = Convert.ToDouble(dr["GrossTot"]);
                    icust.Discount = Convert.ToDouble(dr["Discount"].ToString());
                    icust.NetTotal = Convert.ToDouble(dr["Total"].ToString());
                    icust.Valid = (dr["Valid"].ToString());
                    icust.Type = (dr["BillType"].ToString());
                    //icust.Discount = (dr["Valid"].ToString());
                    //////icust.InvDateTime = Convert.ToDouble(dr["CPrice"]);
                    ////icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                    ////icust.PhoneNumber = dr["PhoneNumber"].ToString();
                    ////icust.Address = dr["Address"].ToString();
                }


            }
            dr.Close();
            return icust;
        }

        public IEnumerable<IInvoice> GetData()
        {
            throw new NotImplementedException();
        }

        public IInvoice GetData(int Index)
        {
            throw new NotImplementedException();
        }

        public void SetData(List<IInvoice> anyTypes)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
