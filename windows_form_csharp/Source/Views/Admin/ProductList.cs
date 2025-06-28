using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.POIFS.Properties;
using Source.Dtos.Order;
using Source.Dtos.Product;
using Source.Models;
using Source.Service;
using Source.Views.Custommer;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;

namespace Source.Views.Admin
{
    public partial class ProductList : Form
    {
        private readonly ProductService _productsService;
        private readonly CategoriesService _categoriesService;
        private readonly ImageService _imagesService;
        private readonly ColorsService _colorService;
        private readonly SizeService _sizeService;
        private List<ProductListDisplayDto> _originalData; // Dữ liệu gốc
        private int _pageSize = 5;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp

        public ProductList()
        {
            InitializeComponent();

            _productsService = new ProductService();
            _categoriesService = new CategoriesService();
            _imagesService = new ImageService();
            _sizeService = new SizeService();
            _colorService = new ColorsService();
            _originalData = new List<ProductListDisplayDto>();
            CustomizeDataGridView();
            InitializeShowing();
            pnFilterCate.Paint += PanelLine_Paint;
            pnFilterPrice.Paint += PanelLine_Paint;
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
        private void CustomizeDataGridView()
        {
            gridView.Columns[0].Width = 120;
            gridView.Columns[1].Width = 120;
            gridView.Columns[2].Width = 120;
            gridView.Columns[3].Width = 120;
            gridView.Columns[4].Width = 120;
            gridView.Columns[5].Width = 75;
            gridView.Columns[6].Width = 75;
        }
        private async void InitializeShowing()
        {
            // comboxbox
            // Thêm các giá trị từ 1 đến 10 vào ComboBox
            for (int i = 1; i <= 10; i++)
            {
                cbxShow.Items.Add(i);
            }

            cbxShow.SelectedIndex = 4; // Mặc định chọn 5 hàng trên mỗi trang

            try
            {
                // Đổ dữ liệu cho danh mục (Category)
                var categoryResponse = await _categoriesService.GetAllCategories();
                if (categoryResponse?.Data != null && categoryResponse.Success)
                {
                    cbxCate.Items.Clear();
                    cbxCate.DataSource = categoryResponse.Data;
                    //foreach (var category in categoryResponse.Data)
                    //{
                    //    cbxCate.Items.Add(category.Name);
                    //}
                }

                //// Đổ dữ liệu cho màu (Color)
                //var colorResponse = await _colorService.GetAllColorsAsync();
                //if (colorResponse?.Data != null && colorResponse.Success)
                //{
                //    clbCate.Items.Clear();
                //    foreach (var category in colorResponse.Data)
                //    {
                //        clbCate.Items.Add(category.Name);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Binding danh sách danh mục vào ComboBox

            cbxCate.DisplayMember = "Name";   // Tên hiển thị trong ComboBox
            cbxCate.ValueMember = "Id";       // Giá trị là Id của danh mục
            cbxCate.SelectedIndex = -1;       // Không chọn gì mặc định

        }

        private void tbxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số, dấu chấm, hoặc dấu âm
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true; // Loại bỏ ký tự
            }

            // Chỉ cho phép một dấu chấm
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu âm ở đầu
            if (e.KeyChar == '-' && (sender as TextBox).SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        private void tbxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số, dấu chấm, hoặc dấu âm
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true; // Loại bỏ ký tự
            }

            // Chỉ cho phép một dấu chấm
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu âm ở đầu
            if (e.KeyChar == '-' && (sender as TextBox).SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        private async void ProductList_Load(object sender, EventArgs e)
        {
            await LoadProductList();
        }

        //private async Task<string> GetUrlById(Guid? productId = null)
        //{
        //    if (!productId.HasValue)
        //    {
        //        // Nếu userId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
        //        return null;
        //    }

        //    var response = await _imagesService.GetImagesByProductId(productId.Value);

        //    // Kiểm tra kết quả trả về
        //    if (response?.Success == true && response.Data?.Url != null)
        //    {
        //        return (response.Data.Url);
        //    }


        //    // Trả về null nếu không tìm thấy người dùng hoặc dữ liệu không hợp lệ
        //    return null;
        //}
        //private async Task<Image> LoadImageFromUrlAsync(string url)
        //{

        //    WebRequest request = WebRequest.Create(url);
        //    using (var response = await request.GetResponseAsync())
        //    using (var stream = response.GetResponseStream())
        //    {
        //        return System.Drawing.Image.FromStream(stream); // Tạo đối tượng Image từ luồng dữ liệu
        //    }
        //}
        private async Task LoadProductList()
        {
            try
            {
                var response = await _productsService.GetAllProductsAsync();
                if (response != null && response.Data != null)
                {
                    // Ánh xạ dữ liệu sang OrderDisplayDto
                    _originalData = new List<ProductListDisplayDto>();

                    foreach (var product in response.Data)
                    {
                        //var url = await GetUrlById(product.Id);
                        //var image = await LoadImageFromUrlAsync(url);
                        _originalData.Add(new ProductListDisplayDto
                        {
                            Id = product.Id,
                            Name = product.Name,
                            //Image = image,
                            StockQuantity = product.StockQuantity,
                            Price = product.Price,
                            CategoryId = product.CategoryId,
                        });
                    }

                    _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize); // Tính tổng số trang
                    DisplayPage(_currentPage); // Hiển thị trang đầu tiên
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayPage(int pageNumber)
        {
            if (_originalData == null || !_originalData.Any()) return;

            // Lấy dữ liệu của trang hiện tại
            var pagedData = _originalData.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();

            // Gán dữ liệu vào DataGridView
            gridView.DataSource = pagedData;

            // Cập nhật trạng thái phân trang
            labelPageInfo.Text = $"Page {pageNumber} of {_totalPages}";
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

        private void cbxShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbxShow.SelectedItem.ToString(), out int newPageSize))
            {
                _pageSize = newPageSize; // Cập nhật kích thước trang
                _currentPage = 1;        // Quay về trang đầu
                _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize); // Tính lại số trang
                DisplayPage(_currentPage); // Hiển thị trang đầu
            }
        }

        private void gridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Kiểm tra nếu cột không cho phép click vào header
            if (gridView.Columns[e.ColumnIndex].Name == "Edit" || (gridView.Columns[e.ColumnIndex].Name == "Remove") || (gridView.Columns[e.ColumnIndex].Name == "Image"))
            {
                return; // Ngăn click vào header
            }
            // Lấy tên cột được nhấn
            string columnName = gridView.Columns[e.ColumnIndex].DataPropertyName;

            // Đảo trạng thái sắp xếp nếu nhấn lại cột cũ
            if (_sortedColumn == columnName)
            {
                _isAscending = !_isAscending;
            }
            else
            {
                // Chọn cột mới -> mặc định sắp xếp tăng dần
                _sortedColumn = columnName;
                _isAscending = true;
            }

            // Sắp xếp dữ liệu
            SortData(columnName, _isAscending);

            // Cập nhật ký tự mũi tên lên/đầu cột
            UpdateColumnHeaders();
        }
        private void SortData(string columnName, bool ascending)
        {
            if (_originalData == null || !_originalData.Any()) return;

            // Sắp xếp tăng hoặc giảm dần dựa trên tên cột
            _originalData = ascending
                ? _originalData.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList()
                : _originalData.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();

            // Hiển thị trang đầu sau khi sắp xếp
            _currentPage = 1;
            DisplayPage(_currentPage);
        }
        private void UpdateColumnHeaders()
        {
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                if (column.DataPropertyName == _sortedColumn)
                {
                    column.HeaderText = _isAscending
                        ? $"{column.HeaderText.TrimEnd('↑', '↓')} ↑"
                        : $"{column.HeaderText.TrimEnd('↑', '↓')} ↓";
                }
                else
                {
                    column.HeaderText = column.HeaderText.TrimEnd('↑', '↓'); // Xóa ký tự mũi tên nếu không phải cột đang sắp xếp
                }
            }
        }

        private async void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu người dùng nhấn vào tiêu đề cột hoặc vùng trống
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Lấy tên cột được nhấn
            string columnName = gridView.Columns[e.ColumnIndex].Name;

            // Lấy thông tin hàng hiện tại
            var selectedRow = gridView.Rows[e.RowIndex];
            var productId = (Guid)selectedRow.Cells["Id"].Value;

            // Kiểm tra nếu người dùng nhấn vào cột "Remove"
            if (columnName == "Remove")
            {
                // Hiển thị hộp thoại xác nhận xóa
                var confirmResult = MessageBox.Show("Are you sure you want to remove this item?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi hàm xóa từ service
                    var isDeleted = await _productsService.DeleteProductAsync(productId);

                    if (isDeleted)
                    {
                        MessageBox.Show("Item removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa hàng khỏi DataGridView
                        await LoadProductList();
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove the item. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



            // Kiểm tra xem có phải cột Edit hay không
            else if (columnName == "Edit")
            {
                // Gọi dịch vụ để lấy thông tin chi tiết
                var response = await _productsService.GetProductByIdAsync(productId);

                if (response.Success)
                {
                    var product = response.Data;

                    // Mở form Edit với dữ liệu lấy từ dịch vụ
                    using (var editForm = new ProductEdit(product))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            await LoadProductList(); // Cập nhật lại dữ liệu trong DataGridView
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve category details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async Task<string> GetCategoryNameById(Guid? categoryId = null)
        {
            if (!categoryId.HasValue)
            {
                // Nếu userId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
                return null;
            }

            var response = await _categoriesService.GetCategoryByIdAsync(categoryId.Value);

            // Kiểm tra kết quả trả về
            if (response?.Success == true && response.Data?.Name != null)
            {
                return response.Data.Name;
            }


            // Trả về null nếu không tìm thấy người dùng hoặc dữ liệu không hợp lệ
            return null;
        }
        private async void ApplyFilters(Guid? selectedCategory)
        {
            // Danh sách sản phẩm gốc
            var filteredData = _originalData;

            // Nếu đã chọn danh mục, lọc theo danh mục
            if (selectedCategory.HasValue)
            {
                var respone = await GetCategoryNameById(selectedCategory.Value);
                filteredData = filteredData
                    .Where(product => product.CategoryId == selectedCategory.Value)
                    .ToList();
            }

            // Lọc các điều kiện khác như giá, size, v.v.
            decimal minPrice = 0; // Hoặc giá trị nhỏ nhất có thể
            decimal maxPrice = decimal.MaxValue; // Hoặc giá trị lớn nhất có thể

            if (tbxMin.Text != "") minPrice = decimal.Parse(tbxMin.Text);
            if (tbxMax.Text != "") maxPrice = decimal.Parse(tbxMax.Text);

            // Lọc theo khoảng giá (min, max)
            filteredData = filteredData
            .Where(product => product.Price >= minPrice && product.Price <= maxPrice)
            .ToList();

            // Cập nhật giao diện (ví dụ: DataGridView)
            gridView.DataSource = filteredData;
        }
        private void ApplyFilters()
        {
            Guid? selectedCategory = cbxCate.SelectedValue as Guid?;
            // Danh sách sản phẩm gốc
            var filteredData = _originalData;

            // Nếu đã chọn danh mục, lọc theo danh mục
            if (selectedCategory.HasValue)
            {
                filteredData = filteredData
                    .Where(product => product.CategoryId == selectedCategory.Value)
                    .ToList();
            }

            // Lọc các điều kiện khác như giá, size, v.v.
            decimal minPrice = 0; // Hoặc giá trị nhỏ nhất có thể
            decimal maxPrice = decimal.MaxValue; // Hoặc giá trị lớn nhất có thể

            if (tbxMin.Text != "") minPrice = decimal.Parse(tbxMin.Text);
            if (tbxMax.Text != "") maxPrice = decimal.Parse(tbxMax.Text);
            // Lọc theo khoảng giá (min, max)
            filteredData = filteredData
            .Where(product => product.Price >= minPrice && product.Price <= maxPrice)
            .ToList();

            // Cập nhật giao diện (ví dụ: DataGridView)
            gridView.DataSource = filteredData;
        }
        private void rbtnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy ID danh mục được chọn
            Guid? selectedCategory = cbxCate.SelectedValue as Guid?;

            // Áp dụng bộ lọc
            ApplyFilters(selectedCategory);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Mở form AddCategoryForm
            var addProductForm = new ProductAdd();

            // Nếu người dùng thêm thành công, form sẽ đóng lại và danh sách cần được cập nhật
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                // Cập nhật lại danh sách (ví dụ: refresh lại DataGridView hoặc ListBox)
                LoadProductList();
            }

            // Đóng form hiện tại (CategoryListForm)
            this.Close();

           
        }
    }
}