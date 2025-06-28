namespace Source.Views
{
    partial class _2StepVerifycationForLogin
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
            lblHeader = new Label();
            pn2Step = new Panel();
            lblEnterCode = new Label();
            lblGetCode = new Label();
            tbxCode = new TextBox();
            lblOther = new Label();
            cbxRemember = new CheckBox();
            label6 = new Label();
            btnDone = new Button();
            pnLine = new Panel();
            modalEffect_Timer = new System.Windows.Forms.Timer(components);
            pn2Step.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top;
            lblHeader.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.Black;
            lblHeader.Location = new Point(268, 21);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(239, 36);
            lblHeader.TabIndex = 3;
            lblHeader.Text = "2-Step Verification";
            // 
            // pn2Step
            // 
            pn2Step.Anchor = AnchorStyles.Top;
            pn2Step.BackColor = Color.WhiteSmoke;
            pn2Step.Controls.Add(lblEnterCode);
            pn2Step.Controls.Add(lblGetCode);
            pn2Step.Controls.Add(tbxCode);
            pn2Step.Controls.Add(lblOther);
            pn2Step.Controls.Add(cbxRemember);
            pn2Step.Controls.Add(label6);
            pn2Step.Controls.Add(btnDone);
            pn2Step.Controls.Add(pnLine);
            pn2Step.Location = new Point(160, 60);
            pn2Step.Name = "pn2Step";
            pn2Step.Size = new Size(458, 496);
            pn2Step.TabIndex = 22;
            // 
            // lblEnterCode
            // 
            lblEnterCode.AutoSize = true;
            lblEnterCode.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnterCode.Location = new Point(65, 111);
            lblEnterCode.Name = "lblEnterCode";
            lblEnterCode.Size = new Size(218, 23);
            lblEnterCode.TabIndex = 39;
            lblEnterCode.Text = "Enter a verification code";
            // 
            // lblGetCode
            // 
            lblGetCode.AutoSize = true;
            lblGetCode.Location = new Point(65, 162);
            lblGetCode.Name = "lblGetCode";
            lblGetCode.Size = new Size(269, 20);
            lblGetCode.TabIndex = 38;
            lblGetCode.Text = "Get a verfication code form your email ";
            // 
            // tbxCode
            // 
            tbxCode.BorderStyle = BorderStyle.FixedSingle;
            tbxCode.Location = new Point(65, 214);
            tbxCode.Multiline = true;
            tbxCode.Name = "tbxCode";
            tbxCode.Size = new Size(322, 54);
            tbxCode.TabIndex = 37;
            // 
            // lblOther
            // 
            lblOther.AutoSize = true;
            lblOther.Cursor = Cursors.Hand;
            lblOther.ForeColor = SystemColors.Highlight;
            lblOther.Location = new Point(123, 437);
            lblOther.Name = "lblOther";
            lblOther.Size = new Size(169, 20);
            lblOther.TabIndex = 36;
            lblOther.Text = "Try another way to login";
            lblOther.Click += lblOther_Click;
            // 
            // cbxRemember
            // 
            cbxRemember.AutoSize = true;
            cbxRemember.Location = new Point(65, 357);
            cbxRemember.Name = "cbxRemember";
            cbxRemember.Size = new Size(276, 24);
            cbxRemember.TabIndex = 35;
            cbxRemember.Text = "Remember this computer for 30 days";
            cbxRemember.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(268, 315);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 33;
            // 
            // btnDone
            // 
            btnDone.Anchor = AnchorStyles.None;
            btnDone.BackColor = Color.CornflowerBlue;
            btnDone.ForeColor = Color.White;
            btnDone.Location = new Point(65, 289);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(322, 46);
            btnDone.TabIndex = 29;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = false;
            btnDone.Click += btnDone_Click;
            // 
            // pnLine
            // 
            pnLine.Anchor = AnchorStyles.Top;
            pnLine.BackColor = Color.Black;
            pnLine.Location = new Point(3, 406);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(455, 1);
            pnLine.TabIndex = 27;
            // 
            // modalEffect_Timer
            // 
            modalEffect_Timer.Enabled = true;
            modalEffect_Timer.Interval = 1;
            modalEffect_Timer.Tick += modalEffect_Timer_Tick;
            // 
            // _2StepVerifycationForLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 569);
            Controls.Add(pn2Step);
            Controls.Add(lblHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "_2StepVerifycationForLogin";
            Text = "_2StepVerifycationForLogin";
            Load += _2StepVerifycationForLogin_Load;
            pn2Step.ResumeLayout(false);
            pn2Step.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel pn2Step;
        private Label lblEnterCode;
        private Label lblGetCode;
        private TextBox tbxCode;
        private Label lblOther;
        private CheckBox cbxRemember;
        private Label label6;
        private Button btnDone;
        private Panel pnLine;
        private System.Windows.Forms.Timer modalEffect_Timer;
    }
}