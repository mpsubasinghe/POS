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
namespace POS
{
    public partial class BillingItemSearch : Form
    {
        IProduct iProduct = null;
        IInvoice iInvoce = null;
        private Interface_DAL<IProduct> productDAL = null;
        private Billing _masterForm;
        private IEnumerable<IProduct> productList = null;
        private string Type="";
        private string productname = "";
        public BillingItemSearch(Billing masterForm,IInvoice inv, Interface_DAL<IProduct> _productDAL,string pname)
        {
            InitializeComponent();
            productname = pname;
            _masterForm = masterForm;
            iInvoce  = inv ;
            productDAL = _productDAL;
        }

        private void BillingItemSearch_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(BillingItemSearch_KeyDown);
            textBox_ItemName .Text = productname;
            ////////productDAL = FactoryDalLayer<Interface_DAL<IProduct>>.Create<Interface_DAL<IProduct>>("ProductDAL");
        }

        private void textBox_ItemName_TextChanged(object sender, EventArgs e)
        {
            productList = productDAL.SearchAny(textBox_ItemName.Text.ToString());
            LoadGrid(productList);
        }
        private void LoadGrid(IEnumerable<IProduct> productList)
        {
            dataGridSearchProduct.Rows.Clear();
            this.Refresh();
            int count = 1;
            foreach (IProduct person in productList)
            {
                //if (!comboBoxStaff.Items.Cast<string>().Contains(person.Name))
                //{
                //    // comboBoxStaff.Items.Add(person.Name);
                this.dataGridSearchProduct.Rows.Add(count, person.ProductID, person.BarCode, person.ProductName);
                //}

                count = count + 1;
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
                if (dataGridSearchProduct.Rows[q].Cells[1].Value==null)
                {
                    return;
                }
                string Main_Pid = dataGridSearchProduct.Rows[q].Cells[1].Value.ToString();
               
                if (dataGridSearchProduct.Rows[q].Cells[1].Value.ToString() != "")
                {
                    ////////InterfaceProduct_DAL<IProduct> productDAL = FactoryDalLayer<InterfaceProduct_DAL<IProduct>>.Create<InterfaceProduct_DAL<IProduct>>("ProductDAL");
                    ////////IEnumerable<IProduct> productList = null;
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
                            BillingItemInfo form1 = new BillingItemInfo(_masterForm, productList.FirstOrDefault(), iInvoce );
                            form1.ShowDialog();
                        }
                        else if (productList.Count() > 1)
                        {
                            BillingPriceSelection form1 = new BillingPriceSelection(_masterForm, productList, iInvoce );
                            form1.ShowDialog();
                        }
                        this.Close();
                    }


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

        private void textBox_ItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridSearchProduct.Select();
                dataGridSearchProduct.Rows[0].Selected = true;
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {

        }

        private void BillingItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
