namespace Source.Views.Custommer
{
    partial class OrderInvoices
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
            pnlOrderInvoices = new Panel();
            panel2 = new Panel();
            pnlListOrders = new Panel();
            pnHeader = new Panel();
            lblReturn = new Label();
            lblCancel = new Label();
            lblWaitTran = new Label();
            lblFinish = new Label();
            lblTran = new Label();
            lblWaitPay = new Label();
            lblAll = new Label();
            pnSearch = new Panel();
            tbxSearch = new TextBox();
            imgSearch = new PictureBox();
            pnlOrderInvoices.SuspendLayout();
            panel2.SuspendLayout();
            pnHeader.SuspendLayout();
            pnSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgSearch).BeginInit();
            SuspendLayout();
            // 
            // pnlOrderInvoices
            // 
            pnlOrderInvoices.Controls.Add(panel2);
            pnlOrderInvoices.Dock = DockStyle.Fill;
            pnlOrderInvoices.Location = new Point(0, 0);
            pnlOrderInvoices.Name = "pnlOrderInvoices";
            pnlOrderInvoices.Size = new Size(964, 538);
            pnlOrderInvoices.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlListOrders);
            panel2.Controls.Add(pnHeader);
            panel2.Controls.Add(pnSearch);
            panel2.Location = new Point(0, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(964, 535);
            panel2.TabIndex = 0;
            // 
            // pnlListOrders
            // 
            pnlListOrders.AutoScroll = true;
            pnlListOrders.Dock = DockStyle.Bottom;
            pnlListOrders.Location = new Point(0, 143);
            pnlListOrders.Name = "pnlListOrders";
            pnlListOrders.Size = new Size(964, 392);
            pnlListOrders.TabIndex = 7;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.White;
            pnHeader.Controls.Add(lblReturn);
            pnHeader.Controls.Add(lblCancel);
            pnHeader.Controls.Add(lblWaitTran);
            pnHeader.Controls.Add(lblFinish);
            pnHeader.Controls.Add(lblTran);
            pnHeader.Controls.Add(lblWaitPay);
            pnHeader.Controls.Add(lblAll);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Margin = new Padding(4, 3, 4, 3);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(964, 59);
            pnHeader.TabIndex = 4;
            // 
            // lblReturn
            // 
            lblReturn.AutoSize = true;
            lblReturn.Cursor = Cursors.Hand;
            lblReturn.Location = new Point(792, 21);
            lblReturn.Name = "lblReturn";
            lblReturn.Size = new Size(160, 22);
            lblReturn.TabIndex = 6;
            lblReturn.Text = "Trả hàng/ hoàn tiền";
            // 
            // lblCancel
            // 
            lblCancel.AutoSize = true;
            lblCancel.Cursor = Cursors.Hand;
            lblCancel.Location = new Point(704, 21);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size(65, 22);
            lblCancel.TabIndex = 5;
            lblCancel.Text = "Đã hủy";
            // 
            // lblWaitTran
            // 
            lblWaitTran.AutoSize = true;
            lblWaitTran.Cursor = Cursors.Hand;
            lblWaitTran.Location = new Point(419, 21);
            lblWaitTran.Name = "lblWaitTran";
            lblWaitTran.Size = new Size(123, 22);
            lblWaitTran.TabIndex = 4;
            lblWaitTran.Text = "Chờ giao hàng";
            // 
            // lblFinish
            // 
            lblFinish.AutoSize = true;
            lblFinish.Cursor = Cursors.Hand;
            lblFinish.Location = new Point(571, 21);
            lblFinish.Name = "lblFinish";
            lblFinish.Size = new Size(98, 22);
            lblFinish.TabIndex = 3;
            lblFinish.Text = "Hoàn thành";
            // 
            // lblTran
            // 
            lblTran.AutoSize = true;
            lblTran.Cursor = Cursors.Hand;
            lblTran.Location = new Point(281, 21);
            lblTran.Name = "lblTran";
            lblTran.Size = new Size(100, 22);
            lblTran.TabIndex = 2;
            lblTran.Text = "Vận chuyển";
            // 
            // lblWaitPay
            // 
            lblWaitPay.AutoSize = true;
            lblWaitPay.Cursor = Cursors.Hand;
            lblWaitPay.Location = new Point(114, 21);
            lblWaitPay.Name = "lblWaitPay";
            lblWaitPay.Size = new Size(127, 22);
            lblWaitPay.TabIndex = 1;
            lblWaitPay.Text = "Chờ thanh toán";
            // 
            // lblAll
            // 
            lblAll.AutoSize = true;
            lblAll.Cursor = Cursors.Hand;
            lblAll.Location = new Point(23, 21);
            lblAll.Name = "lblAll";
            lblAll.Size = new Size(59, 22);
            lblAll.TabIndex = 0;
            lblAll.Text = "Tất cả";
            // 
            // pnSearch
            // 
            pnSearch.BackColor = Color.FromArgb(234, 234, 234);
            pnSearch.Controls.Add(tbxSearch);
            pnSearch.Controls.Add(imgSearch);
            pnSearch.Location = new Point(0, 82);
            pnSearch.Name = "pnSearch";
            pnSearch.Size = new Size(961, 31);
            pnSearch.TabIndex = 6;
            // 
            // tbxSearch
            // 
            tbxSearch.BackColor = Color.FromArgb(234, 234, 234);
            tbxSearch.BorderStyle = BorderStyle.None;
            tbxSearch.Cursor = Cursors.IBeam;
            tbxSearch.Location = new Point(94, 3);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.PlaceholderText = "Bạn có thể tìm kiếm theo tên đơn hàng hoặc tên sản phẩm";
            tbxSearch.Size = new Size(864, 23);
            tbxSearch.TabIndex = 2;
            // 
            // imgSearch
            // 
            imgSearch.Dock = DockStyle.Left;
            imgSearch.Image = Properties.Resources.kinhlup;
            imgSearch.Location = new Point(0, 0);
            imgSearch.Name = "imgSearch";
            imgSearch.Size = new Size(88, 31);
            imgSearch.SizeMode = PictureBoxSizeMode.Zoom;
            imgSearch.TabIndex = 1;
            imgSearch.TabStop = false;
            // 
            // OrderInvoices
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(964, 538);
            Controls.Add(pnlOrderInvoices);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrderInvoices";
            Text = "OrderInvoices";
            Load += OrderInvoices_Load;
            pnlOrderInvoices.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            pnSearch.ResumeLayout(false);
            pnSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgSearch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlOrderInvoices;
        private Panel panel2;
        private Panel pnHeader;
        private Label lblReturn;
        private Label lblCancel;
        private Label lblWaitTran;
        private Label lblFinish;
        private Label lblTran;
        private Label lblWaitPay;
        private Label lblAll;
        private Panel pnSearch;
        private TextBox tbxSearch;
        private PictureBox imgSearch;
        private Panel pnlListOrders;
    }
}