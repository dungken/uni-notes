using Source.Dtos.Product;
using Source.Service;
using System.Drawing;
using Control = System.Windows.Forms.Control;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Source.Views.Custommer
{
    public partial class ProductsCustomer : Form
    {
        private readonly ProductService _productService;
        private readonly CategoriesService _categoryService;
        private readonly ImageService _imageService;
        private readonly CartService _cartService;

        private int _pageSize = 6; // Số sản phẩm trên mỗi trang
        private int _currentPage = 1; // Trang hiện tại
        private int _totalPages = 1; // Tổng số trang

        private List<Source.Dtos.Product.ProductDTO> _products; // Danh sách sản phẩm DTO
        private string _selectedProductId;
        private List<Source.Dtos.Product.ProductDTO> _originalProducts;

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
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        public ProductsCustomer()
        {
            InitializeComponent();
            btnDecrease.Enabled = false;

            // Khởi tạo dịch vụ
            _productService = new ProductService();
            _categoryService = new CategoriesService();
            _imageService = new ImageService();
            _cartService = new CartService();

            pnlProduct1.Click += Panel_Click;
            pnlProduct2.Click += Panel_Click;
            pnlProduct3.Click += Panel_Click;
            pnlProduct4.Click += Panel_Click;
            pnlProduct5.Click += Panel_Click;
            pnlProduct6.Click += Panel_Click;
        }

        private Panel _previousClickedPanel;

        private void Panel_Click(object sender, EventArgs e)
        {
            if (sender is Panel clickedPanel)
            {
                // Lấy sản phẩm từ Tag của Panel
                var product = clickedPanel.Tag as ProductDTO;
                if (product != null)
                {
                    _selectedProductId = product.Id.ToString();
                    ChangeInforMain(clickedPanel);
                }

                // Reset Panel trước đó (nếu cần)
                if (_previousClickedPanel != null && _previousClickedPanel != clickedPanel)
                {
                    ResetPanel(_previousClickedPanel);
                }

                // Highlight Panel hiện tại
                HighlightPanel(clickedPanel);

                // Cập nhật tham chiếu Panel hiện tại
                _previousClickedPanel = clickedPanel;
            }
        }


        // Method to reset a panel's appearance or text
        private void ResetPanel(Panel panel)
        {
            // Reset the appearance of the panel (e.g., color, text)
            panel.BackColor = Color.FromArgb(255, 235, 224, 234); // Alpha 255 = fully opaque
            panel.Text = ""; // Optional: Reset any text on the panel
        }



        private void ChangeInforMain(Panel selectedPanel)
        {
            // Lấy các Label cần thiết từ panel
            var nameLabel = selectedPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Name"));
            var priceLabel = selectedPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Price"));
            var categoryLabel = selectedPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Cate"));
            var pictureBox = selectedPanel.Controls.OfType<PictureBox>().FirstOrDefault();

            // Gán thông tin từ panel vào các thành phần chính
            lblNameMain.Text = nameLabel?.Text ?? "Tên sản phẩm";
            lblPriceMain.Text = priceLabel?.Text ?? "Giá";
            lblCategoryMain.Text = categoryLabel?.Text ?? "Danh mục";
            pictureBoxMain.Image = pictureBox?.Image;
            pictureBoxMain.Visible = pictureBox?.Image != null;


        }

        // Sự kiện khi click vào panel sản phẩm


        private void HighlightPanel(Panel selectedPanel)
        {
            foreach (var panel in Controls.OfType<Panel>().Where(p => p.Name.StartsWith("pnlProduct")))
            {
                panel.BackColor = Color.White; // Màu mặc định
            }

            selectedPanel.BackColor = Color.LightBlue; // Màu nổi bật
        }

        // Hiển thị chi tiết sản phẩm khi nhấn nút
        private void btnProductDetail_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_selectedProductId))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var product = _products.FirstOrDefault(p => p.Id.ToString() == _selectedProductId);
            
            if (product != null)
            {
                openChildForm(new ProductDetails(product));
            }
            else
            { 
                MessageBox.Show("Không tìm thấy thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblQuantity.Text) > 1)
            {
                lblQuantity.Text = Convert.ToString(Convert.ToInt32(lblQuantity.Text) - 1);
            }
            if (Convert.ToInt32(lblQuantity.Text) == 1)
            {
                btnDecrease.Enabled = false;
            }
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            btnDecrease.Enabled = true;
            lblQuantity.Text = Convert.ToString(Convert.ToInt32(lblQuantity.Text) + 1);
        }

        private async void ProductsCustomer_Load(object sender, EventArgs e)
        {
            LoadingForm loadingForm = new LoadingForm();

            // Hiển thị form loading trên một luồng khác
            Task showLoading = Task.Run(() => loadingForm.ShowDialog());
            try
            {
                var response = await _productService.GetAllProductsAsync();
                if (response.Success)
                {
                    _products = response.Data.ToList(); // Lấy danh sách sản phẩm
                    _originalProducts = new List<ProductDTO>(_products); // Sao chép danh sách gốc
                    UpdatePagination(); // Tính toán và hiển thị phân trang
                }
                else
                {
                    MessageBox.Show($"Lỗi khi tải sản phẩm: {response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng form loading
                loadingForm.Invoke((Action)(() => loadingForm.Close()));
            }
        }

        private void UpdatePagination()
        {
            if (_products != null && _products.Any())
            {
                _totalPages = (int)Math.Ceiling((double)_products.Count / _pageSize);
                DisplayProductsForCurrentPage();
            }
        }

        private async void DisplayProductsForCurrentPage()
        {
            ClearProductPanels();

            var productsToDisplay = _products
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            for (int i = 0; i < productsToDisplay.Count; i++)
            {
                var product = productsToDisplay[i];
                var panel = GetProductPanel(i + 1);

                if (panel == null) continue;

                // Gán sản phẩm vào Tag của panel
                panel.Tag = product;

                // Gán thông tin vào các Label và PictureBox
                var nameLabel = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Name"));
                var priceLabel = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Price"));
                var categoryLabel = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Cate"));
                var imagePicture = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                if (nameLabel != null)
                {
                    nameLabel.Text = product.Name;
                }
                if (priceLabel != null)
                {
                    priceLabel.Text = product.Price.ToString();
                }
                await SetCategoryTextAsync(categoryLabel, product.CategoryId);
                await SetImageAsync(imagePicture, product);

                panel.Visible = true;
            }

            UpdatePaginationButtons();
        }


        private async Task SetCategoryTextAsync(Label categoryLabel, Guid categoryId)
        {
            if (categoryLabel == null) return;

            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(categoryId);
                categoryLabel.Text = category?.Data?.Name ?? "Unknown Category";
            }
            catch (Exception ex)
            {
                categoryLabel.Text = "Error fetching";
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task SetImageAsync(PictureBox imagePicture, ProductDTO product)
        {
            if (imagePicture == null) return;

            try
            {
                var image = product.Images?.FirstOrDefault();
                if (image == null || string.IsNullOrEmpty(image.Url))
                {
                    Console.WriteLine("Không có URL hợp lệ để tải hình ảnh.");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    // Tải dữ liệu ảnh từ URL
                    var response = await client.GetAsync(image.Url);
                    response.EnsureSuccessStatusCode(); // Kiểm tra lỗi HTTP

                    var imageData = await response.Content.ReadAsByteArrayAsync();
                    using (var stream = new MemoryStream(imageData))
                    {
                        imagePicture.Image = Image.FromStream(stream);
                        imagePicture.SizeMode = PictureBoxSizeMode.Zoom; // Đặt chế độ hiển thị ảnh
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Không thể tải hình ảnh. Chi tiết lỗi: {ex.Message}");
            }
        }




        private void UpdatePaginationButtons()
        {
            // Bật/tắt nút Previous và Next
            btnPre.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;

            // Hiển thị thông tin trang
            lblPaginationInfo.Text = $"Page {_currentPage} of {_totalPages}";
        }



        private void ClearProductPanels()
        {
            // Ẩn tất cả các panel và xóa thông tin cũ
            for (int i = 1; i <= 6; i++)
            {
                var panel = GetProductPanel(i);
                if (panel != null)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Label label)
                            label.Text = string.Empty;
                    }
                    panel.Visible = false;
                }
            }
        }

        private Panel GetProductPanel(int position)
        {
            switch (position)
            {
                case 1: return pnlProduct1;
                case 2: return pnlProduct2;
                case 3: return pnlProduct3;
                case 4: return pnlProduct4;
                case 5: return pnlProduct5;
                case 6: return pnlProduct6;
                default: return null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void SearchProducts()
        {
            var search = txtSearch.Text.Trim().ToLower(); // Lấy nội dung tìm kiếm và chuyển về chữ thường
            _products = new List<ProductDTO>(_originalProducts);
            if (string.IsNullOrEmpty(search))
            {
                // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ sản phẩm
                DisplayProductsForCurrentPage();
                return;
            }

            // Lọc danh sách sản phẩm dựa trên từ khóa tìm kiếm
            var filteredProducts = _products
                .Where(p =>
                    (p.Name?.ToLower().Contains(search) ?? false) ||   // Tìm theo tên sản phẩm
                    (p.Description?.ToLower().Contains(search) ?? false)) // Tìm theo mô tả (nếu có)
                .ToList();

            if (filteredProducts.Any())
            {
                // Cập nhật danh sách sản phẩm được hiển thị
                _products = filteredProducts;
                _currentPage = 1; // Đặt lại trang hiện tại về trang đầu
                UpdatePagination();
            }
            else
            {
                // Thông báo nếu không tìm thấy sản phẩm nào
                MessageBox.Show(
                    "Không tìm thấy sản phẩm phù hợp với từ khóa tìm kiếm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchProducts();
        }
        private void btnAddTheCart_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(_selectedProductId))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }
        private void btnBuyNow_Click(object sender, EventArgs e)
        {

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayProductsForCurrentPage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                DisplayProductsForCurrentPage();
            }
        }
    }
}
