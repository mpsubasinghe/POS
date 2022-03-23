using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationAlgorithem;
using I_MiddleLayer;

namespace MiddleLayer
{
    public    class GRNProduct : IGRNProduct 
    {
        private I_Validatoin<IGRNProduct> validation = null;
        public int GRNID { get; set; }
        public int ProdudctID { get; set; }
        public string ProductFullcode { get; set; }
        public string ProductName { get; set; }
        public double Qty { get; set; }
        public double MRP { get; set; }
        public double SPrice { get; set; }
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public double SubTotal { get; set; }
        public string Type { get; set; }
        
    }
}
