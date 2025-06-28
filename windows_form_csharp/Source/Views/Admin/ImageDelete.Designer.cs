namespace Source.Views.Admin
{
    partial class ImageDelete
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
            pnImg = new Panel();
            lblHeader = new Label();
            SuspendLayout();
            // 
            // pnImg
            // 
            pnImg.Location = new Point(12, 60);
            pnImg.Name = "pnImg";
            pnImg.Size = new Size(763, 228);
            pnImg.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(38, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(259, 22);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Click chọn những ảnh muốn xóa";
            // 
            // ImageDelete
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 301);
            Controls.Add(lblHeader);
            Controls.Add(pnImg);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ImageDelete";
            Text = "ImageDelete";
            Load += ImageDelete_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnImg;
        private Label lblHeader;
    }
}