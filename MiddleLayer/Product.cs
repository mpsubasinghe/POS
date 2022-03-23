using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using I_MiddleLayer;
//using FactoryDAL;
//using I_DAL;
using I_MiddleLayer;


namespace MiddleLayer
{
    public class Product :IProduct
    {
        public int ProductID { get; set; }
        public string ProductFullcode { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public double CPrice { get; set; }
        public double SPrice { get; set; }
        public double WSPrice { get; set; }
        public double CSPrice { get; set; }
        public double MRP { get; set; }
        public double Dis { get; set; }
        public DateTime EffectiveDate { get; set; }
        public double Qty { get; set; }

        public double GetSellingPrice(string type)
        {
         
            if (type == "Retailer")
            {
                return SPrice;
            }
            if (type == "Whole Sale")
            {
                return WSPrice;
            }
            if (type == "Credit")
            {
                return CSPrice;
            }
            return MRP;
        }
        public string Add(IProduct produt)
        {
            IProduct dd = FactoryML_inMiddle<IProduct>.Create1<IProduct>("");
            //Interface_DAL<IProduct> CusIdal = null;//FactoryDalLayer<Interface_DAL<IProduct>>.Create1<Interface_DAL<IProduct>>("CustomerDAL");
        
            return "";
        }
    }
}
