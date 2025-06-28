namespace Source.Views
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            btnSetting = new Button();
            btnSupport = new Button();
            btnAboutUs = new Button();
            btnLogOut = new Button();
            btnCart = new Button();
            pnlSubMenuProducts = new Panel();
            btnCustomDesign = new Button();
            btnPants = new Button();
            btnMenTop = new Button();
            btnBestSeller = new Button();
            btnProducts = new Button();
            btnHome = new Button();
            panel4 = new Panel();
            pictureBoxLogo = new PictureBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            lblNavigationImage = new Label();
            lblNavigation = new Label();
            lblNotifications = new Label();
            label4 = new Label();
            lblUsername = new Label();
            label2 = new Label();
            lblAvarata = new Label();
            pnlSubMenuAvata = new Panel();
            btnProfilePage = new Button();
            btnOrderInvoices = new Button();
            panel6 = new Panel();
            panel5 = new Panel();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            btnLogOutSubAvata = new Button();
            pnlChildForm = new Panel();
            pnlSubNotifications = new Panel();
            button7 = new Button();
            button2 = new Button();
            button5 = new Button();
            panel8 = new Panel();
            panel9 = new Panel();
            label1 = new Label();
            label10 = new Label();
            button6 = new Button();
            imageList1 = new ImageList(components);
            panel1.SuspendLayout();
            pnlSubMenuProducts.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlSubMenuAvata.SuspendLayout();
            panel5.SuspendLayout();
            pnlChildForm.SuspendLayout();
            pnlSubNotifications.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(154, 156, 233);
            panel1.Controls.Add(btnSetting);
            panel1.Controls.Add(btnSupport);
            panel1.Controls.Add(btnAboutUs);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(btnCart);
            panel1.Controls.Add(pnlSubMenuProducts);
            panel1.Controls.Add(btnProducts);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 628);
            panel1.TabIndex = 0;
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
            btnSetting.Location = new Point(0, 444);
            btnSetting.Margin = new Padding(4, 3, 4, 3);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(221, 50);
            btnSetting.TabIndex = 9;
            btnSetting.Text = "         Setting";
            btnSetting.TextAlign = ContentAlignment.MiddleLeft;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // btnSupport
            // 
            btnSupport.Dock = DockStyle.Top;
            btnSupport.FlatAppearance.BorderSize = 0;
            btnSupport.FlatStyle = FlatStyle.Flat;
            btnSupport.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnSupport.ForeColor = Color.White;
            btnSupport.Image = Properties.Resources.icon_help;
            btnSupport.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupport.Location = new Point(0, 394);
            btnSupport.Margin = new Padding(4, 3, 4, 3);
            btnSupport.Name = "btnSupport";
            btnSupport.Size = new Size(221, 50);
            btnSupport.TabIndex = 8;
            btnSupport.Text = "         Support";
            btnSupport.TextAlign = ContentAlignment.MiddleLeft;
            btnSupport.UseVisualStyleBackColor = true;
            btnSupport.Click += btnSupport_Click;
            // 
            // btnAboutUs
            // 
            btnAboutUs.Dock = DockStyle.Top;
            btnAboutUs.FlatAppearance.BorderSize = 0;
            btnAboutUs.FlatStyle = FlatStyle.Flat;
            btnAboutUs.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnAboutUs.ForeColor = Color.White;
            btnAboutUs.Image = Properties.Resources.icon_aboutUs;
            btnAboutUs.ImageAlign = ContentAlignment.MiddleLeft;
            btnAboutUs.Location = new Point(0, 344);
            btnAboutUs.Margin = new Padding(4, 3, 4, 3);
            btnAboutUs.Name = "btnAboutUs";
            btnAboutUs.Size = new Size(221, 50);
            btnAboutUs.TabIndex = 7;
            btnAboutUs.Text = "         About us";
            btnAboutUs.TextAlign = ContentAlignment.MiddleLeft;
            btnAboutUs.UseVisualStyleBackColor = true;
            btnAboutUs.Click += btnAboutUs_Click;
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
            btnLogOut.TabIndex = 6;
            btnLogOut.Text = "         Log out";
            btnLogOut.TextAlign = ContentAlignment.MiddleLeft;
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnCart
            // 
            btnCart.Dock = DockStyle.Top;
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnCart.ForeColor = Color.White;
            btnCart.Image = Properties.Resources.GioHang;
            btnCart.ImageAlign = ContentAlignment.MiddleLeft;
            btnCart.Location = new Point(0, 294);
            btnCart.Margin = new Padding(4, 3, 4, 3);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(221, 50);
            btnCart.TabIndex = 5;
            btnCart.Text = "         Cart";
            btnCart.TextAlign = ContentAlignment.MiddleLeft;
            btnCart.UseVisualStyleBackColor = true;
            btnCart.Click += btnCart_Click;
            // 
            // pnlSubMenuProducts
            // 
            pnlSubMenuProducts.Controls.Add(btnCustomDesign);
            pnlSubMenuProducts.Controls.Add(btnPants);
            pnlSubMenuProducts.Controls.Add(btnMenTop);
            pnlSubMenuProducts.Controls.Add(btnBestSeller);
            pnlSubMenuProducts.Dock = DockStyle.Top;
            pnlSubMenuProducts.Location = new Point(0, 131);
            pnlSubMenuProducts.Margin = new Padding(4, 3, 4, 3);
            pnlSubMenuProducts.Name = "pnlSubMenuProducts";
            pnlSubMenuProducts.Size = new Size(221, 163);
            pnlSubMenuProducts.TabIndex = 4;
            // 
            // btnCustomDesign
            // 
            btnCustomDesign.Dock = DockStyle.Top;
            btnCustomDesign.FlatAppearance.BorderSize = 0;
            btnCustomDesign.FlatStyle = FlatStyle.Flat;
            btnCustomDesign.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnCustomDesign.ForeColor = Color.White;
            btnCustomDesign.Location = new Point(0, 117);
            btnCustomDesign.Margin = new Padding(4, 3, 4, 3);
            btnCustomDesign.Name = "btnCustomDesign";
            btnCustomDesign.Padding = new Padding(24, 0, 0, 0);
            btnCustomDesign.Size = new Size(221, 39);
            btnCustomDesign.TabIndex = 3;
            btnCustomDesign.Text = "Custom Design";
            btnCustomDesign.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomDesign.UseVisualStyleBackColor = true;
            btnCustomDesign.Click += btnCustomDesign_Click;
            // 
            // btnPants
            // 
            btnPants.Dock = DockStyle.Top;
            btnPants.FlatAppearance.BorderSize = 0;
            btnPants.FlatStyle = FlatStyle.Flat;
            btnPants.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnPants.ForeColor = Color.White;
            btnPants.Location = new Point(0, 78);
            btnPants.Margin = new Padding(4, 3, 4, 3);
            btnPants.Name = "btnPants";
            btnPants.Padding = new Padding(24, 0, 0, 0);
            btnPants.Size = new Size(221, 39);
            btnPants.TabIndex = 2;
            btnPants.Text = "Pants ";
            btnPants.TextAlign = ContentAlignment.MiddleLeft;
            btnPants.UseVisualStyleBackColor = true;
            btnPants.Click += btnPants_Click;
            // 
            // btnMenTop
            // 
            btnMenTop.Dock = DockStyle.Top;
            btnMenTop.FlatAppearance.BorderSize = 0;
            btnMenTop.FlatStyle = FlatStyle.Flat;
            btnMenTop.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnMenTop.ForeColor = Color.White;
            btnMenTop.Location = new Point(0, 39);
            btnMenTop.Margin = new Padding(4, 3, 4, 3);
            btnMenTop.Name = "btnMenTop";
            btnMenTop.Padding = new Padding(24, 0, 0, 0);
            btnMenTop.Size = new Size(221, 39);
            btnMenTop.TabIndex = 1;
            btnMenTop.Text = "Men's Top";
            btnMenTop.TextAlign = ContentAlignment.MiddleLeft;
            btnMenTop.UseVisualStyleBackColor = true;
            btnMenTop.Click += btnMenTop_Click;
            // 
            // btnBestSeller
            // 
            btnBestSeller.Cursor = Cursors.Hand;
            btnBestSeller.Dock = DockStyle.Top;
            btnBestSeller.FlatAppearance.BorderSize = 0;
            btnBestSeller.FlatStyle = FlatStyle.Flat;
            btnBestSeller.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnBestSeller.ForeColor = Color.White;
            btnBestSeller.ImageAlign = ContentAlignment.MiddleLeft;
            btnBestSeller.Location = new Point(0, 0);
            btnBestSeller.Margin = new Padding(4, 3, 4, 3);
            btnBestSeller.Name = "btnBestSeller";
            btnBestSeller.Padding = new Padding(24, 0, 0, 0);
            btnBestSeller.Size = new Size(221, 39);
            btnBestSeller.TabIndex = 0;
            btnBestSeller.Text = "Best-seller";
            btnBestSeller.TextAlign = ContentAlignment.MiddleLeft;
            btnBestSeller.UseVisualStyleBackColor = true;
            btnBestSeller.Click += btnBestSeller_Click;
            // 
            // btnProducts
            // 
            btnProducts.Cursor = Cursors.Hand;
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnProducts.ForeColor = Color.White;
            btnProducts.Image = Properties.Resources._45506_box_delivery_package_product_shipment_icon;
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(0, 81);
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
            btnHome.Anchor = AnchorStyles.Left;
            btnHome.Cursor = Cursors.Hand;
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
            // panel4
            // 
            panel4.Controls.Add(pictureBoxLogo);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(221, 81);
            panel4.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Anchor = AnchorStyles.Left;
            pictureBoxLogo.Image = Properties.Resources.logo;
            pictureBoxLogo.Location = new Point(0, 1);
            pictureBoxLogo.Margin = new Padding(4, 3, 4, 3);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(218, 80);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(162, 185, 237);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(lblNavigationImage);
            panel2.Controls.Add(lblNavigation);
            panel2.Controls.Add(lblNotifications);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblUsername);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblAvarata);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(221, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1015, 72);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.imagesHome;
            pictureBox1.Location = new Point(637, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblNavigationImage
            // 
            lblNavigationImage.Image = Properties.Resources.icon_home;
            lblNavigationImage.Location = new Point(5, 23);
            lblNavigationImage.Name = "lblNavigationImage";
            lblNavigationImage.Size = new Size(50, 40);
            lblNavigationImage.TabIndex = 8;
            lblNavigationImage.Text = "          ";
            // 
            // lblNavigation
            // 
            lblNavigation.AutoSize = true;
            lblNavigation.ForeColor = Color.Transparent;
            lblNavigation.Location = new Point(70, 35);
            lblNavigation.Name = "lblNavigation";
            lblNavigation.Size = new Size(58, 20);
            lblNavigation.TabIndex = 7;
            lblNavigation.Text = "Home";
            // 
            // lblNotifications
            // 
            lblNotifications.Anchor = AnchorStyles.Right;
            lblNotifications.Image = Properties.Resources.bell;
            lblNotifications.Location = new Point(783, 26);
            lblNotifications.Name = "lblNotifications";
            lblNotifications.Size = new Size(32, 40);
            lblNotifications.TabIndex = 4;
            lblNotifications.Text = "          ";
            lblNotifications.Click += lblNotifications_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(832, 46);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 5;
            label4.Text = "Customer";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Right;
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(821, 26);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(114, 20);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "lblUsername";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.Image = Properties.Resources.circle;
            label2.Location = new Point(724, 26);
            label2.Name = "label2";
            label2.Size = new Size(42, 40);
            label2.TabIndex = 3;
            label2.Text = "          ";
            // 
            // lblAvarata
            // 
            lblAvarata.Anchor = AnchorStyles.Right;
            lblAvarata.Cursor = Cursors.Hand;
            lblAvarata.Image = Properties.Resources.ImageAvarata;
            lblAvarata.Location = new Point(932, 29);
            lblAvarata.Name = "lblAvarata";
            lblAvarata.Size = new Size(42, 40);
            lblAvarata.TabIndex = 0;
            lblAvarata.Text = "          ";
            lblAvarata.Click += lblAvarata_Click;
            // 
            // pnlSubMenuAvata
            // 
            pnlSubMenuAvata.BackColor = Color.FromArgb(162, 185, 237);
            pnlSubMenuAvata.Controls.Add(btnProfilePage);
            pnlSubMenuAvata.Controls.Add(btnOrderInvoices);
            pnlSubMenuAvata.Controls.Add(panel6);
            pnlSubMenuAvata.Controls.Add(panel5);
            pnlSubMenuAvata.Controls.Add(btnLogOutSubAvata);
            pnlSubMenuAvata.ForeColor = Color.White;
            pnlSubMenuAvata.Location = new Point(702, 532);
            pnlSubMenuAvata.Name = "pnlSubMenuAvata";
            pnlSubMenuAvata.Size = new Size(200, 195);
            pnlSubMenuAvata.TabIndex = 1;
            // 
            // btnProfilePage
            // 
            btnProfilePage.Cursor = Cursors.Hand;
            btnProfilePage.DialogResult = DialogResult.Abort;
            btnProfilePage.Dock = DockStyle.Bottom;
            btnProfilePage.FlatAppearance.BorderSize = 0;
            btnProfilePage.FlatStyle = FlatStyle.Flat;
            btnProfilePage.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnProfilePage.ForeColor = Color.White;
            btnProfilePage.Location = new Point(0, 78);
            btnProfilePage.Margin = new Padding(4, 3, 4, 3);
            btnProfilePage.Name = "btnProfilePage";
            btnProfilePage.Padding = new Padding(24, 0, 0, 0);
            btnProfilePage.Size = new Size(200, 39);
            btnProfilePage.TabIndex = 5;
            btnProfilePage.Text = "Profile Page";
            btnProfilePage.TextAlign = ContentAlignment.MiddleLeft;
            btnProfilePage.UseVisualStyleBackColor = true;
            btnProfilePage.Click += btnProfilePage_Click;
            // 
            // btnOrderInvoices
            // 
            btnOrderInvoices.Cursor = Cursors.Hand;
            btnOrderInvoices.Dock = DockStyle.Bottom;
            btnOrderInvoices.FlatAppearance.BorderSize = 0;
            btnOrderInvoices.FlatStyle = FlatStyle.Flat;
            btnOrderInvoices.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnOrderInvoices.ForeColor = Color.White;
            btnOrderInvoices.Location = new Point(0, 117);
            btnOrderInvoices.Margin = new Padding(4, 3, 4, 3);
            btnOrderInvoices.Name = "btnOrderInvoices";
            btnOrderInvoices.Padding = new Padding(24, 0, 0, 0);
            btnOrderInvoices.Size = new Size(200, 39);
            btnOrderInvoices.TabIndex = 4;
            btnOrderInvoices.Text = "Order Invoices";
            btnOrderInvoices.TextAlign = ContentAlignment.MiddleLeft;
            btnOrderInvoices.UseVisualStyleBackColor = true;
            btnOrderInvoices.Click += btnOrderInvoices_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Black;
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 59);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 1);
            panel6.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label7);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 59);
            panel5.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(64, 29);
            label9.Name = "label9";
            label9.Size = new Size(82, 20);
            label9.TabIndex = 6;
            label9.Text = "Customer";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(64, 9);
            label8.Name = "label8";
            label8.Size = new Size(59, 20);
            label8.TabIndex = 5;
            label8.Text = "label8";
            // 
            // label7
            // 
            label7.Cursor = Cursors.Hand;
            label7.Image = Properties.Resources.ImageAvarata;
            label7.Location = new Point(3, 3);
            label7.Name = "label7";
            label7.Size = new Size(42, 40);
            label7.TabIndex = 1;
            label7.Text = "          ";
            // 
            // btnLogOutSubAvata
            // 
            btnLogOutSubAvata.Cursor = Cursors.Hand;
            btnLogOutSubAvata.Dock = DockStyle.Bottom;
            btnLogOutSubAvata.FlatAppearance.BorderSize = 0;
            btnLogOutSubAvata.FlatStyle = FlatStyle.Flat;
            btnLogOutSubAvata.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            btnLogOutSubAvata.ForeColor = Color.White;
            btnLogOutSubAvata.Location = new Point(0, 156);
            btnLogOutSubAvata.Margin = new Padding(4, 3, 4, 3);
            btnLogOutSubAvata.Name = "btnLogOutSubAvata";
            btnLogOutSubAvata.Padding = new Padding(24, 0, 0, 0);
            btnLogOutSubAvata.Size = new Size(200, 39);
            btnLogOutSubAvata.TabIndex = 1;
            btnLogOutSubAvata.Text = "Log out";
            btnLogOutSubAvata.TextAlign = ContentAlignment.MiddleLeft;
            btnLogOutSubAvata.UseVisualStyleBackColor = true;
            // 
            // pnlChildForm
            // 
            pnlChildForm.Controls.Add(pnlSubMenuAvata);
            pnlChildForm.Controls.Add(pnlSubNotifications);
            pnlChildForm.Dock = DockStyle.Fill;
            pnlChildForm.Location = new Point(221, 72);
            pnlChildForm.Name = "pnlChildForm";
            pnlChildForm.Size = new Size(1015, 556);
            pnlChildForm.TabIndex = 3;
            // 
            // pnlSubNotifications
            // 
            pnlSubNotifications.BackColor = Color.White;
            pnlSubNotifications.Controls.Add(button7);
            pnlSubNotifications.Controls.Add(button2);
            pnlSubNotifications.Controls.Add(button5);
            pnlSubNotifications.Controls.Add(panel8);
            pnlSubNotifications.Controls.Add(panel9);
            pnlSubNotifications.Controls.Add(button6);
            pnlSubNotifications.ForeColor = Color.White;
            pnlSubNotifications.Location = new Point(438, 541);
            pnlSubNotifications.Name = "pnlSubNotifications";
            pnlSubNotifications.Size = new Size(246, 239);
            pnlSubNotifications.TabIndex = 2;
            // 
            // button7
            // 
            button7.Cursor = Cursors.Hand;
            button7.DialogResult = DialogResult.Abort;
            button7.Dock = DockStyle.Bottom;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            button7.ForeColor = Color.Black;
            button7.Location = new Point(0, 83);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Padding = new Padding(24, 0, 0, 0);
            button7.Size = new Size(246, 39);
            button7.TabIndex = 6;
            button7.Text = "QuangCao1";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.DialogResult = DialogResult.Abort;
            button2.Dock = DockStyle.Bottom;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(0, 122);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Padding = new Padding(24, 0, 0, 0);
            button2.Size = new Size(246, 39);
            button2.TabIndex = 5;
            button2.Text = "QuangCao1";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Cursor = Cursors.Hand;
            button5.Dock = DockStyle.Bottom;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            button5.ForeColor = Color.Black;
            button5.Location = new Point(0, 161);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Padding = new Padding(24, 0, 0, 0);
            button5.Size = new Size(246, 39);
            button5.TabIndex = 4;
            button5.Text = "QuangCao2";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Black;
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 59);
            panel8.Name = "panel8";
            panel8.Size = new Size(246, 1);
            panel8.TabIndex = 3;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(154, 156, 233);
            panel9.Controls.Add(label1);
            panel9.Controls.Add(label10);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(246, 59);
            panel9.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 6;
            label1.Text = "Notifications";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(216, 20);
            label10.Name = "label10";
            label10.Size = new Size(24, 25);
            label10.TabIndex = 5;
            label10.Text = "6";
            // 
            // button6
            // 
            button6.Cursor = Cursors.Hand;
            button6.Dock = DockStyle.Bottom;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(0, 200);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Padding = new Padding(24, 0, 0, 0);
            button6.Size = new Size(246, 39);
            button6.TabIndex = 1;
            button6.Text = "QuangCao3";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 628);
            Controls.Add(pnlChildForm);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ClientSizeChanged += MainForm_ClientSizeChanged;
            panel1.ResumeLayout(false);
            pnlSubMenuProducts.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlSubMenuAvata.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            pnlChildForm.ResumeLayout(false);
            pnlSubNotifications.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Button btnHome;
        private PictureBox pictureBoxLogo;
        private Button btnLogOut;
        private Button btnCart;
        private Panel pnlSubMenuProducts;
        private Button btnCustomDesign;
        private Button btnPants;
        private Button btnMenTop;
        private Button btnBestSeller;
        private Button btnProducts;
        private Button btnAboutUs;
        private Button btnSupport;
        private Label lblAvarata;
        private Label label4;
        private Label lblUsername;
        private Label label2;
        private Label lblNotifications;
        private Label lblNavigation;
        private Label lblNavigationImage;
        private Panel pnlChildForm;
        private Panel pnlSubMenuAvata;
        private Button btnLogOutSubAvata;
        private Panel panel5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Panel panel6;
        private Button btnSetting;
        private Button btnProfilePage;
        private Button btnOrderInvoices;
        private Panel pnlSubNotifications;
        private Button button2;
        private Button button5;
        private Panel panel8;
        private Panel panel9;
        private Label label1;
        private Label label10;
        private Button button6;
        private Button button7;
        private PictureBox pictureBox1;
        private ImageList imageList1;
    }
}