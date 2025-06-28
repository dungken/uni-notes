namespace Source.Views.Admin.Inventory
{
    partial class StockList
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
            lblHeader = new Label();
            pnLine = new Panel();
            pnTitle = new Panel();
            lblShowing = new Label();
            pnFotter = new Panel();
            panel1 = new Panel();
            labelPageInfo = new Label();
            rbtnNext = new MyCustomControl.RJButton();
            rbtnPre = new MyCustomControl.RJButton();
            gridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Products = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            DateAdded = new DataGridViewTextBoxColumn();
            Instock = new DataGridViewTextBoxColumn();
            ProductColor = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            pnList = new Panel();
            pnMain = new Panel();
            btnEntries = new Label();
            cbxShow = new ComboBox();
            lblShow = new Label();
            pnLeftHeader = new Panel();
            tbxSearch = new TextBox();
            lblSearch = new Label();
            pnSearch = new Panel();
            pnHeader = new Panel();
            pnTitle.SuspendLayout();
            pnFotter.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            pnList.SuspendLayout();
            pnMain.SuspendLayout();
            pnLeftHeader.SuspendLayout();
            pnSearch.SuspendLayout();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Cursor = Cursors.IBeam;
            lblHeader.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(23, 27);
            lblHeader.Margin = new Padding(2, 0, 2, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(273, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Stock Inventory List";
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.ForeColor = SystemColors.ActiveCaptionText;
            pnLine.Location = new Point(0, 88);
            pnLine.Margin = new Padding(2, 3, 2, 3);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(964, 1);
            pnLine.TabIndex = 9;
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(0, -2);
            pnTitle.Margin = new Padding(2, 3, 2, 3);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(964, 91);
            pnTitle.TabIndex = 8;
            // 
            // lblShowing
            // 
            lblShowing.AutoSize = true;
            lblShowing.Cursor = Cursors.IBeam;
            lblShowing.Location = new Point(23, 14);
            lblShowing.Margin = new Padding(2, 0, 2, 0);
            lblShowing.Name = "lblShowing";
            lblShowing.Size = new Size(243, 22);
            lblShowing.TabIndex = 0;
            lblShowing.Text = "Showing 1 to 10 of 13 entries";
            // 
            // pnFotter
            // 
            pnFotter.Controls.Add(panel1);
            pnFotter.Controls.Add(lblShowing);
            pnFotter.Location = new Point(2, 389);
            pnFotter.Margin = new Padding(2, 3, 2, 3);
            pnFotter.Name = "pnFotter";
            pnFotter.Size = new Size(957, 47);
            pnFotter.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelPageInfo);
            panel1.Controls.Add(rbtnNext);
            panel1.Controls.Add(rbtnPre);
            panel1.Location = new Point(644, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(313, 45);
            panel1.TabIndex = 2;
            // 
            // labelPageInfo
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Location = new Point(115, 11);
            labelPageInfo.Name = "labelPageInfo";
            labelPageInfo.Size = new Size(0, 22);
            labelPageInfo.TabIndex = 5;
            // 
            // rbtnNext
            // 
            rbtnNext.BackColor = Color.FromArgb(249, 251, 253);
            rbtnNext.BackgroundColor = Color.FromArgb(249, 251, 253);
            rbtnNext.BorderColor = Color.PaleVioletRed;
            rbtnNext.BorderRadius = 20;
            rbtnNext.BorderSize = 0;
            rbtnNext.Cursor = Cursors.Hand;
            rbtnNext.FlatAppearance.BorderSize = 0;
            rbtnNext.FlatStyle = FlatStyle.Flat;
            rbtnNext.ForeColor = Color.MediumSlateBlue;
            rbtnNext.Location = new Point(213, 1);
            rbtnNext.Margin = new Padding(2, 3, 2, 3);
            rbtnNext.Name = "rbtnNext";
            rbtnNext.Size = new Size(108, 42);
            rbtnNext.TabIndex = 1;
            rbtnNext.Text = "Next";
            rbtnNext.TextColor = Color.MediumSlateBlue;
            rbtnNext.UseVisualStyleBackColor = false;
            rbtnNext.Click += rbtnNext_Click;
            // 
            // rbtnPre
            // 
            rbtnPre.BackColor = Color.FromArgb(249, 251, 253);
            rbtnPre.BackgroundColor = Color.FromArgb(249, 251, 253);
            rbtnPre.BorderColor = Color.PaleVioletRed;
            rbtnPre.BorderRadius = 20;
            rbtnPre.BorderSize = 0;
            rbtnPre.Cursor = Cursors.Hand;
            rbtnPre.FlatAppearance.BorderSize = 0;
            rbtnPre.FlatStyle = FlatStyle.Flat;
            rbtnPre.ForeColor = Color.MediumSlateBlue;
            rbtnPre.Location = new Point(2, 1);
            rbtnPre.Margin = new Padding(2, 3, 2, 3);
            rbtnPre.Name = "rbtnPre";
            rbtnPre.Size = new Size(108, 42);
            rbtnPre.TabIndex = 0;
            rbtnPre.Text = "Previous";
            rbtnPre.TextColor = Color.MediumSlateBlue;
            rbtnPre.UseVisualStyleBackColor = false;
            rbtnPre.Click += rbtnPre_Click;
            // 
            // gridView
            // 
            gridView.BorderStyle = BorderStyle.None;
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { Id, Products, Category, DateAdded, Instock, ProductColor, Status });
            gridView.GridColor = Color.Gray;
            gridView.Location = new Point(5, 3);
            gridView.Margin = new Padding(2, 3, 2, 3);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(953, 328);
            gridView.TabIndex = 0;
            gridView.ColumnHeaderMouseClick += gridView_ColumnHeaderMouseClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.SortMode = DataGridViewColumnSortMode.Programmatic;
            Id.Width = 125;
            // 
            // Products
            // 
            Products.DataPropertyName = "Name";
            Products.HeaderText = "Products";
            Products.MinimumWidth = 6;
            Products.Name = "Products";
            Products.SortMode = DataGridViewColumnSortMode.Programmatic;
            Products.Width = 125;
            // 
            // Category
            // 
            Category.DataPropertyName = "CategoryName";
            Category.HeaderText = "Category";
            Category.MinimumWidth = 6;
            Category.Name = "Category";
            Category.SortMode = DataGridViewColumnSortMode.Programmatic;
            Category.Width = 125;
            // 
            // DateAdded
            // 
            DateAdded.DataPropertyName = "DateAdded";
            DateAdded.HeaderText = "Date Added";
            DateAdded.MinimumWidth = 6;
            DateAdded.Name = "DateAdded";
            DateAdded.SortMode = DataGridViewColumnSortMode.Programmatic;
            DateAdded.Width = 125;
            // 
            // Instock
            // 
            Instock.DataPropertyName = "StockQuantity";
            Instock.HeaderText = "Instock";
            Instock.MinimumWidth = 6;
            Instock.Name = "Instock";
            Instock.SortMode = DataGridViewColumnSortMode.Programmatic;
            Instock.Width = 125;
            // 
            // ProductColor
            // 
            ProductColor.DataPropertyName = "ColorName";
            ProductColor.HeaderText = "Color";
            ProductColor.MinimumWidth = 6;
            ProductColor.Name = "ProductColor";
            ProductColor.SortMode = DataGridViewColumnSortMode.Programmatic;
            ProductColor.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.SortMode = DataGridViewColumnSortMode.Programmatic;
            Status.Width = 125;
            // 
            // pnList
            // 
            pnList.Controls.Add(gridView);
            pnList.Cursor = Cursors.IBeam;
            pnList.Location = new Point(-2, 51);
            pnList.Margin = new Padding(2, 3, 2, 3);
            pnList.Name = "pnList";
            pnList.Size = new Size(966, 336);
            pnList.TabIndex = 1;
            // 
            // pnMain
            // 
            pnMain.BackColor = Color.White;
            pnMain.Controls.Add(pnList);
            pnMain.Controls.Add(pnFotter);
            pnMain.Location = new Point(1, 101);
            pnMain.Margin = new Padding(2, 3, 2, 3);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(963, 440);
            pnMain.TabIndex = 10;
            // 
            // btnEntries
            // 
            btnEntries.AutoSize = true;
            btnEntries.Location = new Point(119, 12);
            btnEntries.Margin = new Padding(2, 0, 2, 0);
            btnEntries.Name = "btnEntries";
            btnEntries.Size = new Size(63, 22);
            btnEntries.TabIndex = 2;
            btnEntries.Text = "entries";
            // 
            // cbxShow
            // 
            cbxShow.FormattingEnabled = true;
            cbxShow.Location = new Point(67, 5);
            cbxShow.Margin = new Padding(2, 3, 2, 3);
            cbxShow.Name = "cbxShow";
            cbxShow.Size = new Size(43, 30);
            cbxShow.TabIndex = 1;
            cbxShow.SelectedIndexChanged += cbxShow_SelectedIndexChanged;
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.Location = new Point(6, 13);
            lblShow.Margin = new Padding(2, 0, 2, 0);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(55, 22);
            lblShow.TabIndex = 0;
            lblShow.Text = "Show";
            // 
            // pnLeftHeader
            // 
            pnLeftHeader.Controls.Add(btnEntries);
            pnLeftHeader.Controls.Add(cbxShow);
            pnLeftHeader.Controls.Add(lblShow);
            pnLeftHeader.Location = new Point(12, 3);
            pnLeftHeader.Margin = new Padding(2, 3, 2, 3);
            pnLeftHeader.Name = "pnLeftHeader";
            pnLeftHeader.Size = new Size(191, 42);
            pnLeftHeader.TabIndex = 0;
            // 
            // tbxSearch
            // 
            tbxSearch.Cursor = Cursors.IBeam;
            tbxSearch.Location = new Point(86, 7);
            tbxSearch.Margin = new Padding(2, 3, 2, 3);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(251, 30);
            tbxSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 12);
            lblSearch.Margin = new Padding(2, 0, 2, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(70, 22);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // pnSearch
            // 
            pnSearch.Controls.Add(tbxSearch);
            pnSearch.Controls.Add(lblSearch);
            pnSearch.Location = new Point(596, 0);
            pnSearch.Margin = new Padding(2, 3, 2, 3);
            pnSearch.Name = "pnSearch";
            pnSearch.Size = new Size(363, 45);
            pnSearch.TabIndex = 1;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.White;
            pnHeader.Controls.Add(pnSearch);
            pnHeader.Controls.Add(pnLeftHeader);
            pnHeader.Location = new Point(0, 104);
            pnHeader.Margin = new Padding(2, 3, 2, 3);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(963, 47);
            pnHeader.TabIndex = 7;
            // 
            // StockList
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(964, 538);
            Controls.Add(pnLine);
            Controls.Add(pnTitle);
            Controls.Add(pnHeader);
            Controls.Add(pnMain);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "StockList";
            Text = "StockList";
            Load += StockList_Load;
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            pnFotter.ResumeLayout(false);
            pnFotter.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            pnList.ResumeLayout(false);
            pnMain.ResumeLayout(false);
            pnLeftHeader.ResumeLayout(false);
            pnLeftHeader.PerformLayout();
            pnSearch.ResumeLayout(false);
            pnSearch.PerformLayout();
            pnHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel pnLine;
        private Panel pnTitle;
        private Label lblShowing;
        private Panel pnFotter;
        private DataGridView gridView;
        private Panel pnList;
        private Panel pnMain;
        private Label btnEntries;
        private ComboBox cbxShow;
        private Label lblShow;
        private Panel pnLeftHeader;
        private TextBox tbxSearch;
        private Label lblSearch;
        private Panel pnSearch;
        private Panel pnHeader;
        private Panel panel1;
        private Label labelPageInfo;
        private MyCustomControl.RJButton rbtnNext;
        private MyCustomControl.RJButton rbtnPre;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Products;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn DateAdded;
        private DataGridViewTextBoxColumn Instock;
        private DataGridViewTextBoxColumn ProductColor;
        private DataGridViewTextBoxColumn Status;
    }
}