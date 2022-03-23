using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace ValidationAlgorithem
{
   public  class StockAvaiabilityValidation : I_Validatoin<IStockAvailability>
    {
        public void Validation(IStockAvailability obj)
        {
            if (obj.Qty > obj .AvalableQty )
            {
                throw new Exception("Sorry No Enough Quantity..??");
            }
        }
    }
}
