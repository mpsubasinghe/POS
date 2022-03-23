using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
using I_DAL;
using FactoryMiddleLayer;
using System.Data.SqlClient;

namespace DAL
{
   public  class InvoiceRDAL: CommonDAL,Interface_DAL<IInvoiceR>
    {
        public void Add(IInvoiceR obj)
        {
            throw new NotImplementedException();
        }

        public void Update(IInvoiceR obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(IInvoiceR obj)
        {
            throw new NotImplementedException();
        }

        public IInvoiceR SearchLast()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoiceR> Search()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoiceR> Search(int Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoiceR> Search(string Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoiceR> Search(string Index1, string Index2, string Index3)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoiceR> SearchAny(string Index)
        {
            throw new NotImplementedException();
        }

        public IInvoiceR SearchOne(string Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from  Invoice WHERE InvID ='" + Index + "' ";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;

            dr = objCommand.ExecuteReader();

            IInvoiceR icust = FactoryML<IInvoiceR>.Create<IInvoiceR>("InvoiceReturn");
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

        public IEnumerable<IInvoiceR> GetData()
        {
            throw new NotImplementedException();
        }

        public IInvoiceR GetData(int Index)
        {
            throw new NotImplementedException();
        }

        public void SetData(List<IInvoiceR> anyTypes)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
