using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

using MiddleLayer;
using I_MiddleLayer;
using ValidationAlgorithem;

namespace FactoryMiddleLayer
{
    public static class FactoryML<AnyType> // Design pattern :- Simple factory pattern
    {
        ////private static IUnityContainer ObjectsofOurProjects = null;

        ////public static AnyType Create(string Type)
        ////{
        ////    // Design pattern :- Lazy loading. Eager loading
        ////    if (ObjectsofOurProjects == null)
        ////    {
        ////        ObjectsofOurProjects = new UnityContainer();
             
              
        ////        ObjectsofOurProjects.RegisterType<I_InvoicedProduct, InvoiceProduct>("InvoicedProductDisounted", new InjectionConstructor(new DiscountItemValue(), new InvoiceProductValidation()));
        ////        ObjectsofOurProjects.RegisterType<I_InvoicedProduct, InvoiceProduct>("InvoicedProductDefault", new InjectionConstructor(new DiscountItemDefault(), new InvoiceProductValidation()));

        ////        ObjectsofOurProjects.RegisterType<IProduct, Product>("Product");
        ////        ObjectsofOurProjects.RegisterType<ICustomer, Customer>("Customer", new InjectionConstructor(new CustomerVaidation()));
        ////        ObjectsofOurProjects.RegisterType<I_Staff, Staff>("Staff");
        ////        ObjectsofOurProjects.RegisterType<I_Invoice, Invoice>("Invoice", new InjectionConstructor(new InvoiceIDValidation()));
        ////        ObjectsofOurProjects.RegisterType<I_InvoicedStaff, InvoiceStaff>("InvoicedStaff");
        ////        ObjectsofOurProjects.RegisterType<I_InvoicedCustomer, InvoicedCustomer>("InvoicedCustomer");
        ////        ObjectsofOurProjects.RegisterType<IR_ProductWise, R_ProductWise>("R_ProductWise");
        ////        ObjectsofOurProjects.RegisterType<I_Stocks, Stocks>("Stocks");
        ////        ObjectsofOurProjects.RegisterType<I_GRN, GRN>("GRN");
        ////        ObjectsofOurProjects.RegisterType<I_GRNProducts, GRNProducts>("GRNProducts", new InjectionConstructor(new GRNProductsValidation()));
        ////        ObjectsofOurProjects.RegisterType<IR_StaffWise, R_StaffWise>("R_StaffWise");

        ////    }
        ////    //Design pattern :-  RIP Replace If with Poly
        ////    return ObjectsofOurProjects.Resolve<AnyType>(Type);
        ////}
        public static T Create<T>(string Type)
        {
            if (Type == "Product")
            {
                return (T)(object)new Product();
            }
            if (Type == "Invoice")
            {
                return (T)(object)new Invoice();
            }
            if (Type == "InvoicedProductDisValue")
            {
                return (T)(object)new InvoiceProduct(new DiscountItemValue());
            }
            if (Type == "InvoicedProductDisDefault")
            {
                return (T)(object)new InvoiceProduct(new DiscountItemDefault());
            }
            if (Type == "InvoicedProductPercentage")
            {
                return (T)(object)new InvoiceProduct(new DiscountItemPercentage());
            }
            if (Type == "InvoiceProductValidation")
            {
                return (T)(object)new InvoiceProductValidation();
            }
            if (Type == "Setting")
            {
                return (T)(object)new Setting();
            }
            if (Type == "StockAvailability")
            {
                return (T)(object)new StockAvailability ();
            }
            if (Type == "StockNoAvailability")
            {
                return (T)(object)new StockNoAvailability();
            }
            if (Type == "Stock")
            {
                return (T)(object)new Stocks();
            }
            if (Type == "InvoiceReturn")
            {
                return (T)(object)new InvoiceReturn();
            }
            return (T)(object)null;
           // return (T)Convert.ChangeType(new Product(), typeof(T));
        }
    }
  
}
