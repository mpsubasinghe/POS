using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_DAL;
using I_MiddleLayer;
using System.Data.SqlClient;
using FactoryMiddleLayer;

namespace DAL
{
    public class ProductStockDAL : CommonDAL, Interface_DAL<IProduct>
    {
        protected List<IProduct> AnyTypes = new List<IProduct>();
        public void Add(IProduct obj)
        {
            throw new NotImplementedException();
        }

        public void Update(IProduct obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(IProduct obj)
        {
            throw new NotImplementedException();
        }

        public IProduct SearchLast()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> Search()
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select Product.ProductID,productName from Product,Stock WHERE Product.ProductFullCode=Stock.ProductFullCode   Group By Product.ProductID,productName Order By productName";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;

            dr = objCommand.ExecuteReader();

            AnyTypes.Clear();
            while (dr.Read())
            {
                IProduct icust = FactoryML<IProduct>.Create<IProduct>("Product");
                icust.ProductID = Convert.ToInt32(dr["ProductID"]);
                icust.ProductName = (dr["ProductName"].ToString());
                //icust.ProductFullcode = Convert.ToDouble(dr["ProductFullcode"]);
                //icust.BarCode = Convert.ToString(dr["UPC"]);
                //icust.SPrice = Convert.ToDouble(dr["SPrice"]);
                //icust.MRP = Convert.ToDouble(dr["MRP"]);
                //icust.CPrice = Convert.ToDouble(dr["CPrice"]);
                //icust.Type = Convert.ToString(dr["Type"]);
                //icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                //icust.PhoneNumber = dr["PhoneNumber"].ToString();
                //icust.Address = dr["Address"].ToString();
                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IEnumerable<IProduct> Search(int Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from Product,Stock WHERE Product.ProductFullCode=Stock.ProductFullCode AND Qty>0 AND Product.ProductID= " + Index + "  Order By CPrice DESC";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            AnyTypes.Clear();
            while (dr.Read())
            {
                IProduct icust = FactoryML<IProduct>.Create<IProduct>("Product");
                icust.ProductID = Convert.ToInt32(dr["ProductID"]);
                icust.ProductName = (dr["ProductName"].ToString());
                icust.ProductFullcode = Convert.ToString(dr["ProductFullcode"]);
                icust.BarCode = Convert.ToString(dr["UPC"]);
                icust.SPrice = Convert.ToDouble(dr["SPrice"]);
                icust.MRP = Convert.ToDouble(dr["MRP"]);
                icust.CPrice = Convert.ToDouble(dr["CPrice"]);
                icust.Type = Convert.ToString(dr["Type"]);
                icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                icust.Qty = Convert.ToDouble(dr["Qty"]);
                //icust.PhoneNumber = dr["PhoneNumber"].ToString();
                //icust.Address = dr["Address"].ToString();
                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IEnumerable<IProduct> Search(string Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from Product,Stock WHERE Product.ProductFullCode=Stock.ProductFullCode AND  Qty>0 AND   Product.UPC= '" + Index + "'  Order By CPrice DESC";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            AnyTypes.Clear();
            while (dr.Read())
            {
                IProduct icust = FactoryML<IProduct>.Create<IProduct>("Product");
                icust.ProductID = Convert.ToInt32(dr["ProductID"]);
                icust.ProductName = (dr["ProductName"].ToString());
                icust.ProductFullcode = Convert.ToString(dr["ProductFullcode"]);
                icust.BarCode = Convert.ToString(dr["UPC"]);
                icust.SPrice = Convert.ToDouble(dr["SPrice"]);
                icust.MRP = Convert.ToDouble(dr["MRP"]);
                icust.CPrice = Convert.ToDouble(dr["CPrice"]);
                icust.Type = Convert.ToString(dr["Type"]);
                icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                icust.Qty = Convert.ToDouble(dr["Qty"]);
                //icust.PhoneNumber = dr["PhoneNumber"].ToString();
                //icust.Address = dr["Address"].ToString();
                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IEnumerable<IProduct> Search(string Index1, string Index2, string Index3)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from Product,Stock WHERE Product.ProductFullCode=Stock.ProductFullCode AND  Qty>0 AND   Product.ProductFullcode= '" + Index1 + "'  Order By CPrice DESC";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            AnyTypes.Clear();
            while (dr.Read())
            {
                IProduct icust = FactoryML<IProduct>.Create<IProduct>("Product");
                icust.ProductID = Convert.ToInt32(dr["ProductID"]);
                icust.ProductName = (dr["ProductName"].ToString());
                icust.ProductFullcode = Convert.ToString(dr["ProductFullcode"]);
                icust.BarCode = Convert.ToString(dr["UPC"]);
                icust.SPrice = Convert.ToDouble(dr["SPrice"]);
                icust.MRP = Convert.ToDouble(dr["MRP"]);
                icust.CPrice = Convert.ToDouble(dr["CPrice"]);
                icust.Type = Convert.ToString(dr["Type"]);
                icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                icust.Qty = Convert.ToDouble(dr["Qty"]);
                //icust.PhoneNumber = dr["PhoneNumber"].ToString();
                //icust.Address = dr["Address"].ToString();
                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IEnumerable<IProduct> SearchAny(string Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select Product.ProductID,ProductName,UPC from Product,Stock WHERE Product.ProductFullCode=Stock.ProductFullCode AND ProductName LIKE '%" + Index + "%'  Group By   Product.ProductID,ProductName,UPC Order By ProductName";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;

            dr = objCommand.ExecuteReader();

            AnyTypes.Clear();
            while (dr.Read())
            {
                IProduct icust = FactoryML<IProduct>.Create<IProduct>("Product");
                icust.ProductID = Convert.ToInt32(dr["ProductID"]);
                icust.ProductName = (dr["ProductName"].ToString());
                //icust.ProductFullcode = Convert.ToDouble(dr["ProductFullcode"]);
                icust.BarCode = Convert.ToString(dr["UPC"]);
                //icust.SPrice = Convert.ToDouble(dr["SPrice"]);
                //icust.MRP = Convert.ToDouble(dr["MRP"]);
                //icust.CPrice = Convert.ToDouble(dr["CPrice"]);
                //icust.Type = Convert.ToString(dr["Type"]);
                //icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);

                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IProduct SearchOne(string Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> GetData()
        {
            throw new NotImplementedException();
        }

        public IProduct GetData(int Index)
        {
            throw new NotImplementedException();
        }

        public void SetData(List<IProduct> anyTypes)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
