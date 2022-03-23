using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
using ValidationAlgorithem;
using FactoryVal;

namespace MiddleLayer
{
   public  class StockAvailability : IStockAvailability
    {
        public int ProdudctID { get; set; }
        public string ProductFullcode { get; set; }
        public string ProductName { get; set; }
        public double Qty { get; set; }
        public string Type { get; set; }
        public double  AvalableQty { get; set; }
        private I_Validatoin<IStockAvailability> Stock_Availability_Validation = null;

        public void Validation()
        {
            Stock_Availability_Validation = FactoryValidation<StockAvaiabilityValidation>.Create<StockAvaiabilityValidation>("StockAvaiabilityValidation");
            Stock_Availability_Validation.Validation(this);
        }
    }
}
