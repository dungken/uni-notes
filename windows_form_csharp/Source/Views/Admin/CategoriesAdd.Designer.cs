namespace Source.Views.Admin
{
    partial class CategoriesAdd
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
            tbxDescription = new TextBox();
            lblDescription = new Label();
            tbxName = new TextBox();
            lblBasic = new Label();
            pnBasicInfor = new Panel();
            lblName = new Label();
            lbxParent = new ListBox();
            label1 = new Label();
            lblCategories = new Label();
            pnParentCategory = new Panel();
            rbtnActive = new RadioButton();
            rbtnInactive = new RadioButton();
            rbtnPending = new RadioButton();
            pnStatus = new Panel();
            lblStatus = new Label();
            pnLine = new Panel();
            btnSave = new MyCustomControl.RJButton();
            lblHeader = new Label();
            pnTitle = new Panel();
            rjButton1 = new MyCustomControl.RJButton();
            pnBasicInfor.SuspendLayout();
            pnParentCategory.SuspendLayout();
            pnStatus.SuspendLayout();
            pnTitle.SuspendLayout();
            SuspendLayout();
            // 
            // tbxDescription
            // 
            tbxDescription.Location = new Point(28, 154);
            tbxDescription.Multiline = true;
            tbxDescription.Name = "tbxDescription";
            tbxDescription.Size = new Size(556, 229);
            tbxDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Cursor = Cursors.IBeam;
            lblDescription.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(26, 118);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(106, 23);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(165, 56);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(419, 30);
            tbxName.TabIndex = 2;
            // 
            // lblBasic
            // 
            lblBasic.AutoSize = true;
            lblBasic.Cursor = Cursors.IBeam;
            lblBasic.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBasic.Location = new Point(19, 14);
            lblBasic.Name = "lblBasic";
            lblBasic.Size = new Size(188, 25);
            lblBasic.TabIndex = 0;
            lblBasic.Text = "Basic information";
            // 
            // pnBasicInfor
            // 
            pnBasicInfor.BackColor = Color.White;
            pnBasicInfor.Controls.Add(tbxDescription);
            pnBasicInfor.Controls.Add(lblDescription);
            pnBasicInfor.Controls.Add(tbxName);
            pnBasicInfor.Controls.Add(lblName);
            pnBasicInfor.Controls.Add(lblBasic);
            pnBasicInfor.Location = new Point(336, 122);
            pnBasicInfor.Name = "pnBasicInfor";
            pnBasicInfor.Size = new Size(676, 400);
            pnBasicInfor.TabIndex = 12;
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
            // lbxParent
            // 
            lbxParent.FormattingEnabled = true;
            lbxParent.ItemHeight = 22;
            lbxParent.Location = new Point(13, 86);
            lbxParent.Name = "lbxParent";
            lbxParent.Size = new Size(277, 70);
            lbxParent.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.IBeam;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 46);
            label1.Name = "label1";
            label1.Size = new Size(203, 23);
            label1.TabIndex = 1;
            label1.Text = "Parent category Select";
            // 
            // lblCategories
            // 
            lblCategories.AutoSize = true;
            lblCategories.Cursor = Cursors.IBeam;
            lblCategories.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategories.Location = new Point(13, 10);
            lblCategories.Name = "lblCategories";
            lblCategories.Size = new Size(119, 25);
            lblCategories.TabIndex = 0;
            lblCategories.Text = "Categories";
            // 
            // pnParentCategory
            // 
            pnParentCategory.BackColor = Color.White;
            pnParentCategory.Controls.Add(lbxParent);
            pnParentCategory.Controls.Add(label1);
            pnParentCategory.Controls.Add(lblCategories);
            pnParentCategory.Location = new Point(12, 319);
            pnParentCategory.Name = "pnParentCategory";
            pnParentCategory.Size = new Size(314, 203);
            pnParentCategory.TabIndex = 11;
            // 
            // rbtnActive
            // 
            rbtnActive.AutoSize = true;
            rbtnActive.Location = new Point(22, 86);
            rbtnActive.Name = "rbtnActive";
            rbtnActive.Size = new Size(84, 26);
            rbtnActive.TabIndex = 3;
            rbtnActive.TabStop = true;
            rbtnActive.Text = "Active";
            rbtnActive.UseVisualStyleBackColor = true;
            // 
            // rbtnInactive
            // 
            rbtnInactive.AutoSize = true;
            rbtnInactive.Location = new Point(22, 132);
            rbtnInactive.Name = "rbtnInactive";
            rbtnInactive.Size = new Size(94, 26);
            rbtnInactive.TabIndex = 2;
            rbtnInactive.TabStop = true;
            rbtnInactive.Text = "Inactive";
            rbtnInactive.UseVisualStyleBackColor = true;
            // 
            // rbtnPending
            // 
            rbtnPending.AutoSize = true;
            rbtnPending.Location = new Point(22, 44);
            rbtnPending.Name = "rbtnPending";
            rbtnPending.Size = new Size(94, 26);
            rbtnPending.TabIndex = 1;
            rbtnPending.TabStop = true;
            rbtnPending.Text = "Pending";
            rbtnPending.UseVisualStyleBackColor = true;
            // 
            // pnStatus
            // 
            pnStatus.BackColor = Color.White;
            pnStatus.Controls.Add(rbtnActive);
            pnStatus.Controls.Add(rbtnInactive);
            pnStatus.Controls.Add(rbtnPending);
            pnStatus.Controls.Add(lblStatus);
            pnStatus.Location = new Point(12, 122);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(314, 178);
            pnStatus.TabIndex = 10;
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
            btnSave.Location = new Point(847, 24);
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
            lblHeader.Size = new Size(210, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Categories Add";
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(rjButton1);
            pnTitle.Controls.Add(pnLine);
            pnTitle.Controls.Add(btnSave);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(0, 16);
            pnTitle.Margin = new Padding(2, 3, 2, 3);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(1012, 91);
            pnTitle.TabIndex = 9;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Red;
            rjButton1.BackgroundColor = Color.Red;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.Cursor = Cursors.Hand;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(706, 24);
            rjButton1.Margin = new Padding(2, 3, 2, 3);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(128, 50);
            rjButton1.TabIndex = 7;
            rjButton1.Text = "Cancel";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // CategoriesAdd
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(1015, 551);
            Controls.Add(pnBasicInfor);
            Controls.Add(pnParentCategory);
            Controls.Add(pnStatus);
            Controls.Add(pnTitle);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "CategoriesAdd";
            Text = "CategoryAdd";
            Load += CategoriesAdd_Load;
            pnBasicInfor.ResumeLayout(false);
            pnBasicInfor.PerformLayout();
            pnParentCategory.ResumeLayout(false);
            pnParentCategory.PerformLayout();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbxDescription;
        private Label lblDescription;
        private TextBox tbxName;
        private Label lblBasic;
        private Panel pnBasicInfor;
        private Label lblName;
        private ListBox lbxParent;
        private Label label1;
        private Label lblCategories;
        private Panel pnParentCategory;
        private RadioButton rbtnActive;
        private RadioButton rbtnInactive;
        private RadioButton rbtnPending;
        private Panel pnStatus;
        private Label lblStatus;
        private Panel pnLine;
        private MyCustomControl.RJButton btnSave;
        private Label lblHeader;
        private Panel pnTitle;
        private MyCustomControl.RJButton rjButton1;
    }
}