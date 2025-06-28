using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Source.Dtos.Category;
using Source.Dtos.Order;
using Source.Models;
using Source.Service;
using Color = System.Drawing.Color;

namespace Source.Views.Admin
{
    public partial class OrdersEdit : Form
    {
        private readonly OrderService _ordersService;
        private OrderDto _order;
        public OrdersEdit()
        {
            InitializeComponent();
            pnStatus.Paint += PanelLine_Paint;
            _ordersService = new OrderService();
        }
        public OrdersEdit(OrderDto order)
        {
            InitializeComponent();
            pnStatus.Paint += PanelLine_Paint;
            _ordersService = new OrderService();
            _order = order;
            LoadOrderData();
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
        private void LoadOrderData()
        {
            if (_order.Status == "Processing")
                rbtnProcessing.Checked = true;
            else if (_order.Status == "Pending")
                rbtnPending.Checked = true;
            else if (_order.Status == "Complied")
                rbtnComplied.Checked = true;
            else
                rbtnCancel.Checked = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (rbtnProcessing.Checked)
            {
                _order.Status = "Processing";
            }
            else if (rbtnPending.Checked)
            {
                _order.Status = "Pending";
            }
            else if (rbtnComplied.Checked)
            {
                _order.Status = "Complied";
            }
            else if (rbtnCancel.Checked)
            {
                _order.Status = "Cancel";
            }
            else
            {
                MessageBox.Show("Please select a status!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi API để cập nhật
            var result = await _ordersService.UpdateOrderStatus(_order.Id, new UpdateOrderDto
            {
               status = _order.Status
            });

            if (result.Success)
            {
                MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Đóng form và báo thành công
            }
            else
            {
                MessageBox.Show("Failed to update order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
