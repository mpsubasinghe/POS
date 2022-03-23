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
  public   class SettingDAL :CommonDAL, Interface_DAL<ISetting>
    {
      protected List<ISetting> AnyTypes = new List<ISetting>();


             public void Add(ISetting obj)
             {
                 throw new NotImplementedException();
             }

             public void Update(ISetting obj)
             {
                 throw new NotImplementedException();
             }

             public void Delete(ISetting obj)
             {
                 throw new NotImplementedException();
             }

             public ISetting SearchLast()
             {
                 throw new NotImplementedException();
             }

             public IEnumerable<ISetting> Search()
             {
                 throw new NotImplementedException();
             }

             public IEnumerable<ISetting> Search(int Index)
             {
                 throw new NotImplementedException();
             }

             public IEnumerable<ISetting> Search(string Index)
             {
                 objCommand = new SqlCommand();
                 objCommand.CommandText = "select * from Setting where SettingID= '" + Index + "' ";
                 objCommand.Connection = objConn;
                 SqlDataReader dr = null;

                 dr = objCommand.ExecuteReader();

                 AnyTypes.Clear();
                 while (dr.Read())
                 {
                     ISetting icust = FactoryML<ISetting>.Create<ISetting>("Setting");
                     icust.SettingID = Convert.ToString (dr["SettingID"]);
                     icust.SettingValue  = (dr["Value"].ToString());
                     //icust.ProductFullcode = Convert.ToString(dr["ProductFullcode"]);
                     //icust.BarCode = Convert.ToString(dr["UPC"]);
                     //icust.SPrice = Convert.ToDouble(dr["SPrice"]);
                     //icust.MRP = Convert.ToDouble(dr["MRP"]);
                     //icust.CPrice = Convert.ToDouble(dr["CPrice"]);
                     //icust.Type = Convert.ToString(dr["Type"]);
                     //icust.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                     //icust.Qty = dr["Qty"] as double? ?? default(double);
                     ////icust.Address = dr["Address"].ToString();
                     AnyTypes.Add(icust);
                 }
                 dr.Close();
                 return AnyTypes;
             }

             public IEnumerable<ISetting> Search(string Index1, string Index2, string Index3)
             {
                 throw new NotImplementedException();
             }

             public IEnumerable<ISetting> SearchAny(string Index)
             {
                 throw new NotImplementedException();
             }

             public ISetting SearchOne(string Index)
             {
                 throw new NotImplementedException();
             }

             public IEnumerable<ISetting> GetData()
             {
                 throw new NotImplementedException();
             }

             public ISetting GetData(int Index)
             {
                 throw new NotImplementedException();
             }

             public void SetData(List<ISetting> anyTypes)
             {
                 throw new NotImplementedException();
             }

             public void Save()
             {
                 throw new NotImplementedException();
             }
    }
}
