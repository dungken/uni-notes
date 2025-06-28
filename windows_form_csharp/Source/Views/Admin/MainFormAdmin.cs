using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Source.Service;
using ScottPlot;
using Source.Views.Admin;
using Source.Views.Custommer;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Guna.Charts.WinForms;
using static SkiaSharp.HarfBuzz.SKShaper;
using NPOI.SS.Formula.Functions;
using ScottPlot.TickGenerators.Financial;
using NPOI.XSSF.Streaming.Values;
namespace Source.Views
{
    public partial class MainFormAdmin : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        private int _year;

        public static int frmAdminMainFormLocationX, frmAdminMainFormLocationY;
        public static int pnlChildFormMainLocationX, pnlChildFormMainLocationY;
        public static int frmWith, frmHeight;
        public MainFormAdmin()
        {
            InitializeComponent();
            _userService = new UserService();
            _orderService = new OrderService();
            _productService = new ProductService();

            LoadData();
            LoadDataDashBoard();

            for (int year = 2015; year <= 2025; year++)
            {
                cbxYear.Items.Add(year);
            }
            cbxYear.SelectedIndex = 10;
            _year = 2025;
            // Tạo ScottPlot control
            //plt = new FormsPlot
            //{
            //    Dock = DockStyle.Fill
            //};
            //this.Controls.Add(plt);

            //// Tải dữ liệu đơn hàng
            //LoadSampleOrders();

            //// Thống kê và hiển thị doanh thu theo tháng
            //var monthlyData = GetRevenueByMonth(_orders);
            //DisplayChart(monthlyData, "Thống Kê Doanh Thu Theo Tháng");

        }
        private void OpenDefaultForm()
{
    // Đóng form con hiện tại nếu có
    if (activeForm != null)
    {
        activeForm.Close();
    }

    // Thiết lập lại trạng thái của form chính
    pnlChildForm.Controls.Clear();
    pnlChildForm.Controls.Add(pnThongKe); // pnThongKe là panel chứa nội dung mặc định
    pnThongKe.BringToFront();
    pnThongKe.Show();
}
        public async void LoadData()
        {
            var responeCus = await _userService.GetAllUser();
            if (responeCus != null)
            {
                lblCustomerV.Text = responeCus.Data.Users.
                    Select(user => user.UserRoles.
                    FirstOrDefault(role => role.Name == "User")).Count().ToString();
            }
            var responeOrder = await _orderService.GetAllOrdersAsync();
            decimal totalSale = 0;
            int product = 0;
            if (responeOrder != null)
            {
                lblOrderV.Text = responeOrder.Data.Count().ToString();
                var responeSale = responeOrder.Data.ToList().Select(s => s.TotalAmount);
                foreach (var order in responeSale)
                {
                    totalSale += order;
                }

                lblTotalSaleV.Text = totalSale.ToString();
                decimal value = (totalSale / int.Parse(lblOrderV.Text));
                decimal roundedValue = Math.Round(value, 2);
                lblAvgSaleV.Text = roundedValue.ToString();

            }
            var responeProduct = await _productService.GetAllProductsAsync();
            if (responeProduct != null)
            {
                product = responeProduct.Data.Count();
                lblTotalProductV.Text = product.ToString();
            }
            if (responeOrder != null && responeProduct != null)
            {
                decimal value = (totalSale / product);
                decimal roundedValue = Math.Round(value, 2);
                lblItemSaleV.Text = roundedValue.ToString();
            }

        }

        // Tạo Form con 
        private Form? activeForm = null;
        private void openChildForm(Form childForm)
        {
            frmAdminMainFormLocationX = Login.frmLoginLocationX;
            frmAdminMainFormLocationY = Login.frmLoginLocationY;
            frmHeight = Login.frmHeight;
            frmWith = Login.frmWith;
            pnlChildFormMainLocationX = pnlChildForm.Location.X;
            pnlChildFormMainLocationY = pnlChildForm.Location.Y;
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductList());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryList());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrdersList());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomersList());
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            openChildForm(new VouchersList());
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            openChildForm(new DiscountsList());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            openChildForm(new Setting());
        }
        private async Task<List<decimal>> GetSaleForMonth()
        {
            var lstSale = new List<decimal>();


            var responeOrder = await _orderService.GetAllOrdersAsync();

            if (responeOrder != null)
            {
                var responeSale = responeOrder.Data.ToList();
                for (int index = 1; index <= 12; index++)
                {

                    var sale = responeSale.Where(s => s.OrderDate.Month == index && s.OrderDate.Year == _year)
                                            .Select(s => s.TotalAmount);
                    decimal totalSale = 0;
                    foreach (var s in sale)
                    {
                        totalSale += s;
                    }
                    lstSale.Add(totalSale);

                }
            }
            return lstSale;
        }
        private async void LoadDataDashBoard()
        {

            string[] months = { "January", "February", "March", "April", "May", "June",
                                "July", "August", "September", "October", "November", "December"};


            var lstSale = await GetSaleForMonth();
            var lPointCollection = new LPointCollection();
            int i = 0;
            foreach (var item in lstSale)
            {

                lPointCollection.Add(months[i], Convert.ToDouble(item));
                i++;
            }
            gunaBarDataset.DataPoints = lPointCollection;
        }
        private async void rbtnExport_Click(object sender, EventArgs e)
        {
            string[] months = { "January", "February", "March", "April", "May", "June",
                    "July", "August", "September", "October", "November", "December" };
            var lstSale = await GetSaleForMonth(); // Danh sách tổng doanh thu cho từng tháng

            // Tạo workbook và worksheet mới
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Data Sale Order");

            // Tạo hàng đầu tiên với tiêu đề năm
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue($"Year: {_year}");

            // Tạo hàng tiêu đề cột
            IRow nextRow = sheet.CreateRow(1);
            nextRow.CreateCell(0).SetCellValue("Month");
            nextRow.CreateCell(1).SetCellValue("Total Sale");

            // Thêm dữ liệu vào Excel từ months và lstSale
            for (int i = 0; i < months.Length; i++)
            {
                IRow row = sheet.CreateRow(i + 2); // Bắt đầu từ dòng thứ 3 (index = 2)
                row.CreateCell(0).SetCellValue(months[i]);         // Tên tháng
                row.CreateCell(1).SetCellValue((double)lstSale[i]); // Tổng doanh thu
            }

            // Lấy thư mục gốc của dự án
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string outputPath = Path.Combine(projectPath, "Statistics", "output.xlsx");

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            string directoryPath = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Lưu workbook vào file
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
                workbook.Close();
            }

            MessageBox.Show($"Dữ liệu đã được xuất thành công ra file Excel tại: {outputPath}", "Success");

        }

        private void MainFormAdmin_Load(object sender, EventArgs e)
        {
            LoadDataDashBoard();
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbxYear.SelectedItem.ToString(), out int newYear))
            {
                _year = newYear;
                LoadDataDashBoard();
            }
        }

        private async void btnHome_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}