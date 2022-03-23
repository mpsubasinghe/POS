using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace MiddleLayer
{
    public class DiscountBillDefault : I_BillDiscount
    {
        public double BillAmount { get; set; }
        public double DisPercentage { get; set; }
        public double DisValRs { get; set; }


        public double CalculateDiscount(IInvoice iInvoice)
        {
            throw new NotImplementedException();
        }
    }
}
