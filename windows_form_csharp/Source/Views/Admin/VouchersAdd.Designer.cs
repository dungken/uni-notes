namespace Source.Views.Admin
{
    partial class VouchersAdd
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
            lblAmount = new Label();
            tbxCode = new TextBox();
            tbxLimit = new TextBox();
            lblCode = new Label();
            pnLine = new Panel();
            btnSave = new MyCustomControl.RJButton();
            pnTitle = new Panel();
            lblHeader = new Label();
            lblLimit = new Label();
            pnDateSchedule = new Panel();
            lblDateSchedule = new Label();
            pnInformation = new Panel();
            tbxMinOrder = new TextBox();
            tbxAmount = new TextBox();
            lblMinOrder = new Label();
            lblBasic = new Label();
            dateStart = new DateTimePicker();
            lblStart = new Label();
            lblEnd = new Label();
            dateEnd = new DateTimePicker();
            pnTitle.SuspendLayout();
            pnDateSchedule.SuspendLayout();
            pnInformation.SuspendLayout();
            SuspendLayout();
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Cursor = Cursors.IBeam;
            lblAmount.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmount.Location = new Point(12, 183);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(153, 23);
            lblAmount.TabIndex = 7;
            lblAmount.Text = "Discount Amount";
            // 
            // tbxCode
            // 
            tbxCode.Location = new Point(168, 55);
            tbxCode.Name = "tbxCode";
            tbxCode.Size = new Size(166, 30);
            tbxCode.TabIndex = 6;
            // 
            // tbxLimit
            // 
            tbxLimit.Location = new Point(171, 238);
            tbxLimit.Name = "tbxLimit";
            tbxLimit.Size = new Size(166, 30);
            tbxLimit.TabIndex = 5;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Cursor = Cursors.IBeam;
            lblCode.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCode.Location = new Point(93, 57);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(54, 23);
            lblCode.TabIndex = 4;
            lblCode.Text = "Code";
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
            btnSave.Location = new Point(567, 24);
            btnSave.Margin = new Padding(2, 3, 2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(pnLine);
            pnTitle.Controls.Add(btnSave);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(0, 16);
            pnTitle.Margin = new Padding(2, 3, 2, 3);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(705, 91);
            pnTitle.TabIndex = 13;
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
            lblHeader.Text = "Vouchers Add";
            // 
            // lblLimit
            // 
            lblLimit.AutoSize = true;
            lblLimit.Cursor = Cursors.IBeam;
            lblLimit.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLimit.Location = new Point(92, 238);
            lblLimit.Name = "lblLimit";
            lblLimit.Size = new Size(55, 23);
            lblLimit.TabIndex = 3;
            lblLimit.Text = "Limit";
            // 
            // pnDateSchedule
            // 
            pnDateSchedule.BackColor = Color.White;
            pnDateSchedule.Controls.Add(lblEnd);
            pnDateSchedule.Controls.Add(dateEnd);
            pnDateSchedule.Controls.Add(lblStart);
            pnDateSchedule.Controls.Add(dateStart);
            pnDateSchedule.Controls.Add(lblDateSchedule);
            pnDateSchedule.Location = new Point(391, 122);
            pnDateSchedule.Name = "pnDateSchedule";
            pnDateSchedule.Size = new Size(314, 304);
            pnDateSchedule.TabIndex = 15;
            // 
            // lblDateSchedule
            // 
            lblDateSchedule.AutoSize = true;
            lblDateSchedule.Cursor = Cursors.IBeam;
            lblDateSchedule.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateSchedule.Location = new Point(13, 10);
            lblDateSchedule.Name = "lblDateSchedule";
            lblDateSchedule.Size = new Size(156, 25);
            lblDateSchedule.TabIndex = 0;
            lblDateSchedule.Text = "Date Schedule";
            // 
            // pnInformation
            // 
            pnInformation.BackColor = Color.White;
            pnInformation.Controls.Add(tbxMinOrder);
            pnInformation.Controls.Add(tbxAmount);
            pnInformation.Controls.Add(lblAmount);
            pnInformation.Controls.Add(tbxCode);
            pnInformation.Controls.Add(tbxLimit);
            pnInformation.Controls.Add(lblCode);
            pnInformation.Controls.Add(lblLimit);
            pnInformation.Controls.Add(lblMinOrder);
            pnInformation.Controls.Add(lblBasic);
            pnInformation.Location = new Point(23, 122);
            pnInformation.Name = "pnInformation";
            pnInformation.Size = new Size(353, 304);
            pnInformation.TabIndex = 16;
            // 
            // tbxMinOrder
            // 
            tbxMinOrder.Location = new Point(168, 117);
            tbxMinOrder.Name = "tbxMinOrder";
            tbxMinOrder.Size = new Size(166, 30);
            tbxMinOrder.TabIndex = 16;
            // 
            // tbxAmount
            // 
            tbxAmount.Location = new Point(171, 181);
            tbxAmount.Name = "tbxAmount";
            tbxAmount.Size = new Size(166, 30);
            tbxAmount.TabIndex = 15;
            // 
            // lblMinOrder
            // 
            lblMinOrder.AutoSize = true;
            lblMinOrder.Cursor = Cursors.IBeam;
            lblMinOrder.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMinOrder.Location = new Point(47, 120);
            lblMinOrder.Name = "lblMinOrder";
            lblMinOrder.Size = new Size(100, 23);
            lblMinOrder.TabIndex = 1;
            lblMinOrder.Text = "Min Order";
            // 
            // lblBasic
            // 
            lblBasic.AutoSize = true;
            lblBasic.Cursor = Cursors.IBeam;
            lblBasic.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBasic.Location = new Point(19, 14);
            lblBasic.Name = "lblBasic";
            lblBasic.Size = new Size(219, 25);
            lblBasic.TabIndex = 0;
            lblBasic.Text = "Voucher information";
            // 
            // dateStart
            // 
            dateStart.Location = new Point(13, 102);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(250, 30);
            dateStart.TabIndex = 1;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Cursor = Cursors.IBeam;
            lblStart.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStart.Location = new Point(13, 57);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(99, 23);
            lblStart.TabIndex = 5;
            lblStart.Text = "Start Date";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Cursor = Cursors.IBeam;
            lblEnd.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnd.Location = new Point(13, 162);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(89, 23);
            lblEnd.TabIndex = 7;
            lblEnd.Text = "End Date";
            // 
            // dateEnd
            // 
            dateEnd.Location = new Point(13, 207);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(250, 30);
            dateEnd.TabIndex = 6;
            // 
            // VouchersAdd
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(724, 438);
            Controls.Add(pnTitle);
            Controls.Add(pnDateSchedule);
            Controls.Add(pnInformation);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "VouchersAdd";
            Text = "CouponsAdd";
            Load += VouchersAdd_Load;
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            pnDateSchedule.ResumeLayout(false);
            pnDateSchedule.PerformLayout();
            pnInformation.ResumeLayout(false);
            pnInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimeStart;
        private RadioButton rbtnInactive;
        private RadioButton rbtnPending;
        private Panel pnStatus;
        private RadioButton rbtnActive;
        private Label lblStatus;
        private TextBox tbxValue;
        private Label lblValue;
        private RadioButton rbtnFixedAmount;
        private RadioButton rbtnPercentage;
        private RadioButton rbtnFree;
        private Label lblCouponType;
        private ComboBox cbxProduct;
        private Label lblAmount;
        private TextBox tbxCode;
        private TextBox tbxLimit;
        private Label lblCode;
        private Panel pnLine;
        private MyCustomControl.RJButton btnSave;
        private Panel pnTitle;
        private Label lblHeader;
        private Label lblLimit;
        private DateTimePicker dateTimeEnd;
        private Panel pnDateSchedule;
        private Label lblEnd;
        private Label lblDateSchedule;
        private Panel pnInformation;
        private TextBox tbxName;
        private Label lblMinOrder;
        private Label lblBasic;
        private TextBox tbxAmount;
        private TextBox tbxMinOrder;
        private DateTimePicker dateEnd;
        private Label lblStart;
        private DateTimePicker dateStart;
    }
}