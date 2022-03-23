using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiddleLayer 
{
    public static class FactoryML_inMiddle<AnyType> 
    {
    
       // private static IUnityContainer ObjectsofOurProjects = null;

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
        public static T Create1<T>(string Type)
        {
            return (T)(object)new Product();
            //////return (T)Convert.ChangeType(new CustomerDAL(), typeof(T));
        }
    }
}
