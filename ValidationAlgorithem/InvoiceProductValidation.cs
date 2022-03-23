using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
namespace ValidationAlgorithem
{
    public class InvoiceProductValidation : I_Validatoin<IInvoicedProduct>
    {

        public void Validation(IInvoicedProduct obj)
        {
            if (obj.SPrice <= 0)
            {
                throw new Exception("Selected Price Type Not Available For This Product..??");
            }
            if (obj.Qty <= 0)
            {
                throw new Exception("Invalid Qty");
            }
            if (obj.DiscountAmount < 0 )
            {
                //obj.Discount = 0;
                throw new Exception("Invalid Discount");
            }
            if (obj.DiscountPercentage < 0)
            {
                //obj.Discount = 0;
                throw new Exception("Invalid Discount");
            }
            if (obj.DiscountAmount >= obj.SPrice)
            {
                throw new Exception("Discount should be lessthan product price..?");
            }
            if (obj.DiscountPercentage >= 100)
            {
                throw new Exception("Discount Percentage should be lessthan 100% ..?");
            }
            if (obj.DiscountPercentage >= 100)
            {
                throw new Exception("Discount Percentage should be lessthan 100% ..?");
            }

        }
    }
}
