using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
////using MiddleLayer;
using I_DAL;
using System.Data.SqlClient;
//using FactoryDAL;
using FactoryMiddleLayer;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class ProductDAL : CommonDAL, Interface_DAL<IProduct>
    {
        ////protected List<AnyType> AnyTypes = new List<AnyType>();
        //protected List<AnyType> AnyTypesLast = new List<AnyType   >();
        protected List<IProduct> AnyTypes = new List<IProduct>();


        public ProductDAL()
        {

        }
        public void Add(IProduct obj)
        {
            throw new NotImplementedException();
        }

        public void Update(IProduct obj)
        {
            //Interface_DAL<IProduct> CusIdal = FactoryDalLayer<Interface_DAL<IProduct>>.Create1<Interface_DAL<IProduct>>("CustomerDAL");
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

        public IEnumerable<IProduct> Search(int Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from Product LEFT JOIN Stock ON  Product.ProductFullCode=Stock.ProductFullCode WHERE Product.ProductID= " + Index + "  Order By CPrice DESC";
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
                icust.CSPrice =  dr["CSPrice"] as double? ?? default(double);;
                icust.WSPrice = dr["WSPrice"] as double? ?? default(double);
                icust.Type = Convert.ToString(dr["Type"]);
                icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                icust.Qty = dr["Qty"] as double? ?? default(double);
                //icust.Address = dr["Address"].ToString();
                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IEnumerable<IProduct> Search(string Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from Product LEFT JOIN Stock ON  Product.ProductFullCode=Stock.ProductFullCode WHERE  UPC= '" + Index + "'  Order By CPrice DESC";
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
                icust.CSPrice = dr["CSPrice"] as double? ?? default(double);
                          icust.WSPrice =  dr["WSPrice"] as double? ?? default(double);
                icust.Type = Convert.ToString(dr["Type"]);
                icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
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
            objCommand.CommandText = "select * from Product LEFT JOIN Stock ON  Product.ProductFullCode=Stock.ProductFullCode WHERE ProductFullcode= '" + Index1 + "'  Order By CPrice DESC";
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
                icust.CSPrice = dr["CSPrice"] as double? ?? default(double);
                icust.WSPrice = dr["WSPrice"] as double? ?? default(double);
                icust.Type = Convert.ToString(dr["Type"]);
                icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                icust.Qty = dr["Qty"] as double? ?? default(double);
                //icust.Address = dr["Address"].ToString();
                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IEnumerable<IProduct> SearchAny(string Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select ProductID,ProductName,UPC from Product WHERE ProductName LIKE '%" + Index + "%'  Group By ProductID,ProductName,UPC Order By ProductName";
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
            return AnyTypes[Index]; 
        }

        public void SetData(List<IProduct> anyTypes)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<IProduct> Search()
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select Product.ProductID,productName from Product LEFT JOIN Stock ON  Product.ProductFullCode=Stock.ProductFullCode  Group By Product.ProductID,productName Order By productName";
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

   
    }
}
