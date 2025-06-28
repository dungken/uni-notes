namespace Source.Views.Custommer
{
    partial class DesignCustomer
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
            pnlDesign = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            btnRequest = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            pnlDesign.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDesign
            // 
            pnlDesign.BackColor = Color.White;
            pnlDesign.Controls.Add(button4);
            pnlDesign.Controls.Add(button3);
            pnlDesign.Controls.Add(button2);
            pnlDesign.Controls.Add(btnRequest);
            pnlDesign.Controls.Add(panel2);
            pnlDesign.Dock = DockStyle.Fill;
            pnlDesign.Location = new Point(0, 0);
            pnlDesign.Name = "pnlDesign";
            pnlDesign.Size = new Size(997, 509);
            pnlDesign.TabIndex = 0;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic);
            button4.ForeColor = Color.FromArgb(80, 40, 60);
            button4.Location = new Point(664, 406);
            button4.Name = "button4";
            button4.Size = new Size(285, 45);
            button4.TabIndex = 11;
            button4.Text = "Bảo hành 60 ngày";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic);
            button3.ForeColor = Color.FromArgb(80, 40, 60);
            button3.Location = new Point(338, 406);
            button3.Name = "button3";
            button3.Size = new Size(285, 45);
            button3.TabIndex = 10;
            button3.Text = "Số lượng không giới hạn";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic);
            button2.ForeColor = Color.FromArgb(80, 40, 60);
            button2.Location = new Point(25, 406);
            button2.Name = "button2";
            button2.Size = new Size(285, 45);
            button2.TabIndex = 9;
            button2.Text = "Giá cạnh tranh";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnRequest
            // 
            btnRequest.FlatStyle = FlatStyle.Flat;
            btnRequest.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRequest.ForeColor = SystemColors.ActiveCaption;
            btnRequest.Location = new Point(394, 280);
            btnRequest.Name = "btnRequest";
            btnRequest.Size = new Size(157, 45);
            btnRequest.TabIndex = 8;
            btnRequest.Text = "Gửi yêu cầu";
            btnRequest.UseVisualStyleBackColor = true;
            btnRequest.Click += btnRequest_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(282, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(411, 140);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaptionText;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 87);
            panel3.Name = "panel3";
            panel3.Size = new Size(411, 1);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(80, 40, 60);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(411, 87);
            label1.TabIndex = 0;
            label1.Text = "COOLxPRINT";
            // 
            // label2
            // 
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic);
            label2.ForeColor = Color.FromArgb(80, 40, 60);
            label2.Location = new Point(3, 91);
            label2.Name = "label2";
            label2.Size = new Size(405, 42);
            label2.TabIndex = 1;
            label2.Text = "Đặt sản xuất chưa bao giờ đơn giản đến vậy ";
            // 
            // DesignCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(997, 509);
            Controls.Add(pnlDesign);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "DesignCustomer";
            Text = "DesignCustomer";
            pnlDesign.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDesign;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button btnRequest;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
    }
}