using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using I_MiddleLayer;
using FactoryMiddleLayer;
using ValidationAlgorithem;
namespace POS
{
    public partial class BillingItemEdit : Form
    {
        private Billing _masterForm;
        private IInvoicedProduct iInvoicedProduct;
        private int Index = 0;
        IInvoice iInvoice = null;
        public BillingItemEdit(Billing masterForm ,IInvoicedProduct invoiceproduct,int index,IInvoice inv)
        {
                      iInvoice = inv;
            Index = index;
            InitializeComponent();
            _masterForm = masterForm;
            iInvoicedProduct=invoiceproduct;
        }

        private void BillingItemEdit_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(BillingItemEdit_KeyDown);
            LoadProductInfo(iInvoicedProduct);
        }
        private void LoadProductInfo(IInvoicedProduct p)
        {
            textBox_ItemName.Text = p.ProductName;
            textBoxPrice.Text =( p.MRP - p.DiscountAmount).ToString();
            textBoxQty.Text = p.Qty.ToString();
            textBoxsubTotal.Text = Convert.ToString(p.CalculateDiscountedSubTotal());
        }

        private void textBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Update();
            }         
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Update();
            }
        }
        private void Update()
        {
            try{
                IInvoicedProduct _iInvoiceProduct = null;
                if (iInvoicedProduct.SPrice != Convert.ToDouble(textBoxPrice.Text))
                {
                    _iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisValue");
                }
                else
                {
                    _iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductDisDefault");
                }
                if (Convert.ToDouble(textBoxDisPer.Text) > 0)
                {
                    _iInvoiceProduct = FactoryML<IInvoicedProduct>.Create<IInvoicedProduct>("InvoicedProductPercentage");
                }
            if (textBoxQty.Text == "")
            {
                MessageBox.Show("Please Enter Quantity...?",
                "Invalid Data",
              MessageBoxButtons.OK,
              MessageBoxIcon.Stop,
              MessageBoxDefaultButton.Button1);
                return;
            }
            if (textBoxPrice.Text == "")
            {
                MessageBox.Show("Please Enter Quantity...?",
                "Invalid Data",
              MessageBoxButtons.OK,
              MessageBoxIcon.Stop,
              MessageBoxDefaultButton.Button1);
                return;
            }
            if (textBoxDisPer.Text == "")
            {
                MessageBox.Show("Please Enter Quantity...?",
                "Invalid Data",
              MessageBoxButtons.OK,
              MessageBoxIcon.Stop,
              MessageBoxDefaultButton.Button1);
                return;
            }
            if (textBoxQty.Text.Trim().Length > 10 || textBoxPrice.Text.Trim().Length > 10 || textBoxDisPer.Text.Trim().Length > 10)
            {
                return;
            }

            _iInvoiceProduct.ProdudctID = iInvoicedProduct.ProdudctID;
            _iInvoiceProduct.ProductFullcode = iInvoicedProduct.ProductFullcode;
            _iInvoiceProduct.ProductName = iInvoicedProduct.ProductName;
            _iInvoiceProduct.MRP = iInvoicedProduct.MRP;
            _iInvoiceProduct.SPrice = iInvoicedProduct.SPrice;
            _iInvoiceProduct.DiscountAmount = iInvoicedProduct.MRP - Convert.ToDouble(textBoxPrice.Text);
            _iInvoiceProduct.DiscountPercentage = Convert.ToDouble(textBoxDisPer.Text);
            _iInvoiceProduct.Qty = Convert.ToDouble(textBoxQty.Text);
            _iInvoiceProduct.Type = iInvoicedProduct.Type;

            _iInvoiceProduct.Validation();


            

            _masterForm.UpdateItem (_iInvoiceProduct ,Index );
            this.Close();

             }  
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                     "  Invalid Data",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Stop,
                   MessageBoxDefaultButton.Button1);
            }
        }

        private void textBoxDisPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Update();
            } 
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void simpleButtondeleterpt_Click(object sender, EventArgs e)
        {
            
        
            _masterForm.DeleteItem (Index );
            this.Close();
        }
      

      


        private void BillingItemEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
       
    }
}
