using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using I_MiddleLayer;
using I_DAL;
using FactoryDAL;
using FactoryMiddleLayer;

namespace POS
{
    public partial class BillingR : Form
    {
        private IEnumerable<IProduct> productList = null;
        private List<IInvoicedProduct> invoiceProductList = null;

        private Interface_DAL<ISetting> stockSettingDAL = null;
        private Interface_DAL<IProduct> productDAL = null;
        private Interface_DAL<IInvoiceR> invoiceDAL = null;

        private IInvoiceR inv = null;

        private string InvType = "Return";
        public BillingR()
        {
            
            InitializeComponent();
        }

        private void BillingR_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(BillingR_KeyDown);
        }
        private void SetReturnInvoice()
        {
            List<IInvoicedProduct> invlist = new List<IInvoicedProduct>();
            IInvoicedProduct ip = null;
            for (int rows = 0; rows < dataGridInvoicedProduct.Rows.Count; rows++)
            {
               
                
                    ip = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisDefault");
                ip.ProductFullcode = dataGridInvoicedProduct.Rows[rows].Cells[1].Value.ToString();
                ip.MRP = Convert.ToDouble(dataGridInvoicedProduct.Rows[rows].Cells[3].Value);
                ip.SPrice = Convert.ToDouble(dataGridInvoicedProduct.Rows[rows].Cells[4].Value);
                if (dataGridInvoicedProduct.Rows[rows].Cells[7].Value != "" && Convert.ToDouble(dataGridInvoicedProduct.Rows[rows].Cells[7].Value) > 0)
                {
                    ip.Qty = Convert.ToDouble(dataGridInvoicedProduct.Rows[rows].Cells[7].Value);
                }
                else
                {
                    ip.Qty = 0;
                }
                ip.Validation();

                invlist.Add(ip);

                
                
                //for (int col = 0; col < dataGridInvoicedProduct.Rows[rows].Cells.Count; col++)
                //{
                //    string value = dataGridInvoicedProduct.Rows[rows].Cells[col].Value.ToString();
                //}
            }
            inv.CreateInvoicedProductList(invlist);
            ////if (inv.invocedproducts != null)
            ////{
            ////    foreach (IInvoicedProduct person in inv.invocedproducts)
            ////    {
            ////        int q = dataGridInvoicedProduct.CurrentRow.Index;
            ////        if (Convert.ToDouble(dataGridInvoicedProduct.Rows[q].Cells[7]) > 0)
            ////        {
            ////            person.Qty = Convert.ToDouble(dataGridInvoicedProduct.Rows[q].Cells[7]);
            ////        }
            ////        else
            ////        {

            ////            inv.invocedproducts.RemoveAt(q);
            ////        }

                    
            ////    }
            ////}
        }
     
        private void LoadGrid(IInvoice i)
        {
            dataGridInvoicedProduct.Rows.Clear();
            this.Refresh();
            int count = 1;
            if (i.invocedproducts != null)
            {
                foreach (IInvoicedProduct person in i.invocedproducts)
                {
                    //if (!comboBoxStaff.Items.Cast<string>().Contains(person.Name))
                    //{
                    //    // comboBoxStaff.Items.Add(person.Name);
                    //SinhalaFonts sinhala = new SinhalaFonts();
                    //string sinhalaWord = sinhala.ConvertTextToSinhala("Sri Lankawa");

                    this.dataGridInvoicedProduct.Rows.Add(count, person.ProdudctID, (person.ProductName), person.MRP, person.MRP - person.CalItemDiscont(), person.Qty, person.CalculateDiscountedSubTotal(),"0");
                    //}

                    count = count + 1;
                }
            }


            textBoxGrTot.Text = i.CalculateGrossTotal().ToString();
            textBox_DisTotalBill.Text = i.CalculateTotalDiscount().ToString();
            textBox_NetDue.Text = i.CalculateNetTotal().ToString();


        }     
        private void GetProduct_And_ViewItemInfo(String Main_Pid)
        {
            if (Main_Pid != "")
            {
                // InterfaceProduct_DAL<IProduct> productDAL = FactoryDalLayer<InterfaceProduct_DAL<IProduct>>.Create<InterfaceProduct_DAL<IProduct>>("ProductDAL");
                IEnumerable<IProduct> productList = null;
                productList = productDAL.Search(Convert.ToInt16(Main_Pid));

                if (productList == null)
                {
                    productList = productDAL.Search((Main_Pid));
                }
                else
                {
                    if (productList.Count() == 1)
                    {
                        string s = Convert.ToString(productList.FirstOrDefault().ProductFullcode);
                        //BillingItemInfoR form1 = new BillingItemInfoR(this, productList.FirstOrDefault(), inv.Type);
                        //form1.ShowDialog();
                    }
                    else if (productList.Count() > 1)
                    {
                        //BillingPriceSelectionR form1 = new BillingPriceSelectionR(this, productList, inv.Type);
                        //form1.ShowDialog();
                    }
                }




            }
        }

        //private void SaveInv()
        //{
        //    try
        //    {
        //        GetNewInvoiceID();
        //        foreach (IInvoicedProduct person in inv.invocedproducts)
        //        {
        //            person.InvID = inv.invocieID;
        //        }

        //        inv.Validation();

        //        invoiceDAL.Add(inv);
        //        Interface_DAL<IInvoicedProduct> InvoicedProductDAL = FactoryDalLayer<Interface_DAL<IInvoicedProduct>>.Create<Interface_DAL<IInvoicedProduct>>("InvoicedProductDAL");
        //        Interface_DAL<IInvoicedProduct> stockDAL = FactoryDalLayer<Interface_DAL<IInvoicedProduct>>.Create<Interface_DAL<IInvoicedProduct>>("InvStockDAL");

        //        foreach (IInvoicedProduct person in inv.invocedproducts)
        //        {
        //            InvoicedProductDAL.Add(person);
        //            stockDAL.Update(person);
        //        }
        //        NewInvoice();
        //        LoadGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(),
        //             "Invalid Data",
        //           MessageBoxButtons.OK,
        //           MessageBoxIcon.Stop,
        //           MessageBoxDefaultButton.Button1);
        //    }



        //}

      

        private void dataGridInvoicedProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //BillingItemInfo form1 = new BillingItemInfo(this);
            //form1.ShowDialog();
            //NewInvoice();
        }


        private void simpleButtonFind_Click(object sender, EventArgs e)
        {
            SetReturnInvoice();
            //BillingItemSearchR form1 = new BillingItemSearchR(this, inv.Type, productDAL);
            //form1.ShowDialog();
            //comboBox_ProductName.Select();
        }

        private void simpleButtonPrint_Click(object sender, EventArgs e)
        {
            //SaveInv();
        }

        private void BillingR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                MessageBox.Show("F1");

            }
            if (e.KeyCode.ToString() == "F12")
            {
                MessageBox.Show("F12");

            }
            //if (e.KeyCode.ToString() == "ESC")
            //{
            //    MessageBox.Show("F1");
            //}
        }

        private void textBox_Inv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                invoiceDAL = FactoryDalLayer<Interface_DAL<IInvoiceR>>.Create<Interface_DAL<IInvoiceR>>("InvoiceRDAL");
                Interface_DAL<IInvoicedProduct> InvoicedProductDAL = FactoryDalLayer<Interface_DAL<IInvoicedProduct>>.Create<Interface_DAL<IInvoicedProduct>>("InvoicedProductDAL");

                inv = invoiceDAL.SearchOne(textBox_Inv.Text.ToString());
                inv.invocedproducts = InvoicedProductDAL.Search(Convert.ToInt32(textBox_Inv.Text)).ToList();

                LoadGrid(inv);
                dataGridInvoicedProduct.Rows[0].Selected = true;
            }
           
        
        
        }

        private void dataGridInvoicedProduct_KeyDown(object sender, KeyEventArgs e)
        {
            ////if (e.KeyCode == Keys.Enter)
            ////{

                
            ////    if (dataGridInvoicedProduct.RowCount == 0)
            ////    {
            ////        return;
            ////    }
            ////    int q = dataGridInvoicedProduct.CurrentRow.Index;
            ////    if (dataGridInvoicedProduct.Rows[q].Cells[1].Value == null)
            ////    {
            ////        return;
            ////    }
            ////    if (Convert.ToDouble(dataGridInvoicedProduct.CurrentRow.Cells[5].Value) >= Convert.ToDouble(dataGridInvoicedProduct.CurrentRow.Cells[7].Value))
            ////    {
            ////    }
            ////    else
            ////    {
            ////        MessageBox.Show("Return Qty should be less than Invoice Qty...??",
            ////     "Invalid Data",
            ////   MessageBoxButtons.OK,
            ////   MessageBoxIcon.Stop,
            ////   MessageBoxDefaultButton.Button1);
            ////        dataGridInvoicedProduct.CurrentRow.Cells[7].Value = "0";
            ////    }


            ////    e.Handled = true;
            ////    return;
            ////}

            ////if (e.KeyCode == Keys.Down)
            ////{
            ////    int c = dataGridInvoicedProduct.CurrentCell.ColumnIndex;
            ////    int r = dataGridInvoicedProduct.CurrentCell.RowIndex;
            ////    if (r < dataGridInvoicedProduct.Rows.Count - 1) //check for index out of range
            ////        dataGridInvoicedProduct.CurrentCell = dataGridInvoicedProduct[c, r + 1];
            ////}
            ////if (e.KeyCode == Keys.Up)
            ////{
            ////    int c = dataGridInvoicedProduct.CurrentCell.ColumnIndex;
            ////    int r = dataGridInvoicedProduct.CurrentCell.RowIndex;
            ////    if (r > 0) //check for index out of range
            ////        dataGridInvoicedProduct.CurrentCell = dataGridInvoicedProduct[c, r - 1];
            ////}
            ////////if (e.KeyCode.Equals(Keys.Up))
            ////////{
            ////////    moveUp();
            ////////}
            ////////if (e.KeyCode.Equals(Keys.Down))
            ////////{
            ////////    moveDown();
            ////////}
            ////e.Handled = true;
               
            }

        private void dataGridInvoicedProduct_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //// if (e.KeyCode == Keys.Enter)
            ////{
            ////    int i =  dataGridInvoicedProduct.CurrentRow.Index;
            ////    MessageBox.Show(i.ToString());
            ////}  
        

        }

   

        private void dataGridInvoicedProduct_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            //if (e.ColumnIndex == dataGridInvoicedProduct.Columns[7].Index)
            //{
            //    dataGridInvoicedProduct.Rows[e.RowIndex].ErrorText = "";
            //    int newInteger;

            //    // Don't try to validate the 'new row' until finished  
            //    // editing since there 
            //    // is not any point in validating its initial value. 
            //    if (dataGridInvoicedProduct.Rows[e.RowIndex].IsNewRow) { return; }
            //    if (!int.TryParse(e.FormattedValue.ToString(),
            //        out newInteger) || newInteger < 0)
            //    {
            //        e.Cancel = true;
            //        dataGridInvoicedProduct.Rows[e.RowIndex].ErrorText = "the value must be a Positive integer";
            //    }
            

            //}

       

        }

        private void textBox_Inv_TextChanged(object sender, EventArgs e)
        {

        }

      

      






    }
    class dataGridInvoicedProduct : DataGridView
    {

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Enter)
            {

                int col = this.CurrentCell.ColumnIndex;

                int row = this.CurrentCell.RowIndex;

                this.CurrentCell = this[col, row];

                return true;

            }

            return base.ProcessDialogKey(keyData);

        }



        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                int col = this.CurrentCell.ColumnIndex;

                int row = this.CurrentCell.RowIndex;

                this.CurrentCell = this[col, row];

                e.Handled = true;

            }

            base.OnKeyDown(e);

        }

    } 
}
