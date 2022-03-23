using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_MiddleLayer
{
    public interface IInvoicedProduct
    {
        int InvID { get; set; }
        int ProdudctID { get; set; }
        string ProductName { get; set; }
        double Qty { get; set; }
         double SPrice { get; set; }
       
         double MRP { get; set; }
          double DiscountPercentage { get; set; }
          double DiscountAmount { get; set; }
        double SubTotal { get; set; }
        string Type { get; set; }
        string ProductFullcode { get; set; }

        double CalItemDiscont();
        double CalTotalDiscont();
        double CalculateDiscountedSubTotal();
        double CalculateSubTotal();
        void Validation();
    }
}
