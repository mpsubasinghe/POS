using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
namespace ValidationAlgorithem
{
    public class InvoiceValidation : I_Validatoin<IInvoice>
    {
        public void Validation(IInvoice obj)
        {
            if (obj.CalculateNetTotal() == 0)
            {
                throw new Exception("Please go to the NEW invoice..!!!");
            }  
            if (obj.invocieID == 0)
            {
                throw new Exception("Customer ID is required");
            }
            if (obj.Type == "Invoice")
            {
                if (obj.CalculateGrossTotal() < obj.CalculateTotalDiscount())
                {
                    throw new Exception("Bill amount should be more than discount value...???");
                }
            }
            
            if (obj.invocedproducts.Count==0)
            {
                throw new Exception("Please Add Items to Invoice..?");
            }

        }
    }
    public class InvoiceIDValidation : I_Validatoin<IInvoice>
    {
        public void Validation(IInvoice obj)
        {
            //if (obj.customer.CusID == null)
            //{
            //    throw new Exception("Please go to the NEW invoice..!!!");
            //}
            if (obj.CalculateNetTotal() == 0)
            {
                throw new Exception("Please go to the NEW invoice..!!!");
            }
            if (obj.invocieID == 0)
            {
                throw new Exception("Customer ID is required");
            }
            if (obj.CalculateGrossTotal() < obj.CalculateTotalDiscount())
            {
                throw new Exception("Bill amount should be more than discount value...???");
            }
            //double tot = 0;
            //foreach (I_InvoicedStaff person in obj.invociedstaff)
            //{
            //    tot = tot + person.Amount;
            //}
            //if (obj.CalculateNetTotal() != tot)
            //{
            //    throw new Exception("Bill amount should be equal to staff total...???");
            //}
        }
    }
}
