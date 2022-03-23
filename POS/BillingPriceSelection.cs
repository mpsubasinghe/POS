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
namespace POS
{
    public partial class BillingPriceSelection : Form
    {
        IProduct iProduct = null;
        IInvoice iInvoice = null;
        IEnumerable<IProduct> ProductList = null;
        private Interface_DAL<IProduct> productDAL = null;
        ////////private IProduct iProduct = null;
        IInvoicedProduct iInvoiceProduct = null;
        private Billing _masterForm;
        private string ProductID;
        private string Type;
        public BillingPriceSelection(Billing masterForm, IEnumerable<IProduct> _productList, IInvoice inv)
        {
            InitializeComponent();
            _masterForm = masterForm;
            ProductList = _productList;
            iInvoice  = inv;
        }

        private void BillingPriceSelection_Load(object sender, EventArgs e)
        {
                this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(BillingPriceSelection_KeyDown);
            LoadGrid();
        }
        private void LoadGrid()
        {
            dataGridSearchProduct.Rows.Clear();
            this.Refresh();
            int count = 1;
            foreach (IProduct person in ProductList)
            {
                //if (!comboBoxStaff.Items.Cast<string>().Contains(person.Name))
                //{
                //    // comboBoxStaff.Items.Add(person.Name);
                this.dataGridSearchProduct.Rows.Add(person.ProductID, person.ProductFullcode, person.ProductName, person.Qty, person.GetSellingPrice(iInvoice .PriceType ) );
                //}

                count = count + 1;
            }
            dataGridSearchProduct.Select();
            dataGridSearchProduct.Rows[0].Selected = true;

            textBox_ItemName.Text = ProductList.FirstOrDefault().ProductName;
        }
      
        private void moveUp()
        {
            if (dataGridSearchProduct.RowCount > 0)
            {
                if (dataGridSearchProduct.SelectedRows.Count > 0)
                {
                    int rowCount = dataGridSearchProduct.Rows.Count;
                    int index = dataGridSearchProduct.SelectedCells[0].OwningRow.Index;

                    if (index == 0)
                    {
                        return;
                    }
                    DataGridViewRowCollection rows = dataGridSearchProduct.Rows;

                    // remove the previous row and add it behind the selected row.
                    DataGridViewRow prevRow = rows[index - 1];
                    rows.Remove(prevRow);
                    prevRow.Frozen = false;
                    rows.Insert(index, prevRow);
                    dataGridSearchProduct.ClearSelection();
                    dataGridSearchProduct.Rows[index - 1].Selected = true;
                }
            }
        }

        private void moveDown()
        {
            if (dataGridSearchProduct.RowCount > 0)
            {
                if (dataGridSearchProduct.SelectedRows.Count > 0)
                {
                    int rowCount = dataGridSearchProduct.Rows.Count;
                    int index = dataGridSearchProduct.SelectedCells[0].OwningRow.Index;

                    if (index == (rowCount - 2)) // include the header row
                    {
                        return;
                    }
                    DataGridViewRowCollection rows = dataGridSearchProduct.Rows;

                    // remove the next row and add it in front of the selected row.
                    DataGridViewRow nextRow = rows[index + 1];
                    rows.Remove(nextRow);
                    nextRow.Frozen = false;
                    rows.Insert(index, nextRow);
                    dataGridSearchProduct.ClearSelection();
                    dataGridSearchProduct.Rows[index + 1].Selected = true;
                }
            }
        }

        private void dataGridSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridSearchProduct.RowCount == 0)
                {
                    return;
                }
                int q = dataGridSearchProduct.CurrentRow.Index;
                if (dataGridSearchProduct.Rows[q].Cells[1].Value == null)
                {
                    return;
                }

                if (dataGridSearchProduct.Rows[q].Cells[1].Value.ToString() != "")
                {
                    BillingItemInfo form1 = new BillingItemInfo(_masterForm, ProductList.ToList()[q], iInvoice );
                    form1.ShowDialog();
                    this.Close();
                }
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Down)
            {
                int c = dataGridSearchProduct.CurrentCell.ColumnIndex;
                int r = dataGridSearchProduct.CurrentCell.RowIndex;
                if (r < dataGridSearchProduct.Rows.Count - 1) //check for index out of range
                    dataGridSearchProduct.CurrentCell = dataGridSearchProduct[c, r + 1];
            }
            if (e.KeyCode == Keys.Up)
            {
                int c = dataGridSearchProduct.CurrentCell.ColumnIndex;
                int r = dataGridSearchProduct.CurrentCell.RowIndex;
                if (r > 0) //check for index out of range
                    dataGridSearchProduct.CurrentCell = dataGridSearchProduct[c, r - 1];
            }
            ////if (e.KeyCode.Equals(Keys.Up))
            ////{
            ////    moveUp();
            ////}
            ////if (e.KeyCode.Equals(Keys.Down))
            ////{
            ////    moveDown();
            ////}
            e.Handled = true;
        }

        private void BillingPriceSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
