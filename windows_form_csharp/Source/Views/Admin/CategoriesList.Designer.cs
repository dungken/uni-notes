namespace Source.Views.Admin
{
    partial class CategoryList
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
            pnHeader = new Panel();
            pnSearch = new Panel();
            tbxSearch = new TextBox();
            lblSearch = new Label();
            pnLeftHeader = new Panel();
            btnEntries = new Label();
            cbxShow = new ComboBox();
            lblShow = new Label();
            pnMain = new Panel();
            pnList = new Panel();
            gridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            Remove = new DataGridViewButtonColumn();
            pnFotter = new Panel();
            lblEntrie = new Label();
            lblOf = new Label();
            lblTo = new Label();
            lblEntries = new Label();
            lblEntriesEnd = new Label();
            lblEntriesStart = new Label();
            pnPage = new Panel();
            labelPageInfo = new Label();
            btnNext = new MyCustomControl.RJButton();
            btnPre = new MyCustomControl.RJButton();
            lblShowing = new Label();
            pnLine = new Panel();
            pnTitle = new Panel();
            btnAdd = new MyCustomControl.RJButton();
            lblHeader = new Label();
            pnHeader.SuspendLayout();
            pnSearch.SuspendLayout();
            pnLeftHeader.SuspendLayout();
            pnMain.SuspendLayout();
            pnList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            pnFotter.SuspendLayout();
            pnPage.SuspendLayout();
            pnTitle.SuspendLayout();
            SuspendLayout();
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
            pnHeader.TabIndex = 3;
            // 
            // pnSearch
            // 
            pnSearch.Controls.Add(tbxSearch);
            pnSearch.Controls.Add(lblSearch);
            pnSearch.Location = new Point(596, 0);
            pnSearch.Margin = new Padding(2, 3, 2, 3);
            pnSearch.Name = "pnSearch";
            pnSearch.Size = new Size(421, 45);
            pnSearch.TabIndex = 1;
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
            // pnMain
            // 
            pnMain.BackColor = Color.White;
            pnMain.Controls.Add(pnList);
            pnMain.Controls.Add(pnFotter);
            pnMain.Location = new Point(1, 101);
            pnMain.Margin = new Padding(2, 3, 2, 3);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1014, 440);
            pnMain.TabIndex = 6;
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
            // gridView
            // 
            gridView.AllowUserToOrderColumns = true;
            gridView.BorderStyle = BorderStyle.None;
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { Id, Category, Description, Status, Edit, Remove });
            gridView.GridColor = Color.Gray;
            gridView.Location = new Point(5, 3);
            gridView.Margin = new Padding(2, 3, 2, 3);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(1009, 328);
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
            // Category
            // 
            Category.DataPropertyName = "CategoryName";
            Category.HeaderText = "Category";
            Category.MinimumWidth = 6;
            Category.Name = "Category";
            Category.SortMode = DataGridViewColumnSortMode.Programmatic;
            Category.Width = 125;
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            Description.Width = 125;
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
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Resizable = DataGridViewTriState.True;
            Edit.Text = "";
            Edit.UseColumnTextForButtonValue = true;
            Edit.Width = 125;
            // 
            // Remove
            // 
            Remove.HeaderText = "Remove";
            Remove.MinimumWidth = 6;
            Remove.Name = "Remove";
            Remove.Resizable = DataGridViewTriState.True;
            Remove.Text = "";
            Remove.UseColumnTextForButtonValue = true;
            Remove.Width = 125;
            // 
            // pnFotter
            // 
            pnFotter.Controls.Add(lblEntrie);
            pnFotter.Controls.Add(lblOf);
            pnFotter.Controls.Add(lblTo);
            pnFotter.Controls.Add(lblEntries);
            pnFotter.Controls.Add(lblEntriesEnd);
            pnFotter.Controls.Add(lblEntriesStart);
            pnFotter.Controls.Add(pnPage);
            pnFotter.Controls.Add(lblShowing);
            pnFotter.Location = new Point(2, 389);
            pnFotter.Margin = new Padding(2, 3, 2, 3);
            pnFotter.Name = "pnFotter";
            pnFotter.Size = new Size(1010, 47);
            pnFotter.TabIndex = 0;
            // 
            // lblEntrie
            // 
            lblEntrie.AutoSize = true;
            lblEntrie.Location = new Point(263, 14);
            lblEntrie.Name = "lblEntrie";
            lblEntrie.Size = new Size(63, 22);
            lblEntrie.TabIndex = 7;
            lblEntrie.Text = "entries";
            // 
            // lblOf
            // 
            lblOf.AutoSize = true;
            lblOf.Location = new Point(195, 14);
            lblOf.Name = "lblOf";
            lblOf.Size = new Size(26, 22);
            lblOf.TabIndex = 6;
            lblOf.Text = "of";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(125, 14);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 22);
            lblTo.TabIndex = 5;
            lblTo.Text = "to";
            // 
            // lblEntries
            // 
            lblEntries.AutoSize = true;
            lblEntries.Location = new Point(227, 14);
            lblEntries.Name = "lblEntries";
            lblEntries.Size = new Size(30, 22);
            lblEntries.TabIndex = 4;
            lblEntries.Text = "13";
            // 
            // lblEntriesEnd
            // 
            lblEntriesEnd.AutoSize = true;
            lblEntriesEnd.Location = new Point(156, 14);
            lblEntriesEnd.Name = "lblEntriesEnd";
            lblEntriesEnd.Size = new Size(30, 22);
            lblEntriesEnd.TabIndex = 3;
            lblEntriesEnd.Text = "10";
            // 
            // lblEntriesStart
            // 
            lblEntriesStart.AutoSize = true;
            lblEntriesStart.Location = new Point(99, 14);
            lblEntriesStart.Name = "lblEntriesStart";
            lblEntriesStart.Size = new Size(20, 22);
            lblEntriesStart.TabIndex = 2;
            lblEntriesStart.Text = "1";
            // 
            // pnPage
            // 
            pnPage.Controls.Add(labelPageInfo);
            pnPage.Controls.Add(btnNext);
            pnPage.Controls.Add(btnPre);
            pnPage.Location = new Point(645, 3);
            pnPage.Margin = new Padding(2, 3, 2, 3);
            pnPage.Name = "pnPage";
            pnPage.Size = new Size(317, 45);
            pnPage.TabIndex = 1;
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
            // lblShowing
            // 
            lblShowing.AutoSize = true;
            lblShowing.Cursor = Cursors.IBeam;
            lblShowing.Location = new Point(23, 14);
            lblShowing.Margin = new Padding(2, 0, 2, 0);
            lblShowing.Name = "lblShowing";
            lblShowing.Size = new Size(84, 22);
            lblShowing.TabIndex = 0;
            lblShowing.Text = "Showing ";
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.ForeColor = SystemColors.ActiveCaptionText;
            pnLine.Location = new Point(0, 88);
            pnLine.Margin = new Padding(2, 3, 2, 3);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(964, 1);
            pnLine.TabIndex = 5;
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(btnAdd);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(0, -2);
            pnTitle.Margin = new Padding(2, 3, 2, 3);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(1017, 91);
            pnTitle.TabIndex = 4;
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
            btnAdd.Text = "Add Categories";
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
            lblHeader.Margin = new Padding(2, 0, 2, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(207, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Categories List";
            // 
            // CategoryList
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(1015, 551);
            Controls.Add(pnHeader);
            Controls.Add(pnMain);
            Controls.Add(pnLine);
            Controls.Add(pnTitle);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "CategoryList";
            Text = "CategoryList";
            Load += CategoryList_Load;
            pnHeader.ResumeLayout(false);
            pnSearch.ResumeLayout(false);
            pnSearch.PerformLayout();
            pnLeftHeader.ResumeLayout(false);
            pnLeftHeader.PerformLayout();
            pnMain.ResumeLayout(false);
            pnList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            pnFotter.ResumeLayout(false);
            pnFotter.PerformLayout();
            pnPage.ResumeLayout(false);
            pnPage.PerformLayout();
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnHeader;
        private Panel pnSearch;
        private TextBox tbxSearch;
        private Label lblSearch;
        private Panel pnLeftHeader;
        private Label btnEntries;
        private ComboBox cbxShow;
        private Label lblShow;
        private Panel pnMain;
        private Panel pnList;
        private DataGridView gridView;
        private Panel pnFotter;
        private Panel pnPage;
        private MyCustomControl.RJButton btnNext;
        private MyCustomControl.RJButton btnPre;
        private Label lblShowing;
        private Panel pnLine;
        private Panel pnTitle;
        private MyCustomControl.RJButton btnAdd;
        private Label lblHeader;
        private Label lblTo;
        private Label lblEntries;
        private Label lblEntriesEnd;
        private Label lblEntriesStart;
        private Label lblEntrie;
        private Label lblOf;
        private Label labelPageInfo;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Remove;
    }
}