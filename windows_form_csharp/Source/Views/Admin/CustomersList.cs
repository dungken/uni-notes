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
using Source.Dtos.User;
using Source.Service;

namespace Source.Views.Admin
{
    public partial class CustomersList : Form
    {
        private readonly UserService _usersService;
        private readonly OrderService _ordersService;
        private List<UserDisplayDto> _originalData; // Dữ liệu gốc
        private int _pageSize = 5;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp
        public CustomersList()
        {
            InitializeComponent();
            _usersService = new UserService();
            _ordersService = new OrderService();
            _originalData = new List<UserDisplayDto>();
            CustomizeDataGridView();
            InitializeShowing();
        }
        private void CustomizeDataGridView()
        {
            gridView.BorderStyle = BorderStyle.None;
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.GridColor = Color.Silver;
            gridView.Columns[0].Width = 150;
            gridView.Columns[1].Width = 150;
            gridView.Columns[2].Width = 200;
            gridView.Columns[3].Width = 150;
            gridView.Columns[4].Width = 150;
            gridView.Columns[5].Width = 80;
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

        private async void CustomersList_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
        }
        private async Task<int> GetTotalOrderById(Guid? userId )
        {
            if (!userId.HasValue)
            {
                // Nếu userId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
                return 0;
            }

            var orderResponse = await _ordersService.GetAllOrdersAsync();


            // Kiểm tra kết quả trả về
            if (orderResponse != null && orderResponse.Data != null)
            {
                var orders = orderResponse.Data;
                return orders.Count(order => order.UserId == userId);
            }
            // Trả về null nếu không tìm thấy người dùng hoặc dữ liệu không hợp lệ
            return 0;
        }
        private async Task LoadCustomers()
        {
            try
            {
                // Lấy danh sách người dùng
                var userResponse = await _usersService.GetAllUser();

                if (userResponse != null && userResponse.Data != null)
                {
                    _originalData = new List<UserDisplayDto>();

                    foreach (var user in userResponse.Data.Users)
                    {
                        // Lấy tổng số đơn hàng của từng người dùng bằng hàm GetOrderById
                        int totalOrders = await GetTotalOrderById(user.Id);

                        if (user.PhoneNumber == null) { user.PhoneNumber = "Chưa cập nhật"; }
                        _originalData.Add(new UserDisplayDto
                        {
                            Id = user.Id,
                            UserName = $"{user.FirstName} {user.LastName}",
                            Email = user.Email,
                            Phone = user.PhoneNumber,
                            TotalOrders = totalOrders
                        });
                        
                    }

                    _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize); // Tính tổng số trang
                    DisplayPage(_currentPage); // Hiển thị trang đầu tiên
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void rbtnPre_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void rbtnNext_Click(object sender, EventArgs e)
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
            if (gridView.Columns[e.ColumnIndex].Name == "Detail")
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
            var customerId = (Guid)selectedRow.Cells["Id"].Value;

            // Kiểm tra xem có phải cột Edit hay không
            if (columnName == "Detail")
            {
                // Gọi dịch vụ để lấy thông tin chi tiết
                var response = await _usersService.GetUserById(customerId);

                if (response.Success)
                {
                    var customer = response.Data;

                    //Mở form Detail với dữ liệu lấy từ dịch vụ
                    using (var detailForm = new CustomersDetails(customer, customerId))
                    {
                        if (detailForm.ShowDialog() == DialogResult.OK)
                        {
                            await LoadCustomers(); // Cập nhật lại dữ liệu trong DataGridView
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
