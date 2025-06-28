namespace Source.Views.Custommer
{
    partial class Refund
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
            lblStatus = new Label();
            pnTop = new Panel();
            lblCurrentPrice = new Label();
            lblOldPrice = new Label();
            pnImage = new Panel();
            imageProduct = new PictureBox();
            lblQuantity = new Label();
            lblColorSize = new Label();
            lblNameProduct = new Label();
            lblHeader1 = new Label();
            pnProduct = new Panel();
            pnDescription = new Panel();
            lblCountTezt = new Label();
            tbxDescription = new TextBox();
            cbxReason = new ComboBox();
            label1 = new Label();
            lblLyDo = new Label();
            lblHeader2 = new Label();
            pnInfor = new Panel();
            btnDone = new Button();
            label3 = new Label();
            lblNhanDuoc = new Label();
            lblRefundableAmount = new Label();
            pnLine = new Panel();
            lblCoThe = new Label();
            cbxRefund = new ComboBox();
            lblRefundAmout = new Label();
            label2 = new Label();
            lblHoanVao = new Label();
            lblHoanLai = new Label();
            lblHeader3 = new Label();
            pnTop.SuspendLayout();
            pnImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageProduct).BeginInit();
            pnProduct.SuspendLayout();
            pnDescription.SuspendLayout();
            pnInfor.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Cursor = Cursors.IBeam;
            lblStatus.ForeColor = Color.SeaGreen;
            lblStatus.Location = new Point(155, 56);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(72, 22);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Đã giao";
            lblStatus.Click += lblStatus_Click;
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.White;
            pnTop.Controls.Add(lblCurrentPrice);
            pnTop.Controls.Add(lblOldPrice);
            pnTop.Controls.Add(pnImage);
            pnTop.Controls.Add(lblStatus);
            pnTop.Controls.Add(lblQuantity);
            pnTop.Controls.Add(lblColorSize);
            pnTop.Controls.Add(lblNameProduct);
            pnTop.Cursor = Cursors.Hand;
            pnTop.Location = new Point(0, 38);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(946, 83);
            pnTop.TabIndex = 0;
            // 
            // lblCurrentPrice
            // 
            lblCurrentPrice.AutoSize = true;
            lblCurrentPrice.ForeColor = SystemColors.ControlDarkDark;
            lblCurrentPrice.Location = new Point(844, 56);
            lblCurrentPrice.Name = "lblCurrentPrice";
            lblCurrentPrice.Size = new Size(65, 22);
            lblCurrentPrice.TabIndex = 8;
            lblCurrentPrice.Text = "160.00";
            // 
            // lblOldPrice
            // 
            lblOldPrice.AutoSize = true;
            lblOldPrice.Font = new Font("Times New Roman", 12F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
            lblOldPrice.ForeColor = SystemColors.ControlDarkDark;
            lblOldPrice.Location = new Point(773, 56);
            lblOldPrice.Name = "lblOldPrice";
            lblOldPrice.Size = new Size(65, 22);
            lblOldPrice.TabIndex = 7;
            lblOldPrice.Text = "198.54";
            // 
            // pnImage
            // 
            pnImage.Controls.Add(imageProduct);
            pnImage.Dock = DockStyle.Left;
            pnImage.Location = new Point(0, 0);
            pnImage.Name = "pnImage";
            pnImage.Size = new Size(149, 83);
            pnImage.TabIndex = 6;
            // 
            // imageProduct
            // 
            imageProduct.Dock = DockStyle.Fill;
            imageProduct.Image = Properties.Resources.capybara3;
            imageProduct.Location = new Point(0, 0);
            imageProduct.Name = "imageProduct";
            imageProduct.Size = new Size(149, 83);
            imageProduct.SizeMode = PictureBoxSizeMode.Zoom;
            imageProduct.TabIndex = 0;
            imageProduct.TabStop = false;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(880, 24);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(29, 22);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "x1";
            // 
            // lblColorSize
            // 
            lblColorSize.AutoSize = true;
            lblColorSize.ForeColor = SystemColors.ControlDarkDark;
            lblColorSize.Location = new Point(155, 34);
            lblColorSize.Name = "lblColorSize";
            lblColorSize.Size = new Size(55, 22);
            lblColorSize.TabIndex = 3;
            lblColorSize.Text = "Đỏ, L";
            // 
            // lblNameProduct
            // 
            lblNameProduct.AutoSize = true;
            lblNameProduct.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameProduct.Location = new Point(155, 9);
            lblNameProduct.Name = "lblNameProduct";
            lblNameProduct.Size = new Size(260, 25);
            lblNameProduct.TabIndex = 1;
            lblNameProduct.Text = "Khăn lau mặt dùng 1 lần";
            // 
            // lblHeader1
            // 
            lblHeader1.AutoSize = true;
            lblHeader1.Cursor = Cursors.IBeam;
            lblHeader1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader1.Location = new Point(3, 3);
            lblHeader1.Name = "lblHeader1";
            lblHeader1.Size = new Size(235, 32);
            lblHeader1.TabIndex = 1;
            lblHeader1.Text = "Đơn hàng đã chọn";
            // 
            // pnProduct
            // 
            pnProduct.BackColor = Color.White;
            pnProduct.Controls.Add(lblHeader1);
            pnProduct.Controls.Add(pnTop);
            pnProduct.Location = new Point(2, 0);
            pnProduct.Name = "pnProduct";
            pnProduct.Size = new Size(946, 124);
            pnProduct.TabIndex = 3;
            // 
            // pnDescription
            // 
            pnDescription.BackColor = Color.White;
            pnDescription.Controls.Add(lblCountTezt);
            pnDescription.Controls.Add(tbxDescription);
            pnDescription.Controls.Add(cbxReason);
            pnDescription.Controls.Add(label1);
            pnDescription.Controls.Add(lblLyDo);
            pnDescription.Controls.Add(lblHeader2);
            pnDescription.Location = new Point(2, 130);
            pnDescription.Name = "pnDescription";
            pnDescription.Size = new Size(946, 189);
            pnDescription.TabIndex = 4;
            // 
            // lblCountTezt
            // 
            lblCountTezt.AutoSize = true;
            lblCountTezt.ForeColor = SystemColors.ControlDarkDark;
            lblCountTezt.Location = new Point(619, 156);
            lblCountTezt.Name = "lblCountTezt";
            lblCountTezt.Size = new Size(66, 22);
            lblCountTezt.TabIndex = 6;
            lblCountTezt.Text = "0/2000";
            lblCountTezt.Click += label2_Click;
            // 
            // tbxDescription
            // 
            tbxDescription.Cursor = Cursors.IBeam;
            tbxDescription.Location = new Point(106, 81);
            tbxDescription.Multiline = true;
            tbxDescription.Name = "tbxDescription";
            tbxDescription.PlaceholderText = "Chi tiết vấn đề bạn gặp phải";
            tbxDescription.Size = new Size(507, 97);
            tbxDescription.TabIndex = 5;
            // 
            // cbxReason
            // 
            cbxReason.Cursor = Cursors.Hand;
            cbxReason.FormattingEnabled = true;
            cbxReason.Location = new Point(108, 38);
            cbxReason.Name = "cbxReason";
            cbxReason.Size = new Size(505, 30);
            cbxReason.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 81);
            label1.Name = "label1";
            label1.Size = new Size(62, 22);
            label1.TabIndex = 3;
            label1.Text = "Mô tả:";
            // 
            // lblLyDo
            // 
            lblLyDo.AutoSize = true;
            lblLyDo.Location = new Point(12, 41);
            lblLyDo.Name = "lblLyDo";
            lblLyDo.Size = new Size(62, 22);
            lblLyDo.TabIndex = 2;
            lblLyDo.Text = "Lý do:";
            // 
            // lblHeader2
            // 
            lblHeader2.AutoSize = true;
            lblHeader2.Cursor = Cursors.IBeam;
            lblHeader2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader2.Location = new Point(2, 3);
            lblHeader2.Name = "lblHeader2";
            lblHeader2.Size = new Size(527, 32);
            lblHeader2.TabIndex = 1;
            lblHeader2.Text = "Chọn sản phẩm cần Trả hàng và Hoàn tiền";
            // 
            // pnInfor
            // 
            pnInfor.BackColor = Color.White;
            pnInfor.Controls.Add(btnDone);
            pnInfor.Controls.Add(label3);
            pnInfor.Controls.Add(lblNhanDuoc);
            pnInfor.Controls.Add(lblRefundableAmount);
            pnInfor.Controls.Add(pnLine);
            pnInfor.Controls.Add(lblCoThe);
            pnInfor.Controls.Add(cbxRefund);
            pnInfor.Controls.Add(lblRefundAmout);
            pnInfor.Controls.Add(label2);
            pnInfor.Controls.Add(lblHoanVao);
            pnInfor.Controls.Add(lblHoanLai);
            pnInfor.Controls.Add(lblHeader3);
            pnInfor.Location = new Point(2, 325);
            pnInfor.Name = "pnInfor";
            pnInfor.Size = new Size(946, 165);
            pnInfor.TabIndex = 5;
            // 
            // btnDone
            // 
            btnDone.BackColor = Color.OrangeRed;
            btnDone.Cursor = Cursors.Hand;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.ForeColor = Color.White;
            btnDone.Location = new Point(758, 113);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(172, 46);
            btnDone.TabIndex = 19;
            btnDone.Text = "Hoàn thành";
            btnDone.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.IBeam;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(713, 74);
            label3.Name = "label3";
            label3.Size = new Size(73, 26);
            label3.TabIndex = 15;
            label3.Text = "160.00";
            // 
            // lblNhanDuoc
            // 
            lblNhanDuoc.AutoSize = true;
            lblNhanDuoc.Cursor = Cursors.IBeam;
            lblNhanDuoc.Location = new Point(472, 77);
            lblNhanDuoc.Name = "lblNhanDuoc";
            lblNhanDuoc.Size = new Size(220, 22);
            lblNhanDuoc.TabIndex = 14;
            lblNhanDuoc.Text = "Số tiền hoàn lại nhận được";
            // 
            // lblRefundableAmount
            // 
            lblRefundableAmount.AutoSize = true;
            lblRefundableAmount.Cursor = Cursors.IBeam;
            lblRefundableAmount.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRefundableAmount.ForeColor = SystemColors.ControlDarkDark;
            lblRefundableAmount.Location = new Point(727, 31);
            lblRefundableAmount.Name = "lblRefundableAmount";
            lblRefundableAmount.Size = new Size(59, 20);
            lblRefundableAmount.TabIndex = 13;
            lblRefundableAmount.Text = "160.00";
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.Location = new Point(455, 0);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1, 159);
            pnLine.TabIndex = 12;
            // 
            // lblCoThe
            // 
            lblCoThe.AutoSize = true;
            lblCoThe.Cursor = Cursors.IBeam;
            lblCoThe.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCoThe.ForeColor = SystemColors.ControlDarkDark;
            lblCoThe.Location = new Point(472, 31);
            lblCoThe.Name = "lblCoThe";
            lblCoThe.Size = new Size(165, 19);
            lblCoThe.TabIndex = 11;
            lblCoThe.Text = "Số tiền có thể hoàn lại:";
            // 
            // cbxRefund
            // 
            cbxRefund.FormattingEnabled = true;
            cbxRefund.Location = new Point(166, 110);
            cbxRefund.Name = "cbxRefund";
            cbxRefund.Size = new Size(148, 30);
            cbxRefund.TabIndex = 10;
            // 
            // lblRefundAmout
            // 
            lblRefundAmout.AutoSize = true;
            lblRefundAmout.Cursor = Cursors.IBeam;
            lblRefundAmout.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRefundAmout.ForeColor = Color.Black;
            lblRefundAmout.Location = new Point(166, 62);
            lblRefundAmout.Name = "lblRefundAmout";
            lblRefundAmout.Size = new Size(73, 26);
            lblRefundAmout.TabIndex = 9;
            lblRefundAmout.Text = "160.00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(536, 192);
            label2.Name = "label2";
            label2.Size = new Size(66, 22);
            label2.TabIndex = 6;
            label2.Text = "0/2000";
            // 
            // lblHoanVao
            // 
            lblHoanVao.AutoSize = true;
            lblHoanVao.Location = new Point(10, 113);
            lblHoanVao.Name = "lblHoanVao";
            lblHoanVao.Size = new Size(126, 22);
            lblHoanVao.TabIndex = 3;
            lblHoanVao.Text = "Hoàn tiền vào:";
            // 
            // lblHoanLai
            // 
            lblHoanLai.AutoSize = true;
            lblHoanLai.Location = new Point(8, 65);
            lblHoanLai.Name = "lblHoanLai";
            lblHoanLai.Size = new Size(139, 22);
            lblHoanLai.TabIndex = 2;
            lblHoanLai.Text = "Số tiền hoàn lại:";
            // 
            // lblHeader3
            // 
            lblHeader3.AutoSize = true;
            lblHeader3.Cursor = Cursors.IBeam;
            lblHeader3.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader3.Location = new Point(2, 3);
            lblHeader3.Name = "lblHeader3";
            lblHeader3.Size = new Size(251, 32);
            lblHeader3.TabIndex = 1;
            lblHeader3.Text = "Thông tin hoàn tiền";
            // 
            // Refund
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(946, 491);
            Controls.Add(pnInfor);
            Controls.Add(pnDescription);
            Controls.Add(pnProduct);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Refund";
            Text = "Refund";
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imageProduct).EndInit();
            pnProduct.ResumeLayout(false);
            pnProduct.PerformLayout();
            pnDescription.ResumeLayout(false);
            pnDescription.PerformLayout();
            pnInfor.ResumeLayout(false);
            pnInfor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblStatus;
        private Panel pnTop;
        private Label lblCurrentPrice;
        private Label lblOldPrice;
        private Panel pnImage;
        private PictureBox imageProduct;
        private Label lblQuantity;
        private Label lblColorSize;
        private Label lblNameProduct;
        private Label lblHeader1;
        private Label lblHeader2;
        private TextBox tbxDescription;
        private ComboBox cbxReason;
        private Label label1;
        private Label lblLyDo;
        private Label lblCountTezt;
        private Panel pnInfor;
        private ComboBox cbxRefund;
        private Label lblRefundAmout;
        private Label label2;
        private Label lblHoanVao;
        private Label lblHoanLai;
        private Label lblHeader3;
        private Panel pnLine;
        private Label lblCoThe;
        private Label label3;
        private Label lblNhanDuoc;
        private Label lblRefundableAmount;
        private Button btnDone;
        private Panel pnProduct;
        private Panel pnDescription;
    }
}