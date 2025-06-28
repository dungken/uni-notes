using NPOI.SS.Formula.Functions;
using Source.Dtos.Order;
using Source.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Source.Views.Custommer
{
    public partial class OrderInvoices : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        public OrderInvoices()
        {
            InitializeComponent();
            _userService = new UserService();
            _orderService = new OrderService();
            _productService = new ProductService();
        }

        //private void ChangeLabelColorInPanel(object sender, EventArgs e)
        //{
        //    // Duyệt qua tất cả các Control trong panel1
        //    foreach (System.Windows.Forms.Control control in pnOrder.Controls)
        //    {
        //        // Kiểm tra nếu Control là Label
        //        if (control is System.Windows.Forms.Label lbl)
        //        {
        //            // Gán sự kiện MouseEnter để đổi màu chữ khi trỏ chuột vào
        //            lbl.MouseEnter += (s, e) => lbl.ForeColor = Color.Red;

        //            // Gán sự kiện MouseLeave để trả về màu chữ mặc định khi rời chuột
        //            lbl.MouseLeave += (s, e) => lbl.ForeColor = Color.Black;
        //        }
        //    }
        //}
        private void RegisterEventsForLabelsInPanel(System.Windows.Forms.Panel panel)
        {
            object sender;
            EventArgs e;
            // Kiểm tra nếu Panel có chứa bất kỳ Control nào không
            if (panel.Controls.Count == 0)
            {
                MessageBox.Show("Panel không có bất kỳ Label nào để xử lý.");
                return;
            }

            // Duyệt qua tất cả các Control trong Panel
            foreach (System.Windows.Forms.Control control in panel.Controls)
            {
                if (control is System.Windows.Forms.Label lbl)
                {
                    lbl.MouseEnter += label_MouseEnter;
                    lbl.MouseLeave += label_MouseLeave;
                }
            }
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Label lbl)
            {
                lbl.ForeColor = Color.Red; // Đổi màu chữ khi chuột vào
            }
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Label lbl)
            {
                lbl.ForeColor = Color.Black; // Đổi màu chữ khi chuột ra
            }
        }
        // Tạo Form con 
        private Form? activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlOrderInvoices.Controls.Add(childForm);
            pnlOrderInvoices.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            openChildForm(new ReviewProduct());
        }

        private async void OrderInvoices_Load(object sender, EventArgs e)
        {
            // Tạo và hiển thị LoadingForm
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Show();

            try
            {
                // Lấy userId từ token
                var userId = await _userService.GetUserIdByToken();
                if (userId?.Data?.UserId == null)
                {
                    MessageBox.Show("Không thể lấy thông tin người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy danh sách đơn hàng
                var orderList = await _orderService.GetAllOrdersByUserIdAsync(userId.Data.UserId);
                if (orderList?.Data == null || !orderList.Data.Any())
                {
                    MessageBox.Show("Không có đơn hàng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tải đơn hàng vào panel
                pnlListOrders.SuspendLayout();
                try
                {
                    LoadOrdersIntoPanel(orderList.Data.ToList());
                }
                finally
                {
                    pnlListOrders.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng form loading
                loadingForm.Close();
            }
        }

        private async void LoadOrdersIntoPanel(List<OrderDto> orders)
        {
            pnlListOrders.Controls.Clear();
            int yOffset = 0;

            foreach (var order in orders)
            {
                var pnOrder = new Panel
                {
                    Location = new Point(2, 90 + yOffset),
                    Name = "pnOrder",
                    Size = new Size(962, 191),
                    TabIndex = 6
                };

                // Tạo và thêm các panel con
                var pnTop = await CreatePnTop(order);
                var pnMid = CreatePnMid(order);
                var pnBot = CreatePnBot(order);

                pnOrder.Controls.Add(pnMid);
                pnOrder.Controls.Add(pnBot);
                pnOrder.Controls.Add(pnTop);

                pnlListOrders.Controls.Add(pnOrder);
                yOffset += 200; // Khoảng cách giữa các đơn hàng
            }
        }

        private async Task<List<Image>> LoadImagesFromUrls(List<string> imageUrls)
        {
            var images = new List<Image>();
            using var client = new HttpClient();

            var imageTasks = imageUrls.Select(async url =>
            {
                try
                {
                    var imageBytes = await client.GetByteArrayAsync(url);
                    using var ms = new MemoryStream(imageBytes);
                    return Image.FromStream(ms);
                }
                catch
                {
                    return Properties.Resources.capybara3; // Ảnh mặc định khi lỗi
                }
            });

            return (await Task.WhenAll(imageTasks)).ToList();
        }

        private async Task<Panel> CreatePnTop(OrderDto order)
        {
            var pnTop = new Panel
            {
                BackColor = Color.White,
                Location = new Point(3, 3),
                Name = "pnTop",
                Size = new Size(959, 78),
                TabIndex = 0
            };

            // Tạo PictureBox để hiển thị ảnh sản phẩm
            var imageProduct = new PictureBox
            {
                Dock = DockStyle.Left,
                Size = new Size(149, 78),
                SizeMode = PictureBoxSizeMode.Zoom,
            };

            var product = await _productService.GetProductByIdAsync(order.OrderDetails.FirstOrDefault().ProductId);
            if (product.Data?.Images != null && product.Data.Images.Any())
            {
                var imageUrls = product.Data.Images.Select(image => image.Url).ToList();
                var images = await LoadImagesFromUrls(imageUrls);

                if (images.Any())
                {
                    imageProduct.Image = images[0];
                }
            }

            // Tạo các Label khác
            var lblCurrentPrice = new Label
            {
                AutoSize = true,
                ForeColor = Color.OrangeRed,
                Location = new Point(835, 25),
                Name = "lblCurrentPrice",
                Size = new Size(65, 22),
                TabIndex = 8,
                Text = order.TotalAmount.ToString("C")
            };

            var lblOldPrice = new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 12F, FontStyle.Strikeout, GraphicsUnit.Point, 0),
                ForeColor = SystemColors.ControlDarkDark,
                Location = new Point(757, 25),
                Name = "lblOldPrice",
                Size = new Size(65, 22),
                TabIndex = 7,
                Text = "N/A"
            };

            var lblNameProduct = new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0),
                Location = new Point(155, 9),
                Name = "lblNameProduct",
                Size = new Size(260, 25),
                TabIndex = 1,
                Text = product.Data?.Name ?? "Product Name"
            };

            // Add các control vào pnTop
            pnTop.Controls.Add(imageProduct);
            pnTop.Controls.Add(lblCurrentPrice);
            pnTop.Controls.Add(lblOldPrice);
            pnTop.Controls.Add(lblNameProduct);

            return pnTop;
        }

        private Panel CreatePnMid(OrderDto order)
        {
            var pnMid = new Panel
            {
                BackColor = Color.FromArgb(255, 254, 251),
                Location = new Point(3, 84),
                Name = "pnMid",
                Size = new Size(959, 47),
                TabIndex = 1
            };

            var lblTotalPrice = new Label
            {
                AutoSize = true,
                Location = new Point(700, 10),
                Name = "lblTotalPrice",
                Size = new Size(200, 22),
                Text = $"Tổng tiền: {order.TotalAmount:C}"
            };

            pnMid.Controls.Add(lblTotalPrice);
            return pnMid;
        }

        private Panel CreatePnBot(OrderDto order)
        {
            var pnBot = new Panel
            {
                BackColor = Color.FromArgb(255, 254, 251),
                Location = new Point(3, 134),
                Name = "pnBot",
                Size = new Size(959, 53),
                TabIndex = 3
            };

            var lblStatus = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Name = "lblStatus",
                Size = new Size(100, 22),
                Text = $"Trạng thái: {order.Status}"
            };

            var btnReview = new Button
            {
                Text = "Đánh giá",
                Location = new Point(800, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightGray
            };

            btnReview.Click += (s, e) =>
            {
                openChildForm(new ReviewProduct());
            };

            pnBot.Controls.Add(lblStatus);
            pnBot.Controls.Add(btnReview);
            return pnBot;
        }

    }
}


