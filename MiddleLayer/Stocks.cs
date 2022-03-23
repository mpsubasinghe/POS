using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace MiddleLayer
{
    public class Stocks : IStock
    {
      
        public int ProdudctID { get; set; }
        public string ProductFullcode { get; set; }
        public string ProductName { get; set; }
        public double Qty { get; set; }
        public string Type { get; set; }
    }
}
