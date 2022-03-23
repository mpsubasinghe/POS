using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace MiddleLayer
{
    public class DiscountItemValue : I_DiscountItem
    {
        public double DisAmount { get; set; }
        public double ItemValue { get; set; }


        public double CalculateItemDiscount(IInvoicedProduct iInvoiceProduct)
        {
            return iInvoiceProduct.DiscountAmount ;
        }
        public double CalculateTotalItemDiscount(IInvoicedProduct iInvoiceProduct)
        {
            return iInvoiceProduct.DiscountAmount * iInvoiceProduct.Qty;
        }
    }
}
