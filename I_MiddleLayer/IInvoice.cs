using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_MiddleLayer
{
   public interface IInvoice 
    {
   
        int invocieID { get; set; }
        double InvDate { get; set; }    
        double GrossTotal { get; set; }
        double Discount { get; set; }
        double NetTotal { get; set; }
        string Valid { get; set; }
        DateTime InvDateTime { get; set; }
         string Type { get; set; }
         string CustomerID { get; set; }

         string UserID { get; set; }
         string PriceType { get; set; }

        //ICustomer customer { get; set; }
        //List<I_InvoicedStaff> invociedstaff { get; set; }
        List<IInvoicedProduct> invocedproducts { get; set; }

        void Validation();
        double CalculateGrossTotal();
        double CalculateTotalDiscount();
        double CalculateNetTotal();

        void AddInvoiceProduct(IInvoicedProduct invProduct);

    }
}
