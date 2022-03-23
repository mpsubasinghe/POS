using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_DAL
{
    public interface InterfaceProduct_DAL<AnyType> 
    {
          IEnumerable<AnyType> SearchProductAvailableStockByProductID(int Index);
          IEnumerable<AnyType> SearchProductAvailableStockByUPC(string Index);
          IEnumerable<AnyType> SearchProductAvailableStockByProductFullCode(string Index);
    }
}
