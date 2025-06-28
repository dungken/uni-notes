namespace Source.Views
{
    partial class Login
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
            pnlChildForm = new Panel();
            pictureBox1 = new PictureBox();
            pnlLogin = new Panel();
            btnResgister = new Button();
            lblForget = new Label();
            btnLoginWGoogle = new Button();
            label6 = new Label();
            btnLogin = new Button();
            txtPassWord = new TextBox();
            panel4 = new Panel();
            label3 = new Label();
            txtUsername = new TextBox();
            panel7 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pnlChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChildForm
            // 
            pnlChildForm.Controls.Add(pictureBox1);
            pnlChildForm.Controls.Add(pnlLogin);
            pnlChildForm.Dock = DockStyle.Fill;
            pnlChildForm.Location = new Point(0, 0);
            pnlChildForm.Name = "pnlChildForm";
            pnlChildForm.Size = new Size(1232, 628);
            pnlChildForm.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.img_posterResgister;
            pictureBox1.Location = new Point(3, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(355, 628);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(btnResgister);
            pnlLogin.Controls.Add(lblForget);
            pnlLogin.Controls.Add(btnLoginWGoogle);
            pnlLogin.Controls.Add(label6);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(txtPassWord);
            pnlLogin.Controls.Add(panel4);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(panel7);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Location = new Point(355, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(881, 628);
            pnlLogin.TabIndex = 7;
            // 
            // btnResgister
            // 
            btnResgister.Anchor = AnchorStyles.Top;
            btnResgister.BackColor = Color.FromArgb(114, 88, 219);
            btnResgister.Cursor = Cursors.Hand;
            btnResgister.ForeColor = Color.White;
            btnResgister.Location = new Point(285, 436);
            btnResgister.Name = "btnResgister";
            btnResgister.Size = new Size(297, 44);
            btnResgister.TabIndex = 50;
            btnResgister.Text = "Resgister";
            btnResgister.UseVisualStyleBackColor = false;
            btnResgister.Click += btnResgister_Click;
            // 
            // lblForget
            // 
            lblForget.AutoSize = true;
            lblForget.Cursor = Cursors.Hand;
            lblForget.ForeColor = SystemColors.ActiveCaption;
            lblForget.Location = new Point(465, 289);
            lblForget.Name = "lblForget";
            lblForget.Size = new Size(117, 20);
            lblForget.TabIndex = 49;
            lblForget.Text = "Forget Password";
            lblForget.Click += lblForget_Click;
            // 
            // btnLoginWGoogle
            // 
            btnLoginWGoogle.Anchor = AnchorStyles.Top;
            btnLoginWGoogle.BackColor = Color.FromArgb(114, 88, 219);
            btnLoginWGoogle.Cursor = Cursors.Hand;
            btnLoginWGoogle.ForeColor = Color.White;
            btnLoginWGoogle.Location = new Point(285, 386);
            btnLoginWGoogle.Name = "btnLoginWGoogle";
            btnLoginWGoogle.Size = new Size(297, 44);
            btnLoginWGoogle.TabIndex = 48;
            btnLoginWGoogle.Text = "Login with Google";
            btnLoginWGoogle.UseVisualStyleBackColor = false;
            btnLoginWGoogle.Click += btnLoginWGoogle_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(477, 422);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 47;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top;
            btnLogin.BackColor = Color.FromArgb(114, 88, 219);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(282, 336);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(297, 44);
            btnLogin.TabIndex = 43;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassWord
            // 
            txtPassWord.Anchor = AnchorStyles.Top;
            txtPassWord.BorderStyle = BorderStyle.None;
            txtPassWord.Location = new Point(345, 237);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.PlaceholderText = "Password";
            txtPassWord.Size = new Size(230, 20);
            txtPassWord.TabIndex = 39;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(285, 271);
            panel4.Name = "panel4";
            panel4.Size = new Size(297, 1);
            panel4.TabIndex = 38;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.BackColor = Color.White;
            label3.Image = Properties.Resources.icon_lock;
            label3.Location = new Point(292, 223);
            label3.Name = "label3";
            label3.Size = new Size(30, 49);
            label3.TabIndex = 37;
            label3.Text = " ";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Location = new Point(345, 152);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(230, 20);
            txtUsername.TabIndex = 36;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top;
            panel7.BackColor = Color.Black;
            panel7.Location = new Point(285, 186);
            panel7.Name = "panel7";
            panel7.Size = new Size(297, 1);
            panel7.TabIndex = 35;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.BackColor = Color.White;
            label2.Image = Properties.Resources.ImageAvarata;
            label2.Location = new Point(292, 138);
            label2.Name = "label2";
            label2.Size = new Size(30, 49);
            label2.TabIndex = 34;
            label2.Text = " ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(345, 34);
            label1.Name = "label1";
            label1.Size = new Size(160, 60);
            label1.TabIndex = 2;
            label1.Text = "LOGIN";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 628);
            Controls.Add(pnlChildForm);
            Name = "Login";
            Text = "Login";
            pnlChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlChildForm;
        private Panel pnlLogin;
        private Button btnResgister;
        private Label lblForget;
        private Button btnLoginWGoogle;
        private Label label6;
        private Button btnLogin;
        private TextBox txtPassWord;
        private Panel panel4;
        private Label label3;
        private TextBox txtUsername;
        private Panel panel7;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
    }
}