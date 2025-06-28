using System.Windows.Forms;

namespace Source.Views.Admin
{
    partial class ProductList
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
            pnTitle = new Panel();
            btnAdd = new MyCustomControl.RJButton();
            lblHeader = new Label();
            rbtnFilter = new MyCustomControl.RJButton();
            pnLine = new Panel();
            pnMain = new Panel();
            pnSearch = new Panel();
            tbxSearch = new TextBox();
            lblSearch = new Label();
            pnHeader = new Panel();
            pnLeftHeader = new Panel();
            btnEntries = new Label();
            cbxShow = new ComboBox();
            lblShow = new Label();
            pnFilter = new Panel();
            pnFilterCate = new Panel();
            cbxCate = new ComboBox();
            lblCate = new Label();
            pnFilterPrice = new Panel();
            tbxMax = new TextBox();
            tbxMin = new TextBox();
            lblMin = new Label();
            lblMax = new Label();
            lblPricingRange = new Label();
            lblFilter = new Label();
            pnList = new Panel();
            gridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            CategoryId = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            Remove = new DataGridViewButtonColumn();
            pnFotter = new Panel();
            lblShowing = new Label();
            panel1 = new Panel();
            labelPageInfo = new Label();
            rjButton1 = new MyCustomControl.RJButton();
            rjButton2 = new MyCustomControl.RJButton();
            pnTitle.SuspendLayout();
            pnMain.SuspendLayout();
            pnSearch.SuspendLayout();
            pnHeader.SuspendLayout();
            pnLeftHeader.SuspendLayout();
            pnFilter.SuspendLayout();
            pnFilterCate.SuspendLayout();
            pnFilterPrice.SuspendLayout();
            pnList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            pnFotter.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(btnAdd);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(0, -2);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(1015, 91);
            pnTitle.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.MediumSlateBlue;
            btnAdd.BackgroundColor = Color.MediumSlateBlue;
            btnAdd.BorderColor = Color.PaleVioletRed;
            btnAdd.BorderRadius = 20;
            btnAdd.BorderSize = 0;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(684, 24);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(250, 50);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Product";
            btnAdd.TextColor = Color.White;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Cursor = Cursors.IBeam;
            lblHeader.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(23, 27);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(186, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Products List";
            // 
            // rbtnFilter
            // 
            rbtnFilter.BackColor = Color.MediumSlateBlue;
            rbtnFilter.BackgroundColor = Color.MediumSlateBlue;
            rbtnFilter.BorderColor = Color.PaleVioletRed;
            rbtnFilter.BorderRadius = 20;
            rbtnFilter.BorderSize = 0;
            rbtnFilter.Cursor = Cursors.Hand;
            rbtnFilter.FlatAppearance.BorderSize = 0;
            rbtnFilter.FlatStyle = FlatStyle.Flat;
            rbtnFilter.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnFilter.ForeColor = Color.White;
            rbtnFilter.Location = new Point(111, 257);
            rbtnFilter.Name = "rbtnFilter";
            rbtnFilter.Size = new Size(122, 45);
            rbtnFilter.TabIndex = 23;
            rbtnFilter.Text = "Filter";
            rbtnFilter.TextColor = Color.White;
            rbtnFilter.UseVisualStyleBackColor = false;
            rbtnFilter.Click += rbtnFilter_Click;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.ForeColor = SystemColors.ActiveCaptionText;
            pnLine.Location = new Point(0, 88);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(964, 1);
            pnLine.TabIndex = 1;
            // 
            // pnMain
            // 
            pnMain.BackColor = Color.White;
            pnMain.Controls.Add(pnSearch);
            pnMain.Controls.Add(pnHeader);
            pnMain.Controls.Add(pnFilter);
            pnMain.Controls.Add(pnList);
            pnMain.Controls.Add(pnFotter);
            pnMain.Location = new Point(1, 101);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1014, 448);
            pnMain.TabIndex = 2;
            // 
            // pnSearch
            // 
            pnSearch.Controls.Add(tbxSearch);
            pnSearch.Controls.Add(lblSearch);
            pnSearch.Location = new Point(589, 3);
            pnSearch.Margin = new Padding(2, 3, 2, 3);
            pnSearch.Name = "pnSearch";
            pnSearch.Size = new Size(423, 45);
            pnSearch.TabIndex = 2;
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
            // pnHeader
            // 
            pnHeader.Controls.Add(pnLeftHeader);
            pnHeader.Location = new Point(254, 3);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(702, 48);
            pnHeader.TabIndex = 0;
            // 
            // pnLeftHeader
            // 
            pnLeftHeader.Controls.Add(btnEntries);
            pnLeftHeader.Controls.Add(cbxShow);
            pnLeftHeader.Controls.Add(lblShow);
            pnLeftHeader.Location = new Point(12, 3);
            pnLeftHeader.Name = "pnLeftHeader";
            pnLeftHeader.Size = new Size(191, 42);
            pnLeftHeader.TabIndex = 0;
            // 
            // btnEntries
            // 
            btnEntries.AutoSize = true;
            btnEntries.Location = new Point(118, 12);
            btnEntries.Name = "btnEntries";
            btnEntries.Size = new Size(63, 22);
            btnEntries.TabIndex = 2;
            btnEntries.Text = "entries";
            // 
            // cbxShow
            // 
            cbxShow.FormattingEnabled = true;
            cbxShow.Location = new Point(67, 5);
            cbxShow.Name = "cbxShow";
            cbxShow.Size = new Size(43, 30);
            cbxShow.TabIndex = 1;
            cbxShow.SelectedIndexChanged += cbxShow_SelectedIndexChanged;
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.Location = new Point(6, 13);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(55, 22);
            lblShow.TabIndex = 0;
            lblShow.Text = "Show";
            // 
            // pnFilter
            // 
            pnFilter.Controls.Add(rbtnFilter);
            pnFilter.Controls.Add(pnFilterCate);
            pnFilter.Controls.Add(pnFilterPrice);
            pnFilter.Controls.Add(lblFilter);
            pnFilter.Location = new Point(4, 0);
            pnFilter.Name = "pnFilter";
            pnFilter.Size = new Size(244, 317);
            pnFilter.TabIndex = 2;
            // 
            // pnFilterCate
            // 
            pnFilterCate.Controls.Add(cbxCate);
            pnFilterCate.Controls.Add(lblCate);
            pnFilterCate.Location = new Point(1, 51);
            pnFilterCate.Name = "pnFilterCate";
            pnFilterCate.Size = new Size(232, 58);
            pnFilterCate.TabIndex = 1;
            // 
            // cbxCate
            // 
            cbxCate.FormattingEnabled = true;
            cbxCate.Location = new Point(106, 10);
            cbxCate.Name = "cbxCate";
            cbxCate.Size = new Size(115, 30);
            cbxCate.TabIndex = 2;
            cbxCate.SelectedIndexChanged += cbxCate_SelectedIndexChanged;
            // 
            // lblCate
            // 
            lblCate.AutoSize = true;
            lblCate.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCate.Location = new Point(4, 10);
            lblCate.Name = "lblCate";
            lblCate.Size = new Size(96, 23);
            lblCate.TabIndex = 0;
            lblCate.Text = "Category:";
            // 
            // pnFilterPrice
            // 
            pnFilterPrice.BackColor = Color.White;
            pnFilterPrice.Controls.Add(tbxMax);
            pnFilterPrice.Controls.Add(tbxMin);
            pnFilterPrice.Controls.Add(lblMin);
            pnFilterPrice.Controls.Add(lblMax);
            pnFilterPrice.Controls.Add(lblPricingRange);
            pnFilterPrice.Location = new Point(3, 115);
            pnFilterPrice.Name = "pnFilterPrice";
            pnFilterPrice.Size = new Size(230, 136);
            pnFilterPrice.TabIndex = 20;
            // 
            // tbxMax
            // 
            tbxMax.Location = new Point(69, 93);
            tbxMax.Name = "tbxMax";
            tbxMax.Size = new Size(105, 30);
            tbxMax.TabIndex = 16;
            tbxMax.KeyPress += tbxMax_KeyPress;
            // 
            // tbxMin
            // 
            tbxMin.Location = new Point(69, 41);
            tbxMin.Name = "tbxMin";
            tbxMin.Size = new Size(105, 30);
            tbxMin.TabIndex = 6;
            tbxMin.KeyPress += tbxMin_KeyPress;
            // 
            // lblMin
            // 
            lblMin.AutoSize = true;
            lblMin.Cursor = Cursors.IBeam;
            lblMin.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMin.Location = new Point(3, 43);
            lblMin.Name = "lblMin";
            lblMin.Size = new Size(43, 23);
            lblMin.TabIndex = 4;
            lblMin.Text = "Min";
            // 
            // lblMax
            // 
            lblMax.AutoSize = true;
            lblMax.Cursor = Cursors.IBeam;
            lblMax.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMax.Location = new Point(3, 95);
            lblMax.Name = "lblMax";
            lblMax.Size = new Size(48, 23);
            lblMax.TabIndex = 1;
            lblMax.Text = "Max";
            // 
            // lblPricingRange
            // 
            lblPricingRange.AutoSize = true;
            lblPricingRange.Cursor = Cursors.IBeam;
            lblPricingRange.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPricingRange.Location = new Point(12, 11);
            lblPricingRange.Name = "lblPricingRange";
            lblPricingRange.Size = new Size(128, 23);
            lblPricingRange.TabIndex = 0;
            lblPricingRange.Text = "Pricing Range";
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Cursor = Cursors.IBeam;
            lblFilter.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFilter.Location = new Point(18, 16);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(66, 25);
            lblFilter.TabIndex = 1;
            lblFilter.Text = "Filter";
            // 
            // pnList
            // 
            pnList.Controls.Add(gridView);
            pnList.Cursor = Cursors.IBeam;
            pnList.Location = new Point(254, 51);
            pnList.Name = "pnList";
            pnList.Size = new Size(760, 336);
            pnList.TabIndex = 1;
            // 
            // gridView
            // 
            gridView.BorderStyle = BorderStyle.None;
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { Id, ProductName, Stock, Price, CategoryId, Edit, Remove });
            gridView.GridColor = Color.Gray;
            gridView.Location = new Point(3, 4);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(754, 328);
            gridView.TabIndex = 0;
            gridView.CellClick += gridView_CellClick;
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
            // ProductName
            // 
            ProductName.DataPropertyName = "Name";
            ProductName.HeaderText = "Name";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            ProductName.SortMode = DataGridViewColumnSortMode.Programmatic;
            ProductName.Width = 125;
            // 
            // Stock
            // 
            Stock.DataPropertyName = "StockQuantity";
            Stock.HeaderText = "Stock";
            Stock.MinimumWidth = 6;
            Stock.Name = "Stock";
            Stock.SortMode = DataGridViewColumnSortMode.Programmatic;
            Stock.Width = 125;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.SortMode = DataGridViewColumnSortMode.Programmatic;
            Price.Width = 125;
            // 
            // CategoryId
            // 
            CategoryId.DataPropertyName = "CategoryId";
            CategoryId.HeaderText = "CategoryId";
            CategoryId.MinimumWidth = 6;
            CategoryId.Name = "CategoryId";
            CategoryId.SortMode = DataGridViewColumnSortMode.Programmatic;
            CategoryId.Width = 125;
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Resizable = DataGridViewTriState.True;
            Edit.Width = 125;
            // 
            // Remove
            // 
            Remove.HeaderText = "Remove";
            Remove.MinimumWidth = 6;
            Remove.Name = "Remove";
            Remove.Resizable = DataGridViewTriState.True;
            Remove.Width = 125;
            // 
            // pnFotter
            // 
            pnFotter.Controls.Add(lblShowing);
            pnFotter.Controls.Add(panel1);
            pnFotter.Location = new Point(254, 390);
            pnFotter.Name = "pnFotter";
            pnFotter.Size = new Size(757, 48);
            pnFotter.TabIndex = 0;
            // 
            // lblShowing
            // 
            lblShowing.AutoSize = true;
            lblShowing.Cursor = Cursors.IBeam;
            lblShowing.Location = new Point(20, 13);
            lblShowing.Name = "lblShowing";
            lblShowing.Size = new Size(243, 22);
            lblShowing.TabIndex = 0;
            lblShowing.Text = "Showing 1 to 10 of 13 entries";
            // 
            // panel1
            // 
            panel1.Controls.Add(labelPageInfo);
            panel1.Controls.Add(rjButton1);
            panel1.Controls.Add(rjButton2);
            panel1.Location = new Point(388, 3);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(369, 45);
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
            // rjButton1
            // 
            rjButton1.BackColor = Color.FromArgb(249, 251, 253);
            rjButton1.BackgroundColor = Color.FromArgb(249, 251, 253);
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.Cursor = Cursors.Hand;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.ForeColor = Color.MediumSlateBlue;
            rjButton1.Location = new Point(261, 3);
            rjButton1.Margin = new Padding(2, 3, 2, 3);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(108, 42);
            rjButton1.TabIndex = 1;
            rjButton1.Text = "Next";
            rjButton1.TextColor = Color.MediumSlateBlue;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // rjButton2
            // 
            rjButton2.BackColor = Color.FromArgb(249, 251, 253);
            rjButton2.BackgroundColor = Color.FromArgb(249, 251, 253);
            rjButton2.BorderColor = Color.PaleVioletRed;
            rjButton2.BorderRadius = 20;
            rjButton2.BorderSize = 0;
            rjButton2.Cursor = Cursors.Hand;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.FlatStyle = FlatStyle.Flat;
            rjButton2.ForeColor = Color.MediumSlateBlue;
            rjButton2.Location = new Point(7, 0);
            rjButton2.Margin = new Padding(2, 3, 2, 3);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(108, 42);
            rjButton2.TabIndex = 0;
            rjButton2.Text = "Previous";
            rjButton2.TextColor = Color.MediumSlateBlue;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // ProductList
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(1015, 551);
            Controls.Add(pnMain);
            Controls.Add(pnLine);
            Controls.Add(pnTitle);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductList";
            Text = "ProductList";
            Load += ProductList_Load;
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            pnMain.ResumeLayout(false);
            pnSearch.ResumeLayout(false);
            pnSearch.PerformLayout();
            pnHeader.ResumeLayout(false);
            pnLeftHeader.ResumeLayout(false);
            pnLeftHeader.PerformLayout();
            pnFilter.ResumeLayout(false);
            pnFilter.PerformLayout();
            pnFilterCate.ResumeLayout(false);
            pnFilterCate.PerformLayout();
            pnFilterPrice.ResumeLayout(false);
            pnFilterPrice.PerformLayout();
            pnList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            pnFotter.ResumeLayout(false);
            pnFotter.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTitle;
        private MyCustomControl.RJButton btnAdd;
        private Label lblHeader;
        private Panel pnLine;
        private Panel pnMain;
        private Panel pnHeader;
        private Panel pnLeftHeader;
        private Label lblShow;
        private Label btnEntries;
        private ComboBox cbxShow;
        private Panel pnFotter;
        private Label lblShowing;
        private Panel pnList;
        private DataGridView gridView;
        private Panel pnFilterCate;
        private Label lblCate;
        private Panel pnFilter;
        private Label lblFilter;
        private Panel pnFilterPrice;
        private TextBox tbxMax;
        private TextBox tbxMin;
        private Label lblMin;
        private Label lblMax;
        private Label lblPricingRange;
        private Panel pnSearch;
        private TextBox tbxSearch;
        private Label lblSearch;
        private Panel panel1;
        private Label labelPageInfo;
        private MyCustomControl.RJButton rjButton1;
        private MyCustomControl.RJButton rjButton2;
        private MyCustomControl.RJButton rbtnFilter;
        private ComboBox cbxCate;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn CategoryId;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Remove;
    }
}