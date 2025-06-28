namespace Source.Views.Custommer
{
    partial class ReviewProduct
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
            pnlReviewProduct = new Panel();
            btnReturn = new Button();
            pnReview = new Panel();
            lblNote = new Label();
            tbxReview = new TextBox();
            btnDone = new Button();
            pnQuality = new Panel();
            lblQuality = new Label();
            pnStar = new Panel();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            picbxStar = new PictureBox();
            lblChatLuong = new Label();
            pnProduct = new Panel();
            pnTop = new Panel();
            pnImage = new Panel();
            imageProduct = new PictureBox();
            lblQuantity = new Label();
            lblColorSize = new Label();
            lblClassify = new Label();
            lblNameProduct = new Label();
            lblHeader = new Label();
            pnlReviewProduct.SuspendLayout();
            pnReview.SuspendLayout();
            pnQuality.SuspendLayout();
            pnStar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picbxStar).BeginInit();
            pnProduct.SuspendLayout();
            pnTop.SuspendLayout();
            pnImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageProduct).BeginInit();
            SuspendLayout();
            // 
            // pnlReviewProduct
            // 
            pnlReviewProduct.Controls.Add(btnReturn);
            pnlReviewProduct.Controls.Add(pnReview);
            pnlReviewProduct.Controls.Add(btnDone);
            pnlReviewProduct.Controls.Add(pnQuality);
            pnlReviewProduct.Controls.Add(pnProduct);
            pnlReviewProduct.Controls.Add(lblHeader);
            pnlReviewProduct.Dock = DockStyle.Fill;
            pnlReviewProduct.Location = new Point(0, 0);
            pnlReviewProduct.Name = "pnlReviewProduct";
            pnlReviewProduct.Size = new Size(827, 538);
            pnlReviewProduct.TabIndex = 0;
            // 
            // btnReturn
            // 
            btnReturn.AutoSize = true;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.Location = new Point(460, 482);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(109, 46);
            btnReturn.TabIndex = 26;
            btnReturn.Text = "Trở lại";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // pnReview
            // 
            pnReview.BackColor = Color.WhiteSmoke;
            pnReview.Controls.Add(lblNote);
            pnReview.Controls.Add(tbxReview);
            pnReview.Location = new Point(37, 222);
            pnReview.Name = "pnReview";
            pnReview.Size = new Size(753, 237);
            pnReview.TabIndex = 24;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Cursor = Cursors.IBeam;
            lblNote.ForeColor = SystemColors.ControlDarkDark;
            lblNote.Location = new Point(278, 203);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(449, 22);
            lblNote.TabIndex = 1;
            lblNote.Text = "Hãy nhập tối thiểu 50 ký tự để đánh giá được duyệt nhé!";
            // 
            // tbxReview
            // 
            tbxReview.Cursor = Cursors.IBeam;
            tbxReview.Location = new Point(28, 18);
            tbxReview.Multiline = true;
            tbxReview.Name = "tbxReview";
            tbxReview.PlaceholderText = "  Hãy chia sẻ những điều bạn thích về sản phẩm này với những người mua khác nhé.";
            tbxReview.Size = new Size(699, 163);
            tbxReview.TabIndex = 0;
            // 
            // btnDone
            // 
            btnDone.BackColor = Color.OrangeRed;
            btnDone.Cursor = Cursors.Hand;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.ForeColor = Color.White;
            btnDone.Location = new Point(594, 482);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(196, 46);
            btnDone.TabIndex = 25;
            btnDone.Text = "Hoàn thành";
            btnDone.UseVisualStyleBackColor = false;
            // 
            // pnQuality
            // 
            pnQuality.Controls.Add(lblQuality);
            pnQuality.Controls.Add(pnStar);
            pnQuality.Controls.Add(lblChatLuong);
            pnQuality.Location = new Point(37, 160);
            pnQuality.Name = "pnQuality";
            pnQuality.Size = new Size(753, 47);
            pnQuality.TabIndex = 23;
            // 
            // lblQuality
            // 
            lblQuality.AutoSize = true;
            lblQuality.Cursor = Cursors.IBeam;
            lblQuality.ForeColor = Color.FromArgb(228, 173, 63);
            lblQuality.Location = new Point(378, 11);
            lblQuality.Name = "lblQuality";
            lblQuality.Size = new Size(85, 22);
            lblQuality.TabIndex = 4;
            lblQuality.Text = "Tuyệt vời";
            // 
            // pnStar
            // 
            pnStar.Controls.Add(pictureBox6);
            pnStar.Controls.Add(pictureBox5);
            pnStar.Controls.Add(pictureBox4);
            pnStar.Controls.Add(pictureBox3);
            pnStar.Controls.Add(picbxStar);
            pnStar.Cursor = Cursors.Hand;
            pnStar.Location = new Point(211, 3);
            pnStar.Name = "pnStar";
            pnStar.Size = new Size(136, 37);
            pnStar.TabIndex = 3;
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
            // lblChatLuong
            // 
            lblChatLuong.AutoSize = true;
            lblChatLuong.Cursor = Cursors.IBeam;
            lblChatLuong.Location = new Point(4, 11);
            lblChatLuong.Name = "lblChatLuong";
            lblChatLuong.Size = new Size(175, 22);
            lblChatLuong.TabIndex = 0;
            lblChatLuong.Text = "Chất lượng sản phẩm";
            // 
            // pnProduct
            // 
            pnProduct.Controls.Add(pnTop);
            pnProduct.Location = new Point(37, 62);
            pnProduct.Name = "pnProduct";
            pnProduct.Size = new Size(753, 80);
            pnProduct.TabIndex = 22;
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.White;
            pnTop.Controls.Add(pnImage);
            pnTop.Controls.Add(lblQuantity);
            pnTop.Controls.Add(lblColorSize);
            pnTop.Controls.Add(lblClassify);
            pnTop.Controls.Add(lblNameProduct);
            pnTop.Cursor = Cursors.Hand;
            pnTop.Location = new Point(3, 3);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(750, 78);
            pnTop.TabIndex = 1;
            // 
            // pnImage
            // 
            pnImage.Controls.Add(imageProduct);
            pnImage.Dock = DockStyle.Left;
            pnImage.Location = new Point(0, 0);
            pnImage.Name = "pnImage";
            pnImage.Size = new Size(149, 78);
            pnImage.TabIndex = 6;
            // 
            // imageProduct
            // 
            imageProduct.Dock = DockStyle.Fill;
            imageProduct.Image = Properties.Resources.capybara3;
            imageProduct.Location = new Point(0, 0);
            imageProduct.Name = "imageProduct";
            imageProduct.Size = new Size(149, 78);
            imageProduct.SizeMode = PictureBoxSizeMode.Zoom;
            imageProduct.TabIndex = 0;
            imageProduct.TabStop = false;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(155, 56);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(29, 22);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "x1";
            // 
            // lblColorSize
            // 
            lblColorSize.AutoSize = true;
            lblColorSize.ForeColor = SystemColors.ControlDarkDark;
            lblColorSize.Location = new Point(288, 34);
            lblColorSize.Name = "lblColorSize";
            lblColorSize.Size = new Size(55, 22);
            lblColorSize.TabIndex = 3;
            lblColorSize.Text = "Đỏ, L";
            // 
            // lblClassify
            // 
            lblClassify.AutoSize = true;
            lblClassify.ForeColor = SystemColors.ControlDarkDark;
            lblClassify.Location = new Point(155, 34);
            lblClassify.Name = "lblClassify";
            lblClassify.Size = new Size(136, 22);
            lblClassify.TabIndex = 2;
            lblClassify.Text = "Phân loại hàng: ";
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
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Cursor = Cursors.IBeam;
            lblHeader.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(37, 11);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(246, 32);
            lblHeader.TabIndex = 21;
            lblHeader.Text = "Đánh giá sản phẩm";
            // 
            // ReviewProduct
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(827, 538);
            Controls.Add(pnlReviewProduct);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ReviewProduct";
            Text = "ReviewProduct";
            pnlReviewProduct.ResumeLayout(false);
            pnlReviewProduct.PerformLayout();
            pnReview.ResumeLayout(false);
            pnReview.PerformLayout();
            pnQuality.ResumeLayout(false);
            pnQuality.PerformLayout();
            pnStar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picbxStar).EndInit();
            pnProduct.ResumeLayout(false);
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imageProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlReviewProduct;
        private Button btnReturn;
        private Panel pnReview;
        private Label lblNote;
        private TextBox tbxReview;
        private Button btnDone;
        private Panel pnQuality;
        private Label lblQuality;
        private Panel pnStar;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox picbxStar;
        private Label lblChatLuong;
        private Panel pnProduct;
        private Panel pnTop;
        private Panel pnImage;
        private PictureBox imageProduct;
        private Label lblQuantity;
        private Label lblColorSize;
        private Label lblClassify;
        private Label lblNameProduct;
        private Label lblHeader;
    }
}