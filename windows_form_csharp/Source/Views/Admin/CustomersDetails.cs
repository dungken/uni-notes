using Source.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Source.Dtos.Order;
using Source.Dtos.Reponse;
using Source.Service;

namespace Source.Views.Admin
{
    public partial class CustomersDetails : Form
    {
        private readonly OrderService _ordersService;
        private readonly UserService _usersService;
        private readonly FeedbackService _feedbackService;
        private List<OrderCustomerDisplayDto> _originalData;
        private GetUserRespone _user;
        private int _pageSize = 5;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp
                                                  // test
        private Guid _customerId;


        public CustomersDetails()
        {
            InitializeComponent();
            CustomizeDataGridView();
            InitializeShowing();
            pnProfile.Paint += PanelLine_Paint;
            pnStatus.Paint += PanelLine_Paint;

            //pnMain.Paint += PanelLine_Paint;
            _ordersService = new OrderService();
            _usersService = new UserService();
            _feedbackService = new FeedbackService();
        }
        public CustomersDetails(GetUserRespone user, Guid customerId)
        {
            InitializeComponent();
            CustomizeDataGridView();
            InitializeShowing();
            pnProfile.Paint += PanelLine_Paint;
            pnStatus.Paint += PanelLine_Paint;
            //pnMain.Paint += PanelLine_Paint;
            _ordersService = new OrderService();
            _usersService = new UserService();
            _feedbackService = new FeedbackService();
            _user = user;
            _customerId = customerId;
            LoadCustomerData();
            //test
            //_userId = Guid.Parse("AB8DD9FF-0FA5-4EF2-CCFE-08DD1BF41832");
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
            gridView.Columns[0].Width = 150;
            gridView.Columns[1].Width = 150;
            gridView.Columns[2].Width = 130;
            gridView.Columns[3].Width = 150;
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
        private void CustomersDetails_Load(object sender, EventArgs e)
        {

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
            //if (int.TryParse(cbxShow.SelectedItem.ToString(), out int newPageSize))
            //{
            //    _pageSize = newPageSize; // Cập nhật kích thước trang
            //    _currentPage = 1;        // Quay về trang đầu
            //    _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize); // Tính lại số trang
            //    DisplayPage(_currentPage); // Hiển thị trang đầu
            //}
        }

        private void gridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

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
        private async Task<int> GetTotalOrderById(Guid? userId)
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
        //private async Task<int> GetTotalReviewById(Guid? userId)
        //{
        //    if (!userId.HasValue)
        //    {
        //        // Nếu userId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
        //        return 0;
        //    }

        //    var reviewResponse = await _feedbackService. (userId.Value);


        //    // Kiểm tra kết quả trả về
        //    if (reviewResponse != null && reviewResponse.Data != null)
        //    {
        //        var orders = reviewResponse.Data.ToList().Count;
        //        return orders;
        //    }
        //    // Trả về null nếu không tìm thấy người dùng hoặc dữ liệu không hợp lệ
        //    return 0;
        //}
        private async Task LoadOrders(Guid userId)
        {
            try
            {
                var response = await _ordersService.GetAllOrdersAsync();
                if (response != null && response.Data != null)
                {
                    // Lọc danh sách đơn hàng có UserId bằng với userId truyền vào
                    var filteredOrders = response.Data.Where(order => order.UserId == userId);

                    // Ánh xạ dữ liệu sang OrderCustomerDisplayDto
                    _originalData = new List<OrderCustomerDisplayDto>();

                    foreach (var order in filteredOrders)
                    {
                        _originalData.Add(new OrderCustomerDisplayDto
                        {
                            Id = order.Id,
                            OrderDate = order.OrderDate,
                            Status = order.Status,
                            TotalAmount = order.TotalAmount,
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
        private async void LoadCustomerData()
        {
            // get image
            if (_user.user.ProfilePicture != null)
            {
                picbxProfile.Load(_user.user.ProfilePicture);
            }
            // get id
            lblId.Text = _customerId.ToString();
            // get name
            lblName.Text = _user.user.FirstName + " " + _user.user.LastName;
            // get gender
            if (!string.IsNullOrEmpty(_user.user.Gender))
                lblGender.Text = $"{DateTime.Now.Year - _user.user.DateOfBirth.Value.Year} years, {_user.user.Gender}";
            else
                lblGender.Text = "Chưa cập nhật";
            // get phone
            if (!string.IsNullOrEmpty(_user.user.PhoneNumber))
                lblPhone.Text = _user.user.PhoneNumber;
            else
                lblPhone.Text = "Chưa cập nhật";
            // get email

            // get date of birth
            if (_user.user.DateOfBirth != null)
                lblDateOfBirth.Text = _user.user.DateOfBirth.ToString();
            else
                lblDateOfBirth.Text = "Chưa cập nhật";
            // get address
            if (!string.IsNullOrEmpty(_user.user.FullAddress))
                lblAddress.Text = _user.user.FullAddress;
            else
                lblPhone.Text = "Chưa cập nhật";
            // get order buy
            int orderCount = (await GetTotalOrderById(_customerId));
            lblOrderBuyV.Text = orderCount.ToString();
            // get review
            //int feedBackCount = (await GetTotalReviewById(_customerId));
            //lblReviewProductV.Text = feedBackCount.ToString();

            // get order
            await LoadOrders(_customerId);
        }
    }
}