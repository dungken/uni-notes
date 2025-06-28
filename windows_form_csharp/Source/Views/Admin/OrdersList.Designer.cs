namespace Source.Views.Admin
{
    partial class OrdersList
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
            rjButton1 = new MyCustomControl.RJButton();
            rjButton2 = new MyCustomControl.RJButton();
            gridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            Detail = new DataGridViewButtonColumn();
            pnList = new Panel();
            pnMain = new Panel();
            pnHeader = new Panel();
            pnSearch = new Panel();
            tbxSearch = new TextBox();
            lblSearch = new Label();
            pnLeftHeader = new Panel();
            btnEntries = new Label();
            cbxShow = new ComboBox();
            lblShow = new Label();
            pnTitle.SuspendLayout();
            pnFotter.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            pnList.SuspendLayout();
            pnMain.SuspendLayout();
            pnHeader.SuspendLayout();
            pnSearch.SuspendLayout();
            pnLeftHeader.SuspendLayout();
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
            lblHeader.Size = new Size(162, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Orders List";
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
            panel1.Controls.Add(rjButton1);
            panel1.Controls.Add(rjButton2);
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
            rjButton1.Location = new Point(213, 1);
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
            rjButton2.Location = new Point(2, 1);
            rjButton2.Margin = new Padding(2, 3, 2, 3);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(108, 42);
            rjButton2.TabIndex = 0;
            rjButton2.Text = "Previous";
            rjButton2.TextColor = Color.MediumSlateBlue;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // gridView
            // 
            gridView.BorderStyle = BorderStyle.None;
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { Id, CustomerName, Date, Status, TotalAmount, Edit, Detail });
            gridView.GridColor = Color.Gray;
            gridView.Location = new Point(5, 3);
            gridView.Margin = new Padding(2, 3, 2, 3);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(953, 328);
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
            // CustomerName
            // 
            CustomerName.DataPropertyName = "CustomerName";
            CustomerName.HeaderText = "Customer";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            CustomerName.SortMode = DataGridViewColumnSortMode.Programmatic;
            CustomerName.Width = 125;
            // 
            // Date
            // 
            Date.DataPropertyName = "OrderDate";
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.SortMode = DataGridViewColumnSortMode.Programmatic;
            Date.Width = 125;
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
            // TotalAmount
            // 
            TotalAmount.DataPropertyName = "TotalAmount";
            TotalAmount.HeaderText = "Total Amount";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            TotalAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            TotalAmount.Width = 125;
            // 
            // Edit
            // 
            Edit.DataPropertyName = "Edit";
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Resizable = DataGridViewTriState.True;
            Edit.UseColumnTextForButtonValue = true;
            Edit.Width = 125;
            // 
            // Detail
            // 
            Detail.HeaderText = "Detail";
            Detail.MinimumWidth = 6;
            Detail.Name = "Detail";
            Detail.Resizable = DataGridViewTriState.True;
            Detail.UseColumnTextForButtonValue = true;
            Detail.Width = 125;
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
            pnMain.Controls.Add(pnHeader);
            pnMain.Controls.Add(pnList);
            pnMain.Controls.Add(pnFotter);
            pnMain.Location = new Point(1, 101);
            pnMain.Margin = new Padding(2, 3, 2, 3);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(963, 440);
            pnMain.TabIndex = 10;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.White;
            pnHeader.Controls.Add(pnSearch);
            pnHeader.Controls.Add(pnLeftHeader);
            pnHeader.Location = new Point(0, 0);
            pnHeader.Margin = new Padding(2, 3, 2, 3);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(963, 47);
            pnHeader.TabIndex = 7;
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
            // OrdersList
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(1015, 551);
            Controls.Add(pnLine);
            Controls.Add(pnTitle);
            Controls.Add(pnMain);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrdersList";
            Text = "OrdersList";
            Load += OrdersList_Load;
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            pnFotter.ResumeLayout(false);
            pnFotter.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            pnList.ResumeLayout(false);
            pnMain.ResumeLayout(false);
            pnHeader.ResumeLayout(false);
            pnSearch.ResumeLayout(false);
            pnSearch.PerformLayout();
            pnLeftHeader.ResumeLayout(false);
            pnLeftHeader.PerformLayout();
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
        private MyCustomControl.RJButton rjButton1;
        private MyCustomControl.RJButton rjButton2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Detail;
    }
}