namespace PortfolioManager
{
    partial class PositionPicker
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 206);
            this.panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "AAPL, 200shr, $102/shr, Date: 9/14/2001",
            "MSFT, 30shr,   $22/shr, Date: 9/14/1999",
            "ROST, 100shr, $32/shr, Date: 9/14/2013",
            "AAPL, 200shr, $102/shr, Date: 9/14/2001",
            "MSFT, 30shr,  $42/shr,  Date: 9/14/1999",
            "ROST, 100shr, $62/shr, Date: 9/14/2013",
            "AAPL, 200shr, $132/shr, Date: 9/14/2001",
            "MSFT, 30shr,   $42/shr, Date: 9/14/1999",
            "ROST, 100shr, $77/shr, Date: 9/14/2013"});
            this.comboBox1.Location = new System.Drawing.Point(49, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "AAPL, 200shr, $102/shr, Date: 9/14/2001",
            "MSFT, 30shr,   $22/shr, Date: 9/14/1999",
            "ROST, 100shr, $32/shr, Date: 9/14/2013",
            "AAPL, 200shr, $102/shr, Date: 9/14/2001",
            "MSFT, 30shr,  $42/shr,  Date: 9/14/1999",
            "ROST, 100shr, $62/shr, Date: 9/14/2013",
            "AAPL, 200shr, $132/shr, Date: 9/14/2001",
            "MSFT, 30shr,   $42/shr, Date: 9/14/1999",
            "ROST, 100shr, $77/shr, Date: 9/14/2013"});
            this.listBox1.Location = new System.Drawing.Point(431, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(231, 69);
            this.listBox1.TabIndex = 1;
            // 
            // PositionPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 206);
            this.Controls.Add(this.panel1);
            this.Name = "PositionPicker";
            this.Text = "PositionPicker";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}