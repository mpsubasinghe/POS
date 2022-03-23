using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationAlgorithem;

namespace FactoryVal
{
    public static class FactoryValidation<AnyType> // Design pattern :- Simple factory pattern
    {
        public static T Create<T>(string Type)
        {

            if (Type == "InvoiceProductValidation")
            {
                return (T)(object)new InvoiceProductValidation();
            }
            if (Type == "InvoiceValidation")
            {
                return (T)(object)new InvoiceValidation();
            }
            if (Type == "StockAvaiabilityValidation")
            {
                return (T)(object)new StockAvaiabilityValidation();
            }
            if (Type == "StockAvaiabilityValidationNull")
            {
                return (T)(object)new StockAvaiabilityValidationNull();
            }
            return (T)(object)null;
            // return (T)Convert.ChangeType(new Product(), typeof(T));
        }
    }
}
