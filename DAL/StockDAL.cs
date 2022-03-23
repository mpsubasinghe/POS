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
    public class StockDAL : CommonDAL, Interface_DAL<IStock>
    {
        public void Add(IStock obj)
        {
            throw new NotImplementedException();
        }

        public void Update(IStock obj)
        {
          
                objCommand = new SqlCommand();
                objCommand.CommandText = @"
                Update Stock SET Qty=Qty-@Parameter1   WHERE ProductFullcode=@Parameter2 ";
                objCommand.Parameters.AddWithValue("@Parameter1", obj.Qty);
                objCommand.Parameters.AddWithValue("@Parameter2", obj.ProductFullcode);       
                objCommand.Connection = objConn;
                objCommand.ExecuteNonQuery();
         
        }

        public void Delete(IStock obj)
        {
            throw new NotImplementedException();
        }

        public IStock SearchLast()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStock> Search()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStock> Search(int Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStock> Search(string Index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStock> Search(string Index1, string Index2, string Index3)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStock> SearchAny(string Index)
        {
            throw new NotImplementedException();
        }

        public IStock SearchOne(string Index)
        {
            objCommand = new SqlCommand();
            objCommand.CommandText = "select * from Stock  WHERE ProductFullcode= '" + Index + "'  ";
            objCommand.Connection = objConn;
            SqlDataReader dr = null;

            dr = objCommand.ExecuteReader();

            IStock  icust = FactoryML<IStock >.Create<IStock >("Stock");

            while (dr.Read())
            {
                icust.ProdudctID = Convert.ToInt32(dr["ProductID"]);
                icust.ProductName = "";
                icust.ProductFullcode = Convert.ToString(dr["ProductFullcode"]);
                icust.Qty = Convert.ToDouble(dr["Qty"]);
                icust.Type = Convert.ToString(dr["Type"]);
    
                
            }
            dr.Close();
            return icust;
        }

        public IEnumerable<IStock> GetData()
        {
            throw new NotImplementedException();
        }

        public IStock GetData(int Index)
        {
            throw new NotImplementedException();
        }

        public void SetData(List<IStock> anyTypes)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
