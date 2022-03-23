using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_MiddleLayer
{
   public interface IStock
    {
         int ProdudctID { get; set; }
         string ProductFullcode { get; set; }
         string ProductName { get; set; }
         double Qty { get; set; }
         string Type { get; set; }
    }

}
