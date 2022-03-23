using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_MiddleLayer
{
    public interface I_BillDiscount
    {
        double BillAmount { get; set; }
        double DisPercentage { get; set; }
        double DisValRs { get; set; }

        double CalculateDiscount(IInvoice iInvoice);
    }
}
