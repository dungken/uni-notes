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
using Source.Models;
using Source.Service;

namespace Source.Views.Admin
{
    public partial class OrderDetails : Form
    {
        private readonly OrderService _ordersService;
        private readonly UserService _usersService;
        private readonly VoucherService _voucherService;
        private readonly ProductService _productService;
        private List<OrderDetailsDisplayDto> _originalData; // Dữ liệu gốc
        private OrderDto _order;
        private int _pageSize = 5;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        public OrderDetails()
        {
            InitializeComponent();
            CustomizeDataGridView();
            _ordersService = new OrderService();
            _usersService = new UserService();
            _voucherService = new VoucherService();
            _productService = new ProductService();
        }
        public OrderDetails(OrderDto order)
        {
            InitializeComponent();

            _ordersService = new OrderService();
            _order = order;
            _usersService = new UserService();
            _voucherService = new VoucherService();
            _productService = new ProductService();
            LoadOrderData();
        }
        private void CustomizeDataGridView()
        {
            //gridView.BorderStyle = BorderStyle.None;
            //gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //gridView.GridColor = Color.Silver;
            gridView.Columns[0].Width = 200;
            gridView.Columns[1].Width = 150;
            gridView.Columns[2].Width = 150;
            gridView.Columns[3].Width = 150;
        }
        //private async void LoadOrdersId()
        //{
        //    var response = await _ordersService.GetAllOrdersAsync();
        //    if (response.Success && response != null)
        //    {
        //        cbxOrderId.Items.Clear();
        //        foreach (var order in response.Data)
        //        {
        //            cbxOrderId.Items.Add(order.Id);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Failed to load parent categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        // dang loi ne
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
        private async Task<string> GetUserPhoneById(Guid? userId = null)
        {
            if (!userId.HasValue)
            {
                // Nếu userId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
                return null;
            }

            // Gọi API thông qua GetUserById
            var response = await _usersService.GetUserById(userId.Value);

            // Kiểm tra kết quả trả về
            if (response?.Success == true && response.Data?.user != null)
            {
                if (response.Data.user.PhoneNumber == null)
                {
                    return "Chưa cập nhật";
                }
                return response.Data.user.PhoneNumber; // Trả về số điện thoại nếu tìm thấy
            }

            // Trả về null nếu không tìm thấy hoặc dữ liệu không hợp lệ
            return null;
        }
        private async Task<string> GetProductNameById(Guid? productId = null)
        {
            if (!productId.HasValue)
            {
                // Nếu userId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
                return null;
            }

            var response = await _productService.GetProductByIdAsync(productId.Value);

            // Kiểm tra kết quả trả về
            if (response?.Success == true && response.Data?.Name != null)
            {
                return response.Data.Name;
            }


            // Trả về null nếu không tìm thấy người dùng hoặc dữ liệu không hợp lệ
            return null;
        }
        private async Task LoadOrderDetaills(Guid orderId)
        {
            try
            {
                var response = await _ordersService.GetOrderByIdAsync(orderId);
                var result = response.Data?.OrderDetails;

                if (result != null)
                {
                    _originalData = new List<OrderDetailsDisplayDto>();

                    foreach (var order in result)
                    {
                        var productName = await GetProductNameById(order.ProductId); // Lấy tên sản phẩm
                        _originalData.Add(new OrderDetailsDisplayDto
                        {
                            Id = orderId,
                            ProductName = productName, // Thêm tên sản phẩm
                            Quantity = order.Quantity,
                            UnitPrice = order.UnitPrice
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
        private async Task<decimal> GetDiscountById(Guid? voucherId = null)
        {
            if (!voucherId.HasValue)
            {
                // Nếu voucherId là null, có thể xử lý theo yêu cầu của bạn (ví dụ: trả về null hoặc throw lỗi)
                return 0;
            }

            var response = await _voucherService.GetVoucherByIdAsync(voucherId.Value);

            // Kiểm tra kết quả trả về
            if (response?.Success == true)
            {
                return response.Data.DiscountAmount;
            }

            // Trả về null nếu không tìm thấy voucher hoặc dữ liệu không hợp lệ
            return 0;
        }

        private async void LoadOrderData()
        {
            // get header
            lblOrderId.Text = _order.Id.ToString();
            // get order id
            //LoadOrdersId();
            // get date
            lblDate.Text = _order.OrderDate.ToString();
            // get name

            lblNameValue.Text = await GetUserNameById(_order.UserId); 
            // get address
            lblAddressValue.Text = _order.shippingAddress.ToString();
            // get phone
            lblPhone.Text = await GetUserPhoneById(_order.UserId); // chua co sdt
            //get summary product
            LoadOrderDetaills(_order.Id);
            //get payment
            lblSubotalPriceValue.Text = _order.TotalAmount.ToString();
            decimal discount = await GetDiscountById(_order.VoucherID);
            if (discount != 0)
                lblDiscountValue.Text = discount.ToString();
            else
            {
                lblDiscountValue.Text = 0.ToString();
            }
            var total = (_order.TotalAmount - discount);
            if (total > 0)
            {
                lblTotalValue.Text = total.ToString();
            }
            else
            {
                lblTotalValue.Text = "0";
            }
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
    }
}
