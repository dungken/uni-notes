namespace Source.Views.Admin
{
    partial class DiscountsAdd
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
            tbxPercentage = new TextBox();
            lblBasic = new Label();
            lblStart = new Label();
            dateStart = new DateTimePicker();
            lblDateSchedule = new Label();
            pnTitle = new Panel();
            pnLine = new Panel();
            btnSave = new MyCustomControl.RJButton();
            lblHeader = new Label();
            lblEnd = new Label();
            dateEnd = new DateTimePicker();
            pnDateSchedule = new Panel();
            lblName = new Label();
            pnInformation = new Panel();
            tbxName = new TextBox();
            lblPercentage = new Label();
            pnTitle.SuspendLayout();
            pnDateSchedule.SuspendLayout();
            pnInformation.SuspendLayout();
            SuspendLayout();
            // 
            // tbxPercentage
            // 
            tbxPercentage.Location = new Point(168, 117);
            tbxPercentage.Name = "tbxPercentage";
            tbxPercentage.Size = new Size(166, 30);
            tbxPercentage.TabIndex = 16;
            // 
            // lblBasic
            // 
            lblBasic.AutoSize = true;
            lblBasic.Cursor = Cursors.IBeam;
            lblBasic.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBasic.Location = new Point(19, 14);
            lblBasic.Name = "lblBasic";
            lblBasic.Size = new Size(223, 25);
            lblBasic.TabIndex = 0;
            lblBasic.Text = "Discount information";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Cursor = Cursors.IBeam;
            lblStart.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStart.Location = new Point(13, 57);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(99, 23);
            lblStart.TabIndex = 5;
            lblStart.Text = "Start Date";
            // 
            // dateStart
            // 
            dateStart.Location = new Point(13, 102);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(250, 30);
            dateStart.TabIndex = 1;
            // 
            // lblDateSchedule
            // 
            lblDateSchedule.AutoSize = true;
            lblDateSchedule.Cursor = Cursors.IBeam;
            lblDateSchedule.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateSchedule.Location = new Point(13, 10);
            lblDateSchedule.Name = "lblDateSchedule";
            lblDateSchedule.Size = new Size(156, 25);
            lblDateSchedule.TabIndex = 0;
            lblDateSchedule.Text = "Date Schedule";
            // 
            // pnTitle
            // 
            pnTitle.Controls.Add(pnLine);
            pnTitle.Controls.Add(btnSave);
            pnTitle.Controls.Add(lblHeader);
            pnTitle.Location = new Point(1, 2);
            pnTitle.Margin = new Padding(2, 3, 2, 3);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(686, 91);
            pnTitle.TabIndex = 17;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.ForeColor = SystemColors.ActiveCaptionText;
            pnLine.Location = new Point(12, 90);
            pnLine.Margin = new Padding(2, 3, 2, 3);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(940, 10);
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
            btnSave.Location = new Point(538, 24);
            btnSave.Margin = new Padding(2, 3, 2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 50);
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
            lblHeader.Location = new Point(23, 27);
            lblHeader.Margin = new Padding(2, 0, 2, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(200, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Discounts Add";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Cursor = Cursors.IBeam;
            lblEnd.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnd.Location = new Point(13, 162);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(89, 23);
            lblEnd.TabIndex = 7;
            lblEnd.Text = "End Date";
            // 
            // dateEnd
            // 
            dateEnd.Location = new Point(13, 207);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(250, 30);
            dateEnd.TabIndex = 6;
            // 
            // pnDateSchedule
            // 
            pnDateSchedule.BackColor = Color.White;
            pnDateSchedule.Controls.Add(lblEnd);
            pnDateSchedule.Controls.Add(dateEnd);
            pnDateSchedule.Controls.Add(lblStart);
            pnDateSchedule.Controls.Add(dateStart);
            pnDateSchedule.Controls.Add(lblDateSchedule);
            pnDateSchedule.Location = new Point(373, 99);
            pnDateSchedule.Name = "pnDateSchedule";
            pnDateSchedule.Size = new Size(314, 304);
            pnDateSchedule.TabIndex = 18;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Cursor = Cursors.IBeam;
            lblName.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(93, 57);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 23);
            lblName.TabIndex = 4;
            lblName.Text = "Name";
            // 
            // pnInformation
            // 
            pnInformation.BackColor = Color.White;
            pnInformation.Controls.Add(tbxPercentage);
            pnInformation.Controls.Add(tbxName);
            pnInformation.Controls.Add(lblName);
            pnInformation.Controls.Add(lblPercentage);
            pnInformation.Controls.Add(lblBasic);
            pnInformation.Location = new Point(1, 99);
            pnInformation.Name = "pnInformation";
            pnInformation.Size = new Size(353, 304);
            pnInformation.TabIndex = 19;
            // 
            // tbxName
            // 
            tbxName.Location = new Point(168, 55);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(166, 30);
            tbxName.TabIndex = 6;
            // 
            // lblPercentage
            // 
            lblPercentage.AutoSize = true;
            lblPercentage.Cursor = Cursors.IBeam;
            lblPercentage.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPercentage.Location = new Point(47, 120);
            lblPercentage.Name = "lblPercentage";
            lblPercentage.Size = new Size(106, 23);
            lblPercentage.TabIndex = 1;
            lblPercentage.Text = "Percentage";
            // 
            // DiscountsAdd
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 251, 253);
            ClientSize = new Size(697, 415);
            Controls.Add(pnTitle);
            Controls.Add(pnDateSchedule);
            Controls.Add(pnInformation);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DiscountsAdd";
            Text = "DiscountsAdd";
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            pnDateSchedule.ResumeLayout(false);
            pnDateSchedule.PerformLayout();
            pnInformation.ResumeLayout(false);
            pnInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbxPercentage;
        private Label lblBasic;
        private Label lblStart;
        private DateTimePicker dateStart;
        private Label lblDateSchedule;
        private Panel pnTitle;
        private Panel pnLine;
        private MyCustomControl.RJButton btnSave;
        private Label lblHeader;
        private Label lblEnd;
        private DateTimePicker dateEnd;
        private Panel pnDateSchedule;
        private Label lblName;
        private Panel pnInformation;
        private TextBox tbxName;
        private Label lblPercentage;
    }
}