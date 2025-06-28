namespace Source.Views.Admin
{
    partial class ProductEdit
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
            rbtnActive = new RadioButton();
            rbtnPending = new RadioButton();
            lblStatus = new Label();
            cbxXL = new CheckBox();
            cbxL = new CheckBox();
            cbxM = new CheckBox();
            cbxS = new CheckBox();
            rbtnInactive = new RadioButton();
            cbxXS = new CheckBox();
            colorDialog = new ColorDialog();
            lbxColor = new ListBox();
            pnCategory = new Panel();
            lbxCategory = new ListBox();
            lblCategories = new Label();
            pnColor = new Panel();
            btnPickColor = new MyCustomControl.RJButton();
            lblColor = new Label();
            lblSelectSize = new Label();
            pnSize = new Panel();
            pnStatus = new Panel();
            pnLine = new Panel();
            btnSave = new MyCustomControl.RJButton();
            lblHeader = new Label();
            lblStock = new Label();
            lblPrice = new Label();
            tbxPrice = new TextBox();
            pnBasicInfor = new Panel();
            rbtnDeleteImg = new MyCustomControl.RJButton();
            flowLayoutPanel = new FlowLayoutPanel();
            btnPickImg = new MyCustomControl.RJButton();
            numeric = new NumericUpDown();
            tbxDescription = new TextBox();
            lblDescription = new Label();
            tbxName = new TextBox();
            lblName = new Label();
            label1 = new Label();
            pnTitle = new Panel();
            lbxDiscount = new ListBox();
            lblDiscount = new Label();
            pnCategory.SuspendLayout();
            pnColor.SuspendLayout();
            pnSize.SuspendLayout();
            pnStatus.SuspendLayout();
            pnBasicInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numeric).BeginInit();
            pnTitle.SuspendLayout();
            SuspendLayout();
            // 
            // rbtnActive
            // 
            rbtnActive.AutoSize = true;
            rbtnActive.Location = new Point(104, 44);
            rbtnActive.Name = "rbtnActive";
            rbtnActive.Size = new Size(84, 26);
            rbtnActive.TabIndex = 3;
            rbtnActive.TabStop = true;
            rbtnActive.Text = "Active";
            rbtnActive.UseVisualStyleBackColor = true;
            // 
            // rbtnPending
            // 
            rbtnPending.AutoSize = true;
            rbtnPending.Location = new Point(4, 44);
            rbtnPending.Name = "rbtnPending";
            rbtnPending.Size = new Size(94, 26);
            rbtnPending.TabIndex = 1;
            rbtnPending.TabStop = true;
            rbtnPending.Text = "Pending";
            rbtnPending.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Cursor = Cursors.IBeam;
            lblStatus.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(13, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(162, 25);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Visibility Status";
            // 
            // cbxXL
            // 
            cbxXL.AutoSize = true;
            cbxXL.Location = new Point(231, 40);
            cbxXL.Name = "cbxXL";
            cbxXL.Size = new Size(57, 26);
            cbxXL.TabIndex = 5;
            cbxXL.Text = "XL";
            cbxXL.UseVisualStyleBackColor = true;
            // 
            // cbxL
            // 
            cbxL.AutoSize = true;
            cbxL.Location = new Point(178, 40);
            cbxL.Name = "cbxL";
            cbxL.Size = new Size(43, 26);
            cbxL.TabIndex = 4;
            cbxL.Text = "L";
            cbxL.UseVisualStyleBackColor = true;
            // 
            // cbxM
            // 
            cbxM.AutoSize = true;
            cbxM.Location = new Point(123, 40);
            cbxM.Name = "cbxM";
            cbxM.Size = new Size(49, 26);
            cbxM.TabIndex = 3;
            cbxM.Text = "M";
            cbxM.UseVisualStyleBackColor = true;
            // 
            // cbxS
            // 
            cbxS.AutoSize = true;
            cbxS.Location = new Point(74, 40);
            cbxS.Name = "cbxS";
            cbxS.Size = new Size(43, 26);
            cbxS.TabIndex = 2;
            cbxS.Text = "S";
            cbxS.UseVisualStyleBackColor = true;
            // 
            // rbtnInactive
            // 
            rbtnInactive.AutoSize = true;
            rbtnInactive.Location = new Point(194, 44);
            rbtnInactive.Name = "rbtnInactive";
            rbtnInactive.Size = new Size(94, 26);
            rbtnInactive.TabIndex = 2;
            rbtnInactive.TabStop = true;
            rbtnInactive.Text = "Inactive";
            rbtnInactive.UseVisualStyleBackColor = true;
            // 
            // cbxXS
            // 
            cbxXS.AutoSize = true;
            cbxXS.Location = new Point(13, 40);
            cbxXS.Name = "cbxXS";
            cbxXS.Size = new Size(57, 26);
            cbxXS.TabIndex = 1;
            cbxXS.Text = "XS";
            cbxXS.UseVisualStyleBackColor = true;
            // 
            // lbxColor
            // 
            lbxColor.FormattingEnabled = true;
            lbxColor.ItemHeight = 22;
            lbxColor.Location = new Point(17, 46);
            lbxColor.Name = "lbxColor";
            lbxColor.Size = new Size(280, 70);
            lbxColor.TabIndex = 9;
            lbxColor.DrawItem += lbxColor_DrawItem;
            // 
            // pnCategory
            // 
            pnCategory.BackColor = Color.White;
            pnCategory.Controls.Add(lbxCategory);
            pnCategory.Controls.Add(lblCategories);
            pnCategory.Location = new Point(14, 196);
            pnCategory.Name = "pnCategory";
            pnCategory.Size = new Size(321, 124);
            pnCategory.TabIndex = 29;
            // 
            // lbxCategory
            // 
            lbxCategory.FormattingEnabled = true;
            lbxCategory.ItemHeight = 22;
            lbxCategory.Location = new Point(15, 41);
            lbxCategory.Name = "lbxCategory";
            lbxCategory.Size = new Size(277, 70);
            lbxCategory.TabIndex = 2;
            // 
            // lblCategories
            // 
            lblCategories.AutoSize = true;
            lblCategories.Cursor = Cursors.IBeam;
            lblCategories.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategories.Location = new Point(13, 10);
            lblCategories.Name = "lblCategories";
            lblCategories.Size = new Size(119, 25);
            lblCategories.TabIndex = 0;
            lblCategories.Text = "Categories";
            // 
            // pnColor
            // 
            pnColor.BackColor = Color.White;
            pnColor.Controls.Add(btnPickColor);
            pnColor.Controls.Add(lbxColor);
            pnColor.Controls.Add(lblColor);
            pnColor.Location = new Point(12, 411);
            pnColor.Name = "pnColor";
            pnColor.Size = new Size(322, 120);
            pnColor.TabIndex = 30;
            // 
            // btnPickColor
            // 
            btnPickColor.BackColor = Color.MediumSlateBlue;
            btnPickColor.BackgroundColor = Color.MediumSlateBlue;
            btnPickColor.BorderColor = Color.PaleVioletRed;
            btnPickColor.BorderRadius = 20;
            btnPickColor.BorderSize = 0;
            btnPickColor.Cursor = Cursors.Hand;
            btnPickColor.FlatAppearance.BorderSize = 0;
            btnPickColor.FlatStyle = FlatStyle.Flat;
            btnPickColor.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPickColor.ForeColor = Color.White;
            btnPickColor.Location = new Point(169, 3);
            btnPickColor.Margin = new Padding(2, 3, 2, 3);
            btnPickColor.Name = "btnPickColor";
            btnPickColor.Size = new Size(128, 37);
            btnPickColor.TabIndex = 7;
            btnPickColor.Text = "Pick Color";
            btnPickColor.TextColor = Color.White;
            btnPickColor.UseVisualStyleBackColor = false;
            btnPickColor.Click += btnPickColor_Click;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Cursor = Cursors.IBeam;
            lblColor.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblColor.Location = new Point(14, 9);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(68, 25);
            lblColor.TabIndex = 1;
            lblColor.Text = "Color";
            // 
            // lblSelectSize
            // 
            lblSelectSize.AutoSize = true;
            lblSelectSize.Cursor = Cursors.IBeam;
            lblSelectSize.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectSize.Location = new Point(13, 12);
            lblSelectSize.Name = "lblSelectSize";
            lblSelectSize.Size = new Size(115, 25);
            lblSelectSize.TabIndex = 0;
            lblSelectSize.Text = "Select Size";
            // 
            // pnSize
            // 
            pnSize.BackColor = Color.White;
            pnSize.Controls.Add(cbxXL);
            pnSize.Controls.Add(cbxL);
            pnSize.Controls.Add(cbxM);
            pnSize.Controls.Add(cbxS);
            pnSize.Controls.Add(cbxXS);
            pnSize.Controls.Add(lblSelectSize);
            pnSize.Location = new Point(13, 326);
            pnSize.Name = "pnSize";
            pnSize.Size = new Size(321, 79);
            pnSize.TabIndex = 28;
            // 
            // pnStatus
            // 
            pnStatus.BackColor = Color.White;
            pnStatus.Controls.Add(rbtnActive);
            pnStatus.Controls.Add(rbtnInactive);
            pnStatus.Controls.Add(rbtnPending);
            pnStatus.Controls.Add(lblStatus);
            pnStatus.Location = new Point(14, 100);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(321, 90);
            pnStatus.TabIndex = 27;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.ForeColor = SystemColors.ActiveCaptionText;
            pnLine.Location = new Point(12, 90);
            pnLine.Margin = new Padding(2, 3, 2, 3);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(940, 10);
            pnLine.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.MediumSlateBlue;
            btnSave.BackgroundColor = Color.MediumSlateBlue;
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 20;
            btnSave.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(803, 24);
            btnSave.Margin = new Padding(2, 3, 2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Cursor = Cursors.IBeam;
            lblHeader.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(23, 27);
            lblHeader.Margin = new Padding(2, 0, 2, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(191, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Products Edit";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Cursor = Cursors.IBeam;
            lblStock.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(337, 214);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(63, 23);
            lblStock.TabIndex = 1;
            lblStock.Text = "Stock ";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Cursor = Cursors.IBeam;
            lblPrice.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(26, 209);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 23);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // tbxPrice
            // 
            tbxPrice.Location = new Point(102, 207);
            tbxPrice.Name = "tbxPrice";
            tbxPrice.Size = new Size(166, 30);
            tbxPrice.TabIndex = 6;
            // 
            // pnBasicInfor
            // 
            pnBasicInfor.BackColor = Color.White;
            pnBasicInfor.Controls.Add(lbxDiscount);
            pnBasicInfor.Controls.Add(lblDiscount);
            pnBasicInfor.Controls.Add(rbtnDeleteImg);
            pnBasicInfor.Controls.Add(flowLayoutPanel);
            pnBasicInfor.Controls.Add(btnPickImg);
            pnBasicInfor.Controls.Add(numeric);
            pnBasicInfor.Controls.Add(tbxDescription);
            pnBasicInfor.Controls.Add(lblStock);
            pnBasicInfor.Controls.Add(lblPrice);
            pnBasicInfor.Controls.Add(tbxPrice);
            pnBasicInfor.Controls.Add(lblDescription);
            pnBasicInfor.Controls.Add(tbxName);
            pnBasicInfor.Controls.Add(lblName);
            pnBasicInfor.Controls.Add(label1);
            pnBasicInfor.Location = new Point(342, 100);
            pnBasicInfor.Name = "pnBasicInfor";
            pnBasicInfor.Size = new Size(616, 431);
            pnBasicInfor.TabIndex = 26;
            // 
            // rbtnDeleteImg
            // 
            rbtnDeleteImg.BackColor = Color.MediumSlateBlue;
            rbtnDeleteImg.BackgroundColor = Color.MediumSlateBlue;
            rbtnDeleteImg.BorderColor = Color.PaleVioletRed;
            rbtnDeleteImg.BorderRadius = 20;
            rbtnDeleteImg.BorderSize = 0;
            rbtnDeleteImg.Cursor = Cursors.Hand;
            rbtnDeleteImg.FlatAppearance.BorderSize = 0;
            rbtnDeleteImg.FlatStyle = FlatStyle.Flat;
            rbtnDeleteImg.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnDeleteImg.ForeColor = Color.White;
            rbtnDeleteImg.Location = new Point(272, 255);
            rbtnDeleteImg.Margin = new Padding(2, 3, 2, 3);
            rbtnDeleteImg.Name = "rbtnDeleteImg";
            rbtnDeleteImg.Size = new Size(128, 37);
            rbtnDeleteImg.TabIndex = 11;
            rbtnDeleteImg.Text = "Delete Image";
            rbtnDeleteImg.TextColor = Color.White;
            rbtnDeleteImg.UseVisualStyleBackColor = false;
            rbtnDeleteImg.Click += rbtnDeleteImg_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(28, 298);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(567, 125);
            flowLayoutPanel.TabIndex = 10;
            // 
            // btnPickImg
            // 
            btnPickImg.BackColor = Color.MediumSlateBlue;
            btnPickImg.BackgroundColor = Color.MediumSlateBlue;
            btnPickImg.BorderColor = Color.PaleVioletRed;
            btnPickImg.BorderRadius = 20;
            btnPickImg.BorderSize = 0;
            btnPickImg.Cursor = Cursors.Hand;
            btnPickImg.FlatAppearance.BorderSize = 0;
            btnPickImg.FlatStyle = FlatStyle.Flat;
            btnPickImg.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPickImg.ForeColor = Color.White;
            btnPickImg.Location = new Point(28, 255);
            btnPickImg.Margin = new Padding(2, 3, 2, 3);
            btnPickImg.Name = "btnPickImg";
            btnPickImg.Size = new Size(128, 37);
            btnPickImg.TabIndex = 8;
            btnPickImg.Text = "Upload Image";
            btnPickImg.TextColor = Color.White;
            btnPickImg.UseVisualStyleBackColor = false;
            btnPickImg.Click += btnPickImg_Click;
            // 
            // numeric
            // 
            numeric.Location = new Point(420, 214);
            numeric.Name = "numeric";
            numeric.Size = new Size(150, 30);
            numeric.TabIndex = 7;
            // 
            // tbxDescription
            // 
            tbxDescription.Location = new Point(28, 137);
            tbxDescription.Multiline = true;
            tbxDescription.Name = "tbxDescription";
            tbxDescription.Size = new Size(354, 49);
            tbxDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Cursor = Cursors.IBeam;
            lblDescription.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(26, 106);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(106, 23);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(165, 56);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(217, 30);
            tbxName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Cursor = Cursors.IBeam;
            lblName.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(26, 58);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 23);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.IBeam;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 14);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 0;
            label1.Text = "Basic information";
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(pnLine);
            pnTitle.Controls.Add(btnSave);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(6, 7);
            pnTitle.Margin = new Padding(2, 3, 2, 3);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(951, 91);
            pnTitle.TabIndex = 25;
            // 
            // lbxDiscount
            // 
            lbxDiscount.FormattingEnabled = true;
            lbxDiscount.ItemHeight = 22;
            lbxDiscount.Location = new Point(391, 96);
            lbxDiscount.Name = "lbxDiscount";
            lbxDiscount.Size = new Size(222, 92);
            lbxDiscount.TabIndex = 14;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Cursor = Cursors.IBeam;
            lblDiscount.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiscount.Location = new Point(391, 58);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(83, 23);
            lblDiscount.TabIndex = 13;
            lblDiscount.Text = "Discount";
            // 
            // ProductEdit
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(964, 538);
            Controls.Add(pnCategory);
            Controls.Add(pnColor);
            Controls.Add(pnSize);
            Controls.Add(pnStatus);
            Controls.Add(pnBasicInfor);
            Controls.Add(pnTitle);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductEdit";
            Text = "ProductEdit";
            Load += ProductEdit_Load;
            pnCategory.ResumeLayout(false);
            pnCategory.PerformLayout();
            pnColor.ResumeLayout(false);
            pnColor.PerformLayout();
            pnSize.ResumeLayout(false);
            pnSize.PerformLayout();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            pnBasicInfor.ResumeLayout(false);
            pnBasicInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numeric).EndInit();
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton rbtnActive;
        private RadioButton rbtnPending;
        private Label lblStatus;
        private CheckBox cbxXL;
        private CheckBox cbxL;
        private CheckBox cbxM;
        private CheckBox cbxS;
        private RadioButton rbtnInactive;
        private CheckBox cbxXS;
        private ColorDialog colorDialog;
        private ListBox lbxColor;
        private Panel pnCategory;
        private ListBox lbxCategory;
        private Label lblCategories;
        private Panel pnColor;
        private MyCustomControl.RJButton btnPickColor;
        private Label lblColor;
        private Label lblSelectSize;
        private Panel pnSize;
        private Panel pnStatus;
        private Panel pnLine;
        private MyCustomControl.RJButton btnSave;
        private Label lblHeader;
        private Label lblStock;
        private Label lblPrice;
        private TextBox tbxPrice;
        private Panel pnBasicInfor;
        private FlowLayoutPanel flowLayoutPanel;
        private MyCustomControl.RJButton btnPickImg;
        private NumericUpDown numeric;
        private TextBox tbxDescription;
        private Label lblDescription;
        private TextBox tbxName;
        private Label lblName;
        private Label label1;
        private Panel pnTitle;
        private MyCustomControl.RJButton rbtnDeleteImg;
        private ListBox lbxDiscount;
        private Label lblDiscount;
    }
}