using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_MiddleLayer
{
   public  interface IInvoiceR:IInvoice 
    {
       void CreateInvoicedProductList(List<IInvoicedProduct> invoiceProductList);
    }
}
