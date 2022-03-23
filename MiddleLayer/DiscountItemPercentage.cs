using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
namespace MiddleLayer
{
   public class DiscountItemPercentage : I_DiscountItem
    {
        public double CalculateItemDiscount(IInvoicedProduct iInvoiceProduct)
        {
            return iInvoiceProduct.SPrice * iInvoiceProduct.DiscountPercentage/100;
        }
        public double CalculateTotalItemDiscount(IInvoicedProduct iInvoiceProduct)
        {
            return (iInvoiceProduct.SPrice * iInvoiceProduct.DiscountPercentage / 100) * iInvoiceProduct.Qty;
        }
    }
}
