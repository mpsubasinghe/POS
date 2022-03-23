namespace POS
{
    partial class BillingItemEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingItemEdit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtondeleterpt = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.textBox_ItemName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxsubTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDisPer = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtondeleterpt);
            this.groupControl1.Controls.Add(this.simpleButtonAdd);
            this.groupControl1.Controls.Add(this.textBox_ItemName);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.label14);
            this.groupControl1.Controls.Add(this.textBox1);
            this.groupControl1.Controls.Add(this.label13);
            this.groupControl1.Controls.Add(this.textBoxsubTotal);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Controls.Add(this.textBoxDisPer);
            this.groupControl1.Controls.Add(this.textBoxPrice);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.textBoxQty);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Location = new System.Drawing.Point(3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(686, 210);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Item Price and  Discount";
            // 
            // simpleButtondeleterpt
            // 
            this.simpleButtondeleterpt.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButtondeleterpt.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtondeleterpt.Image")));
            this.simpleButtondeleterpt.Location = new System.Drawing.Point(557, 166);
            this.simpleButtondeleterpt.Name = "simpleButtondeleterpt";
            this.simpleButtondeleterpt.Size = new System.Drawing.Size(114, 35);
            this.simpleButtondeleterpt.TabIndex = 117;
            this.simpleButtondeleterpt.Text = "Remove Item";
            this.simpleButtondeleterpt.Click += new System.EventHandler(this.simpleButtondeleterpt_Click);
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAdd.Image")));
            this.simpleButtonAdd.Location = new System.Drawing.Point(425, 166);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(114, 35);
            this.simpleButtonAdd.TabIndex = 116;
            this.simpleButtonAdd.Text = "Update";
            this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // textBox_ItemName
            // 
            this.textBox_ItemName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_ItemName.Location = new System.Drawing.Point(156, 23);
            this.textBox_ItemName.Name = "textBox_ItemName";
            this.textBox_ItemName.ReadOnly = true;
            this.textBox_ItemName.Size = new System.Drawing.Size(333, 22);
            this.textBox_ItemName.TabIndex = 115;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.Location = new System.Drawing.Point(66, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 14);
            this.label9.TabIndex = 114;
            this.label9.Text = "Item Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label14.Location = new System.Drawing.Point(404, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 14);
            this.label14.TabIndex = 113;
            this.label14.Text = "Sub Total";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(575, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(96, 22);
            this.textBox1.TabIndex = 112;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label13.Location = new System.Drawing.Point(583, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 111;
            this.label13.Text = "Available Qty";
            // 
            // textBoxsubTotal
            // 
            this.textBoxsubTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBoxsubTotal.Location = new System.Drawing.Point(378, 92);
            this.textBoxsubTotal.Name = "textBoxsubTotal";
            this.textBoxsubTotal.ReadOnly = true;
            this.textBoxsubTotal.Size = new System.Drawing.Size(111, 22);
            this.textBoxsubTotal.TabIndex = 110;
            this.textBoxsubTotal.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(344, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 14);
            this.label2.TabIndex = 109;
            this.label2.Text = "=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(191, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 108;
            this.label1.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label12.Location = new System.Drawing.Point(81, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 107;
            this.label12.Text = "Discount %";
            // 
            // textBoxDisPer
            // 
            this.textBoxDisPer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBoxDisPer.Location = new System.Drawing.Point(69, 156);
            this.textBoxDisPer.Name = "textBoxDisPer";
            this.textBoxDisPer.Size = new System.Drawing.Size(96, 22);
            this.textBoxDisPer.TabIndex = 106;
            this.textBoxDisPer.Text = "0";
            this.textBoxDisPer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDisPer_KeyPress);
            this.textBoxDisPer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxDisPer_PreviewKeyDown);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBoxPrice.Location = new System.Drawing.Point(228, 92);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(96, 22);
            this.textBoxPrice.TabIndex = 105;
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            this.textBoxPrice.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxPrice_PreviewKeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(251, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 104;
            this.label6.Text = "Price";
            // 
            // textBoxQty
            // 
            this.textBoxQty.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBoxQty.Location = new System.Drawing.Point(69, 92);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(96, 22);
            this.textBoxQty.TabIndex = 103;
            this.textBoxQty.Text = "1";
            this.textBoxQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQty_KeyPress);
            this.textBoxQty.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxQty_PreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(81, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 102;
            this.label3.Text = "Quantity";
            // 
            // BillingItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 224);
            this.Controls.Add(this.groupControl1);
            this.Name = "BillingItemEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillingItemEdit";
            this.Load += new System.EventHandler(this.BillingItemEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BillingItemEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxsubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDisPer;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ItemName;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton simpleButtondeleterpt;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
    }
}