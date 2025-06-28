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
using Source.Dtos.Order;
using Source.Models;
using Source.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Source.Views.Admin
{
    public partial class OrdersList : Form
    {
        private readonly OrderService _ordersService;
        private readonly UserService _usersService;
        private List<OrderDisplayDto> _originalData; // Dữ liệu gốc
        private int _pageSize = 5;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp
        public OrdersList()
        {
            InitializeComponent();
            _ordersService = new OrderService();
            _usersService = new UserService();
            _originalData = new List<OrderDisplayDto>();
            CustomizeDataGridView();
            InitializeShowing();
        }
        private void CustomizeDataGridView()
        {
            gridView.Columns[0].Width = 190;
            gridView.Columns[1].Width = 150;
            gridView.Columns[2].Width = 190;
            gridView.Columns[3].Width = 100;
            gridView.Columns[4].Width = 100;
            gridView.Columns[5].Width = 80;
            gridView.Columns[6].Width = 80;
            gridView.AutoGenerateColumns = false;
        }
        private void InitializeShowing()
        {
            // comboxbox
            // Thêm các giá trị từ 1 đến 10 vào ComboBox
            for (int i = 1; i <= 10; i++)
            {
                cbxShow.Items.Add(i);
            }

            cbxShow.SelectedIndex = 4; // Mặc định chọn 5 hàng trên mỗi trang
        }

        private async void OrdersList_Load(object sender, EventArgs e)
        {
            await LoadOrders();
        }

        private async Task<string> GetUserNameById(Guid? userId = null)
        {
            if (!userId.HasValue)
            {
                // Nếu userId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
                return null;
            }

            var response = await _usersService.GetUserById(userId.Value);

            // Kiểm tra kết quả trả về
            if (response?.Success == true && response.Data?.user.FirstName != null && response.Data?.user.LastName != null)
            {
                return (response.Data.user.FirstName + " " + response.Data.user.LastName);
            }


            // Trả về null nếu không tìm thấy người dùng hoặc dữ liệu không hợp lệ
            return null;
        }
        
        private async Task LoadOrders()
        {
            try
            {
                var response = await _ordersService.GetAllOrdersAsync();
                if (response != null && response.Data != null)
                {
                    // Ánh xạ dữ liệu sang OrderDisplayDto
                    _originalData = new List<OrderDisplayDto>();

                    foreach (var order in response.Data)
                    {
                        var userName = await GetUserNameById(order.UserId); // Lấy tên người dùng
                        _originalData.Add(new OrderDisplayDto
                        {
                            Id = order.Id,
                            OrderDate = order.OrderDate,
                            Status = order.Status,
                            TotalAmount = order.TotalAmount,
                            CustomerName = userName // Thêm tên khách hàng
                        });
                    }

                    _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize); // Tính tổng số trang
                    DisplayPage(_currentPage); // Hiển thị trang đầu tiên
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu order.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (gridView.Columns[e.ColumnIndex].Name == "Edit" || gridView.Columns[e.ColumnIndex].Name == "Detail")
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
            var orderId = (Guid)selectedRow.Cells["Id"].Value;
            // Kiểm tra xem có phải cột Edit hay không
            if (columnName == "Edit")
            {
                // Gọi dịch vụ để lấy thông tin chi tiết
                var response = await _ordersService.GetOrderByIdAsync(orderId);

                if (response.Success)
                {
                    var order = response.Data;

                    // Mở form Edit với dữ liệu lấy từ dịch vụ
                    using (var editForm = new OrdersEdit(order))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            await LoadOrders(); // Cập nhật lại dữ liệu trong DataGridView
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve category details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (columnName == "Detail")
            {
                // Gọi dịch vụ để lấy thông tin chi tiết
                var response = await _ordersService.GetOrderByIdAsync(orderId);

                if (response.Success)
                {
                    var order = response.Data;

                    // Mở form Edit với dữ liệu lấy từ dịch vụ
                    using (var detailForm = new OrderDetails(order))
                    {
                        if (detailForm.ShowDialog() == DialogResult.OK)
                        {
                            await LoadOrders(); // Cập nhật lại dữ liệu trong DataGridView
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve category details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    
    }
}
