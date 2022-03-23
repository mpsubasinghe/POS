using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace MiddleLayer
{
    public class InvoiceReturn :InvoiceBase ,IInvoiceR
    {

        public void Validation()
        {
            throw new NotImplementedException();
        }

        public override double CalculateNetTotal()
        {
            return CalculateGrossTotal() - CalculateTotalDiscount() * -1;
        }

        public void  CreateInvoicedProductList(List <IInvoicedProduct> invoiceProductList)
        {
            List<IInvoicedProduct> invlist = new List<IInvoicedProduct>();
            int count = 0;
            List<int> removeArray = new List<int>();
            foreach (IInvoicedProduct person in invoiceProductList)
            {
                
                if (person.Qty > 0)
                {
                    this.invocedproducts[count].Qty = person.Qty;
                }
                else
                {
                    removeArray.Add(count);
                    this.invocedproducts[count].Qty = 0;
                }

                count = count + 1;
            }
      
            foreach (int a in removeArray )
            {
                this.invocedproducts.RemoveAt(a);
            }

            

        }
    }
}
