namespace PortfolioManager
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostBasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DollarGainLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerctGainLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.samplePortfolioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.flowLayoutPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.StockName,
            this.LastPrice,
            this.Shares,
            this.BuyPrice,
            this.CostBasis,
            this.CurrentValue,
            this.DollarGainLoss,
            this.PerctGainLoss,
            this.Weight,
            this.Date});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1180, 403);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // Symbol
            // 
            this.Symbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Symbol.FillWeight = 60F;
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.MaxInputLength = 10;
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            this.Symbol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // StockName
            // 
            this.StockName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockName.HeaderText = "Name";
            this.StockName.MaxInputLength = 10;
            this.StockName.Name = "StockName";
            this.StockName.ReadOnly = true;
            this.StockName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // LastPrice
            // 
            this.LastPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastPrice.FillWeight = 70F;
            this.LastPrice.HeaderText = "Last Price";
            this.LastPrice.MaxInputLength = 10;
            this.LastPrice.Name = "LastPrice";
            this.LastPrice.ReadOnly = true;
            this.LastPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Shares
            // 
            this.Shares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Shares.FillWeight = 90F;
            this.Shares.HeaderText = "Shares";
            this.Shares.MaxInputLength = 10;
            this.Shares.Name = "Shares";
            this.Shares.ReadOnly = true;
            this.Shares.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // BuyPrice
            // 
            this.BuyPrice.FillWeight = 70F;
            this.BuyPrice.HeaderText = "Buy Price";
            this.BuyPrice.MaxInputLength = 10;
            this.BuyPrice.Name = "BuyPrice";
            this.BuyPrice.ReadOnly = true;
            this.BuyPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CostBasis
            // 
            this.CostBasis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CostBasis.HeaderText = "Cost Basis";
            this.CostBasis.MaxInputLength = 10;
            this.CostBasis.Name = "CostBasis";
            this.CostBasis.ReadOnly = true;
            this.CostBasis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CurrentValue
            // 
            this.CurrentValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CurrentValue.HeaderText = "Current Value";
            this.CurrentValue.MaxInputLength = 10;
            this.CurrentValue.Name = "CurrentValue";
            this.CurrentValue.ReadOnly = true;
            this.CurrentValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DollarGainLoss
            // 
            this.DollarGainLoss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DollarGainLoss.HeaderText = "$ - Gain/Loss";
            this.DollarGainLoss.MaxInputLength = 10;
            this.DollarGainLoss.Name = "DollarGainLoss";
            this.DollarGainLoss.ReadOnly = true;
            this.DollarGainLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // PerctGainLoss
            // 
            this.PerctGainLoss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PerctGainLoss.FillWeight = 85F;
            this.PerctGainLoss.HeaderText = "% - Gain/Loss";
            this.PerctGainLoss.MaxInputLength = 5;
            this.PerctGainLoss.Name = "PerctGainLoss";
            this.PerctGainLoss.ReadOnly = true;
            this.PerctGainLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Weight
            // 
            this.Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Weight.FillWeight = 75F;
            this.Weight.HeaderText = "% - Weight";
            this.Weight.MaxInputLength = 5;
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.FillWeight = 90F;
            this.Date.HeaderText = "Purchase Date";
            this.Date.MaxInputLength = 50;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(938, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add...";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(1019, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit...";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(1100, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete...";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Controls.Add(this.buttonDelete);
            this.flowLayoutPanel.Controls.Add(this.buttonEdit);
            this.flowLayoutPanel.Controls.Add(this.buttonAdd);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 427);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1180, 31);
            this.flowLayoutPanel.TabIndex = 7;
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1180, 403);
            this.panel.TabIndex = 8;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1180, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.samplePortfolioToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.refreshToolStripMenuItem.Text = "Refresh Prices";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // samplePortfolioToolStripMenuItem
            // 
            this.samplePortfolioToolStripMenuItem.Name = "samplePortfolioToolStripMenuItem";
            this.samplePortfolioToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.samplePortfolioToolStripMenuItem.Text = "Sample Portfolio";
            this.samplePortfolioToolStripMenuItem.Click += new System.EventHandler(this.samplePortfolioToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.FileName = "portfolio";
            this.openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            this.openFileDialog.Title = "Open";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            this.saveFileDialog.FileName = "portfolio";
            this.saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            this.saveFileDialog.Title = "Save";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1180, 458);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Portfolio Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.flowLayoutPanel.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shares;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostBasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn DollarGainLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerctGainLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem samplePortfolioToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

