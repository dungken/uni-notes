namespace Source.Views
{
    partial class MainFormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormAdmin));
            Guna.Charts.WinForms.ChartFont chartFont1 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont2 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont3 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont4 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid1 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick1 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont5 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid2 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick2 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont6 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid3 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel1 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont7 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick3 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont8 = new Guna.Charts.WinForms.ChartFont();
            lblNavigation = new Label();
            label5 = new Label();
            btnProducts = new Button();
            btnHome = new Button();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCustomers = new Button();
            btnOrders = new Button();
            btnCategories = new Button();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBoxLogo = new PictureBox();
            panel2 = new Panel();
            label11 = new Label();
            label9 = new Label();
            label8 = new Label();
            pictureBox2 = new PictureBox();
            lblAvarata = new Label();
            lblNotifications = new Label();
            label7 = new Label();
            lblNavigationImage = new Label();
            panel1 = new Panel();
            btnLogOut = new Button();
            btnSetting = new Button();
            btnDiscount = new Button();
            btnSale = new Button();
            pnlChildForm = new Panel();
            lblYear = new Label();
            cbxYear = new ComboBox();
            rbtnExport = new MyCustomControl.RJButton();
            gunaChart = new Guna.Charts.WinForms.GunaChart();
            gunaBarDataset = new Guna.Charts.WinForms.GunaBarDataset();
            pnThongKe = new Panel();
            lblTotalProductV = new Label();
            lblTotalProduct = new Label();
            rbtnTotalProduct = new MyCustomControl.RJButton();
            lblTotalSaleV = new Label();
            lblTotalSale = new Label();
            rbtnTotalSale = new MyCustomControl.RJButton();
            lblItemSaleV = new Label();
            lblAvgItemSale = new Label();
            rbtnAvgItemSale = new MyCustomControl.RJButton();
            lblAvgSaleV = new Label();
            label10 = new Label();
            rbtnAvgSale = new MyCustomControl.RJButton();
            lblOrderV = new Label();
            lblOrder = new Label();
            lblCustomerV = new Label();
            lblCustomer = new Label();
            rbtnCustomer = new MyCustomControl.RJButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            rbtnOrder = new MyCustomControl.RJButton();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            pnlChildForm.SuspendLayout();
            pnThongKe.SuspendLayout();
            SuspendLayout();
            // 
            // lblNavigation
            // 
            lblNavigation.AutoSize = true;
            lblNavigation.ForeColor = Color.Transparent;
            lblNavigation.Location = new Point(75, 38);
            lblNavigation.Name = "lblNavigation";
            lblNavigation.Size = new Size(51, 20);
            lblNavigation.TabIndex = 7;
            lblNavigation.Text = "Home";
            // 
            // label5
            // 
            label5.Location = new Point(730, 26);
            label5.Name = "label5";
            label5.Size = new Size(32, 40);
            label5.TabIndex = 4;
            label5.Text = "          ";
            // 
            // btnProducts
            // 
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnProducts.ForeColor = Color.White;
            btnProducts.Image = Properties.Resources._45506_box_delivery_package_product_shipment_icon;
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(0, 131);
            btnProducts.Margin = new Padding(4, 3, 4, 3);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(221, 50);
            btnProducts.TabIndex = 3;
            btnProducts.Text = "         Products";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Image = Properties.Resources.icon_home;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 81);
            btnHome.Margin = new Padding(4, 3, 4, 3);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(221, 50);
            btnHome.TabIndex = 1;
            btnHome.Text = "         Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // label6
            // 
            label6.Location = new Point(508, 26);
            label6.Name = "label6";
            label6.Size = new Size(50, 40);
            label6.TabIndex = 4;
            label6.Text = "          ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(831, 46);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 5;
            label4.Text = "Admin";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(836, 26);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.Location = new Point(639, 26);
            label2.Name = "label2";
            label2.Size = new Size(42, 40);
            label2.TabIndex = 3;
            label2.Text = "          ";
            // 
            // btnCustomers
            // 
            btnCustomers.Dock = DockStyle.Top;
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.Image = (Image)resources.GetObject("btnCustomers.Image");
            btnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomers.Location = new Point(0, 281);
            btnCustomers.Margin = new Padding(4, 3, 4, 3);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(221, 50);
            btnCustomers.TabIndex = 8;
            btnCustomers.Text = "         Customers";
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnOrders
            // 
            btnOrders.Dock = DockStyle.Top;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnOrders.ForeColor = Color.White;
            btnOrders.Image = Properties.Resources.icon_invoice;
            btnOrders.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrders.Location = new Point(0, 231);
            btnOrders.Margin = new Padding(4, 3, 4, 3);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(221, 50);
            btnOrders.TabIndex = 7;
            btnOrders.Text = "         Orders";
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnCategories
            // 
            btnCategories.Dock = DockStyle.Top;
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnCategories.ForeColor = Color.White;
            btnCategories.Image = (Image)resources.GetObject("btnCategories.Image");
            btnCategories.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategories.Location = new Point(0, 181);
            btnCategories.Margin = new Padding(4, 3, 4, 3);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(221, 50);
            btnCategories.TabIndex = 5;
            btnCategories.Text = "         Categories";
            btnCategories.TextAlign = ContentAlignment.MiddleLeft;
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // label1
            // 
            label1.Location = new Point(893, 26);
            label1.Name = "label1";
            label1.Size = new Size(42, 40);
            label1.TabIndex = 0;
            label1.Text = "          ";
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox3);
            panel4.Controls.Add(pictureBoxLogo);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(221, 81);
            panel4.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.logo;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(221, 80);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Dock = DockStyle.Top;
            pictureBoxLogo.Location = new Point(0, 0);
            pictureBoxLogo.Margin = new Padding(4, 3, 4, 3);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(221, 80);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(162, 185, 237);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(lblAvarata);
            panel2.Controls.Add(lblNotifications);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(lblNavigationImage);
            panel2.Controls.Add(lblNavigation);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel2.Location = new Point(221, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1015, 77);
            panel2.TabIndex = 5;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(64, 64, 0);
            label11.Location = new Point(342, 31);
            label11.Name = "label11";
            label11.Size = new Size(203, 43);
            label11.TabIndex = 15;
            label11.Text = "PHÁT ĐẠT";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(64, 64, 0);
            label9.Location = new Point(191, 7);
            label9.Name = "label9";
            label9.Size = new Size(170, 43);
            label9.TabIndex = 14;
            label9.Text = "LÀM ĂN ";
            // 
            // label8
            // 
            label8.Image = Properties.Resources.icon_home;
            label8.Location = new Point(19, 26);
            label8.Name = "label8";
            label8.Size = new Size(50, 40);
            label8.TabIndex = 13;
            label8.Text = "          ";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.imagesHome;
            pictureBox2.Location = new Point(601, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 72);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // lblAvarata
            // 
            lblAvarata.Anchor = AnchorStyles.Right;
            lblAvarata.Cursor = Cursors.Hand;
            lblAvarata.Image = Properties.Resources.ImageAvarata;
            lblAvarata.Location = new Point(941, 26);
            lblAvarata.Name = "lblAvarata";
            lblAvarata.Size = new Size(42, 40);
            lblAvarata.TabIndex = 11;
            lblAvarata.Text = "          ";
            // 
            // lblNotifications
            // 
            lblNotifications.Anchor = AnchorStyles.Right;
            lblNotifications.Image = Properties.Resources.bell;
            lblNotifications.Location = new Point(776, 26);
            lblNotifications.Name = "lblNotifications";
            lblNotifications.Size = new Size(32, 40);
            lblNotifications.TabIndex = 10;
            lblNotifications.Text = "          ";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.Image = Properties.Resources.circle;
            label7.Location = new Point(720, 26);
            label7.Name = "label7";
            label7.Size = new Size(42, 40);
            label7.TabIndex = 9;
            label7.Text = "          ";
            // 
            // lblNavigationImage
            // 
            lblNavigationImage.Location = new Point(7, 26);
            lblNavigationImage.Name = "lblNavigationImage";
            lblNavigationImage.Size = new Size(50, 40);
            lblNavigationImage.TabIndex = 8;
            lblNavigationImage.Text = "          ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(154, 156, 233);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(btnSetting);
            panel1.Controls.Add(btnDiscount);
            panel1.Controls.Add(btnSale);
            panel1.Controls.Add(btnCustomers);
            panel1.Controls.Add(btnOrders);
            panel1.Controls.Add(btnCategories);
            panel1.Controls.Add(btnProducts);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 628);
            panel1.TabIndex = 4;
            // 
            // btnLogOut
            // 
            btnLogOut.Dock = DockStyle.Bottom;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Image = Properties.Resources.icon_exit;
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.Location = new Point(0, 578);
            btnLogOut.Margin = new Padding(4, 3, 4, 3);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(221, 50);
            btnLogOut.TabIndex = 12;
            btnLogOut.Text = "         Log out";
            btnLogOut.TextAlign = ContentAlignment.MiddleLeft;
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnSetting
            // 
            btnSetting.Dock = DockStyle.Top;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnSetting.ForeColor = Color.White;
            btnSetting.Image = Properties.Resources.icon_setting;
            btnSetting.ImageAlign = ContentAlignment.MiddleLeft;
            btnSetting.Location = new Point(0, 431);
            btnSetting.Margin = new Padding(4, 3, 4, 3);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(221, 50);
            btnSetting.TabIndex = 11;
            btnSetting.Text = "         Setting";
            btnSetting.TextAlign = ContentAlignment.MiddleLeft;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // btnDiscount
            // 
            btnDiscount.Dock = DockStyle.Top;
            btnDiscount.FlatAppearance.BorderSize = 0;
            btnDiscount.FlatStyle = FlatStyle.Flat;
            btnDiscount.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnDiscount.ForeColor = Color.White;
            btnDiscount.Image = (Image)resources.GetObject("btnDiscount.Image");
            btnDiscount.ImageAlign = ContentAlignment.MiddleLeft;
            btnDiscount.Location = new Point(0, 381);
            btnDiscount.Margin = new Padding(4, 3, 4, 3);
            btnDiscount.Name = "btnDiscount";
            btnDiscount.Size = new Size(221, 50);
            btnDiscount.TabIndex = 10;
            btnDiscount.Text = "         Discount";
            btnDiscount.TextAlign = ContentAlignment.MiddleLeft;
            btnDiscount.UseVisualStyleBackColor = true;
            btnDiscount.Click += btnDiscount_Click;
            // 
            // btnSale
            // 
            btnSale.Dock = DockStyle.Top;
            btnSale.FlatAppearance.BorderSize = 0;
            btnSale.FlatStyle = FlatStyle.Flat;
            btnSale.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnSale.ForeColor = Color.White;
            btnSale.Image = Properties.Resources.voucher;
            btnSale.ImageAlign = ContentAlignment.MiddleLeft;
            btnSale.Location = new Point(0, 331);
            btnSale.Margin = new Padding(4, 3, 4, 3);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(221, 50);
            btnSale.TabIndex = 9;
            btnSale.Text = "         Sales Promotion";
            btnSale.TextAlign = ContentAlignment.MiddleLeft;
            btnSale.UseVisualStyleBackColor = true;
            btnSale.Click += btnSale_Click;
            // 
            // pnlChildForm
            // 
            pnlChildForm.BackColor = Color.FromArgb(249, 251, 253);
            pnlChildForm.Controls.Add(lblYear);
            pnlChildForm.Controls.Add(cbxYear);
            pnlChildForm.Controls.Add(rbtnExport);
            pnlChildForm.Controls.Add(gunaChart);
            pnlChildForm.Controls.Add(pnThongKe);
            pnlChildForm.Dock = DockStyle.Fill;
            pnlChildForm.Location = new Point(221, 77);
            pnlChildForm.Name = "pnlChildForm";
            pnlChildForm.Size = new Size(1015, 551);
            pnlChildForm.TabIndex = 23;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYear.Location = new Point(98, 123);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(53, 22);
            lblYear.TabIndex = 26;
            lblYear.Text = "Year:";
            // 
            // cbxYear
            // 
            cbxYear.FormattingEnabled = true;
            cbxYear.Location = new Point(164, 117);
            cbxYear.Name = "cbxYear";
            cbxYear.Size = new Size(151, 28);
            cbxYear.TabIndex = 25;
            cbxYear.SelectedIndexChanged += cbxYear_SelectedIndexChanged;
            // 
            // rbtnExport
            // 
            rbtnExport.BackColor = Color.MediumSlateBlue;
            rbtnExport.BackgroundColor = Color.MediumSlateBlue;
            rbtnExport.BorderColor = Color.PaleVioletRed;
            rbtnExport.BorderRadius = 20;
            rbtnExport.BorderSize = 0;
            rbtnExport.FlatAppearance.BorderSize = 0;
            rbtnExport.FlatStyle = FlatStyle.Flat;
            rbtnExport.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnExport.ForeColor = Color.White;
            rbtnExport.Location = new Point(819, 111);
            rbtnExport.Name = "rbtnExport";
            rbtnExport.Size = new Size(138, 34);
            rbtnExport.TabIndex = 23;
            rbtnExport.Text = "Export";
            rbtnExport.TextColor = Color.White;
            rbtnExport.UseVisualStyleBackColor = false;
            rbtnExport.Click += rbtnExport_Click;
            // 
            // gunaChart
            // 
            gunaChart.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { gunaBarDataset });
            chartFont1.FontName = "Arial";
            gunaChart.Legend.LabelFont = chartFont1;
            gunaChart.Location = new Point(19, 151);
            gunaChart.Name = "gunaChart";
            gunaChart.Size = new Size(964, 397);
            gunaChart.TabIndex = 24;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            gunaChart.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            gunaChart.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            gunaChart.Tooltips.TitleFont = chartFont4;
            gunaChart.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            gunaChart.XAxes.Ticks = tick1;
            gunaChart.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            gunaChart.YAxes.Ticks = tick2;
            gunaChart.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            gunaChart.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            gunaChart.ZAxes.Ticks = tick3;
            // 
            // gunaBarDataset
            // 
            gunaBarDataset.Label = "Bar1";
            gunaBarDataset.TargetChart = gunaChart;
            // 
            // pnThongKe
            // 
            pnThongKe.Controls.Add(lblTotalProductV);
            pnThongKe.Controls.Add(lblTotalProduct);
            pnThongKe.Controls.Add(rbtnTotalProduct);
            pnThongKe.Controls.Add(lblTotalSaleV);
            pnThongKe.Controls.Add(lblTotalSale);
            pnThongKe.Controls.Add(rbtnTotalSale);
            pnThongKe.Controls.Add(lblItemSaleV);
            pnThongKe.Controls.Add(lblAvgItemSale);
            pnThongKe.Controls.Add(rbtnAvgItemSale);
            pnThongKe.Controls.Add(lblAvgSaleV);
            pnThongKe.Controls.Add(label10);
            pnThongKe.Controls.Add(rbtnAvgSale);
            pnThongKe.Controls.Add(lblOrderV);
            pnThongKe.Controls.Add(lblOrder);
            pnThongKe.Controls.Add(lblCustomerV);
            pnThongKe.Controls.Add(lblCustomer);
            pnThongKe.Controls.Add(rbtnCustomer);
            pnThongKe.Controls.Add(iconButton1);
            pnThongKe.Controls.Add(rbtnOrder);
            pnThongKe.Location = new Point(0, 0);
            pnThongKe.Name = "pnThongKe";
            pnThongKe.Size = new Size(1015, 105);
            pnThongKe.TabIndex = 22;
            // 
            // lblTotalProductV
            // 
            lblTotalProductV.AutoSize = true;
            lblTotalProductV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalProductV.ForeColor = Color.Black;
            lblTotalProductV.Location = new Point(797, 61);
            lblTotalProductV.Name = "lblTotalProductV";
            lblTotalProductV.Size = new Size(30, 22);
            lblTotalProductV.TabIndex = 39;
            lblTotalProductV.Text = "56";
            // 
            // lblTotalProduct
            // 
            lblTotalProduct.AutoSize = true;
            lblTotalProduct.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalProduct.ForeColor = SystemColors.ControlDarkDark;
            lblTotalProduct.Location = new Point(797, 25);
            lblTotalProduct.Name = "lblTotalProduct";
            lblTotalProduct.Size = new Size(117, 22);
            lblTotalProduct.TabIndex = 38;
            lblTotalProduct.Text = "Total Product";
            // 
            // rbtnTotalProduct
            // 
            rbtnTotalProduct.BackColor = Color.White;
            rbtnTotalProduct.BackgroundColor = Color.White;
            rbtnTotalProduct.BorderColor = Color.Silver;
            rbtnTotalProduct.BorderRadius = 10;
            rbtnTotalProduct.BorderSize = 1;
            rbtnTotalProduct.FlatAppearance.BorderSize = 0;
            rbtnTotalProduct.FlatStyle = FlatStyle.Flat;
            rbtnTotalProduct.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnTotalProduct.ForeColor = Color.Black;
            rbtnTotalProduct.Location = new Point(786, 6);
            rbtnTotalProduct.Name = "rbtnTotalProduct";
            rbtnTotalProduct.Size = new Size(151, 83);
            rbtnTotalProduct.TabIndex = 37;
            rbtnTotalProduct.TextAlign = ContentAlignment.TopCenter;
            rbtnTotalProduct.TextColor = Color.Black;
            rbtnTotalProduct.UseVisualStyleBackColor = false;
            // 
            // lblTotalSaleV
            // 
            lblTotalSaleV.AutoSize = true;
            lblTotalSaleV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSaleV.ForeColor = Color.Black;
            lblTotalSaleV.Location = new Point(331, 61);
            lblTotalSaleV.Name = "lblTotalSaleV";
            lblTotalSaleV.Size = new Size(30, 22);
            lblTotalSaleV.TabIndex = 36;
            lblTotalSaleV.Text = "67";
            // 
            // lblTotalSale
            // 
            lblTotalSale.AutoSize = true;
            lblTotalSale.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSale.ForeColor = SystemColors.ControlDarkDark;
            lblTotalSale.Location = new Point(331, 25);
            lblTotalSale.Name = "lblTotalSale";
            lblTotalSale.Size = new Size(91, 22);
            lblTotalSale.TabIndex = 35;
            lblTotalSale.Text = "Total Sale";
            // 
            // rbtnTotalSale
            // 
            rbtnTotalSale.BackColor = Color.White;
            rbtnTotalSale.BackgroundColor = Color.White;
            rbtnTotalSale.BorderColor = Color.Silver;
            rbtnTotalSale.BorderRadius = 10;
            rbtnTotalSale.BorderSize = 1;
            rbtnTotalSale.FlatAppearance.BorderSize = 0;
            rbtnTotalSale.FlatStyle = FlatStyle.Flat;
            rbtnTotalSale.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnTotalSale.ForeColor = Color.Black;
            rbtnTotalSale.Location = new Point(314, 6);
            rbtnTotalSale.Name = "rbtnTotalSale";
            rbtnTotalSale.Size = new Size(151, 83);
            rbtnTotalSale.TabIndex = 34;
            rbtnTotalSale.TextAlign = ContentAlignment.TopCenter;
            rbtnTotalSale.TextColor = Color.Black;
            rbtnTotalSale.UseVisualStyleBackColor = false;
            // 
            // lblItemSaleV
            // 
            lblItemSaleV.AutoSize = true;
            lblItemSaleV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblItemSaleV.ForeColor = Color.Black;
            lblItemSaleV.Location = new Point(644, 61);
            lblItemSaleV.Name = "lblItemSaleV";
            lblItemSaleV.Size = new Size(30, 22);
            lblItemSaleV.TabIndex = 33;
            lblItemSaleV.Text = "89";
            // 
            // lblAvgItemSale
            // 
            lblAvgItemSale.AutoSize = true;
            lblAvgItemSale.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvgItemSale.ForeColor = SystemColors.ControlDarkDark;
            lblAvgItemSale.Location = new Point(634, 25);
            lblAvgItemSale.Name = "lblAvgItemSale";
            lblAvgItemSale.Size = new Size(121, 22);
            lblAvgItemSale.TabIndex = 32;
            lblAvgItemSale.Text = "Avg Item Sale";
            // 
            // rbtnAvgItemSale
            // 
            rbtnAvgItemSale.BackColor = Color.White;
            rbtnAvgItemSale.BackgroundColor = Color.White;
            rbtnAvgItemSale.BorderColor = Color.Silver;
            rbtnAvgItemSale.BorderRadius = 10;
            rbtnAvgItemSale.BorderSize = 1;
            rbtnAvgItemSale.FlatAppearance.BorderSize = 0;
            rbtnAvgItemSale.FlatStyle = FlatStyle.Flat;
            rbtnAvgItemSale.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnAvgItemSale.ForeColor = Color.Black;
            rbtnAvgItemSale.Location = new Point(628, 6);
            rbtnAvgItemSale.Name = "rbtnAvgItemSale";
            rbtnAvgItemSale.Size = new Size(151, 83);
            rbtnAvgItemSale.TabIndex = 31;
            rbtnAvgItemSale.TextAlign = ContentAlignment.TopCenter;
            rbtnAvgItemSale.TextColor = Color.Black;
            rbtnAvgItemSale.UseVisualStyleBackColor = false;
            // 
            // lblAvgSaleV
            // 
            lblAvgSaleV.AutoSize = true;
            lblAvgSaleV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvgSaleV.ForeColor = Color.Black;
            lblAvgSaleV.Location = new Point(170, 61);
            lblAvgSaleV.Name = "lblAvgSaleV";
            lblAvgSaleV.Size = new Size(30, 22);
            lblAvgSaleV.TabIndex = 30;
            lblAvgSaleV.Text = "78";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(164, 25);
            label10.Name = "label10";
            label10.Size = new Size(82, 22);
            label10.TabIndex = 29;
            label10.Text = "Avg Sale";
            // 
            // rbtnAvgSale
            // 
            rbtnAvgSale.BackColor = Color.White;
            rbtnAvgSale.BackgroundColor = Color.White;
            rbtnAvgSale.BorderColor = Color.Silver;
            rbtnAvgSale.BorderRadius = 10;
            rbtnAvgSale.BorderSize = 1;
            rbtnAvgSale.FlatAppearance.BorderSize = 0;
            rbtnAvgSale.FlatStyle = FlatStyle.Flat;
            rbtnAvgSale.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnAvgSale.ForeColor = Color.Black;
            rbtnAvgSale.Location = new Point(157, 3);
            rbtnAvgSale.Name = "rbtnAvgSale";
            rbtnAvgSale.Size = new Size(151, 83);
            rbtnAvgSale.TabIndex = 28;
            rbtnAvgSale.TextAlign = ContentAlignment.TopCenter;
            rbtnAvgSale.TextColor = Color.Black;
            rbtnAvgSale.UseVisualStyleBackColor = false;
            // 
            // lblOrderV
            // 
            lblOrderV.AutoSize = true;
            lblOrderV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderV.ForeColor = Color.Black;
            lblOrderV.Location = new Point(491, 61);
            lblOrderV.Name = "lblOrderV";
            lblOrderV.Size = new Size(30, 22);
            lblOrderV.TabIndex = 27;
            lblOrderV.Text = "56";
            // 
            // lblOrder
            // 
            lblOrder.AutoSize = true;
            lblOrder.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrder.ForeColor = SystemColors.ControlDarkDark;
            lblOrder.Location = new Point(488, 25);
            lblOrder.Name = "lblOrder";
            lblOrder.Size = new Size(57, 22);
            lblOrder.TabIndex = 26;
            lblOrder.Text = "Order";
            // 
            // lblCustomerV
            // 
            lblCustomerV.AutoSize = true;
            lblCustomerV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerV.ForeColor = Color.Black;
            lblCustomerV.Location = new Point(12, 61);
            lblCustomerV.Name = "lblCustomerV";
            lblCustomerV.Size = new Size(30, 22);
            lblCustomerV.TabIndex = 24;
            lblCustomerV.Text = "56";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomer.ForeColor = SystemColors.ControlDarkDark;
            lblCustomer.Location = new Point(12, 25);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(85, 22);
            lblCustomer.TabIndex = 23;
            lblCustomer.Text = "Customer";
            // 
            // rbtnCustomer
            // 
            rbtnCustomer.BackColor = Color.White;
            rbtnCustomer.BackgroundColor = Color.White;
            rbtnCustomer.BorderColor = Color.Silver;
            rbtnCustomer.BorderRadius = 10;
            rbtnCustomer.BorderSize = 1;
            rbtnCustomer.FlatAppearance.BorderSize = 0;
            rbtnCustomer.FlatStyle = FlatStyle.Flat;
            rbtnCustomer.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnCustomer.ForeColor = Color.Black;
            rbtnCustomer.Location = new Point(0, 6);
            rbtnCustomer.Name = "rbtnCustomer";
            rbtnCustomer.Size = new Size(151, 83);
            rbtnCustomer.TabIndex = 22;
            rbtnCustomer.TextAlign = ContentAlignment.TopCenter;
            rbtnCustomer.TextColor = Color.Black;
            rbtnCustomer.UseVisualStyleBackColor = false;
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(0, 0);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(8, 8);
            iconButton1.TabIndex = 21;
            iconButton1.Text = "iconButton1";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // rbtnOrder
            // 
            rbtnOrder.BackColor = Color.White;
            rbtnOrder.BackgroundColor = Color.White;
            rbtnOrder.BorderColor = Color.Silver;
            rbtnOrder.BorderRadius = 10;
            rbtnOrder.BorderSize = 1;
            rbtnOrder.FlatAppearance.BorderSize = 0;
            rbtnOrder.FlatStyle = FlatStyle.Flat;
            rbtnOrder.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnOrder.ForeColor = Color.Black;
            rbtnOrder.Location = new Point(471, 6);
            rbtnOrder.Name = "rbtnOrder";
            rbtnOrder.Size = new Size(151, 83);
            rbtnOrder.TabIndex = 25;
            rbtnOrder.TextAlign = ContentAlignment.TopCenter;
            rbtnOrder.TextColor = Color.Black;
            rbtnOrder.UseVisualStyleBackColor = false;
            // 
            // MainFormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 628);
            Controls.Add(pnlChildForm);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MainFormAdmin";
            Text = "MainFormAdmin";
            Load += MainFormAdmin_Load;
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            pnlChildForm.ResumeLayout(false);
            pnlChildForm.PerformLayout();
            pnThongKe.ResumeLayout(false);
            pnThongKe.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNavigation;
        private Label label5;
        private Button btnProducts;
        private Button btnHome;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnCustomers;
        private Button btnOrders;
        private Button btnCategories;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel4;
        private PictureBox pictureBoxLogo;
        private Panel panel2;
        private Label lblNavigationImage;
        private Panel panel1;
        private Label label7;
        private Label lblNotifications;
        private Label lblAvarata;
        private PictureBox pictureBox2;
        private Label label8;
        private PictureBox pictureBox3;
        private Button btnDiscount;
        private Button btnSale;
        private Button btnSetting;
        private Button btnLogOut;
        private Panel pnlChildForm;
        private Panel pnThongKe;
        private Label lblTotalProductV;
        private Label lblTotalProduct;
        private MyCustomControl.RJButton rbtnTotalProduct;
        private Label lblTotalSaleV;
        private Label lblTotalSale;
        private MyCustomControl.RJButton rbtnTotalSale;
        private Label lblItemSaleV;
        private Label lblAvgItemSale;
        private MyCustomControl.RJButton rbtnAvgItemSale;
        private Label lblAvgSaleV;
        private Label label10;
        private MyCustomControl.RJButton rbtnAvgSale;
        private Label lblOrderV;
        private Label lblOrder;
        private MyCustomControl.RJButton rbtnOrder;
        private Label lblCustomerV;
        private Label lblCustomer;
        private MyCustomControl.RJButton rbtnCustomer;
        private FontAwesome.Sharp.IconButton iconButton1;
        private MyCustomControl.RJButton rbtnExport;
        private Guna.Charts.WinForms.GunaChart gunaChart;
        private Guna.Charts.WinForms.GunaBarDataset gunaBarDataset;
        private Label lblYear;
        private ComboBox cbxYear;
        private Label label11;
        private Label label9;
    }
}