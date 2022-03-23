using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace MiddleLayer
 {
    public abstract class InvoiceBase
    {
            public int invocieID { get; set; }
            public double InvDate { get; set; }
            public DateTime InvDateTime { get; set; }
            public double Discount { get; set; }
            public double GrossTotal { get; set; }
            public double NetTotal { get; set; }
            public string Valid { get; set; }
            public string Type { get; set; }
            public string CustomerID { get; set; }
            public string UserID { get; set; }
            public string PriceType { get; set; }
            public List<IInvoicedProduct> invocedproducts { get; set; }

            public InvoiceBase()
            {
                this.invocedproducts = new List<IInvoicedProduct>();
            }

        public  void AddInvoiceProduct(IInvoicedProduct invProduct)
        {
              this.invocedproducts .Add (invProduct);
        }
        public void AddInvoiceProduct_FastBilling(IInvoicedProduct invProduct)
        {
            this.invocedproducts.Add(invProduct);
        }

        //Reguler method
        public  double CalculateGrossTotal()
        {
            double tot = 0;
            if (invocedproducts != null)
            {
                foreach (IInvoicedProduct invproducts in invocedproducts)
                {                 
                        tot = tot + (invproducts.CalculateSubTotal());                                    
                }
            }
            return tot;
        }

        //Reguler method
        public double CalculateTotalDiscount()
        {
            double tot = 0;
            if (invocedproducts != null)
            {
                foreach (IInvoicedProduct invproducts in invocedproducts)
                {
                    tot = tot + (invproducts.CalTotalDiscont());
                }
            }
            return tot;
        }
        //Abstract method
        public abstract double CalculateNetTotal();
      
    }
}
