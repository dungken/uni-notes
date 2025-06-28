using NPOI.SS.Formula.Functions;
using Source.Dtos.Order;
using Source.Models;
using Source.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Size = System.Drawing.Size;
using Image = System.Drawing.Image;

namespace Source.Views.Custommer
{
    public partial class PaymentCustomer : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;

        private decimal totalPriceProducts;
        private decimal totalPrice;

        private CreateOrderDto orderDto;

        public PaymentCustomer(CreateOrderDto OrderDto)
        {
            InitializeComponent();
            orderDto = OrderDto;
            _userService = new UserService();
            _orderService = new OrderService();
            _productService = new ProductService();
            _userService = new UserService();
        }
        public PaymentCustomer()
        {
            InitializeComponent();
        }

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
            pnlPaymentCustomer.Controls.Add(childForm);
            pnlPaymentCustomer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        public static int parentX, parentY;
        private void btnOptionVourcher_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();

            using (OptionVourcher modal = new OptionVourcher())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = 0.50d;
                modalBackground.Size = new System.Drawing.Size(Login.frmWith, MainForm.frmHeight);


                modalBackground.Location = new Point(MainForm.frmMainLocationX, MainForm.frmMainLocationY);
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                modal.Owner = modalBackground;

                parentX = MainForm.frmMainLocationX + MainForm.pnlChildFormLocationX;
                parentY = MainForm.frmMainLocationY + MainForm.pnlChildFormLocationY;
                modal.ShowDialog();
                modalBackground.Dispose();

            }
        }

        private void btnOptionShippingMethod_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();

            using (OptionShippingMethod modal = new OptionShippingMethod())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = 0.50d;
                modalBackground.Size = new System.Drawing.Size(MainForm.frmWith, MainForm.frmHeight);


                modalBackground.Location = new Point(MainForm.frmMainLocationX, MainForm.frmMainLocationY);
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                modal.Owner = modalBackground;

                parentX = MainForm.frmMainLocationX + MainForm.pnlChildFormLocationX;
                parentY = MainForm.frmMainLocationY + MainForm.pnlChildFormLocationY;
                modal.ShowDialog();
                modalBackground.Dispose();

            }
        }

        private async void PaymentCustomer_Load(object sender, EventArgs e)
        {
            
            var userOrder = await _userService.GetUserByToken();

            if (userOrder != null)
            {
                lblNameCus.Text = userOrder.Data.User.FirstName + userOrder.Data.User.LastName;

                if (string.IsNullOrEmpty(userOrder.Data.User.PhoneNumber) || string.IsNullOrEmpty(userOrder.Data.User.FullAddress))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Số điện thoại và Địa chỉ");
                    //ProfilePage form = new ProfilePage();
                    //form.Show();
                    openChildForm(new ProfilePage());
                }
                else
                {
                    lblPhoneNumber.Text = userOrder.Data.User.PhoneNumber;
                    lblAdress.Text = userOrder.Data.User.FullAddress;
                }
            }

            await LoadProductsAsync();

            totalPriceProducts -= totalPriceProducts * OptionVourcher.Discount;
            lblToTalPriceProducts.Text = totalPriceProducts.ToString();
            lblShip.Text = "0";

            totalPrice = totalPriceProducts;
            lblToTalPayment.Text = totalPrice.ToString();
            lblToTalPrice.Text = totalPrice.ToString();
        }
        private async Task<Panel> CreateProductPanel(CreateOrderDetailDto orderDetailDto)
        {
            var product = await _productService.GetProductByIdAsync(orderDetailDto.ProductId);
            // Tạo Panel sản phẩm
            Panel pnlProduct = new Panel
            {
                Name = $"pnlProduct_{Guid.NewGuid()}",
                Size = new Size(474, 133),
                Dock = DockStyle.Top,
                BorderStyle = BorderStyle.FixedSingle // Thêm đường viền (tùy chọn)
            };

            // Tạo Panel chứa thông tin sản phẩm
            Panel pnlInforProduct = new Panel
            {
                Name = $"pnlInforProduct_{Guid.NewGuid()}",
                Size = new Size(474, 130),
                Dock = DockStyle.Top
            };

            // Tạo PictureBox hiển thị ảnh sản phẩm
            PictureBox pictureBox = new PictureBox
            {
                Name = "pictureProduct",
                Size = new Size(100, 100),
                Location = new Point(10, 15),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle // Thêm đường viền cho ảnh
            };

            // Nếu có URL ảnh, tải ảnh đầu tiên
            if (product.Data.Images != null && product.Data.Images.Any())
            {
                // Lấy các URL từ ImageDTO
                List<string> imageUrls = product.Data.Images.Select(image => image.Url).ToList();

                // Tải hình ảnh từ các URL
                List<Image> images = await LoadImagesFromUrls(imageUrls);

                // Nếu có ảnh, gán ảnh đầu tiên vào PictureBox
                if (images.Count > 0)
                {
                    pictureBox.Image = images[0]; // Gán ảnh đầu tiên vào PictureBox
                }
            }


            // Tạo các Label hiển thị thông tin sản phẩm
            Label lblName = new Label
            {
                Name = "lblName",
                Text = $"Name: {product.Data.Name}",
                Location = new Point(120, 15),
                AutoSize = true
            };

            Label lblColor = new Label
            {
                Name = "lblColor",
                Text = "Color",
                BackColor = ColorTranslator.FromHtml(orderDetailDto.Color),
                Location = new Point(120, 45),
                AutoSize = true,

            };

            Label lblSize = new Label
            {
                Name = "lblSize",
                Text = $"Size: {orderDetailDto.Size}",
                Location = new Point(120, 75),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Name = "lblPrice",
                Text = $"Price: {orderDetailDto.UnitPrice:C}",
                Location = new Point(120, 105),
                AutoSize = true
            };

            Label lblQuantity = new Label
            {
                Name = "lblQuantity",
                Text = $"Quantity: {orderDetailDto.Quantity}",
                AutoSize = true
            };
            lblQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Gắn vào cạnh phải và giữa chiều dọc của panel cha
            lblQuantity.Location = new Point(pnlProduct.Width - lblQuantity.Width - 10, pnlProduct.Height / 2 - lblQuantity.Height / 2);

            // Thêm các Control vào Panel thông tin
            pnlInforProduct.Controls.Add(pictureBox);
            pnlInforProduct.Controls.Add(lblName);
            pnlInforProduct.Controls.Add(lblColor);
            pnlInforProduct.Controls.Add(lblSize);
            pnlInforProduct.Controls.Add(lblPrice);
            pnlInforProduct.Controls.Add(lblQuantity);

            // Thêm Panel thông tin vào Panel sản phẩm
            pnlProduct.Controls.Add(pnlInforProduct);

            return pnlProduct;
        }

        private async Task LoadProductsAsync()
        {
            // Xóa hết các Control cũ nếu cần
            pnlInforProducts.Controls.Clear();
            totalPriceProducts = 0;

            // Duyệt qua danh sách sản phẩm và tạo Panel động
            foreach (var orderDetail in orderDto.OrderDetails)
            {
                var product = await _productService.GetProductByIdAsync(orderDetail.ProductId);
                Panel productPanel = await CreateProductPanel(orderDetail); // Tạo panel bất đồng bộ
                pnlInforProducts.Controls.Add(productPanel);
                totalPriceProducts += product.Data.Price * orderDetail.Quantity - orderDetail.DiscountAmount;
            }
        }

        private async Task<List<Image>> LoadImagesFromUrls(List<string> imageUrls)
        {
            List<Image> images = new List<Image>();

            using (HttpClient client = new HttpClient())
            {
                foreach (var url in imageUrls)
                {
                    try
                    {
                        byte[] imageBytes = await client.GetByteArrayAsync(url);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            images.Add(Image.FromStream(ms));
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            return images;
        }

        private async void btnOrder_Click(object sender, EventArgs e)
        {

            var respone = await _orderService.CreateOrderAsync(orderDto);
            if (respone != null) {

                MessageBox.Show("Đặt hàng thành công! Vui lòng kiểm tra thông tin đơn hàng trong email của bạn");
                this.Hide();
            }
        }
    }
}
