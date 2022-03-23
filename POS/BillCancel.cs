using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using I_MiddleLayer;
using I_DAL;
using FactoryDAL;
using FactoryMiddleLayer;

namespace POS
{
    public partial class BillCancel : Form
    {
        public BillCancel()
        {
            InitializeComponent();
        }

        private void simpleButtondeleterpt_Click(object sender, EventArgs e)
        {
            ////SqlParameter[] param = new SqlParameter[1];
            ////    param[0] = new SqlParameter("@InvID", textBox_Inv.Text );
            ////    DataTable dt1 = new DataTable();
            ////    dt1 = DAL.GetReader("Select * From Invoice WHERE InvID=@InvID AND  Valid='No'  ", param);
            ////    if (dt1.Rows.Count > 0)
            ////    {
            ////        MessageBox.Show("This Invoice is already Canceled...???",
            ////         "Bill Cancel",
            ////         MessageBoxButtons.OK,
            ////         MessageBoxIcon.Stop,
            ////         MessageBoxDefaultButton.Button1);
            ////        return;
            ////    }


            ////    param = new SqlParameter[1];
            ////    param[0] = new SqlParameter("@InvID", textBox_Inv.Text );
            ////    dt1 = new DataTable();
            ////    dt1 = DAL.GetReader("Select * From InvoicedProduct WHERE InvID=@InvID ", param);
            ////    if (dt1.Rows.Count > 0)
            ////    {
            ////        for (int i = 0; i < dt1.Rows.Count; i++)
            ////        {
            ////            param = new SqlParameter[2];
            ////            param[0] = new SqlParameter("@ProductID", dt1.Rows[i]["ProductID"].ToString());
            ////            param[1] = new SqlParameter("@qty", dt1.Rows[i]["Qty"].ToString());

            ////            DAL.ExecuteNonQuery("UPDATE Stock SET Qty=Qty+@qty WHERE ProductID=@ProductID  ", param);

            ////        }
            ////    }

            ////    param = new SqlParameter[1];
            ////    param[0] = new SqlParameter("@InvID", textBox_Inv.Text);
            ////    DAL.ExecuteNonQuery("UPDATE Invoice SET Valid='No' WHERE InvID=@InvID  ", param);

           Interface_DAL<IInvoice> InvoiceDAL = FactoryDalLayer<Interface_DAL<IInvoice>>.Create<Interface_DAL<IInvoice>>("InvoiceDAL");
           Interface_DAL<IInvoicedProduct> InvoicedProductDAL = FactoryDalLayer<Interface_DAL<IInvoicedProduct>>.Create<Interface_DAL<IInvoicedProduct>>("InvoicedProductDAL");
           Interface_DAL<IInvoicedProduct> stockDAL = FactoryDalLayer<Interface_DAL<IInvoicedProduct>>.Create<Interface_DAL<IInvoicedProduct>>("InvStockDAL");

           foreach (IInvoicedProduct person in InvoicedProductDAL.Search(Convert.ToInt16(textBox_Inv.Text)))
           {
               person.Type = "Return";
               stockDAL.Update(person);  
           }
           IInvoice iInvoice = InvoiceDAL.SearchOne(Convert.ToString (textBox_Inv.Text));
           iInvoice.Valid = "NO";
           InvoiceDAL.Update(iInvoice);


                MessageBox.Show("Bill Cancel Process is Successfully completed..!!!?",
             "Bill Cancel",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information,
             MessageBoxDefaultButton.Button1);

        }
    }
}
