namespace Source.Views
{
    partial class ChangePassword
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            txtConfirmPass = new TextBox();
            panel3 = new Panel();
            label4 = new Label();
            btnChangePassword = new Button();
            txtOldPassword = new TextBox();
            panel5 = new Panel();
            txtPassWord = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            label3 = new Label();
            lblExit = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(162, 185, 237);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(194, 479);
            panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.img_posterResgister;
            pictureBox1.Location = new Point(3, 66);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 347);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(234, 9);
            label1.Name = "label1";
            label1.Size = new Size(102, 36);
            label1.TabIndex = 2;
            label1.Text = "Login";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblExit);
            panel2.Controls.Add(txtConfirmPass);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnChangePassword);
            panel2.Controls.Add(txtOldPassword);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(txtPassWord);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(194, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(584, 479);
            panel2.TabIndex = 5;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Anchor = AnchorStyles.Top;
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Location = new Point(204, 279);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderText = "Confirm New Password";
            txtConfirmPass.Size = new Size(230, 20);
            txtConfirmPass.TabIndex = 46;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(144, 313);
            panel3.Name = "panel3";
            panel3.Size = new Size(297, 1);
            panel3.TabIndex = 45;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.BackColor = Color.White;
            label4.Image = Properties.Resources.icon_lock;
            label4.Location = new Point(151, 265);
            label4.Name = "label4";
            label4.Size = new Size(30, 49);
            label4.TabIndex = 44;
            label4.Text = " ";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top;
            btnChangePassword.BackColor = Color.FromArgb(114, 88, 219);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(144, 343);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(297, 44);
            btnChangePassword.TabIndex = 43;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Anchor = AnchorStyles.Top;
            txtOldPassword.BorderStyle = BorderStyle.None;
            txtOldPassword.Location = new Point(204, 107);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PlaceholderText = "Old Password";
            txtOldPassword.Size = new Size(230, 20);
            txtOldPassword.TabIndex = 39;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.BackColor = Color.Black;
            panel5.Location = new Point(144, 141);
            panel5.Name = "panel5";
            panel5.Size = new Size(297, 1);
            panel5.TabIndex = 38;
            // 
            // txtPassWord
            // 
            txtPassWord.Anchor = AnchorStyles.Top;
            txtPassWord.BorderStyle = BorderStyle.None;
            txtPassWord.Location = new Point(204, 188);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.PlaceholderText = "New Password";
            txtPassWord.Size = new Size(230, 20);
            txtPassWord.TabIndex = 39;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.BackColor = Color.White;
            label2.Image = Properties.Resources.icon_lock;
            label2.Location = new Point(151, 93);
            label2.Name = "label2";
            label2.Size = new Size(30, 49);
            label2.TabIndex = 37;
            label2.Text = " ";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(144, 222);
            panel4.Name = "panel4";
            panel4.Size = new Size(297, 1);
            panel4.TabIndex = 38;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.BackColor = Color.White;
            label3.Image = Properties.Resources.icon_lock;
            label3.Location = new Point(151, 174);
            label3.Name = "label3";
            label3.Size = new Size(30, 49);
            label3.TabIndex = 37;
            label3.Text = " ";
            // 
            // lblExit
            // 
            lblExit.Cursor = Cursors.Hand;
            lblExit.Image = Properties.Resources.icon_exit;
            lblExit.Location = new Point(0, 433);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(51, 46);
            lblExit.TabIndex = 47;
            lblExit.Click += lblExit_Click;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 479);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ChangePassword";
            Text = "Login";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel2;
        private Label label6;
        private Button btnChangePassword;
        private TextBox txtPassWord;
        private Panel panel4;
        private Label label3;
        private TextBox txtConfirmPass;
        private Panel panel3;
        private Label label4;
        private Label lblForget;
        private TextBox txtOldPassword;
        private Panel panel5;
        private Label label2;
        private Label lblExit;
    }
}