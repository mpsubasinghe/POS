using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
namespace MiddleLayer
{
    public class DiscountItemDefault : I_DiscountItem
    {
        public double DisAmount { get; set; }
        public double ItemValue { get; set; }

        public double CalculateItemDiscount(IInvoicedProduct iInvoiceProduct)
        {
            return 0;
        }
        public double CalculateTotalItemDiscount(IInvoicedProduct iInvoiceProduct)
        {
            return 0;
        }
      
    }
}
