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
using FactoryMiddleLayer;
using FactoryDAL;
namespace POS
{
    public partial class BillingItemInfo : Form
    {
        IProduct iProduct = null;
         private Interface_DAL<IProduct> productDAL = null;
         ////////private IProduct iProduct = null;
         IInvoicedProduct iInvoiceProduct = null;
        private Billing _masterForm;
        IInvoice iInvoice=null;
        private string ProductFullCode;
        public BillingItemInfo(Billing masterForm, IProduct pid, IInvoice inv)
        {
             InitializeComponent();
            _masterForm = masterForm;
            iProduct = pid;
             iInvoice =inv  ;
        } 

       

        private void BillingItemInfo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(BillingItemInfo_KeyDown);
            ////productDAL = FactoryDalLayer<Interface_DAL<IProduct>>.Create<Interface_DAL<IProduct>>("ProductDAL");
            ////iProduct = productDAL.Search(Convert.ToInt16(ProductID)).FirstOrDefault();

            ////if (iProduct == null)
            ////{
            ////    iProduct =  productDAL.Search((ProductID)).FirstOrDefault();
            ////}
            ////if (iProduct != null) //Search from UPC
            ////{
            ////    LoadProductInfo(iProduct);
            ////}
            ////else
            ////{
            ////    this.Close();
            ////}

            //InterfaceProduct_DAL<IProduct> productDAL = FactoryDalLayer<InterfaceProduct_DAL<IProduct>>.Create<InterfaceProduct_DAL<IProduct>>("ProductDAL");
            //IEnumerable<IProduct> productList = null;
            //productList = productDAL.SearchProductAvailableStockByProductFullCode(ProductFullCode);
            //iProduct = productList.FirstOrDefault();
         
            if (iProduct != null) //Search from UPC
            {
                LoadProductInfo(iProduct);
            }
            else
            {
                this.Close();
            }

        }
        private void LoadProductInfo(IProduct p)
        {
            textBox_ItemName.Text = p.ProductName;
            textBox_Pid.Text = p.ProductID.ToString();
            textBoxUPC.Text = p.BarCode.ToString();
            textBoxPrice.Text = p.GetSellingPrice(iInvoice.PriceType).ToString();
            labelMRP.Text = p.MRP.ToString();
            textBoxQty.Text = "1";
            textBoxAvalableQty.Text = p.Qty.ToString();
            textBoxQty.Focus();
            textBoxQty.SelectAll();
        }

        private void textBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //if (textBoxQty.TextLength > 5)
                //{
                //    return;
                //}
                CreateInvoicedProduct();
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //if (textBoxQty.TextLength > 5)
                //{
                //    return;
                //}
                CreateInvoicedProduct();
            }
        }
        private void textBoxDisPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CreateInvoicedProduct();
            }
        }
        private Boolean UI_Validation()
        {
            double num;
            bool isNum = double .TryParse(textBoxQty.Text.Trim(), out num);
            bool isNump = double.TryParse(textBoxPrice.Text.Trim(), out num);
            bool isNumd = double.TryParse(textBoxDisPer.Text.Trim(), out num);
            if (!isNum)
            {
                if (textBoxQty.Text.Trim() != "")
                {
                  //  MessageBox.Show("Please Enter Numbers For Quantity...?",
                  //"Invalid Data",
                  //MessageBoxButtons.OK,
                  //MessageBoxIcon.Stop,
                  //MessageBoxDefaultButton.Button1);
                }
            
                return false;
            }
            if (!isNump)
            {
                if (textBoxPrice.Text.Trim() != "")
                {
                  //  MessageBox.Show("Please Enter Numbers For Price...?",
                  //"Invalid Data",
                  //MessageBoxButtons.OK,
                  //MessageBoxIcon.Stop,
                  //MessageBoxDefaultButton.Button1);
                }
                return false;
            }
            if (!isNumd)
            {
                if (textBoxDisPer.Text.Trim() != "")
                {
                  //  MessageBox.Show("Please Enter Numbers For Discount Percentage...?",
                  //"Invalid Data",
                  //MessageBoxButtons.OK,
                  //MessageBoxIcon.Stop,
                  //MessageBoxDefaultButton.Button1);
                }
                return false;
            }
          
          
            
        
            return true;
        }
        private void SetObjectValues()
        {
  

            if (!UI_Validation())
            {
                return;
            }

            if (iProduct.MRP != Convert.ToDouble(textBoxPrice.Text))
            {
                iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisValue");
            }
            else
            {
                iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisDefault");
            }
            if (Convert.ToDouble(textBoxDisPer.Text) > 0)
            {
                iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductPercentage");
            }

            iInvoiceProduct.InvID = iInvoice .invocieID;
            iInvoiceProduct.ProdudctID = iProduct.ProductID;
            iInvoiceProduct.ProductFullcode = iProduct.ProductFullcode; 
            iInvoiceProduct.ProductName = iProduct.ProductName;
            iInvoiceProduct.MRP = iProduct.MRP;
            iInvoiceProduct.SPrice = iProduct.GetSellingPrice (iInvoice.PriceType);
            iInvoiceProduct.Qty = Convert.ToDouble(textBoxQty.Text);
            iInvoiceProduct.DiscountAmount = iProduct.MRP - Convert.ToDouble(textBoxPrice.Text);
            iInvoiceProduct.DiscountPercentage = Convert.ToDouble(textBoxDisPer.Text);
           iInvoiceProduct.Type = iInvoice .Type;

             textBoxsubTotal.Text = Convert.ToString(iInvoiceProduct.CalculateDiscountedSubTotal());

        }

        private void CreateInvoicedProduct()
        {
            try
            {
                if (textBoxQty.Text.Trim().Length > 10 || textBoxPrice.Text.Trim().Length > 10 || textBoxDisPer.Text.Trim().Length > 10)
                {
                    LoadProductInfo(iProduct);
                    return ;
                }


                 iInvoiceProduct.Validation();                 
                _masterForm.AddItem_CustomBilling (iInvoiceProduct );
                 this.Close();

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

        private void textBoxQty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:

                    textBoxPrice.Focus();
                    textBoxPrice.SelectAll();
                //    MessageBox.Show("Down");
                    break;
                case Keys.Right:
                    textBoxPrice.Focus();
                    textBoxPrice.SelectAll();
                   //   MessageBox.Show("Right");
                    break;
                case Keys.Up:
                    //MessageBox.Show("Up");
                    break;
                case Keys.Left:
                    //action
                    //   MessageBox.Show("Left");
                    break;
            }
        }

        private void textBoxPrice_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:

                    textBoxDisPer.Focus();
                    textBoxDisPer.SelectAll();
                    //MessageBox.Show("Down");
                    break;
                case Keys.Right:
                    textBoxDisPer.Focus();
                    textBoxDisPer.SelectAll();
                    //  MessageBox.Show("Right");
                    break;
                case Keys.Up:
                     textBoxQty.Focus();
                     textBoxQty.SelectAll();
                    //MessageBox.Show("Up");
                    break;
                case Keys.Left:
                  textBoxQty.Focus();
                     textBoxQty.SelectAll();
                    //   MessageBox.Show("Left");
                    break;
            }
        }

        private void textBoxDisPer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:

                    //textBoxDisPer.Focus();
                    //textBoxDisPer.SelectAll();
                    //MessageBox.Show("Down");
                    break;
                case Keys.Right:
                    //textBoxDisPer.Focus();
                    //textBoxDisPer.SelectAll();
                    //  MessageBox.Show("Right");
                    break;
                case Keys.Up:
                    textBoxPrice.Focus();
                    textBoxPrice.SelectAll();
                    //MessageBox.Show("Up");
                    break;
                case Keys.Left:
                    textBoxPrice.Focus();
                    textBoxPrice.SelectAll();
                    //   MessageBox.Show("Left");
                    break;
            }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            SetObjectValues();
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            SetObjectValues();
        }
        private void textBoxDisItem_TextChanged(object sender, EventArgs e)
        {
            SetObjectValues();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BillingItemInfo_KeyDown(object sender, KeyEventArgs e)
        {
                 if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
        }

      

    }
}
