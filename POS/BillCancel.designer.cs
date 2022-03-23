namespace POS
{
    partial class BillCancel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillCancel));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Inv = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtondeleterpt = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(51, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 66;
            this.label1.Text = "Inv.No";
            // 
            // textBox_Inv
            // 
            this.textBox_Inv.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Inv.Location = new System.Drawing.Point(107, 48);
            this.textBox_Inv.Name = "textBox_Inv";
            this.textBox_Inv.Size = new System.Drawing.Size(146, 22);
            this.textBox_Inv.TabIndex = 67;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtondeleterpt);
            this.groupControl1.Controls.Add(this.textBox_Inv);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(2, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(337, 144);
            this.groupControl1.TabIndex = 68;
            this.groupControl1.Text = "Bill Cancel";
            // 
            // simpleButtondeleterpt
            // 
            this.simpleButtondeleterpt.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButtondeleterpt.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtondeleterpt.Image")));
            this.simpleButtondeleterpt.Location = new System.Drawing.Point(156, 76);
            this.simpleButtondeleterpt.Name = "simpleButtondeleterpt";
            this.simpleButtondeleterpt.Size = new System.Drawing.Size(97, 35);
            this.simpleButtondeleterpt.TabIndex = 77;
            this.simpleButtondeleterpt.Text = "Cancel Bill";
            this.simpleButtondeleterpt.Click += new System.EventHandler(this.simpleButtondeleterpt_Click);
            // 
            // BillCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 145);
            this.Controls.Add(this.groupControl1);
            this.Name = "BillCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Cancel";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Inv;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtondeleterpt;
    }
}