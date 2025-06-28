using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Source.Dtos.Discount;
using Source.Dtos.Voucher;
using Source.Service;

namespace Source.Views.Admin
{
    public partial class DiscountsAdd : Form
    {
        private readonly DiscountsService _discountsService;
        public string _name { get; set; }
        public decimal _percentage { get; set; }
        public DateTime _startDate { get; set; }
        public DateTime _endDate { get; set; }
        public DiscountsAdd()
        {
            InitializeComponent();
            pnDateSchedule.Paint += PanelLine_Paint;
            pnInformation.Paint += PanelLine_Paint;
            _discountsService = new DiscountsService();
        }
        private void PanelLine_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            // Thiết lập màu và độ dày viền
            Color borderColor = Color.Silver;
            float borderSize = 0.5f;

            // Vẽ đường viền
            using (Pen pen = new Pen(borderColor, borderSize))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("Voucher code cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _name = tbxName.Text;
            if (!decimal.TryParse(tbxPercentage.Text, out _))
            {
                MessageBox.Show("\"Please enter a valid value of amount!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _percentage = decimal.Parse(tbxPercentage.Text);

            // Lấy ngày bắt đầu và ngày kết thúc từ MonthCalendar
            DateTime currentDate = DateTime.Now.Date; // Ngày hiện tại

            // Kiểm tra điều kiện: Ngày bắt đầu phải lớn hơn hoặc bằng ngày hiện tại
            if (dateStart.Value.Day < currentDate.Day)
            {
                MessageBox.Show("Start date must be greater than or equal to current date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng kiểm tra tiếp
            }

            // Kiểm tra điều kiện: Ngày kết thúc phải sau hoặc bằng ngày bắt đầu
            if (dateEnd.Value.Day < dateStart.Value.Day)
            {
                MessageBox.Show("End date must be after or equal to start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _startDate = dateStart.Value;
            _endDate = dateEnd.Value;

            // Tạo đối tượng CategoryDto cho mục mới
            var newDiscountrDto = new CreateDiscountDto
            {
                Name = _name,
                Percentage = _percentage,
                StartDate = _startDate,
                EndDate = _endDate,
            };

            // Gọi service để thêm danh mục vào backend
            var response = await _discountsService.CreateDiscountAsync(newDiscountrDto);

            if (response.Id != null)
            {
                // Thông báo thành công và đóng form
                MessageBox.Show("Discount added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add voucher. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
