using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class Main_Menu : Form
    {
    //    BillingForm b1;
    //    ReportPendingList ReportPendingList;
    //    DoctorCommision DoctorCommision;
        //ADD_Product ADD_Product;
        //AddStock AddStock;
        //StockDayEnd StockDayEnd;
        Billing Billing_Form;
        //StockView StockView;
        //InvoiceView InvoiceView;
        //InvoiceList InvoiceList;
        BillCancel BillCancel;
        //GRNView GRNView;
        //GRNList GRNList;
        //R_ProductWiseSales R_ProductWiseSales;
        //GRNCancel GRNCancel;
        //RDayWiseSales RDayWiseSales;
        //R_StockDateWise R_StockDateWise;
        //StockAdjustment StockAdjustment;
        //ServiceChargeRPT ServiceChargeRPT;

        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            //LoginFormcs.UserID = "Priyankara";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (b1 == null)
            //{
            //    b1 = new BillingForm();
            //    b1.MdiParent = this;
            //    b1.FormClosed += new FormClosedEventHandler(b1_FormClosed);

            //    b1.Show();

            //}
            //else
            //{
            //    b1.Activate();
            //}


        }

        void b1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //b1 = null;
            //throw new NotImplementedException();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!SUser.CheckAuthorize(LoginFormcs.UserID, "ProductWiseSales"))
            //{
            //    MessageBox.Show("Sorry..!, Unauthorized Operation..???",
            //  "Unauthorized access",
            //  MessageBoxButtons.OK,
            //  MessageBoxIcon.Stop,
            //  MessageBoxDefaultButton.Button1);
            //    return;
            //}

            //R_ProductWiseSales =new R_ProductWiseSales();
            //R_ProductWiseSales.Show();

            //if (ReportPendingList == null)
            //{
            //    ReportPendingList = new ReportPendingList();
            //    ReportPendingList.MdiParent = this;
            //    ReportPendingList.FormClosed += new FormClosedEventHandler(ReportPendingList_FormClosed);

            //    ReportPendingList.Show();

            //}
            //else
            //{
            //    ReportPendingList.Activate();
            //}
        }

        void ReportPendingList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ReportPendingList = null;
            //throw new NotImplementedException();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (DoctorCommision == null)
            //{
            //    DoctorCommision = new DoctorCommision();
            //    DoctorCommision.MdiParent = this;
            //    DoctorCommision.FormClosed += new FormClosedEventHandler(DoctorCommision_FormClosed);

            //    DoctorCommision.Show();

            //}
            //else
            //{
            //    DoctorCommision.Activate();
            //}

        }

        void DoctorCommision_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            //DoctorCommision = null;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (ReportMasterUpdate == null)
            //{
            //    ReportMasterUpdate = new ReportMasterUpdate();
            //    ReportMasterUpdate.MdiParent = this;
            //    ReportMasterUpdate.FormClosed += new FormClosedEventHandler(ReportMasterUpdate_FormClosed);

            //    ReportMasterUpdate.Show();

            //}
            //else
            //{
            //    ReportMasterUpdate.Activate();
            //}
        }

        void ReportMasterUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            //ReportMasterUpdate = null;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if ((Application.OpenForms["Billing_Form"] as Billing) != null)
            {
                //Form is already open
            }
            else
            {
                Billing Billing_Form;
                Billing_Form = new Billing();
                Billing_Form.Show();
            }
          
    
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BillingR Billing_Form;
            Billing_Form = new BillingR();
            Billing_Form.Show();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BillCancel = new BillCancel();
              BillCancel.Show();
        }

        //private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (!SUser.CheckAuthorize(LoginFormcs.UserID, "BillCancel"))
        //    {
        //        MessageBox.Show("Sorry..!, Unauthorized Operation..???",
        //      "Unauthorized access",
        //      MessageBoxButtons.OK,
        //      MessageBoxIcon.Stop,
        //      MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    ADD_Product = new ADD_Product();
        //    ADD_Product.Show();
        //}

        //private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    AddStock = new AddStock();
        //    AddStock.Show();
        //}

        //private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    StockView = new StockView();
        //    StockView.Show();
        //}

        //private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    StockDayEnd = new StockDayEnd();
        //    StockDayEnd.Show();

        //}

        //private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{

        //    InvoiceView = new InvoiceView("");
        //    InvoiceView.Show();     
        //}

        //private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (!SUser.CheckAuthorize(LoginFormcs.UserID, "InvoieList"))
        //    {
        //        MessageBox.Show("Sorry..!, Unauthorized Operation..???",
        //      "Unauthorized access",
        //      MessageBoxButtons.OK,
        //      MessageBoxIcon.Stop,
        //      MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    InvoiceList = new InvoiceList();
        //    InvoiceList.Show();
        //}

        //private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (!SUser.CheckAuthorize(LoginFormcs.UserID, "BillCancel"))
        //    {
        //        MessageBox.Show("Sorry..!, Unauthorized Operation..???",
        //      "Unauthorized access",
        //      MessageBoxButtons.OK,
        //      MessageBoxIcon.Stop,
        //      MessageBoxDefaultButton.Button1);
        //        return;
        //    }


        //    BillCancel = new BillCancel();
        //    BillCancel.Show();
        //}

        //private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    GRNList = new GRNList();
        //    GRNList.Show();
        //}

        //private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    GRNView = new GRNView("");
        //    GRNView.Show();
        //}

        //private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (!SUser.CheckAuthorize(LoginFormcs.UserID, "GRNCancel"))
        //    {
        //        MessageBox.Show("Sorry..!, Unauthorized Operation..???",
        //      "Unauthorized access",
        //      MessageBoxButtons.OK,
        //      MessageBoxIcon.Stop,
        //      MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    GRNCancel = new GRNCancel();
        //    GRNCancel.Show();
        //}

        //private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (!SUser.CheckAuthorize(LoginFormcs.UserID, "DayWiseSales"))
        //    {
        //        MessageBox.Show("Sorry..!, Unauthorized Operation..???",
        //      "Unauthorized access",
        //      MessageBoxButtons.OK,
        //      MessageBoxIcon.Stop,
        //      MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    RDayWiseSales = new RDayWiseSales();
        //    RDayWiseSales.Show();
        //}

        //private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    R_StockDateWise = new R_StockDateWise();
        //    R_StockDateWise.Show();
        //}

        //private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    StockView = new StockView();
        //    StockView.Show();
        //}

        //private void Main_Menu_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Application.Exit();
        //}

        //private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (!SUser.CheckAuthorize(LoginFormcs.UserID, "StockAdjustment"))
        //    {
        //        MessageBox.Show("Sorry..!, Unauthorized Operation..???",
        //      "Unauthorized access",
        //      MessageBoxButtons.OK,
        //      MessageBoxIcon.Stop,
        //      MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    StockAdjustment = new StockAdjustment();
        //    StockAdjustment.Show();
        //}

        //private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (!SUser.CheckAuthorize(LoginFormcs.UserID, "ServiceCharge"))
        //    {
        //        MessageBox.Show("Sorry..!, Unauthorized Operation..???",
        //      "Unauthorized access",
        //      MessageBoxButtons.OK,
        //      MessageBoxIcon.Stop,
        //      MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    ServiceChargeRPT = new ServiceChargeRPT();
        //    ServiceChargeRPT.Show();
        //}



        
    }
}
