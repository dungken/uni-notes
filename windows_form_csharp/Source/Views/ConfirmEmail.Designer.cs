namespace Source.Views
{
    partial class ConfirmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmEmail));
            lblHeader = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblEnterCode = new Label();
            lblGetCode = new Label();
            tbxCode = new TextBox();
            lblOther = new Label();
            cbxRemember = new CheckBox();
            label6 = new Label();
            btnDone = new Button();
            pnLine = new Panel();
            modalEffect_Timer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top;
            lblHeader.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.Black;
            lblHeader.Location = new Point(180, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(196, 36);
            lblHeader.TabIndex = 3;
            lblHeader.Text = "Email Confirm";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblEnterCode);
            panel1.Controls.Add(lblGetCode);
            panel1.Controls.Add(tbxCode);
            panel1.Controls.Add(lblOther);
            panel1.Controls.Add(cbxRemember);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnDone);
            panel1.Controls.Add(pnLine);
            panel1.Location = new Point(58, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(458, 480);
            panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(183, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 50;
            pictureBox1.TabStop = false;
            // 
            // lblEnterCode
            // 
            lblEnterCode.AutoSize = true;
            lblEnterCode.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnterCode.Location = new Point(64, 102);
            lblEnterCode.Name = "lblEnterCode";
            lblEnterCode.Size = new Size(218, 23);
            lblEnterCode.TabIndex = 48;
            lblEnterCode.Text = "Enter a verification code";
            // 
            // lblGetCode
            // 
            lblGetCode.AutoSize = true;
            lblGetCode.Location = new Point(64, 153);
            lblGetCode.Name = "lblGetCode";
            lblGetCode.Size = new Size(269, 20);
            lblGetCode.TabIndex = 47;
            lblGetCode.Text = "Get a verfication code form your email ";
            // 
            // tbxCode
            // 
            tbxCode.BorderStyle = BorderStyle.FixedSingle;
            tbxCode.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxCode.Location = new Point(64, 205);
            tbxCode.Multiline = true;
            tbxCode.Name = "tbxCode";
            tbxCode.Size = new Size(322, 54);
            tbxCode.TabIndex = 46;
            // 
            // lblOther
            // 
            lblOther.AutoSize = true;
            lblOther.Cursor = Cursors.Hand;
            lblOther.ForeColor = SystemColors.Highlight;
            lblOther.Location = new Point(48, 427);
            lblOther.Name = "lblOther";
            lblOther.Size = new Size(338, 20);
            lblOther.TabIndex = 45;
            lblOther.Text = "Try comeback resgister to check your information ";
            lblOther.Click += lblOther_Click;
            // 
            // cbxRemember
            // 
            cbxRemember.AutoSize = true;
            cbxRemember.Location = new Point(64, 348);
            cbxRemember.Name = "cbxRemember";
            cbxRemember.Size = new Size(276, 24);
            cbxRemember.TabIndex = 44;
            cbxRemember.Text = "Remember this computer for 30 days";
            cbxRemember.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(267, 306);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 43;
            // 
            // btnDone
            // 
            btnDone.Anchor = AnchorStyles.None;
            btnDone.BackColor = Color.CornflowerBlue;
            btnDone.ForeColor = Color.White;
            btnDone.Location = new Point(64, 273);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(322, 46);
            btnDone.TabIndex = 42;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = false;
            btnDone.Click += btnDone_Click;
            // 
            // pnLine
            // 
            pnLine.Anchor = AnchorStyles.Top;
            pnLine.BackColor = Color.Black;
            pnLine.Location = new Point(2, 397);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(455, 1);
            pnLine.TabIndex = 41;
            // 
            // modalEffect_Timer
            // 
            modalEffect_Timer.Enabled = true;
            modalEffect_Timer.Interval = 1;
            modalEffect_Timer.Tick += modalEffect_Timer_Tick;
            // 
            // ConfirmEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 617);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(lblHeader);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmEmail";
            ShowInTaskbar = false;
            Text = "ConfirmEmail";
            Load += ConfirmEmail_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel panel1;
        private Label lblEnterCode;
        private Label lblGetCode;
        private TextBox tbxCode;
        private Label lblOther;
        private CheckBox cbxRemember;
        private Label label6;
        private Button btnDone;
        private Panel pnLine;
        private System.Windows.Forms.Timer modalEffect_Timer;
        private PictureBox pictureBox1;
    }
}