    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_MiddleLayer
{
    public interface IProduct
    {
         int ProductID { get; set; }
         string ProductFullcode { get; set; }
         string BarCode { get; set; }
         string ProductName { get; set; }
         string Type { get; set; }
         double CPrice { get; set; }
         double SPrice { get; set; }
         double MRP { get; set; }
         double Dis { get; set; }
         DateTime EffectiveDate { get; set; }
         double Qty { get; set; }
         double WSPrice { get; set; }
         double CSPrice { get; set; }

         double GetSellingPrice(string type);
    }
}
