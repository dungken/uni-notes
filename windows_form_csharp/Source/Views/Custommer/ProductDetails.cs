using api.Dtos.Cart;
using Newtonsoft.Json;
using NPOI.HPSF;
using Source.Dtos.Discount;
using Source.Dtos.Order;
using Source.Dtos.Product;
using Source.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.Views.Custommer
{
    public partial class ProductDetails : Form
    {
        private readonly ProductService _productService;
        private readonly DiscountsService _countsService;
        private readonly CartService _cartService;
        private readonly UserService _userService;

        private readonly ProductDTO _product;
        private List<Image> _images;
        private int _currentPage = 0;
        private const int ItemsPerPage = 3;

        private string selectedColor; // Lưu trữ màu được chọn
        private string selectedSize;  // Lưu trữ kích thước được chọn

        private Button btnSelectedColor;
        private Button btnSelectedSize;
        public ProductDetails(ProductDTO product)
        {
            InitializeComponent();
            _countsService = new DiscountsService();
            _productService = new ProductService();
            _cartService = new CartService();
            _userService = new UserService();

            _product = product;
            selectedColor = "";
            selectedSize = "";
            LoadProductDetails();
            btnSelectedColor = new Button();
            btnSelectedSize = new Button();

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
            pnlProductDetail.Controls.Add(childForm);
            pnlProductDetail.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private async void LoadProductDetails()
        {
            try
            {
                var response = await _productService.GetProductByIdAsync(_product.Id);
                if (response != null)
                {
                    lblName.Text = response.Data.Name;
                    lblOldPrice.Text = response.Data.Price.ToString("C");

                    // Handle Discount
                    if (response.Data.DiscountId != null)
                    {
                        var discount = await _countsService.GetDiscountByIdAsync((Guid)response.Data.DiscountId);
                        var price = response.Data.Price * discount.Data.Percentage;
                        lblPrice.Text = price.ToString("C");
                        lblDiscount.Text = discount.Data.Percentage.ToString("D");
                    }
                    else
                    {
                        lblPrice.Text = lblOldPrice.Text;
                        lblDiscount.Text = "0%";
                    }

                    // Handle Reviews and Ratings
                    if (response.Data.Feedbacks != null && response.Data.Feedbacks.Count > 0)
                    {
                        lblReview.Text = response.Data.Feedbacks.Count.ToString();
                        var averageRating = response.Data.Feedbacks.Average(fb => fb.Rating);
                        lblRating.Text = averageRating.ToString("F1");
                    }
                    else
                    {
                        lblReview.Text = "0";
                        lblRating.Text = "0.0";
                    }

                    // Handle Colors
                    var colors = response.Data.Colors;
                    for (int i = 0; i < colors.Count && i < pnlColor.Controls.OfType<Button>().Count(); i++)
                    {
                        var btn = pnlColor.Controls.OfType<Button>().ElementAtOrDefault(i);
                        if (btn != null)
                        {
                            btn.BackColor = ColorTranslator.FromHtml(colors[i].ColorCode);
                            btn.Tag = colors[i].ColorCode; // Tag stores the color code
                            btn.Visible = true;
                            btn.Click += btnColor_Click; // Gắn sự kiện cho nút
                        }
                    }

                    // Hide extra color buttons
                    for (int i = colors.Count; i < pnlColor.Controls.OfType<Button>().Count(); i++)
                    {
                        var btn = pnlColor.Controls.OfType<Button>().ElementAtOrDefault(i);
                        if (btn != null)
                        {
                            btn.Visible = false;
                        }
                    }

                    // Handle Sizes
                    var sizes = response.Data.Sizes;
                    for (int i = 0; i < sizes.Count && i < pnlSize.Controls.OfType<Button>().Count(); i++)
                    {
                        var btn = pnlSize.Controls.OfType<Button>().ElementAtOrDefault(i);
                        if (btn != null)
                        {
                            btn.Text = sizes[i].Name.ToString();
                            btn.Tag = sizes[i].Name; // Tag stores the size name
                            btn.Visible = true;
                            btn.Click += btnSize_Click; // Gắn sự kiện cho nút
                        }
                    }

                    // Hide extra size buttons
                    for (int i = sizes.Count; i < pnlSize.Controls.OfType<Button>().Count(); i++)
                    {
                        var btn = pnlSize.Controls.OfType<Button>().ElementAtOrDefault(i);
                        if (btn != null)
                        {
                            btn.Visible = false;
                        }
                    }

                    // Load images
                    var imageUrls = response.Data.Images.Select(img => img.Url).ToList();
                    _images = await LoadImagesFromUrls(imageUrls);
                    DisplayImagesForCurrentPage();
                }
                else
                {
                    MessageBox.Show("Không thể tải thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DisplayImagesForCurrentPage()
        {
            int startIndex = _currentPage * ItemsPerPage;
            int endIndex = Math.Min(startIndex + ItemsPerPage, _images.Count);

            if (startIndex < _images.Count) picBox1.Image = _images.ElementAtOrDefault(startIndex);
            if (startIndex + 1 < _images.Count) picBox2.Image = _images.ElementAtOrDefault(startIndex + 1);
            if (startIndex + 2 < _images.Count) picBox3.Image = _images.ElementAtOrDefault(startIndex + 2);

            picBox1.Visible = (startIndex < _images.Count);
            picBox2.Visible = (startIndex + 1 < _images.Count);
            picBox3.Visible = (startIndex + 2 < _images.Count);
        }

        private void UpdateHighlightColor(Button selectedButton)
        {
            // Chỉ cập nhật các nút màu đang hiển thị
            foreach (var button in pnlColor.Controls.OfType<Button>())
            {
                if (button.Visible)
                {
                    if (selectedColor != null && button.Tag.ToString() == selectedColor)
                    {
                        // Button được chọn: Thêm text "X", đổi màu viền và thay đổi padding và kích thước chữ
                        button.FlatAppearance.BorderSize = 2; // Đổi độ dày viền
                        button.FlatAppearance.BorderColor = Color.Blue; // Màu viền "highlight"
                        button.Font = new Font(button.Font.FontFamily, 10, FontStyle.Bold); // Kích thước chữ
                        button.Padding = new Padding(5); // Thay đổi Padding để "thu nhỏ" nội dung
                        button.Text = "X"; // Thêm chữ "X"
                        btnSelectedColor = button; // Lưu lại button được chọn
                    }
                    else
                    {
                        // Button không được chọn: Đặt lại viền, padding và text mặc định
                        button.FlatAppearance.BorderSize = 0; // Loại bỏ viền
                        button.Font = new Font(button.Font.FontFamily, 8, FontStyle.Regular); // Trả lại kích thước chữ mặc định
                        button.Padding = new Padding(10); // Trả lại padding mặc định
                        button.Text = ""; // Xóa text
                    }
                }
            }
        }


        private void UpdateHighlightSize(Button selectedButton)
        {
            // Chỉ cập nhật các nút kích thước đang hiển thị
            foreach (var button in pnlSize.Controls.OfType<Button>())
            {
                if (button.Visible)
                {
                    if (selectedSize != null && button.Tag.ToString() == selectedSize)
                    {
                        // Button được chọn: Đổi màu viền, thay đổi padding và kích thước chữ
                        button.FlatAppearance.BorderSize = 2; // Đổi độ dày viền
                        button.FlatAppearance.BorderColor = Color.Blue; // Màu viền "highlight"
                        button.Font = new Font(button.Font.FontFamily, 14, FontStyle.Bold); // Kích thước chữ
                        button.Padding = new Padding(5); // Thay đổi Padding để "thu nhỏ" nội dung
                        btnSelectedSize = button; // Lưu lại button được chọn
                    }
                    else
                    {
                        // Button không được chọn: Đặt lại viền và padding mặc định
                        button.FlatAppearance.BorderSize = 0; // Loại bỏ viền
                        button.Font = new Font(button.Font.FontFamily, 8, FontStyle.Regular); // Trả lại kích thước chữ mặc định
                        button.Padding = new Padding(10); // Trả lại padding mặc định
                    }
                }
            }
        }



        private void btnColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            selectedColor = button.Tag.ToString();  // Lưu lại màu được chọn thông qua Tag của button

            // Cập nhật trạng thái highlight cho các button màu
            UpdateHighlightColor(button);

            // Kiểm tra điều kiện để bật nút Đặt hàng
            ValidateOrder();
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            selectedSize = button.Tag.ToString();  // Lưu lại kích thước được chọn thông qua Tag của button

            // Cập nhật trạng thái highlight cho các button kích thước
            UpdateHighlightSize(button);

            // Kiểm tra điều kiện để bật nút Đặt hàng
            ValidateOrder();
        }




        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((_currentPage + 1) * ItemsPerPage < _images.Count)
            {
                _currentPage++;
                DisplayImagesForCurrentPage();
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                DisplayImagesForCurrentPage();
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblQuantity.Text) > 1)
                lblQuantity.Text = $"{Convert.ToInt32(lblQuantity.Text) - 1}";
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblQuantity.Text) < _product.StockQuantity)
                lblQuantity.Text = $"{Convert.ToInt32(lblQuantity.Text) + 1}";
        }


        private void ValidateOrder()
        {
            if (!string.IsNullOrEmpty(selectedColor) && !string.IsNullOrEmpty(selectedSize))
            {
                btnBuy.Enabled = true; // Bật nút "Đặt hàng"
                btnBuy.BackColor = Color.Green; // Thay đổi màu nút (tùy chọn)
            }
            else
            {
                btnBuy.Enabled = false; // Tắt nút "Đặt hàng"
                btnBuy.BackColor = Color.Gray; // Thay đổi màu nút (tùy chọn)
            }
        }

        private async void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedColor) || string.IsNullOrEmpty(selectedSize))
                {
                    MessageBox.Show("Vui lòng chọn màu sắc và kích thước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int quantity = Convert.ToInt32(lblQuantity.Text);
                decimal unitPrice = decimal.TryParse(lblPrice.Text, out decimal price) ? price : _product.Price;
                decimal discountAmount = 0;

                if (_product.DiscountId != null)
                {
                    var discount = _countsService.GetDiscountByIdAsync((Guid)_product.DiscountId).Result;
                    discountAmount = unitPrice * (decimal)discount.Data.Percentage;
                }

                UserService userService = new UserService();
                CreateOrderDto dto = new CreateOrderDto();
                CreateOrderDetailDto orderDetailDto = new CreateOrderDetailDto()
                {
                    ProductId = _product.Id,
                    Quantity = quantity,
                    Color = selectedColor,
                    Size = selectedSize,
                    UnitPrice = unitPrice,
                    DiscountAmount = discountAmount,
                    OrderId = dto.OrderId
                };

                dto.OrderDetails.Add(orderDetailDto);

                // Assuming BaseResponse<GetUserIdByTokenRespone> has a property 'Data' containing 'UserId'
                var response_Id = await userService.GetUserIdByToken();
                if (response_Id != null && response_Id.Data != null)
                {
                    dto.UserId = response_Id.Data.UserId; // Extract the Guid
                }
                else
                {
                    throw new Exception("Failed to retrieve UserId from the response.");
                }

                var response_user = await userService.GetUserByToken();
                if (response_user != null && response_user.Data != null)
                {
                    dto.ShippingAddress = response_user.Data.User.FullAddress; // Extract the Guid
                }
                else
                {
                    throw new Exception("Failed to retrieve UserId from the response.");
                }

                openChildForm(new PaymentCustomer(dto));

                // Hiển thị thông báo xác nhận

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picBox1_Click(object sender, EventArgs e)
        {
            picbxMain.Image = picBox1.Image;
        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            picbxMain.Image = picBox2.Image;
        }

        private void picBox3_Click(object sender, EventArgs e)
        {
            picbxMain.Image = picBox3.Image;
        }

        private async void btnAddCart_Click(object sender, EventArgs e)
        {
            var user = await _userService.GetUserIdByToken();

            InforProductForCartDto inforProduct = new InforProductForCartDto()
            {
                ProductId = _product.Id,
                Size = selectedSize,
                Color = selectedColor,
                Quantity = Convert.ToInt32(lblQuantity.Text)
            };

            await _cartService.AddToCartAsync(user.Data.UserId, inforProduct);
            MessageBox.Show("Đã thêm vào giỏ hàng");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
