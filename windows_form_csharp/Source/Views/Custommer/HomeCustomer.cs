using Source.Models;
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

namespace Source.Views.Custommer
{
    public partial class HomeCustomer : Form
    {
        private readonly VoucherService _voucherService;
        private int _pageSize = 3; // Số sản phẩm trên mỗi trang
        private int _currentPage = 1; // Trang hiện tại
        private int _totalPages = 1; // Tổng số trang

        private List<Voucher> _vouchers; 
        private List<Voucher> _originalVouchers;
        public HomeCustomer()
        {
            InitializeComponent();
            _voucherService = new VoucherService();

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
            pnlHomeCustomer.Controls.Add(childForm);
            pnlHomeCustomer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductsCustomer());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductsCustomer());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductsCustomer());
        }

        private async void HomeCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                var response = await _voucherService.GetAllVouchersAsync();
                if (response.Success)
                {
                    _vouchers = response.Data.ToList(); // Lấy danh sách sản phẩm
                    _originalVouchers = new List<Voucher>(_vouchers); // Sao chép danh sách gốc
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
        }
        private void UpdatePagination()
        {
            if (_vouchers != null && _vouchers.Any())
            {
                _totalPages = (int)Math.Ceiling((double)_vouchers.Count / _pageSize);
                DisplayVouchersForCurrentPage();
            }
        }
        private async void DisplayVouchersForCurrentPage()
        {
            ClearVoucherPanels();

            var vouchersToDisplay = _vouchers
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            for (int i = 0; i < vouchersToDisplay.Count; i++)
            {
                var voucher = vouchersToDisplay[i];
                var panel = GetVoucherPanel(i + 1);

                if (panel == null) continue;

                // Gán sản phẩm vào Tag của panel
                panel.Tag = voucher;

                // Duyệt panelInforVoucher của từng panel
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is Panel panelInforVoucher)
                    {
                        foreach (Control infoCtrl in panelInforVoucher.Controls)
                        {
                            if (infoCtrl is Label label)
                            {

                                switch (label.Name)
                                {
                                    case "lblNameVoucher1":
                                    case "lblNameVoucher2":
                                    case "lblNameVoucher3":
                                        label.Text = "Giảm " + voucher.DiscountAmount + " đồng cho đơn " + voucher.MinimumOrderValue + " đồng";
                                        break;

                                    case "lblMinOrder1":
                                    case "lblMinOrder2":
                                    case "lblMinOrder3":
                                        label.Text = "Hóa đơn tối thiểu: " + voucher.MinimumOrderValue.ToString("C");
                                        break;
                                    case "lblEndDate1":
                                    case "lblEndDate2":
                                    case "lblEndDate3":
                                        label.Text = "Ngày kết thúc:" + voucher.EndDate.ToShortDateString();
                                        break;
                                }
                            }
                        }
                    }
                }

                panel.Visible = true;
            }

            UpdatePaginationButtons();
        }
        private void UpdatePaginationButtons()
        {
            // Bật/tắt nút Previous và Next
            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;

            // Hiển thị thông tin trang
            lblPaginationInfo.Text = $"Page {_currentPage} of {_totalPages}";
        }
        private void ClearVoucherPanels()
        {
            // Ẩn tất cả các panel và xóa thông tin cũ
            for (int i = 1; i <= 3; i++)
            {
                var panel = GetVoucherPanel(i);
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
        private Panel GetVoucherPanel(int position)
        {
            switch (position)
            {
                case 1: return pnlVourcher1;
                case 2: return pnlVourcher2;
                case 3: return pnlVourcher3;

                default: return null;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayVouchersForCurrentPage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                DisplayVouchersForCurrentPage();
            }
        }
    }
}
