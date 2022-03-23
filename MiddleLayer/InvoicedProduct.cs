using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
using ValidationAlgorithem;
using FactoryVal;
namespace MiddleLayer
{
    public class InvoiceProduct : IInvoicedProduct
    {
        private I_DiscountItem iDiscountitem = null;
        private I_Validatoin<IInvoicedProduct> validation = null;
        public int InvID { get; set; }
        public int ProdudctID { get; set; }
        public string ProductName { get; set; }
        public double Qty { get; set; }       
        public double MRP { get; set; }
        public double SPrice { get; set; }
        public double DiscountPercentage { get; set; } 
        public double DiscountAmount { get; set; }
        public double SubTotal { get; set; }
        public string Type { get; set; }
        public string ProductFullcode  { get; set; }

        public double CalculateDiscountedSubTotal()
        {
            return ((this.MRP * this.Qty) - this.CalTotalDiscont());
        }
        public double CalculateSubTotal()
        {
            return ((this.MRP * this.Qty));
        } 

        //private double subTotal;
        //public double SubTotal
        //{
        //    get { return (this.Price - this.CalculateDiscont()) * this.Qty; }
        //    set { subTotal = value; }
        //}


        //public double SubTotal
        //{
        //    get
        //    {
        //        return (this.Price - this.CalculateDiscont()) * this.Qty;
        //    }
        //    set
        //    {
        //        this.SubTotal = value;
        //    }
        //}  

        public InvoiceProduct()
        {

        }
        public InvoiceProduct(I_DiscountItem _iDiscount)
        {
            iDiscountitem = _iDiscount;
            //validation = _validation;
        }

        public double CalItemDiscont()
        {
            return iDiscountitem.CalculateItemDiscount(this);
        }
        public double CalTotalDiscont()
        {
            return iDiscountitem.CalculateTotalItemDiscount(this);
        }

        public void Validation()
        {
            validation = FactoryValidation<InvoiceProductValidation>.Create<InvoiceProductValidation>("InvoiceProductValidation");
            validation.Validation(this);
        }
    }
}
