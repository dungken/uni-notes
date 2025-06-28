namespace Source.Views.Custommer
{
    partial class Cart
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
            pnlCart = new Panel();
            pnlProductList = new Panel();
            pnlProduct = new Panel();
            btnDecrease = new Button();
            btnIncrease = new Button();
            pictureBoxProduct = new PictureBox();
            lblQuantity = new Label();
            lblNameProduct = new Label();
            pnlTopLine = new Panel();
            pnlRightLine = new Panel();
            pnlBotLine = new Panel();
            pnlLeftLine = new Panel();
            lblDelete = new Label();
            lblPriceProduct = new Label();
            lblCurrentPrice = new Label();
            lblOldPrice = new Label();
            lblColorSize = new Label();
            lblPLH = new Label();
            cbxProduct = new CheckBox();
            pnFooter = new Panel();
            panel1 = new Panel();
            lblTotalProduct = new Label();
            lblTotalPrice = new Label();
            btnBuy = new Button();
            lblDelMul = new Label();
            lblCount = new Label();
            cbxAllBot = new CheckBox();
            pnHeader = new Panel();
            lblThaoTac = new Label();
            lblSoLuong = new Label();
            lblSoTien = new Label();
            lblDonGia = new Label();
            lblSanPham = new Label();
            cbxAll = new CheckBox();
            pnlChildFormCart = new Panel();
            pnlCart.SuspendLayout();
            pnlProductList.SuspendLayout();
            pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            pnFooter.SuspendLayout();
            pnHeader.SuspendLayout();
            pnlChildFormCart.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCart
            // 
            pnlCart.Controls.Add(pnlChildFormCart);
            pnlCart.Dock = DockStyle.Fill;
            pnlCart.Location = new Point(0, 0);
            pnlCart.Name = "pnlCart";
            pnlCart.Size = new Size(964, 538);
            pnlCart.TabIndex = 0;
            // 
            // pnlProductList
            // 
            pnlProductList.AutoScroll = true;
            pnlProductList.Controls.Add(pnlProduct);
            pnlProductList.Dock = DockStyle.Fill;
            pnlProductList.Location = new Point(0, 52);
            pnlProductList.Name = "pnlProductList";
            pnlProductList.Size = new Size(964, 410);
            pnlProductList.TabIndex = 14;
            // 
            // pnlProduct
            // 
            pnlProduct.BackColor = Color.White;
            pnlProduct.Controls.Add(btnDecrease);
            pnlProduct.Controls.Add(btnIncrease);
            pnlProduct.Controls.Add(pictureBoxProduct);
            pnlProduct.Controls.Add(lblQuantity);
            pnlProduct.Controls.Add(lblNameProduct);
            pnlProduct.Controls.Add(pnlTopLine);
            pnlProduct.Controls.Add(pnlRightLine);
            pnlProduct.Controls.Add(pnlBotLine);
            pnlProduct.Controls.Add(pnlLeftLine);
            pnlProduct.Controls.Add(lblDelete);
            pnlProduct.Controls.Add(lblPriceProduct);
            pnlProduct.Controls.Add(lblCurrentPrice);
            pnlProduct.Controls.Add(lblOldPrice);
            pnlProduct.Controls.Add(lblColorSize);
            pnlProduct.Controls.Add(lblPLH);
            pnlProduct.Controls.Add(cbxProduct);
            pnlProduct.Dock = DockStyle.Top;
            pnlProduct.Location = new Point(0, 0);
            pnlProduct.Name = "pnlProduct";
            pnlProduct.Size = new Size(964, 125);
            pnlProduct.TabIndex = 12;
            pnlProduct.Visible = false;
            // 
            // btnDecrease
            // 
            btnDecrease.Cursor = Cursors.Hand;
            btnDecrease.Location = new Point(660, 44);
            btnDecrease.Name = "btnDecrease";
            btnDecrease.Size = new Size(31, 40);
            btnDecrease.TabIndex = 32;
            btnDecrease.Text = "-";
            btnDecrease.UseVisualStyleBackColor = true;
            // 
            // btnIncrease
            // 
            btnIncrease.Cursor = Cursors.Hand;
            btnIncrease.Location = new Point(744, 42);
            btnIncrease.Name = "btnIncrease";
            btnIncrease.Size = new Size(31, 40);
            btnIncrease.TabIndex = 33;
            btnIncrease.Text = "+";
            btnIncrease.UseVisualStyleBackColor = true;
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Cursor = Cursors.Hand;
            pictureBoxProduct.Image = Properties.Resources.capybara3;
            pictureBoxProduct.Location = new Point(58, 14);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(121, 92);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            // 
            // lblQuantity
            // 
            lblQuantity.Cursor = Cursors.IBeam;
            lblQuantity.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(706, 44);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(23, 34);
            lblQuantity.TabIndex = 33;
            lblQuantity.Text = "1";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNameProduct
            // 
            lblNameProduct.Cursor = Cursors.Hand;
            lblNameProduct.Location = new Point(190, 14);
            lblNameProduct.Name = "lblNameProduct";
            lblNameProduct.Size = new Size(161, 92);
            lblNameProduct.TabIndex = 8;
            lblNameProduct.Text = "Quần jean nữ dài ống rộng cạp cao vãi bò phối dây";
            lblNameProduct.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTopLine
            // 
            pnlTopLine.BackColor = Color.Silver;
            pnlTopLine.Dock = DockStyle.Top;
            pnlTopLine.Location = new Point(1, 0);
            pnlTopLine.Name = "pnlTopLine";
            pnlTopLine.Size = new Size(962, 1);
            pnlTopLine.TabIndex = 7;
            // 
            // pnlRightLine
            // 
            pnlRightLine.BackColor = Color.Silver;
            pnlRightLine.Dock = DockStyle.Right;
            pnlRightLine.Location = new Point(963, 0);
            pnlRightLine.Name = "pnlRightLine";
            pnlRightLine.Size = new Size(1, 124);
            pnlRightLine.TabIndex = 7;
            // 
            // pnlBotLine
            // 
            pnlBotLine.BackColor = Color.Silver;
            pnlBotLine.Dock = DockStyle.Bottom;
            pnlBotLine.Location = new Point(1, 124);
            pnlBotLine.Name = "pnlBotLine";
            pnlBotLine.Size = new Size(963, 1);
            pnlBotLine.TabIndex = 8;
            // 
            // pnlLeftLine
            // 
            pnlLeftLine.BackColor = Color.Silver;
            pnlLeftLine.Dock = DockStyle.Left;
            pnlLeftLine.Location = new Point(0, 0);
            pnlLeftLine.Name = "pnlLeftLine";
            pnlLeftLine.Size = new Size(1, 125);
            pnlLeftLine.TabIndex = 6;
            // 
            // lblDelete
            // 
            lblDelete.AutoSize = true;
            lblDelete.Cursor = Cursors.Hand;
            lblDelete.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDelete.ForeColor = Color.Black;
            lblDelete.Location = new Point(885, 49);
            lblDelete.Name = "lblDelete";
            lblDelete.Size = new Size(43, 22);
            lblDelete.TabIndex = 16;
            lblDelete.Text = "Xóa";
            // 
            // lblPriceProduct
            // 
            lblPriceProduct.AutoSize = true;
            lblPriceProduct.Cursor = Cursors.IBeam;
            lblPriceProduct.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPriceProduct.ForeColor = Color.OrangeRed;
            lblPriceProduct.Location = new Point(794, 49);
            lblPriceProduct.Name = "lblPriceProduct";
            lblPriceProduct.Size = new Size(65, 22);
            lblPriceProduct.TabIndex = 15;
            lblPriceProduct.Text = "160.00";
            // 
            // lblCurrentPrice
            // 
            lblCurrentPrice.AutoSize = true;
            lblCurrentPrice.Cursor = Cursors.IBeam;
            lblCurrentPrice.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentPrice.ForeColor = Color.Black;
            lblCurrentPrice.Location = new Point(578, 51);
            lblCurrentPrice.Name = "lblCurrentPrice";
            lblCurrentPrice.Size = new Size(65, 22);
            lblCurrentPrice.TabIndex = 13;
            lblCurrentPrice.Text = "160.00";
            // 
            // lblOldPrice
            // 
            lblOldPrice.AutoSize = true;
            lblOldPrice.Cursor = Cursors.IBeam;
            lblOldPrice.Font = new Font("Times New Roman", 12F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
            lblOldPrice.ForeColor = SystemColors.ControlDarkDark;
            lblOldPrice.Location = new Point(507, 51);
            lblOldPrice.Name = "lblOldPrice";
            lblOldPrice.Size = new Size(65, 22);
            lblOldPrice.TabIndex = 12;
            lblOldPrice.Text = "289.00";
            // 
            // lblColorSize
            // 
            lblColorSize.ForeColor = SystemColors.ControlDarkDark;
            lblColorSize.Location = new Point(357, 60);
            lblColorSize.Name = "lblColorSize";
            lblColorSize.Size = new Size(92, 25);
            lblColorSize.TabIndex = 11;
            lblColorSize.Text = "Xanh, M";
            // 
            // lblPLH
            // 
            lblPLH.AutoSize = true;
            lblPLH.Cursor = Cursors.Hand;
            lblPLH.ForeColor = SystemColors.ControlDarkDark;
            lblPLH.Location = new Point(357, 29);
            lblPLH.Name = "lblPLH";
            lblPLH.Size = new Size(131, 22);
            lblPLH.TabIndex = 10;
            lblPLH.Text = "Phân loại hàng:";
            // 
            // cbxProduct
            // 
            cbxProduct.AutoSize = true;
            cbxProduct.Location = new Point(22, 54);
            cbxProduct.Name = "cbxProduct";
            cbxProduct.Size = new Size(18, 17);
            cbxProduct.TabIndex = 6;
            cbxProduct.TextAlign = ContentAlignment.MiddleCenter;
            cbxProduct.UseVisualStyleBackColor = true;
            cbxProduct.CheckedChanged += cbxProduct_CheckedChanged;
            // 
            // pnFooter
            // 
            pnFooter.Controls.Add(panel1);
            pnFooter.Controls.Add(lblTotalProduct);
            pnFooter.Controls.Add(lblTotalPrice);
            pnFooter.Controls.Add(btnBuy);
            pnFooter.Controls.Add(lblDelMul);
            pnFooter.Controls.Add(lblCount);
            pnFooter.Controls.Add(cbxAllBot);
            pnFooter.Dock = DockStyle.Bottom;
            pnFooter.Location = new Point(0, 462);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(964, 76);
            pnFooter.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Location = new Point(0, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(957, 1);
            panel1.TabIndex = 9;
            // 
            // lblTotalProduct
            // 
            lblTotalProduct.AutoSize = true;
            lblTotalProduct.Cursor = Cursors.IBeam;
            lblTotalProduct.Location = new Point(357, 31);
            lblTotalProduct.Name = "lblTotalProduct";
            lblTotalProduct.Size = new Size(250, 22);
            lblTotalProduct.TabIndex = 20;
            lblTotalProduct.Text = "Tổng thanh toán (0 Sản phẩm):";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Cursor = Cursors.IBeam;
            lblTotalPrice.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.ForeColor = Color.OrangeRed;
            lblTotalPrice.Location = new Point(625, 28);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(78, 25);
            lblTotalPrice.TabIndex = 19;
            lblTotalPrice.Text = "167.00";
            // 
            // btnBuy
            // 
            btnBuy.BackColor = Color.OrangeRed;
            btnBuy.Cursor = Cursors.Hand;
            btnBuy.FlatStyle = FlatStyle.Flat;
            btnBuy.ForeColor = Color.White;
            btnBuy.Location = new Point(768, 17);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(196, 46);
            btnBuy.TabIndex = 18;
            btnBuy.Text = "Mua hàng";
            btnBuy.UseVisualStyleBackColor = false;
            btnBuy.Click += btnBuy_Click;
            // 
            // lblDelMul
            // 
            lblDelMul.AutoSize = true;
            lblDelMul.Cursor = Cursors.Hand;
            lblDelMul.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDelMul.ForeColor = Color.Black;
            lblDelMul.Location = new Point(222, 31);
            lblDelMul.Name = "lblDelMul";
            lblDelMul.Size = new Size(124, 22);
            lblDelMul.TabIndex = 17;
            lblDelMul.Text = "Xóa Giỏ Hàng";
            lblDelMul.Click += lblDelMul_Click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Cursor = Cursors.IBeam;
            lblCount.Location = new Point(58, 31);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(137, 22);
            lblCount.TabIndex = 10;
            lblCount.Text = "Chọn tất cả (19)";
            // 
            // cbxAllBot
            // 
            cbxAllBot.AutoSize = true;
            cbxAllBot.Location = new Point(25, 33);
            cbxAllBot.Name = "cbxAllBot";
            cbxAllBot.Size = new Size(18, 17);
            cbxAllBot.TabIndex = 9;
            cbxAllBot.TextAlign = ContentAlignment.MiddleCenter;
            cbxAllBot.UseVisualStyleBackColor = true;
            cbxAllBot.CheckedChanged += cbxAllBot_CheckedChanged;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.White;
            pnHeader.Controls.Add(lblThaoTac);
            pnHeader.Controls.Add(lblSoLuong);
            pnHeader.Controls.Add(lblSoTien);
            pnHeader.Controls.Add(lblDonGia);
            pnHeader.Controls.Add(lblSanPham);
            pnHeader.Controls.Add(cbxAll);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(964, 52);
            pnHeader.TabIndex = 11;
            // 
            // lblThaoTac
            // 
            lblThaoTac.AutoSize = true;
            lblThaoTac.Cursor = Cursors.IBeam;
            lblThaoTac.ForeColor = SystemColors.ControlDarkDark;
            lblThaoTac.Location = new Point(876, 16);
            lblThaoTac.Name = "lblThaoTac";
            lblThaoTac.Size = new Size(78, 22);
            lblThaoTac.TabIndex = 5;
            lblThaoTac.Text = "Thao tác";
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Cursor = Cursors.IBeam;
            lblSoLuong.ForeColor = SystemColors.ControlDarkDark;
            lblSoLuong.Location = new Point(675, 16);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(82, 22);
            lblSoLuong.TabIndex = 4;
            lblSoLuong.Text = "Số lượng";
            // 
            // lblSoTien
            // 
            lblSoTien.AutoSize = true;
            lblSoTien.Cursor = Cursors.IBeam;
            lblSoTien.ForeColor = SystemColors.ControlDarkDark;
            lblSoTien.Location = new Point(797, 16);
            lblSoTien.Name = "lblSoTien";
            lblSoTien.Size = new Size(65, 22);
            lblSoTien.TabIndex = 3;
            lblSoTien.Text = "Số tiền";
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Cursor = Cursors.IBeam;
            lblDonGia.ForeColor = SystemColors.ControlDarkDark;
            lblDonGia.Location = new Point(554, 16);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(73, 22);
            lblDonGia.TabIndex = 2;
            lblDonGia.Text = "Đơn giá";
            // 
            // lblSanPham
            // 
            lblSanPham.AutoSize = true;
            lblSanPham.Cursor = Cursors.IBeam;
            lblSanPham.Location = new Point(46, 18);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(86, 22);
            lblSanPham.TabIndex = 1;
            lblSanPham.Text = "Sản phẩm";
            // 
            // cbxAll
            // 
            cbxAll.AutoSize = true;
            cbxAll.Location = new Point(22, 21);
            cbxAll.Name = "cbxAll";
            cbxAll.Size = new Size(18, 17);
            cbxAll.TabIndex = 0;
            cbxAll.TextAlign = ContentAlignment.MiddleCenter;
            cbxAll.UseVisualStyleBackColor = true;
            // 
            // pnlChildFormCart
            // 
            pnlChildFormCart.Controls.Add(pnlProductList);
            pnlChildFormCart.Controls.Add(pnFooter);
            pnlChildFormCart.Controls.Add(pnHeader);
            pnlChildFormCart.Dock = DockStyle.Fill;
            pnlChildFormCart.Location = new Point(0, 0);
            pnlChildFormCart.Name = "pnlChildFormCart";
            pnlChildFormCart.Size = new Size(964, 538);
            pnlChildFormCart.TabIndex = 15;
            // 
            // Cart
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(964, 538);
            Controls.Add(pnlCart);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Cart";
            Text = "Cart";
            Load += Cart_Load;
            pnlCart.ResumeLayout(false);
            pnlProductList.ResumeLayout(false);
            pnlProduct.ResumeLayout(false);
            pnlProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            pnFooter.ResumeLayout(false);
            pnFooter.PerformLayout();
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            pnlChildFormCart.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCart;
        private Panel pnFooter;
        private Panel panel1;
        private Label lblTotalProduct;
        private Label lblTotalPrice;
        private Button btnBuy;
        private Label lblCount;
        private CheckBox cbxAllBot;
        private Panel pnlProduct;
        private Panel pnlTopLine;
        private Panel pnlRightLine;
        private Panel pnlBotLine;
        private Panel pnlLeftLine;
        private Label lblDelete;
        private Label lblPriceProduct;
        private Label lblCurrentPrice;
        private Label lblOldPrice;
        private Label lblColorSize;
        private Label lblPLH;
        private Panel pnNameProduct;
        private Label lblNameProduct;
        private Panel pnImgProduct;
        private PictureBox pictureBox1;
        private CheckBox cbxProduct;
        private Panel pnHeader;
        private Label lblThaoTac;
        private Label lblSoLuong;
        private Label lblSoTien;
        private Label lblDonGia;
        private Label lblSanPham;
        private CheckBox cbxAll;
        private Panel pnQuantuty;
        private Button btnIncrease;
        private Label lblQuantity;
        private Button btnDecrease;
        private Panel pnlProductList;
        private PictureBox pictureBoxProduct;
        private Panel pnlQuantuty;
        private Label lblDelMul;
        private Panel pnlChildFormCart;
    }
}