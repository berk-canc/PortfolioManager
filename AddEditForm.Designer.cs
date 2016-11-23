namespace PortfolioManager
{
    partial class AddEditForm
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
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelShares = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelSymbol = new System.Windows.Forms.Label();
            this.textBoxShares = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxSymbol = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.labelDate);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.labelShares);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.labelSymbol);
            this.panel1.Controls.Add(this.textBoxShares);
            this.panel1.Controls.Add(this.textBoxPrice);
            this.panel1.Controls.Add(this.textBoxSymbol);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 142);
            this.panel1.TabIndex = 0;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(6, 87);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(78, 13);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Purchase Date";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(86, 87);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // labelShares
            // 
            this.labelShares.AutoSize = true;
            this.labelShares.Location = new System.Drawing.Point(6, 61);
            this.labelShares.Name = "labelShares";
            this.labelShares.Size = new System.Drawing.Size(40, 13);
            this.labelShares.TabIndex = 5;
            this.labelShares.Text = "Shares";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(6, 35);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(79, 13);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "Purchase Price";
            // 
            // labelSymbol
            // 
            this.labelSymbol.AutoSize = true;
            this.labelSymbol.Location = new System.Drawing.Point(6, 9);
            this.labelSymbol.Name = "labelSymbol";
            this.labelSymbol.Size = new System.Drawing.Size(41, 13);
            this.labelSymbol.TabIndex = 3;
            this.labelSymbol.Text = "Symbol";
            // 
            // textBoxShares
            // 
            this.textBoxShares.Location = new System.Drawing.Point(86, 61);
            this.textBoxShares.MaxLength = 10;
            this.textBoxShares.Name = "textBoxShares";
            this.textBoxShares.Size = new System.Drawing.Size(66, 20);
            this.textBoxShares.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(86, 35);
            this.textBoxPrice.MaxLength = 10;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(66, 20);
            this.textBoxPrice.TabIndex = 1;
            // 
            // textBoxSymbol
            // 
            this.textBoxSymbol.Location = new System.Drawing.Point(86, 9);
            this.textBoxSymbol.MaxLength = 10;
            this.textBoxSymbol.Name = "textBoxSymbol";
            this.textBoxSymbol.Size = new System.Drawing.Size(66, 20);
            this.textBoxSymbol.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonSaveClose);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 113);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(294, 29);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(216, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveClose
            // 
            this.buttonSaveClose.AutoSize = true;
            this.buttonSaveClose.Location = new System.Drawing.Point(130, 3);
            this.buttonSaveClose.Name = "buttonSaveClose";
            this.buttonSaveClose.Size = new System.Drawing.Size(80, 23);
            this.buttonSaveClose.TabIndex = 0;
            this.buttonSaveClose.Text = "Save && Close";
            this.buttonSaveClose.UseVisualStyleBackColor = true;
            this.buttonSaveClose.Click += new System.EventHandler(this.buttonSaveClose_Click);
            // 
            // AddEditWindow
            // 
            this.AcceptButton = this.buttonSaveClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(294, 142);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditWindow";
            this.ShowInTaskbar = false;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSymbol;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxShares;
        private System.Windows.Forms.Label labelShares;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelSymbol;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonSaveClose;
        private System.Windows.Forms.Button buttonCancel;
    }
}