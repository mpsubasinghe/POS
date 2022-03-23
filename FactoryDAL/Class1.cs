using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace FactoryDAL
{
    public static class FactoryDalLayer<AnyType> // Design pattern :- Simple factory pattern
    {

        //private static IUnityContainer ObjectsofOurProjects = null;

        //public static AnyType Create(string Type)
        //{
        //    // Design pattern :- Lazy loading. Eager loading
        //    if (ObjectsofOurProjects == null)
        //    {
        //        ObjectsofOurProjects = new UnityContainer();

        //        ObjectsofOurProjects.RegisterType<Interface_DAL<ICustomer>,
        //            CustomerDAL>("CustomerDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_InvoicedCustomer>,
        //           InvoicedCustomerDAL>("InvoicedCustomerDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_Staff>,
        //           StaffDAL>("StaffDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_Product>,
        //          ProductDAL>("ProductDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_Invoice>,
        //            InvoiceDAL>("InvoiceDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_InvoicedStaff>,
        //            InvoicedStaffDAL>("InvoicedStaffDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_InvoicedProduct>,
        //            InvoicedProductDAL>("InvoicedProductDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_Stocks>,
        //            StocksDAL>("StocksDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_GRN>,
        //            GRNDAL>("GRNDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<I_GRNProducts>,
        //            GRNProductsDAL>("GRNProductsDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<IR_ProductWise>,
        //                        R_ProductWiseDAL>("R_ProductWiseDAL");
        //        ObjectsofOurProjects.RegisterType<Interface_DAL<IR_StaffWise>,
        //                        R_StaffWiseDAL>("R_StaffWiseDAL");
        //    }
        //    //Design pattern :-  RIP Replace If with Poly
        //    return ObjectsofOurProjects.Resolve<AnyType>(Type);
        //}

        public static T Create<T>(string Type)
        {
            if (Type == "ProductDAL")
            {
                return (T)(object)new ProductDAL();
            }
            if (Type == "InvoiceDAL")
            {
                return (T)(object)new InvoiceDAL();
            }
            if (Type == "InvoicedProductDAL")
            {
                return (T)(object)new InvoiceProductDAL();
            }
            if (Type == "StockDAL")
            {
                return (T)(object)new StockDAL();
            }
            if (Type == "StockNullDAL")
            {
                return (T)(object)new StockNullDAL();
            }
            if (Type == "StockReturnDAL")
            {
                return (T)(object)new StockReturnDAL();
            }
            if (Type == "ProductStockDAL")
            {
                return (T)(object)new ProductStockDAL();
            }
            if (Type == "SettingDAL")
            {
                return (T)(object)new SettingDAL();
            }
            if (Type == "InvoiceRDAL")
            {
                return (T)(object)new InvoiceRDAL();
            }
            return (T)(object)null;

           // return (T)(object)new ProductDAL();if
         
           // return (T)Convert.ChangeType(new ProductDAL(), typeof(T));
        }

        ////public static T CreateML<T>(string Type)
        ////{
        ////    return (T)(object)new Product();
        ////    //  return (T)Convert.ChangeType(new CustomerDAL(), typeof(T));
        ////}
    }
}
