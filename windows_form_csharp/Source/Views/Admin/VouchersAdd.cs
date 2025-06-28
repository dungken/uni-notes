using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Source.Dtos.Category;
using Source.Dtos.Voucher;
using Source.Service;

namespace Source.Views.Admin
{
    public partial class VouchersAdd : Form
    {
        private readonly VoucherService _vouchersService;
        public string _code { get; set; }
        public decimal _discountAmount { get; set; }
        public decimal _minimumAmount { get; set; }
        public int? _usageLimit { get; set; }
        public DateTime _startDate { get; set; }
        public DateTime _endDate { get; set; }
        public VouchersAdd()
        {
            InitializeComponent();
            pnDateSchedule.Paint += PanelLine_Paint;
            pnInformation.Paint += PanelLine_Paint;

            _vouchersService = new VoucherService();
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
        private void VouchersAdd_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxCode.Text))
            {
                MessageBox.Show("Voucher code cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _code = tbxCode.Text;
            if (!decimal.TryParse(tbxAmount.Text, out _))
            {
                MessageBox.Show("\"Please enter a valid value of amount!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _discountAmount = decimal.Parse(tbxAmount.Text);
            if (!decimal.TryParse(tbxMinOrder.Text, out _))
            {
                MessageBox.Show("\"Please enter a valid value of min order!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _minimumAmount = decimal.Parse(tbxMinOrder.Text);
            if (tbxLimit.Text != "")
            {
                _usageLimit = int.Parse(tbxLimit.Text);
            }

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
            var newVoucherDto = new CreateVoucherDto
            {
                Code = _code,
                DiscountAmount = _discountAmount,   
                MinimumAmount = _minimumAmount,
                UsageLimit = _usageLimit,
                StartDate = _startDate,
                EndDate = _endDate,
            };

            // Gọi service để thêm danh mục vào backend
            var response = await _vouchersService.CreateVoucherAsync(newVoucherDto);

            if (response.Success)
            {
                // Thông báo thành công và đóng form
                MessageBox.Show("Voucher added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
