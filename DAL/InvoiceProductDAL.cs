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
    public class InvoiceProductDAL : CommonDAL, Interface_DAL<IInvoicedProduct>
    {
        protected List<IInvoicedProduct> AnyTypes = new List<IInvoicedProduct>();
        public void Add(IInvoicedProduct obj)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = @"
                INSERT INTO InvoicedProduct 
                VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7, @Parameter8, @Parameter9)";

            objCommand.Parameters.AddWithValue("@Parameter1", obj.InvID);
            objCommand.Parameters.AddWithValue("@Parameter2", obj.ProdudctID);
            objCommand.Parameters.AddWithValue("@Parameter3", obj.ProductFullcode);
            objCommand.Parameters.AddWithValue("@Parameter4", obj.SPrice);
            objCommand.Parameters.AddWithValue("@Parameter5", obj.CalItemDiscont());
            objCommand.Parameters.AddWithValue("@Parameter6", obj.DiscountPercentage);
            objCommand.Parameters.AddWithValue("@Parameter7", obj.Qty);
            objCommand.Parameters.AddWithValue("@Parameter8", obj.CalculateDiscountedSubTotal());
            objCommand.Parameters.AddWithValue("@Parameter9", obj.Type);
            //objCommand.Parameters.AddWithValue("@Parameter9", "YES");
            //objCommand.Parameters.AddWithValue("@Parameter10", "Print");
            //objCommand.Parameters.AddWithValue("@Parameter11", "");
            //objCommand.Parameters.AddWithValue("@Parameter12", 0);
            //objCommand.Parameters.AddWithValue("@Parameter13", "");
            //objCommand.Parameters.AddWithValue("@Parameter14", "");
            objCommand.Connection = objConn;
            objCommand.ExecuteNonQuery();
          
            objCommand.Parameters.Clear();
        }

        public void Update(IInvoicedProduct obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(IInvoicedProduct obj)
        {
            throw new NotImplementedException();
        }

        public IInvoicedProduct SearchLast()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoicedProduct> Search()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoicedProduct> Search(int Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select InvID,InvoicedProduct.ProductID,InvoicedProduct.ProductFullcode,ProductName,MRP,InvoicedProduct.SPrice,Qty,DiscountAmount,DiscountPercentage,SubTotal From InvoicedProduct,Product WHERE InvoicedProduct.ProductFullcode=Product.ProductFullcode AND InvID=" + Index + "  ";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            AnyTypes.Clear();
            while (dr.Read())
            {
                IInvoicedProduct icust = null;
                if (Convert.ToDouble(dr["DiscountAmount"])>0)
                {
                    icust = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisValue");
                }
                else
                {
                    icust = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisDefault");
                }
                if (Convert.ToDouble(dr["DiscountPercentage"]) > 0)
                {
                    icust = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductPercentage");
                }
                icust.InvID = Convert.ToInt32(dr["InvID"]);
                icust.ProdudctID = Convert.ToInt32(dr["ProductID"]);
                icust.ProductFullcode = Convert.ToString(dr["ProductFullcode"]);
                icust.ProductName = (dr["ProductName"].ToString());
                icust.MRP = Convert.ToDouble(dr["MRP"]);
                icust.SPrice = Convert.ToDouble(dr["SPrice"]);
                icust.Qty = Convert.ToDouble(dr["Qty"]);
                icust.DiscountAmount = Convert.ToDouble(dr["DiscountAmount"]);
                icust.DiscountPercentage = Convert.ToDouble(dr["DiscountPercentage"]);
                icust.SubTotal = Convert.ToDouble(dr["SubTotal"]);

              

      
                //icust.PhoneNumber = dr["PhoneNumber"].ToString();
                //icust.Address = dr["Address"].ToString();
                AnyTypes.Add(icust);
            }
            dr.Close();
            return AnyTypes;
        }

        public IEnumerable<IInvoicedProduct> Search(string Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoicedProduct> Search(string Index1, string Index2, string Index3)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoicedProduct> SearchAny(string Index)
        {
            throw new NotImplementedException();
        }

        public IInvoicedProduct SearchOne(string Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInvoicedProduct> GetData()
        {
            throw new NotImplementedException();
        }

        public IInvoicedProduct GetData(int Index)
        {
            throw new NotImplementedException();
        }

        public void SetData(List<IInvoicedProduct> anyTypes)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
