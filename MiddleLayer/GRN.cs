using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace MiddleLayer
{
    public    class GRN
    {
        public int invocieID { get; set; }
        public double InvDate { get; set; }
        public DateTime InvDateTime { get; set; }
        public double Discount { get; set; }
        public double GrossTotal { get; set; }
        public double NetTotal { get; set; }
        public string Valid { get; set; }
        public string Type { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }

        public List<IInvoicedProduct> invocedproducts { get; set; } 

    }
}
