namespace Source.Views.Admin
{
    partial class OrdersEdit
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
            pnStatus = new Panel();
            rbtnCancel = new RadioButton();
            rbtnPending = new RadioButton();
            rbtnComplied = new RadioButton();
            rbtnProcessing = new RadioButton();
            lblStatus = new Label();
            pnTitle = new Panel();
            pnLine = new Panel();
            btnSave = new MyCustomControl.RJButton();
            lblHeader = new Label();
            pnStatus.SuspendLayout();
            pnTitle.SuspendLayout();
            SuspendLayout();
            // 
            // pnStatus
            // 
            pnStatus.BackColor = Color.White;
            pnStatus.Controls.Add(rbtnCancel);
            pnStatus.Controls.Add(rbtnPending);
            pnStatus.Controls.Add(rbtnComplied);
            pnStatus.Controls.Add(rbtnProcessing);
            pnStatus.Controls.Add(lblStatus);
            pnStatus.Location = new Point(2, 104);
            pnStatus.Margin = new Padding(4, 3, 4, 3);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(503, 152);
            pnStatus.TabIndex = 7;
            // 
            // rbtnCancel
            // 
            rbtnCancel.AutoSize = true;
            rbtnCancel.Location = new Point(297, 95);
            rbtnCancel.Margin = new Padding(4, 3, 4, 3);
            rbtnCancel.Name = "rbtnCancel";
            rbtnCancel.Size = new Size(86, 26);
            rbtnCancel.TabIndex = 4;
            rbtnCancel.TabStop = true;
            rbtnCancel.Text = "Cancel";
            rbtnCancel.UseVisualStyleBackColor = true;
            // 
            // rbtnPending
            // 
            rbtnPending.AutoSize = true;
            rbtnPending.Location = new Point(82, 95);
            rbtnPending.Margin = new Padding(4, 3, 4, 3);
            rbtnPending.Name = "rbtnPending";
            rbtnPending.Size = new Size(94, 26);
            rbtnPending.TabIndex = 3;
            rbtnPending.TabStop = true;
            rbtnPending.Text = "Pending";
            rbtnPending.UseVisualStyleBackColor = true;
            // 
            // rbtnComplied
            // 
            rbtnComplied.AutoSize = true;
            rbtnComplied.Location = new Point(297, 48);
            rbtnComplied.Margin = new Padding(4, 3, 4, 3);
            rbtnComplied.Name = "rbtnComplied";
            rbtnComplied.Size = new Size(109, 26);
            rbtnComplied.TabIndex = 2;
            rbtnComplied.TabStop = true;
            rbtnComplied.Text = "Complied";
            rbtnComplied.UseVisualStyleBackColor = true;
            // 
            // rbtnProcessing
            // 
            rbtnProcessing.AutoSize = true;
            rbtnProcessing.Location = new Point(82, 48);
            rbtnProcessing.Margin = new Padding(4, 3, 4, 3);
            rbtnProcessing.Name = "rbtnProcessing";
            rbtnProcessing.Size = new Size(117, 26);
            rbtnProcessing.TabIndex = 1;
            rbtnProcessing.TabStop = true;
            rbtnProcessing.Text = "Processing";
            rbtnProcessing.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Cursor = Cursors.IBeam;
            lblStatus.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(18, 11);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(162, 25);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Visibility Status";
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(pnLine);
            pnTitle.Controls.Add(btnSave);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(2, 2);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(503, 100);
            pnTitle.TabIndex = 8;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.ForeColor = SystemColors.ActiveCaptionText;
            pnLine.Location = new Point(16, 99);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1292, 11);
            pnLine.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.MediumSlateBlue;
            btnSave.BackgroundColor = Color.MediumSlateBlue;
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 20;
            btnSave.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(297, 25);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(176, 55);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Cursor = Cursors.IBeam;
            lblHeader.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(32, 30);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(167, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Orders Edit";
            // 
            // OrdersEdit
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(509, 261);
            Controls.Add(pnTitle);
            Controls.Add(pnStatus);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrdersEdit";
            Text = "OrdersEdit";
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnStatus;
        private RadioButton rbtnPending;
        private RadioButton rbtnComplied;
        private RadioButton rbtnProcessing;
        private Label lblStatus;
        private Panel pnTitle;
        private Panel pnLine;
        private MyCustomControl.RJButton btnSave;
        private Label lblHeader;
        private RadioButton rbtnCancel;
    }
}