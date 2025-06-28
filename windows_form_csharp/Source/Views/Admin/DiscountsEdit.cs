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
using Source.Models;
using Source.Service;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Color = System.Drawing.Color;

namespace Source.Views.Admin
{
    public partial class DiscountsEdit : Form
    {
        private readonly DiscountsService _discountsService;
        private readonly DiscountDto _discount;
        public DiscountsEdit()
        {
            InitializeComponent();

            pnDateSchedule.Paint += PanelLine_Paint;
            pnInformation.Paint += PanelLine_Paint;

            _discountsService = new DiscountsService();
        }
        public DiscountsEdit(DiscountDto discount)
        {
            InitializeComponent();

            pnDateSchedule.Paint += PanelLine_Paint;
            pnInformation.Paint += PanelLine_Paint;

            _discountsService = new DiscountsService();

            _discount = discount;
            LoadDiscountData();
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
        private void LoadDiscountData()
        {
            tbxName.Text = _discount.Name;
            tbxPercentage.Text = _discount.Percentage.ToString();
            dateStart.Value = _discount.StartDate;
            dateEnd.Value = _discount.EndDate;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("Discount name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _discount.Name = tbxName.Text;
            if (!decimal.TryParse(tbxPercentage.Text, out _))
            {
                MessageBox.Show("\"Please enter a valid value of Percentage!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _discount.Percentage = decimal.Parse(tbxPercentage.Text);
           

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
            _discount.StartDate = dateStart.Value;
            _discount.EndDate = dateEnd.Value;

            // Gọi service để thêm danh mục vào backend
            var response = await _discountsService.UpdateDiscount(_discount.Id, new CreateDiscountDto
            {
                Name = _discount.Name,
                Percentage = _discount.Percentage,
                StartDate = _discount.StartDate,
                EndDate = _discount.EndDate
            });




            if (response.Success)
            {
                // Thông báo thành công và đóng form
                MessageBox.Show("Discount edited successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add discount. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
