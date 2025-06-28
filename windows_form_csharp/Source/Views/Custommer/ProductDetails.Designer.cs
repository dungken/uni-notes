namespace Source.Views.Custommer
{
    partial class ProductDetails
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
            pnlProductDetail = new Panel();
            pnRating = new Panel();
            button1 = new Button();
            btnAddCart = new Button();
            btnBuy = new Button();
            pnChoose = new Panel();
            pnQuantuty = new Panel();
            btnIncrease = new Button();
            lblQuantity = new Label();
            btnDecrease = new Button();
            lblSoLuong = new Label();
            pnlSize = new Panel();
            btnSize1 = new Button();
            btnSize2 = new Button();
            btnSize3 = new Button();
            lblSize = new Label();
            pnlColor = new Panel();
            btnColor1 = new Button();
            btnColor2 = new Button();
            btnColor3 = new Button();
            lblMauSac = new Label();
            pnPrice = new Panel();
            lblDiscount = new Label();
            lblOldPrice = new Label();
            lblPrice = new Label();
            pnDetail = new Panel();
            lblDaBan = new Label();
            lblSold = new Label();
            pnLineRight = new Panel();
            lblDanhGia = new Label();
            lblReview = new Label();
            pnLineLeft = new Panel();
            panel2 = new Panel();
            pnStar = new Panel();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            picbxStar = new PictureBox();
            lblRating = new Label();
            pnName = new Panel();
            lblName = new Label();
            pnImg = new Panel();
            btnPre = new Button();
            btnNext = new Button();
            picBox1 = new PictureBox();
            picBox2 = new PictureBox();
            picBox3 = new PictureBox();
            picbxMain = new PictureBox();
            pnlProductDetail.SuspendLayout();
            pnRating.SuspendLayout();
            pnChoose.SuspendLayout();
            pnQuantuty.SuspendLayout();
            pnlSize.SuspendLayout();
            pnlColor.SuspendLayout();
            pnPrice.SuspendLayout();
            pnDetail.SuspendLayout();
            pnLineLeft.SuspendLayout();
            pnStar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picbxStar).BeginInit();
            pnName.SuspendLayout();
            pnImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picbxMain).BeginInit();
            SuspendLayout();
            // 
            // pnlProductDetail
            // 
            pnlProductDetail.Controls.Add(pnRating);
            pnlProductDetail.Controls.Add(pnImg);
            pnlProductDetail.Dock = DockStyle.Fill;
            pnlProductDetail.Location = new Point(0, 0);
            pnlProductDetail.Name = "pnlProductDetail";
            pnlProductDetail.Size = new Size(964, 538);
            pnlProductDetail.TabIndex = 0;
            pnlProductDetail.Paint += panel1_Paint;
            // 
            // pnRating
            // 
            pnRating.Controls.Add(button1);
            pnRating.Controls.Add(btnAddCart);
            pnRating.Controls.Add(btnBuy);
            pnRating.Controls.Add(pnChoose);
            pnRating.Controls.Add(pnPrice);
            pnRating.Controls.Add(pnDetail);
            pnRating.Controls.Add(pnName);
            pnRating.Location = new Point(379, 12);
            pnRating.Name = "pnRating";
            pnRating.Size = new Size(573, 514);
            pnRating.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(556, 444);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 21;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnAddCart
            // 
            btnAddCart.BackColor = Color.FromArgb(253, 239, 225);
            btnAddCart.Cursor = Cursors.Hand;
            btnAddCart.FlatStyle = FlatStyle.Flat;
            btnAddCart.ForeColor = Color.FromArgb(229, 132, 109);
            btnAddCart.Image = Properties.Resources.CartIcon1;
            btnAddCart.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddCart.Location = new Point(30, 434);
            btnAddCart.Name = "btnAddCart";
            btnAddCart.Size = new Size(196, 46);
            btnAddCart.TabIndex = 20;
            btnAddCart.Text = "   Thêm vào giỏ hàng";
            btnAddCart.UseVisualStyleBackColor = false;
            btnAddCart.Click += btnAddCart_Click;
            // 
            // btnBuy
            // 
            btnBuy.BackColor = Color.OrangeRed;
            btnBuy.Cursor = Cursors.Hand;
            btnBuy.FlatStyle = FlatStyle.Flat;
            btnBuy.ForeColor = Color.White;
            btnBuy.Location = new Point(242, 434);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(196, 46);
            btnBuy.TabIndex = 19;
            btnBuy.Text = "Mua ngay";
            btnBuy.UseVisualStyleBackColor = false;
            btnBuy.Click += btnBuy_Click;
            // 
            // pnChoose
            // 
            pnChoose.Controls.Add(pnQuantuty);
            pnChoose.Controls.Add(lblSoLuong);
            pnChoose.Controls.Add(pnlSize);
            pnChoose.Controls.Add(lblSize);
            pnChoose.Controls.Add(pnlColor);
            pnChoose.Controls.Add(lblMauSac);
            pnChoose.Location = new Point(30, 226);
            pnChoose.Name = "pnChoose";
            pnChoose.Size = new Size(490, 180);
            pnChoose.TabIndex = 4;
            // 
            // pnQuantuty
            // 
            pnQuantuty.Controls.Add(btnIncrease);
            pnQuantuty.Controls.Add(lblQuantity);
            pnQuantuty.Controls.Add(btnDecrease);
            pnQuantuty.Location = new Point(112, 135);
            pnQuantuty.Name = "pnQuantuty";
            pnQuantuty.Size = new Size(87, 40);
            pnQuantuty.TabIndex = 9;
            // 
            // btnIncrease
            // 
            btnIncrease.Cursor = Cursors.Hand;
            btnIncrease.Dock = DockStyle.Right;
            btnIncrease.Location = new Point(56, 0);
            btnIncrease.Name = "btnIncrease";
            btnIncrease.Size = new Size(31, 40);
            btnIncrease.TabIndex = 33;
            btnIncrease.Text = "+";
            btnIncrease.UseVisualStyleBackColor = true;
            btnIncrease.Click += btnIncrease_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.Cursor = Cursors.IBeam;
            lblQuantity.Dock = DockStyle.Left;
            lblQuantity.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(31, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(23, 40);
            lblQuantity.TabIndex = 33;
            lblQuantity.Text = "1";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDecrease
            // 
            btnDecrease.Cursor = Cursors.Hand;
            btnDecrease.Dock = DockStyle.Left;
            btnDecrease.Location = new Point(0, 0);
            btnDecrease.Name = "btnDecrease";
            btnDecrease.Size = new Size(31, 40);
            btnDecrease.TabIndex = 32;
            btnDecrease.Text = "-";
            btnDecrease.UseVisualStyleBackColor = true;
            btnDecrease.Click += btnDecrease_Click;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Cursor = Cursors.IBeam;
            lblSoLuong.ForeColor = SystemColors.ControlDarkDark;
            lblSoLuong.Location = new Point(4, 144);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(82, 22);
            lblSoLuong.TabIndex = 4;
            lblSoLuong.Text = "Số lượng";
            // 
            // pnlSize
            // 
            pnlSize.Controls.Add(btnSize1);
            pnlSize.Controls.Add(btnSize2);
            pnlSize.Controls.Add(btnSize3);
            pnlSize.Location = new Point(101, 67);
            pnlSize.Name = "pnlSize";
            pnlSize.Size = new Size(384, 47);
            pnlSize.TabIndex = 3;
            // 
            // btnSize1
            // 
            btnSize1.Cursor = Cursors.Hand;
            btnSize1.Location = new Point(9, 3);
            btnSize1.Name = "btnSize1";
            btnSize1.Size = new Size(94, 44);
            btnSize1.TabIndex = 2;
            btnSize1.UseVisualStyleBackColor = true;
            // 
            // btnSize2
            // 
            btnSize2.Cursor = Cursors.Hand;
            btnSize2.Location = new Point(109, 3);
            btnSize2.Name = "btnSize2";
            btnSize2.Size = new Size(94, 44);
            btnSize2.TabIndex = 3;
            btnSize2.UseVisualStyleBackColor = true;
            // 
            // btnSize3
            // 
            btnSize3.Cursor = Cursors.Hand;
            btnSize3.Location = new Point(213, 3);
            btnSize3.Name = "btnSize3";
            btnSize3.Size = new Size(94, 44);
            btnSize3.TabIndex = 3;
            btnSize3.UseVisualStyleBackColor = true;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Cursor = Cursors.IBeam;
            lblSize.ForeColor = SystemColors.ControlDarkDark;
            lblSize.Location = new Point(4, 81);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(44, 22);
            lblSize.TabIndex = 2;
            lblSize.Text = "Size";
            // 
            // pnlColor
            // 
            pnlColor.Controls.Add(btnColor1);
            pnlColor.Controls.Add(btnColor2);
            pnlColor.Controls.Add(btnColor3);
            pnlColor.Location = new Point(103, 3);
            pnlColor.Name = "pnlColor";
            pnlColor.Size = new Size(384, 47);
            pnlColor.TabIndex = 1;
            // 
            // btnColor1
            // 
            btnColor1.Cursor = Cursors.Hand;
            btnColor1.Location = new Point(9, 3);
            btnColor1.Name = "btnColor1";
            btnColor1.Size = new Size(94, 44);
            btnColor1.TabIndex = 2;
            btnColor1.UseVisualStyleBackColor = true;
            // 
            // btnColor2
            // 
            btnColor2.Cursor = Cursors.Hand;
            btnColor2.Location = new Point(109, 3);
            btnColor2.Name = "btnColor2";
            btnColor2.Size = new Size(94, 44);
            btnColor2.TabIndex = 3;
            btnColor2.UseVisualStyleBackColor = true;
            // 
            // btnColor3
            // 
            btnColor3.Cursor = Cursors.Hand;
            btnColor3.Location = new Point(211, 3);
            btnColor3.Name = "btnColor3";
            btnColor3.Padding = new Padding(3);
            btnColor3.Size = new Size(94, 44);
            btnColor3.TabIndex = 3;
            btnColor3.UseVisualStyleBackColor = true;
            // 
            // lblMauSac
            // 
            lblMauSac.AutoSize = true;
            lblMauSac.Cursor = Cursors.IBeam;
            lblMauSac.ForeColor = SystemColors.ControlDarkDark;
            lblMauSac.Location = new Point(4, 18);
            lblMauSac.Name = "lblMauSac";
            lblMauSac.Size = new Size(79, 22);
            lblMauSac.TabIndex = 0;
            lblMauSac.Text = "Màu Sắc";
            // 
            // pnPrice
            // 
            pnPrice.BackColor = Color.FromArgb(250, 250, 250);
            pnPrice.Controls.Add(lblDiscount);
            pnPrice.Controls.Add(lblOldPrice);
            pnPrice.Controls.Add(lblPrice);
            pnPrice.Location = new Point(8, 138);
            pnPrice.Name = "pnPrice";
            pnPrice.Size = new Size(548, 53);
            pnPrice.TabIndex = 3;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.BackColor = Color.Transparent;
            lblDiscount.Cursor = Cursors.IBeam;
            lblDiscount.FlatStyle = FlatStyle.Flat;
            lblDiscount.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiscount.ForeColor = Color.OrangeRed;
            lblDiscount.Location = new Point(220, 19);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(49, 19);
            lblDiscount.TabIndex = 22;
            lblDiscount.Text = "-33%";
            // 
            // lblOldPrice
            // 
            lblOldPrice.AutoSize = true;
            lblOldPrice.Cursor = Cursors.IBeam;
            lblOldPrice.Font = new Font("Times New Roman", 12F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
            lblOldPrice.ForeColor = SystemColors.ControlDarkDark;
            lblOldPrice.Location = new Point(136, 19);
            lblOldPrice.Name = "lblOldPrice";
            lblOldPrice.Size = new Size(65, 22);
            lblOldPrice.TabIndex = 21;
            lblOldPrice.Text = "289.00";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Cursor = Cursors.IBeam;
            lblPrice.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.OrangeRed;
            lblPrice.Location = new Point(26, 9);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(91, 32);
            lblPrice.TabIndex = 20;
            lblPrice.Text = "167.00";
            // 
            // pnDetail
            // 
            pnDetail.Controls.Add(lblDaBan);
            pnDetail.Controls.Add(lblSold);
            pnDetail.Controls.Add(pnLineRight);
            pnDetail.Controls.Add(lblDanhGia);
            pnDetail.Controls.Add(lblReview);
            pnDetail.Controls.Add(pnLineLeft);
            pnDetail.Controls.Add(pnStar);
            pnDetail.Controls.Add(lblRating);
            pnDetail.Location = new Point(5, 69);
            pnDetail.Name = "pnDetail";
            pnDetail.Size = new Size(565, 43);
            pnDetail.TabIndex = 2;
            // 
            // lblDaBan
            // 
            lblDaBan.AutoSize = true;
            lblDaBan.Cursor = Cursors.IBeam;
            lblDaBan.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDaBan.ForeColor = SystemColors.ControlDarkDark;
            lblDaBan.Location = new Point(433, 12);
            lblDaBan.Name = "lblDaBan";
            lblDaBan.Size = new Size(66, 22);
            lblDaBan.TabIndex = 6;
            lblDaBan.Text = "Đã bán";
            // 
            // lblSold
            // 
            lblSold.AutoSize = true;
            lblSold.Cursor = Cursors.IBeam;
            lblSold.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSold.Location = new Point(398, 12);
            lblSold.Name = "lblSold";
            lblSold.Size = new Size(29, 22);
            lblSold.TabIndex = 5;
            lblSold.Text = "2k";
            // 
            // pnLineRight
            // 
            pnLineRight.BackColor = SystemColors.ControlDark;
            pnLineRight.Location = new Point(380, 0);
            pnLineRight.Name = "pnLineRight";
            pnLineRight.Size = new Size(1, 43);
            pnLineRight.TabIndex = 5;
            // 
            // lblDanhGia
            // 
            lblDanhGia.AutoSize = true;
            lblDanhGia.Cursor = Cursors.Hand;
            lblDanhGia.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDanhGia.ForeColor = SystemColors.ControlDarkDark;
            lblDanhGia.Location = new Point(278, 12);
            lblDanhGia.Name = "lblDanhGia";
            lblDanhGia.Size = new Size(80, 22);
            lblDanhGia.TabIndex = 5;
            lblDanhGia.Text = "Đánh giá";
            // 
            // lblReview
            // 
            lblReview.AutoSize = true;
            lblReview.Cursor = Cursors.Hand;
            lblReview.Font = new Font("Times New Roman", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblReview.Location = new Point(232, 12);
            lblReview.Name = "lblReview";
            lblReview.Size = new Size(40, 22);
            lblReview.TabIndex = 4;
            lblReview.Text = "443";
            // 
            // pnLineLeft
            // 
            pnLineLeft.BackColor = SystemColors.ControlDark;
            pnLineLeft.Controls.Add(panel2);
            pnLineLeft.Location = new Point(206, 0);
            pnLineLeft.Name = "pnLineLeft";
            pnLineLeft.Size = new Size(1, 43);
            pnLineLeft.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1, 43);
            panel2.TabIndex = 4;
            // 
            // pnStar
            // 
            pnStar.Controls.Add(pictureBox6);
            pnStar.Controls.Add(pictureBox5);
            pnStar.Controls.Add(pictureBox4);
            pnStar.Controls.Add(pictureBox3);
            pnStar.Controls.Add(picbxStar);
            pnStar.Cursor = Cursors.Hand;
            pnStar.Location = new Point(50, 3);
            pnStar.Name = "pnStar";
            pnStar.Size = new Size(136, 37);
            pnStar.TabIndex = 1;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.Star;
            pictureBox6.Location = new Point(113, 8);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(20, 20);
            pictureBox6.TabIndex = 4;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Star;
            pictureBox5.Location = new Point(87, 8);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(20, 20);
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Star;
            pictureBox4.Location = new Point(61, 8);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(20, 20);
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Star;
            pictureBox3.Location = new Point(35, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(20, 20);
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // picbxStar
            // 
            picbxStar.Image = Properties.Resources.Star;
            picbxStar.Location = new Point(9, 8);
            picbxStar.Name = "picbxStar";
            picbxStar.Size = new Size(20, 20);
            picbxStar.TabIndex = 0;
            picbxStar.TabStop = false;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Cursor = Cursors.Hand;
            lblRating.Font = new Font("Times New Roman", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblRating.Location = new Point(7, 12);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(35, 22);
            lblRating.TabIndex = 0;
            lblRating.Text = "4.8";
            // 
            // pnName
            // 
            pnName.Controls.Add(lblName);
            pnName.Location = new Point(8, 3);
            pnName.Name = "pnName";
            pnName.Size = new Size(562, 58);
            pnName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Cursor = Cursors.IBeam;
            lblName.Dock = DockStyle.Fill;
            lblName.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(562, 58);
            lblName.TabIndex = 0;
            lblName.Text = "Áo Thun Baby Tee Choice AH39 In Chữ POSITIVE MENTAL 100% Cotton Mẫu Mới";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnImg
            // 
            pnImg.Controls.Add(btnPre);
            pnImg.Controls.Add(btnNext);
            pnImg.Controls.Add(picBox1);
            pnImg.Controls.Add(picBox2);
            pnImg.Controls.Add(picBox3);
            pnImg.Controls.Add(picbxMain);
            pnImg.Location = new Point(12, 12);
            pnImg.Name = "pnImg";
            pnImg.Size = new Size(332, 514);
            pnImg.TabIndex = 2;
            // 
            // btnPre
            // 
            btnPre.Cursor = Cursors.Hand;
            btnPre.Image = Properties.Resources.PreviousIcon;
            btnPre.Location = new Point(0, 447);
            btnPre.Name = "btnPre";
            btnPre.Size = new Size(20, 20);
            btnPre.TabIndex = 5;
            btnPre.UseVisualStyleBackColor = true;
            btnPre.Click += btnPre_Click;
            // 
            // btnNext
            // 
            btnNext.BackgroundImageLayout = ImageLayout.None;
            btnNext.Cursor = Cursors.Hand;
            btnNext.Image = Properties.Resources.NextIcon2;
            btnNext.Location = new Point(309, 447);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(20, 20);
            btnNext.TabIndex = 4;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // picBox1
            // 
            picBox1.Cursor = Cursors.Hand;
            picBox1.Image = Properties.Resources.capybara3;
            picBox1.Location = new Point(3, 403);
            picBox1.Name = "picBox1";
            picBox1.Size = new Size(93, 108);
            picBox1.SizeMode = PictureBoxSizeMode.Zoom;
            picBox1.TabIndex = 1;
            picBox1.TabStop = false;
            picBox1.Click += picBox1_Click;
            // 
            // picBox2
            // 
            picBox2.Cursor = Cursors.Hand;
            picBox2.Image = Properties.Resources.capybara3;
            picBox2.Location = new Point(122, 403);
            picBox2.Name = "picBox2";
            picBox2.Size = new Size(93, 108);
            picBox2.SizeMode = PictureBoxSizeMode.Zoom;
            picBox2.TabIndex = 2;
            picBox2.TabStop = false;
            picBox2.Click += picBox2_Click;
            // 
            // picBox3
            // 
            picBox3.Cursor = Cursors.Hand;
            picBox3.Image = Properties.Resources.capybara3;
            picBox3.Location = new Point(236, 403);
            picBox3.Name = "picBox3";
            picBox3.Size = new Size(93, 108);
            picBox3.SizeMode = PictureBoxSizeMode.Zoom;
            picBox3.TabIndex = 3;
            picBox3.TabStop = false;
            picBox3.Click += picBox3_Click;
            // 
            // picbxMain
            // 
            picbxMain.Cursor = Cursors.Hand;
            picbxMain.Image = Properties.Resources.capybara3;
            picbxMain.Location = new Point(3, 3);
            picbxMain.Name = "picbxMain";
            picbxMain.Size = new Size(326, 380);
            picbxMain.SizeMode = PictureBoxSizeMode.Zoom;
            picbxMain.TabIndex = 0;
            picbxMain.TabStop = false;
            // 
            // ProductDetails
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(964, 538);
            Controls.Add(pnlProductDetail);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductDetails";
            Text = "ProductDetails";
            pnlProductDetail.ResumeLayout(false);
            pnRating.ResumeLayout(false);
            pnChoose.ResumeLayout(false);
            pnChoose.PerformLayout();
            pnQuantuty.ResumeLayout(false);
            pnlSize.ResumeLayout(false);
            pnlColor.ResumeLayout(false);
            pnPrice.ResumeLayout(false);
            pnPrice.PerformLayout();
            pnDetail.ResumeLayout(false);
            pnDetail.PerformLayout();
            pnLineLeft.ResumeLayout(false);
            pnStar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picbxStar).EndInit();
            pnName.ResumeLayout(false);
            pnImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picbxMain).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel pnlProductDetail;
        private Panel pnRating;
        private Button button1;
        private Button btnAddCart;
        private Button btnBuy;
        private Panel pnChoose;
        private Panel pnQuantuty;
        private Button btnIncrease;
        private Label lblQuantity;
        private Button btnDecrease;
        private Label lblSoLuong;
        private Panel pnlSize;
        private Button btnSize1;
        private Button btnSize2;
        private Button btnSize3;
        private Label lblSize;
        private Panel pnlColor;
        private Button btnColor1;
        private Button btnColor2;
        private Button btnColor3;
        private Label lblMauSac;
        private Panel pnPrice;
        private Label lblDiscount;
        private Label lblOldPrice;
        private Label lblPrice;
        private Panel pnDetail;
        private Label lblDaBan;
        private Label lblSold;
        private Panel pnLineRight;
        private Label lblDanhGia;
        private Label lblReview;
        private Panel pnLineLeft;
        private Panel panel2;
        private Panel pnStar;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox picbxStar;
        private Label lblRating;
        private Panel pnName;
        private Label lblName;
        private Panel pnImg;
        private Button btnPre;
        private Button btnNext;
        private PictureBox picBox1;
        private PictureBox picBox2;
        private PictureBox picBox3;
        private PictureBox picbxMain;
    }
}