namespace Source.Views.Admin
{
    partial class VouchersList
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
            btnAdd = new MyCustomControl.RJButton();
            lblShowing = new Label();
            pnFotter = new Panel();
            gridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            MinOrder = new DataGridViewTextBoxColumn();
            Limit = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            Remove = new DataGridViewButtonColumn();
            pnList = new Panel();
            pnMain = new Panel();
            pnPage = new Panel();
            labelPageInfo = new Label();
            btnNext = new MyCustomControl.RJButton();
            btnPre = new MyCustomControl.RJButton();
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
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            pnList.SuspendLayout();
            pnMain.SuspendLayout();
            pnPage.SuspendLayout();
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
            lblHeader.Size = new Size(188, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Vouchers List";
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
            pnTitle.Controls.Add(btnAdd);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(0, -2);
            pnTitle.Margin = new Padding(2, 3, 2, 3);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(1014, 91);
            pnTitle.TabIndex = 8;
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
            btnAdd.Margin = new Padding(2, 3, 2, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(251, 50);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Vouchers";
            btnAdd.TextColor = Color.White;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
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
            pnFotter.Controls.Add(lblShowing);
            pnFotter.Location = new Point(2, 389);
            pnFotter.Margin = new Padding(2, 3, 2, 3);
            pnFotter.Name = "pnFotter";
            pnFotter.Size = new Size(1011, 47);
            pnFotter.TabIndex = 0;
            // 
            // gridView
            // 
            gridView.AllowUserToOrderColumns = true;
            gridView.BorderStyle = BorderStyle.None;
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { Id, Code, Amount, StartDate, EndDate, MinOrder, Limit, Edit, Remove });
            gridView.GridColor = Color.Gray;
            gridView.Location = new Point(19, 3);
            gridView.Margin = new Padding(2, 3, 2, 3);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(996, 328);
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
            // Code
            // 
            Code.DataPropertyName = "Code";
            Code.HeaderText = "Code";
            Code.MinimumWidth = 6;
            Code.Name = "Code";
            Code.SortMode = DataGridViewColumnSortMode.Programmatic;
            Code.Width = 125;
            // 
            // Amount
            // 
            Amount.DataPropertyName = "Amount";
            Amount.HeaderText = "Amount";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            Amount.SortMode = DataGridViewColumnSortMode.Programmatic;
            Amount.Width = 125;
            // 
            // StartDate
            // 
            StartDate.DataPropertyName = "StartDate";
            StartDate.HeaderText = "Start Date";
            StartDate.MinimumWidth = 6;
            StartDate.Name = "StartDate";
            StartDate.SortMode = DataGridViewColumnSortMode.Programmatic;
            StartDate.Width = 125;
            // 
            // EndDate
            // 
            EndDate.DataPropertyName = "EndDate";
            EndDate.HeaderText = "End Date";
            EndDate.MinimumWidth = 6;
            EndDate.Name = "EndDate";
            EndDate.SortMode = DataGridViewColumnSortMode.Programmatic;
            EndDate.Width = 125;
            // 
            // MinOrder
            // 
            MinOrder.DataPropertyName = "MinOrder";
            MinOrder.HeaderText = "Min Order ";
            MinOrder.MinimumWidth = 6;
            MinOrder.Name = "MinOrder";
            MinOrder.SortMode = DataGridViewColumnSortMode.Programmatic;
            MinOrder.Width = 125;
            // 
            // Limit
            // 
            Limit.DataPropertyName = "Limit";
            Limit.HeaderText = "Limit";
            Limit.MinimumWidth = 6;
            Limit.Name = "Limit";
            Limit.SortMode = DataGridViewColumnSortMode.Programmatic;
            Limit.Width = 125;
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.UseColumnTextForButtonValue = true;
            Edit.Width = 125;
            // 
            // Remove
            // 
            Remove.HeaderText = "Remove";
            Remove.MinimumWidth = 6;
            Remove.Name = "Remove";
            Remove.Resizable = DataGridViewTriState.True;
            Remove.UseColumnTextForButtonValue = true;
            Remove.Width = 125;
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
            pnMain.Controls.Add(pnPage);
            pnMain.Controls.Add(pnList);
            pnMain.Controls.Add(pnFotter);
            pnMain.Location = new Point(1, 101);
            pnMain.Margin = new Padding(2, 3, 2, 3);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(963, 440);
            pnMain.TabIndex = 10;
            // 
            // pnPage
            // 
            pnPage.Controls.Add(labelPageInfo);
            pnPage.Controls.Add(btnNext);
            pnPage.Controls.Add(btnPre);
            pnPage.Location = new Point(643, 388);
            pnPage.Margin = new Padding(2, 3, 2, 3);
            pnPage.Name = "pnPage";
            pnPage.Size = new Size(313, 45);
            pnPage.TabIndex = 2;
            // 
            // labelPageInfo
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Location = new Point(115, 11);
            labelPageInfo.Name = "labelPageInfo";
            labelPageInfo.Size = new Size(0, 22);
            labelPageInfo.TabIndex = 5;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(249, 251, 253);
            btnNext.BackgroundColor = Color.FromArgb(249, 251, 253);
            btnNext.BorderColor = Color.PaleVioletRed;
            btnNext.BorderRadius = 20;
            btnNext.BorderSize = 0;
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.ForeColor = Color.MediumSlateBlue;
            btnNext.Location = new Point(213, 1);
            btnNext.Margin = new Padding(2, 3, 2, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(108, 42);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.TextColor = Color.MediumSlateBlue;
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPre
            // 
            btnPre.BackColor = Color.FromArgb(249, 251, 253);
            btnPre.BackgroundColor = Color.FromArgb(249, 251, 253);
            btnPre.BorderColor = Color.PaleVioletRed;
            btnPre.BorderRadius = 20;
            btnPre.BorderSize = 0;
            btnPre.Cursor = Cursors.Hand;
            btnPre.FlatAppearance.BorderSize = 0;
            btnPre.FlatStyle = FlatStyle.Flat;
            btnPre.ForeColor = Color.MediumSlateBlue;
            btnPre.Location = new Point(2, 1);
            btnPre.Margin = new Padding(2, 3, 2, 3);
            btnPre.Name = "btnPre";
            btnPre.Size = new Size(108, 42);
            btnPre.TabIndex = 0;
            btnPre.Text = "Previous";
            btnPre.TextColor = Color.MediumSlateBlue;
            btnPre.UseVisualStyleBackColor = false;
            btnPre.Click += btnPre_Click;
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
            pnSearch.Location = new Point(646, 0);
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
            pnHeader.Size = new Size(1014, 47);
            pnHeader.TabIndex = 7;
            // 
            // VouchersList
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(1015, 551);
            Controls.Add(pnLine);
            Controls.Add(pnTitle);
            Controls.Add(pnHeader);
            Controls.Add(pnMain);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "VouchersList";
            Text = "CouponsList";
            Load += VouchersList_Load;
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            pnFotter.ResumeLayout(false);
            pnFotter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            pnList.ResumeLayout(false);
            pnMain.ResumeLayout(false);
            pnPage.ResumeLayout(false);
            pnPage.PerformLayout();
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
        private MyCustomControl.RJButton btnAdd;
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
        private Panel pnPage;
        private Label labelPageInfo;
        private MyCustomControl.RJButton btnNext;
        private MyCustomControl.RJButton btnPre;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn EndDate;
        private DataGridViewTextBoxColumn MinOrder;
        private DataGridViewTextBoxColumn Limit;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Remove;
    }
}