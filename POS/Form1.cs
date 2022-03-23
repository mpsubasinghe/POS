using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FactoryDAL;
using I_MiddleLayer;
using I_DAL;

namespace POS
{
    public partial class Form1 : Form
    {
       
    

       string[] data = new string[] {
    "Absecon123","Abstracta","Abundantia","Academia","Acadiau","Acamas",
    "Ackerman","Ackley","Ackworth","Acomita","Aconcagua","Acton","Acushnet",
    "Acworth","Ada","Ada","Adair","Adairs","Adair","Adak","Adalberta","Adamkrafft",
    "Adams"

};
        public Form1()
        {
            InitializeComponent();
        }

      

        private void HandleTextChanged()
        {
            var txt = comboBox1.Text;
            var list = from d in data
                       where d.ToUpper().StartsWith(comboBox1.Text.ToUpper())
                       select d;
            if (list.Count() > 0)
            {
                comboBox1.DataSource = list.ToList();
                //comboBox1.SelectedIndex = 0;
                var sText = comboBox1.Items[0].ToString();
                comboBox1.SelectionStart = txt.Length;
                comboBox1.SelectionLength = sText.Length - txt.Length;
                comboBox1.DroppedDown = true;
                return;
            }
            else
            {
                comboBox1.DroppedDown = false;
                comboBox1.SelectionStart = txt.Length;
            }
        }

      

        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            HandleTextChanged();
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                int sStart = comboBox1.SelectionStart;
                if (sStart > 0)
                {
                    sStart--;
                    if (sStart == 0)
                    {
                        comboBox1.Text = "";
                    }
                    else
                    {
                        comboBox1.Text = comboBox1.Text.Substring(0, sStart);
                    }
                }
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = data;
        }

       
    }
}
