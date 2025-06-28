using System;
using System.Drawing;
using System.Windows.Forms;

namespace Source.Views
{
    public partial class LoadingForm : Form
    {
        private System.Windows.Forms.Timer _timer;
        private Label lblLoading;

        public LoadingForm()
        {
            InitializeComponent();

            // Thiết lập form đẹp mắt
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // Không có viền
            this.BackColor = Color.White;
            this.Opacity = 0.75; // Làm form trong suốt một chút

            // Label thông báo đang tải (giảm kích thước chữ)
            lblLoading = new Label
            {
                Text = "Đang tải dữ liệu, vui lòng chờ...",
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold), // Kích thước chữ nhỏ hơn (10)
                Location = new Point(30, 70), // Căn giữa từ trên xuống
                ForeColor = Color.FromArgb(64, 64, 64), // Màu chữ xám nhẹ
            };
            this.Controls.Add(lblLoading);

            // Điều chỉnh kích thước form
            this.Size = new Size(400, 200);

            // Viền mờ cho form
            this.Paint += (sender, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.LightGray, 2), 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            };

            // Tạo timer để thêm hiệu ứng động
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100; // Cập nhật mỗi 100ms
            _timer.Tick += (sender, e) =>
            {
                // Làm cho label thay đổi màu sắc, tạo hiệu ứng "nhấp nháy"
                lblLoading.ForeColor = lblLoading.ForeColor == Color.FromArgb(64, 64, 64)
                    ? Color.FromArgb(100, 100, 100)
                    : Color.FromArgb(64, 64, 64);
            };
            _timer.Start();
        }

        // Dừng hiệu ứng sau khi loading xong
        public void StopLoading()
        {
            _timer.Stop();
            this.Close();
        }
    }
}
