namespace Source.Views
{
    partial class Resgister
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
            label1 = new Label();
            lblExit = new Label();
            panel3 = new Panel();
            ckAgreement = new CheckBox();
            label6 = new Label();
            textBox4 = new TextBox();
            panel6 = new Panel();
            label5 = new Label();
            btnResgiter = new Button();
            textBox3 = new TextBox();
            panel5 = new Panel();
            label4 = new Label();
            textBox2 = new TextBox();
            panel4 = new Panel();
            label3 = new Label();
            textBox1 = new TextBox();
            panel7 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pnlChildForm = new Panel();
            txtFirstName = new TextBox();
            panel1 = new Panel();
            label7 = new Label();
            txtLastName = new TextBox();
            label8 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlChildForm.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(665, 29);
            label1.Name = "label1";
            label1.Size = new Size(240, 64);
            label1.TabIndex = 2;
            label1.Text = "Resgister";
            // 
            // lblExit
            // 
            lblExit.Cursor = Cursors.Hand;
            lblExit.Image = Properties.Resources.icon_exit;
            lblExit.Location = new Point(352, 582);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(51, 46);
            lblExit.TabIndex = 20;
            lblExit.Click += lblExit_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.Controls.Add(label8);
            panel3.Controls.Add(txtLastName);
            panel3.Controls.Add(txtFirstName);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(ckAgreement);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(btnResgiter);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(530, 108);
            panel3.Name = "panel3";
            panel3.Size = new Size(529, 508);
            panel3.TabIndex = 21;
            // 
            // ckAgreement
            // 
            ckAgreement.AutoSize = true;
            ckAgreement.Location = new Point(233, 389);
            ckAgreement.Name = "ckAgreement";
            ckAgreement.Size = new Size(173, 24);
            ckAgreement.TabIndex = 65;
            ckAgreement.Text = "I agree all agreement";
            ckAgreement.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(280, 353);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 64;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.None;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(176, 198);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Email";
            textBox4.Size = new Size(230, 20);
            textBox4.TabIndex = 63;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top;
            panel6.BackColor = Color.Black;
            panel6.Location = new Point(116, 230);
            panel6.Name = "panel6";
            panel6.Size = new Size(297, 1);
            panel6.TabIndex = 62;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.BackColor = Color.White;
            label5.Image = Properties.Resources.icon_mail;
            label5.Location = new Point(123, 184);
            label5.Name = "label5";
            label5.Size = new Size(30, 49);
            label5.TabIndex = 61;
            label5.Text = " ";
            // 
            // btnResgiter
            // 
            btnResgiter.Anchor = AnchorStyles.None;
            btnResgiter.BackColor = Color.FromArgb(114, 88, 219);
            btnResgiter.ForeColor = Color.White;
            btnResgiter.Location = new Point(116, 419);
            btnResgiter.Name = "btnResgiter";
            btnResgiter.Size = new Size(297, 46);
            btnResgiter.TabIndex = 60;
            btnResgiter.Text = "Resgister";
            btnResgiter.UseVisualStyleBackColor = false;
            btnResgiter.Click += btnResgiter_Click;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.None;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(176, 340);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Confirm password";
            textBox3.Size = new Size(230, 20);
            textBox3.TabIndex = 59;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.BackColor = Color.Black;
            panel5.Location = new Point(116, 372);
            panel5.Name = "panel5";
            panel5.Size = new Size(297, 1);
            panel5.TabIndex = 58;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.BackColor = Color.White;
            label4.Image = Properties.Resources.icon_lock;
            label4.Location = new Point(123, 326);
            label4.Name = "label4";
            label4.Size = new Size(30, 49);
            label4.TabIndex = 57;
            label4.Text = " ";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(176, 272);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(230, 20);
            textBox2.TabIndex = 56;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(116, 304);
            panel4.Name = "panel4";
            panel4.Size = new Size(297, 1);
            panel4.TabIndex = 55;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.BackColor = Color.White;
            label3.Image = Properties.Resources.icon_lock;
            label3.Location = new Point(123, 258);
            label3.Name = "label3";
            label3.Size = new Size(30, 49);
            label3.TabIndex = 54;
            label3.Text = " ";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(176, 61);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Username";
            textBox1.Size = new Size(230, 20);
            textBox1.TabIndex = 53;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top;
            panel7.BackColor = Color.Black;
            panel7.Location = new Point(116, 93);
            panel7.Name = "panel7";
            panel7.Size = new Size(297, 1);
            panel7.TabIndex = 52;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.White;
            label2.Image = Properties.Resources.ImageAvarata1;
            label2.Location = new Point(123, 47);
            label2.Name = "label2";
            label2.Size = new Size(30, 49);
            label2.TabIndex = 51;
            label2.Text = " ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.img_posterResgister;
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(355, 628);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // pnlChildForm
            // 
            pnlChildForm.BackColor = Color.White;
            pnlChildForm.Controls.Add(pictureBox1);
            pnlChildForm.Controls.Add(panel3);
            pnlChildForm.Controls.Add(lblExit);
            pnlChildForm.Controls.Add(label1);
            pnlChildForm.Dock = DockStyle.Fill;
            pnlChildForm.Location = new Point(0, 0);
            pnlChildForm.Name = "pnlChildForm";
            pnlChildForm.Size = new Size(1236, 628);
            pnlChildForm.TabIndex = 3;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.None;
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Location = new Point(176, 123);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(92, 20);
            txtFirstName.TabIndex = 68;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(116, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(297, 1);
            panel1.TabIndex = 67;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.BackColor = Color.White;
            label7.Image = Properties.Resources.ImageAvarata1;
            label7.Location = new Point(123, 109);
            label7.Name = "label7";
            label7.Size = new Size(30, 49);
            label7.TabIndex = 66;
            label7.Text = " ";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.None;
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Location = new Point(309, 123);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(104, 20);
            txtLastName.TabIndex = 69;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.BackColor = Color.White;
            label8.Image = Properties.Resources.ImageAvarata1;
            label8.Location = new Point(273, 109);
            label8.Name = "label8";
            label8.Size = new Size(30, 43);
            label8.TabIndex = 70;
            label8.Text = " ";
            // 
            // Resgister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 628);
            Controls.Add(pnlChildForm);
            Name = "Resgister";
            Text = "Resgister";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlChildForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label lblExit;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Panel pnlChildForm;
        private CheckBox ckAgreement;
        private Label label6;
        private TextBox textBox4;
        private Panel panel6;
        private Label label5;
        private Button btnResgiter;
        private TextBox textBox3;
        private Panel panel5;
        private Label label4;
        private TextBox textBox2;
        private Panel panel4;
        private Label label3;
        private TextBox textBox1;
        private Panel panel7;
        private Label label2;
        private Label label8;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Panel panel1;
        private Label label7;
    }
}