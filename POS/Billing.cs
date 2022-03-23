using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using I_DAL;
using I_MiddleLayer;
using FactoryDAL;
using FactoryMiddleLayer;
using UniCode;
using ValidationAlgorithem;
using FactoryVal;

namespace POS
{
    public partial class Billing : Form
    {
        private IEnumerable<IProduct> productList = null;
        private Interface_DAL<ISetting> stockSettingDAL = null;
        private Interface_DAL<IProduct> productDAL = null;
        private Interface_DAL<IInvoice> invoiceDAL = null;
        private IInvoice inv=null;  
        private IStockAvailability stockAvailability = null;
        private Interface_DAL<IStock > stockDAL = null;

        public Billing()
        {
            
            InitializeComponent();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Billing_KeyDown);

            

            stockSettingDAL = FactoryDalLayer<Interface_DAL<ISetting>>.Create<Interface_DAL<ISetting>>("SettingDAL");
            if (stockSettingDAL.Search("InvoiceStockAvailable").FirstOrDefault().SettingValue == "1")
            {
                // Stock available items
                productDAL = FactoryDalLayer<Interface_DAL<IProduct>>.Create<Interface_DAL<IProduct>>("ProductStockDAL");
                stockAvailability = FactoryML<IStockAvailability>.Create<IStockAvailability>("StockAvailability");
                stockDAL = FactoryDalLayer<Interface_DAL<IStock >>.Create<Interface_DAL<IStock >>("StockDAL");
            }
            else
            {
                //  All items
                productDAL = FactoryDalLayer<Interface_DAL<IProduct>>.Create<Interface_DAL<IProduct>>("ProductDAL");
                stockAvailability = FactoryML<IStockAvailability>.Create<IStockAvailability>("StockNoAvailability");
                stockDAL = FactoryDalLayer<Interface_DAL<IStock>>.Create<Interface_DAL<IStock>>("StockNullDAL");
              
            }
            if (stockSettingDAL.Search("ChangePriceType").FirstOrDefault().SettingValue == "0")
            {
                comboBoxPriceType.Enabled = false;
            }

            invoiceDAL = FactoryDalLayer<Interface_DAL<IInvoice>>.Create<Interface_DAL<IInvoice>>("InvoiceDAL");       
            NewInvoice();

            listBoxItemView.Visible = false;
            comboBoxPriceType.SelectedIndex = 0;
            comboBoxBillPattern.SelectedIndex = 0;

            

        }
        private void GetNewInvoiceID()
        {
            IInvoice i = invoiceDAL.SearchLast();
            if (i != null)
            {
                inv.invocieID = (i.invocieID) + 1;
            }
            else
            {
                inv.invocieID = 1;
            }
            textBox_Inv.Text = inv.invocieID.ToString();
        }
        private void NewInvoice()
        {
            inv = FactoryML<IInvoice>.Create<IInvoice>("Invoice");
          
            inv.PriceType = comboBoxPriceType.Text;
            inv.Type = "Invoice";
            GetNewInvoiceID();
            textBoxItemSearch.Select();

        }
        public void DeleteItem(int Index)
        {
            inv.invocedproducts.RemoveAt(Index);
            LoadGrid();
        }
        public void UpdateItem(IInvoicedProduct iInvoiceProduct,int Index)
        {
            stockAvailability.ProdudctID = iInvoiceProduct.ProdudctID;
            stockAvailability.ProductFullcode = iInvoiceProduct.ProductFullcode;
            stockAvailability.Qty = iInvoiceProduct.Qty;
            stockAvailability.AvalableQty = stockDAL.SearchOne(iInvoiceProduct.ProductFullcode).Qty;
            stockAvailability.Validation();
            
            inv.invocedproducts[Index] = iInvoiceProduct;
            LoadGrid();
        }
        public void AddItem_CustomBilling(IInvoicedProduct iInvoiceProduct)
        {
            try 
            {
                stockAvailability.ProdudctID = iInvoiceProduct.ProdudctID;
                stockAvailability.ProductFullcode = iInvoiceProduct.ProductFullcode;
                stockAvailability.Qty = iInvoiceProduct.Qty;
                stockAvailability.AvalableQty = stockDAL.SearchOne(iInvoiceProduct.ProductFullcode).Qty;
                stockAvailability.Validation();
                inv.AddInvoiceProduct(iInvoiceProduct);
                LoadGrid();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                     "Invalid Data",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Stop,
                   MessageBoxDefaultButton.Button1);
            }
        }
        private void LoadGrid()  
        {
            dataGridInvoicedProduct.Rows.Clear();
            this.Refresh();
            int count = 1;
            if (inv.invocedproducts!= null)
            {
                foreach (IInvoicedProduct person in inv.invocedproducts)
                {
                    //if (!comboBoxStaff.Items.Cast<string>().Contains(person.Name))
                    //{
                    //    // comboBoxStaff.Items.Add(person.Name);
                    //SinhalaFonts sinhala = new SinhalaFonts();
                    //string sinhalaWord = sinhala.ConvertTextToSinhala("Sri Lankawa");

                    this.dataGridInvoicedProduct.Rows.Add(count, person.ProdudctID, (person.ProductName), person.MRP, person.MRP - person.CalItemDiscont(), person.Qty, person.CalculateDiscountedSubTotal());
                    //}

                    count = count + 1;
                }
            }
           

            textBoxGrTot.Text = inv.CalculateGrossTotal().ToString();
            textBox_DisTotalBill.Text = inv.CalculateTotalDiscount().ToString();
            textBox_NetDue.Text = inv.CalculateNetTotal().ToString();
            labelNoOfItems.Text = inv.invocedproducts.Count().ToString();

            if (dataGridInvoicedProduct.Rows.Count>0)
            {
                dataGridInvoicedProduct.ClearSelection();//If you want

                int nRowIndex = dataGridInvoicedProduct.Rows.Count - 1;
                int nColumnIndex = 3;

                dataGridInvoicedProduct.Rows[nRowIndex].Selected = true;
                dataGridInvoicedProduct.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                //In case if you want to scroll down as well.
                dataGridInvoicedProduct.FirstDisplayedScrollingRowIndex = nRowIndex;
             
            }
            
        }
        private void dataGridInvoicedProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridInvoicedProduct.RowCount == 0)
            {
                return;
            }
            int q = dataGridInvoicedProduct.CurrentRow.Index;
            ////if (string.IsNullOrEmpty(dataGridInvoicedProduct.Rows[q].Cells[1].Value as string))
            ////{
            ////      return;
            ////}
            UpdateView(q);
        }
        private void UpdateView(int index)
        {
          
            BillingItemEdit form1 = new BillingItemEdit(this, inv.invocedproducts[index], index , inv );
            form1.ShowDialog();
            textBoxItemSearch.Select(); 
        }
        private void simpleButtonFind_Click(object sender, EventArgs e)
        {
            BillingItemSearch form1 = new BillingItemSearch(this, inv, productDAL, textBoxItemSearch.Text);
            form1.ShowDialog();
            textBoxItemSearch.Select(); 
        }
        private void simpleButtonPrint_Click(object sender, EventArgs e)
        {
   
            SaveInv();
        }
        private void SaveInv()
        {
            //try
            //{
                GetNewInvoiceID();
                foreach (IInvoicedProduct person in inv.invocedproducts)
                {
                    person.InvID = inv.invocieID;
                } 

                inv.Validation();

                invoiceDAL.Add(inv);
                Interface_DAL<IInvoicedProduct> InvoicedProductDAL = FactoryDalLayer<Interface_DAL<IInvoicedProduct>>.Create<Interface_DAL<IInvoicedProduct>>("InvoicedProductDAL");
                IStock icust = FactoryML<IStock>.Create<IStock>("Stock");
                foreach (IInvoicedProduct person in inv.invocedproducts)
                {
                    InvoicedProductDAL.Add(person);
                    icust.ProductFullcode = person.ProductFullcode;
                    icust.Qty = person.Qty;
                    stockDAL.Update(icust );
                }
                NewInvoice();
                LoadGrid();
            //}
            //catch (Exception ex)
            //{MessageBox.Show(ex.Message.ToString(),
            //         "Invalid Data",
            //       MessageBoxButtons.OK,
            //       MessageBoxIcon.Stop,
            //       MessageBoxDefaultButton.Button1);
            //}

          
                

        }
        private void AddItem_FastBilling(IProduct iProduct)
        {
            try 
            {
            IInvoicedProduct iInvoiceProduct = null;
            if (iProduct.MRP != iProduct.SPrice)
            {
                iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisValue");
            }
            else
            {
                iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisDefault");
            }
          
            iInvoiceProduct.InvID = inv.invocieID;
            iInvoiceProduct.ProdudctID = iProduct.ProductID;
            iInvoiceProduct.ProductFullcode = iProduct.ProductFullcode;
            iInvoiceProduct.ProductName = iProduct.ProductName;
            iInvoiceProduct.MRP = iProduct.MRP;
            iInvoiceProduct.SPrice = iProduct.GetSellingPrice(inv.PriceType);
            iInvoiceProduct.Qty = 1;
            iInvoiceProduct.DiscountAmount =iProduct .MRP -iProduct .SPrice ;
            iInvoiceProduct.DiscountPercentage = 0;
            iInvoiceProduct.Type = inv.Type;

            iInvoiceProduct.Validation();

               
            stockAvailability.ProdudctID = iInvoiceProduct.ProdudctID;
            stockAvailability.ProductFullcode = iInvoiceProduct.ProductFullcode;
            stockAvailability.Qty = iInvoiceProduct.Qty;
            stockAvailability.AvalableQty = stockDAL.SearchOne(iInvoiceProduct.ProductFullcode).Qty;

            stockAvailability.Validation();

           
            inv.AddInvoiceProduct(iInvoiceProduct);

            LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                     "Invalid Data",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Stop,
                   MessageBoxDefaultButton.Button1);
            }
        }
        private void Billing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                BillingItemSearch form1 = new BillingItemSearch(this, inv, productDAL, textBoxItemSearch.Text);
                form1.ShowDialog();
                textBoxItemSearch.Select();
                
            }
            if (e.KeyCode.ToString() == "F12")
            {
                MessageBox.Show("F12");
               
            }
            if (e.KeyCode == Keys.Escape)
            {
                //this.Close();
            }
            if (e.KeyCode == Keys.Add)
            {
                textBoxPaidAmount.SelectAll();
            }

            switch (e.KeyCode)
            {
                case Keys.Down:                 
                    break;
                case Keys.Right:
               
                    break;
                case Keys.Up:
                
                    break;
                case Keys.Left:           
                    break;
            }

        }
        private void dataGridInvoicedProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            NewInvoice();
        }
       
        //==============================================
        #region 

        private void textBoxItemSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            string Main_Pid = textBoxItemSearch.Text;
            if (e.KeyChar == 13)
            {
                
                if (Main_Pid != "")
                {
                    GetProductListFromMainCode(Main_Pid);
                }
                else 
                {
                    UpdateView(inv.invocedproducts.Count()-1);
                }

            }
        }
        private void textBoxItemSearch_TextChanged(object sender, EventArgs e)
        {
            
            if (textBoxItemSearch.Text == "")
            {
                listBoxItemView.Visible = false;
                return;
            }
            if (textBoxItemSearch.Text .Length == 5)
            {
                double num;
                bool isNum = double.TryParse(textBoxItemSearch.Text.Trim(), out num);
                if (isNum)
                {
                    return;
                }
            }
            

              //////Interface_DAL<IProduct> productDAL1 = null;
              //////stockSettingDAL = FactoryDalLayer<Interface_DAL<ISetting>>.Create<Interface_DAL<ISetting>>("SettingDAL");
              //////if (stockSettingDAL.Search("InvoiceStockAvailable").FirstOrDefault().SettingValue == "1")
              //////{
              //////    // Stock available items
              //////    productDAL1 = FactoryDalLayer<Interface_DAL<IProduct>>.Create<Interface_DAL<IProduct>>("ProductStockDAL");
              //////}
              //////else
              //////{
              //////    //  productDAL1 items
              //////    productDAL1 = FactoryDalLayer<Interface_DAL<IProduct>>.Create<Interface_DAL<IProduct>>("ProductDAL");
              //////}

              IEnumerable<IProduct> productListCombo = null;
              productListCombo = productDAL .SearchAny(textBoxItemSearch.Text); // Search From Name
              listBoxItemView.DataSource = null;
              listBoxItemView.Items.Clear();

              BindingSource bs = new BindingSource();
              bs.DataSource = productListCombo;

              this.listBoxItemView.DisplayMember = "ProductName";
              this.listBoxItemView.ValueMember = "ProductID";
              this.listBoxItemView.DataSource = bs;

              bs.ResetBindings(false);
              if (productListCombo.Count() == 0)
              {
                  listBoxItemView.Visible = false;
              }
              else
              {
                  listBoxItemView.Visible = true;
              }
              listBoxItemView.SelectedIndex = -1;
           
        }
        private void textBoxItemSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:

                    listBoxItemView.Focus();
                    listBoxItemView.Select();

                    //MessageBox.Show("Down");
                    break;
                case Keys.Right:
                    //listBoxItemView.Focus();
                    listBoxItemView.Select();
                    //  MessageBox.Show("Right");
                    break;
                case Keys.Up:
                    listBoxItemView.Focus();
                    listBoxItemView.Select();
                    //MessageBox.Show("Up");
                    break;
                case Keys.Left:
                    listBoxItemView.Focus();
                    listBoxItemView.Select();
                    //   MessageBox.Show("Left");
                    break;
            }
        }
        private void listBoxItemView_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (listBoxItemView.SelectedIndex != -1)
                {
                    GetProductListFromMainCode(listBoxItemView.SelectedValue.ToString());
                }
                
            }
            switch (e.KeyCode)
            {
                case Keys.Down:

                    ////if (listBoxItemView.SelectedIndex == listBoxItemView.Items.Count-1)
                    ////{
                    ////    textBoxItemSearch.Focus();
                    ////    textBoxItemSearch.SelectAll();
                    ////}
                    break;
                case Keys.Right:
                    //listBoxItemView.Focus();
                    //listBoxItemView.Select();
                    ////  MessageBox.Show("Right");
                    break;
                case Keys.Up:
                    if (listBoxItemView.SelectedIndex == 0)
                    {
                        listBoxItemView.SelectedIndex = -1;
                        textBoxItemSearch.Focus();
                        textBoxItemSearch.SelectAll();

                    }

                    //MessageBox.Show("Up");
                    break;
                case Keys.Left:
                    //listBoxItemView.Focus();
                    //listBoxItemView.Select();
                    //   MessageBox.Show("Left");
                    break;
            }
        }
        private void GetProductListFromMainCode(string Main_Pid)
        {
            comboBoxPriceType.Enabled = false;
            IEnumerable<IProduct> productList = null;

            if (Main_Pid.Length == 13)
            {
                productList = productDAL.Search((Main_Pid)); // Search From UPC
            }
            else
            {
                int a;
                if (int.TryParse(Main_Pid, out a))
                {
                    productList = productDAL.Search(Convert.ToInt32(Main_Pid)); //Search From ProductID
                }
            }

            if (productList == null)
            {
                textBoxItemSearch.Focus();
                textBoxItemSearch.SelectAll();
                textBoxItemSearch.Text = "";
                return;
            }
            if (productList.Count() == 0)
            {
                textBoxItemSearch.Focus();
                textBoxItemSearch.SelectAll();
                textBoxItemSearch.Text = "";
                return;
            }

            
                if(comboBoxBillPattern .Text =="Fast Billing")
                {
                    AddItem_FastBilling(productList .FirstOrDefault());
                    textBoxItemSearch.Focus();
                    textBoxItemSearch.SelectAll();
                    textBoxItemSearch.Text = "";
                    return;
                }
                if (productList.Count() == 1) // if there is a one product
                {
                    string s = Convert.ToString(productList.FirstOrDefault().ProductFullcode);
                  BillingItemInfo form1 = new BillingItemInfo(this, productList.FirstOrDefault(), inv);
                    textBoxItemSearch.Focus();
                    textBoxItemSearch.SelectAll();
                    textBoxItemSearch.Text = "";
                    listBoxItemView.Visible = false;
                    form1.ShowDialog();
                }
                else if (productList.Count() > 1) // if there are more product
                {
                    BillingPriceSelection form1 = new BillingPriceSelection(this, productList, inv);
                    textBoxItemSearch.Focus();
                    textBoxItemSearch.SelectAll();
                    textBoxItemSearch.Text = "";
                    listBoxItemView.Visible = false;
                    form1.ShowDialog();
                }
            
        }    

        #endregion

        private void dataGridInvoicedProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridInvoicedProduct.CurrentRow.Cells[0].Value != null)
                {
                    //this.SelectedEmployeeId = (int)dgvEmployees.CurrentRow.Cells[0].Value;
                    //this.OnEmployeeSelected(new TestEmployeeGridListEventArgs()
                    //{
                    //    SelectedEmployeeId = this.SelectedEmployeeId,
                    //    SelectedEmployeeIdentifier = dgvEmployees.CurrentRow.Cells["Identifier"].Value.ToString()
                    //});
                }
                if (dataGridInvoicedProduct.RowCount == 0)
                {
                    return;
                }
                int q = dataGridInvoicedProduct.CurrentRow.Index;
                UpdateView(q);
                e.SuppressKeyPress = true;
            }
        }

        private void comboBoxPriceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            inv.PriceType = comboBoxPriceType.Text;
            //comboBoxPriceType.Enabled = false;
        }

        private void comboBoxBillPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxItemSearch.Focus();
            textBoxItemSearch.SelectAll();
            textBoxItemSearch.Text = "";
        }


        
        

       
       

       

      

        


    }
}
