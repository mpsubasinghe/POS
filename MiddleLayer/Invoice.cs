using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
using ValidationAlgorithem;
using FactoryVal;


namespace MiddleLayer
{
    public class Invoice : InvoiceBase , IInvoice
    {
        //public int invocieID { get; set; }
        //public double InvDate { get; set; }
        //public DateTime InvDateTime { get; set; }
        //public double Discount { get; set; }
        //public double GrossTotal { get; set; }
        //public double NetTotal { get; set; }
        //public string Valid { get; set; }
        //public string Type { get; set; }
        //public string CustomerID { get; set; }
        //public string UserID { get; set; }

        private I_Validatoin<IInvoice> invoiceValidation = null;
        //public List<IInvoicedProduct> invocedproducts { get; set; }

        //public Invoice(I_Validatoin<I_Invoice> _invoiceValidation)
        //{
        //    invoiceValidation = _invoiceValidation;
        //}

        //public  double CalculateGrossTotal()
        //{
       
        //    double tot = 0;
        //    if (invocedproducts != null)
        //    {
        //        foreach (IInvoicedProduct invproducts in invocedproducts)
        //        {
        //            if (invproducts.Type == "Invoice")
        //            {
        //                tot = tot + (invproducts.CalculateSubTotal());
        //            }
        //            else
        //            {
        //                tot = tot + (invproducts.CalculateSubTotal());
        //            }
        //        }
        //    }
        //    return tot;
        //}


        //public double CalculateTotalDiscount()
        //{
        //    double tot = 0;
        //    if (invocedproducts != null)
        //    {
        //        foreach (IInvoicedProduct invproducts in invocedproducts)
        //        {
        //            tot = tot + (invproducts.CalTotalDiscont());
        //        }
        //    }
        //    return tot;
        //}

        //public double CalculateNetTotal()
        //{
        //    return CalculateGrossTotal() - CalculateTotalDiscount();
        //}


        //public ICustomer customer { get; set; }
        //public List<I_InvoicedStaff> invociedstaff { get; set; }
      
        public void Validation()
        {
            //Interface_DAL<IProduct> productDAL = FactoryDalLayer<Interface_DAL<IProduct>>.Create<Interface_DAL<IProduct>>("ProductDAL");

            invoiceValidation = FactoryValidation<InvoiceValidation>.Create<InvoiceValidation>("InvoiceValidation");
            invoiceValidation.Validation(this);
        }

        ////public double GrossTotal { 

        ////     get{
        ////        double tot = 0;
        ////        if (invocedproducts != null)
        ////        {
        ////            foreach (I_InvoicedProduct invproducts in invocedproducts)
        ////            {
        ////                tot = tot + (invproducts.Qty * invproducts.Price) ;
        ////            }
        ////        }
        ////        return tot;
        ////    }
        ////    set { GrossTotal = value; }           
        ////}

        //public double Discount
        //{

        //    get
        //    {
        //        double tot = 0;
        //        if (invocedproducts != null)
        //        {
        //            foreach (I_InvoicedProduct invproducts in invocedproducts)
        //            {
        //                tot = tot + invproducts.CalculateDiscont();
        //            }
        //        }
        //        return tot;
        //    }
        //    set { Discount = value; }
        //}
        //  public double Discount { get; set; }
        ////public double NetTotal
        ////{
        ////    get             // This is custom, not auto-implemented
        ////    {
        ////        return GrossTotal - Discount;
        ////    }
        ////    set             // This is custom, not auto-implemented. Correct
        ////    {
        ////       // NetTotal = value;
        ////    }

        ////}

        //////////////private double NetTotal;
        //////////////public double GetNetTotal()
        //////////////{
        //////////////    return GrossTotal - Discount;
        //////////////}

        //////////////public void SetNetTotal(double _NetTotal)
        //////////////{
        //////////////    NetTotal = _NetTotal;
        //////////////}

        public override double CalculateNetTotal()
        {
            return CalculateGrossTotal() - CalculateTotalDiscount();
        }
    }
}
