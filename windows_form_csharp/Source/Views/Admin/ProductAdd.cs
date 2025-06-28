using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using api.Dtos.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Source.Dtos.Category;
using Source.Dtos.Discount;
using Source.Dtos.Product;
using Source.Dtos.Reponse;
using Source.Dtos.Voucher;
using Source.Models;
using Source.Service;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;
using Panel = System.Windows.Forms.Panel;

namespace Source.Views.Admin
{
    public partial class ProductAdd : Form
    {
        private readonly ProductService _productService;
        private readonly ImageService _imageService;
        private readonly ColorsService _colorsService;
        private readonly SizeService _sizeService;
        private readonly CategoriesService _categoriesService;
        private readonly DiscountsService _discountsService;
        public string _name { get; set; }
        public string _description { get; set; }
        public decimal _price { get; set; }
        public int _stockQuantity { get; set; }
        public Guid _categoryId { get; set; }

        public string _status { get; set; }
        public Guid? _discountId { get; set; }

        public List<ColorDTO> _colors { get; set; } = new List<ColorDTO>();
        public List<CreateSizeforProductDto> _sizes { get; set; } = new List<CreateSizeforProductDto>();
        public List<ImageDTO> _images { get; set; } = new List<ImageDTO>();

        public List<IFormFile> _formFiles = new List<IFormFile>();
        //public ColorDialog _colorDialog;
        public List<Color> _selectedColors;
        private string _selectedFilePath = "";
        public ProductAdd()
        {
            InitializeComponent();
            pnBasicInfor.Paint += PanelLine_Paint;
            pnCategory.Paint += PanelLine_Paint;
            pnColor.Paint += PanelLine_Paint;
            pnSize.Paint += PanelLine_Paint;
            pnStatus.Paint += PanelLine_Paint;

            _productService = new ProductService();
            _imageService = new ImageService();
            _colorsService = new ColorsService();
            _sizeService = new SizeService();
            _categoriesService = new CategoriesService();
            _discountsService = new DiscountsService();

            //_colorDialog = new ColorDialog();
            _selectedColors = new List<Color>();

            LoadCategories();
            LoadDiscounts();
            lbxDiscount.SelectedIndex = -1; // Không chọn mục nào

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
        private async void LoadCategories()
        {
            var response = await _categoriesService.GetAllCategories();
            if (response.Success)
            {
                // Thêm danh mục cha vào ListBox
                lbxCategory.DataSource = response.Data;
                lbxCategory.DisplayMember = "Name";
                lbxCategory.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("Failed to load parent categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void LoadDiscounts()
        {
            var response = await _discountsService.GetAllDiscounts();
            if (response.Success)
            {
                // Thêm danh mục cha vào ListBox
                lbxDiscount.DataSource = response.Data;
                lbxDiscount.DisplayMember = "Percentage";
                lbxDiscount.ValueMember = "Id";
                lbxDiscount.SelectedIndex = -1; // Không chọn mục nào
            }
            else
            {
                MessageBox.Show("Failed to load discount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("Product name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _name = tbxName.Text;
            if (string.IsNullOrEmpty(tbxDescription.Text))
            {
                MessageBox.Show("Product description cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _description = tbxDescription.Text;
            //if (int.Parse(numeric.Value.ToString()) < _sizes.Count)
            //{
            //    MessageBox.Show("The number of products must not be less than the number of sizes.!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (int.Parse(numeric.Value.ToString()) < _colors.Count)
            //{
            //    MessageBox.Show("The number of products must not be less than the number of colors.!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            _stockQuantity = int.Parse(numeric.Value.ToString());
            if (lbxCategory.SelectedItem == null)
            {
                MessageBox.Show("Product category cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _categoryId = ((CategoryDto)lbxCategory.SelectedItem).Id;
            if (!decimal.TryParse(tbxPrice.Text, out _))
            {
                MessageBox.Show("\"Please enter a valid value of price!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _price = decimal.Parse(tbxPrice.Text);
            if (lbxDiscount.SelectedItem != null)
            {
                _discountId = ((DiscountDto)lbxDiscount.SelectedItem).Id;
            }
            else
            {
                _discountId = null;
            }

            // Kiểm tra trạng thái từ RadioButton
            if (rbtnActive.Checked)
            {
                _status = "Active";
            }
            else if (rbtnInactive.Checked)
            {
                _status = "Inactive";
            }
            else if (rbtnPending.Checked)
            {
                _status = "Pending";
            }
            else
            {
                MessageBox.Show("Please select a status!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // size
            List<string> size;
            size = new List<string>();
            if (cbxXS.Checked)
            {
                size.Add("XS");
            }
            if (cbxS.Checked)
            {
                size.Add("S");
            }
            if (cbxM.Checked)
            {
                size.Add("M");
            }
            if (cbxL.Checked)
            {
                size.Add("L");
            }
            if (cbxXL.Checked)
            {
                size.Add("XL");
            }

            var newProductDto = new CreateProductDto
            {
                Name = _name,
                Description = _description,
                StockQuantity = _stockQuantity,
                CategoryId = _categoryId,
                Status = _status,
                Price = _price,
                DiscountId = _discountId,
            };

            // Gọi service để thêm danh mục vào backend
            var response = await _productService.CreateProductAsync(newProductDto);

            if (response.Success)
            {
                if (size != null)
                {
                    foreach (var index in size)
                    {
                        var newSizeDto = new CreateSizeforProductDto
                        {
                            Id = Guid.NewGuid(),
                            Name = index,
                            ProductId = response.Data.Id,
                        };
                        _sizes.Add(newSizeDto);
                    }
                    if (_sizes.Count > 0 && _sizes != null)
                    {
                        foreach (var size1 in _sizes)
                        {
                            await _sizeService.CreateSizeAsync(size1);
                        }
                    }
                }
                if (_colors.Count > 0 && _colors != null)
                {
                    foreach (var color in _colors)
                    {
                        var newColorDto = new ColorDTO
                        {
                            Id = color.Id,
                            Name = color.Name,
                            ColorCode = color.ColorCode,
                            ProductId = response.Data.Id,
                        };
                        await _colorsService.CreateCollorAsync(newColorDto);
                    }
                }

                if (_formFiles.Count > 0)
                {
                    UploadMultiImg(response.Data.Id, _name);
                    response.Data.Images = _images;
                }
                // Thông báo thành công và đóng form
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void UploadMultiImg(Guid productId, string altText)
        {
            var response = await _imageService.UploadMultipleImages(_formFiles.ToArray(), productId, altText);
            if (response != null && response.Success)
            {
                MessageBox.Show($"Registration Successful\nMessage: {response.Message}");
                foreach (var item in response.Data)
                {
                    _images.Add(item);
                    MessageBox.Show($"{item.CreatedAt}: {item.Url}");
                }

            }
            else
            {
                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", response.Errors)}");
            }
        }
        // Phương thức để lấy tên màu
        private string GetColorName(Color color)
        {
            // Kiểm tra xem màu có phải là một màu chuẩn đã định nghĩa trong Color hay không
            var colorProperty = typeof(Color).GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(Color) && (Color)p.GetValue(null) == color);

            return colorProperty?.Name ?? "Unknown"; // Nếu không tìm thấy tên, trả về "Unknown"
        }
        // vẽ màu
        // Xử lý sự kiện vẽ để hiển thị màu
        private void LbxColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Lấy màu từ ListBox
            Color color = (Color)lbxColor.Items[e.Index];

            // Vẽ nền mục
            e.DrawBackground();

            // Vẽ ô vuông màu
            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(brush, e.Bounds.X + 2, e.Bounds.Y + 2, 20, e.Bounds.Height - 4);
            }

            // Hiển thị tên màu (nếu cần)
            string colorName = $"ARGB: {color.ToArgb()}";
            using (Brush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(colorName, e.Font, textBrush, e.Bounds.X + 25, e.Bounds.Y + 2);
            }

            e.DrawFocusRectangle();
        }
        private async void btnPickColor_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn màu
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy màu đã chọn
                Color selectedColor = colorDialog.Color;
                // Chuyển đổi thành mã màu Hex
                string hexColor = $"#{selectedColor.R:X2}{selectedColor.G:X2}{selectedColor.B:X2}";

                // Tìm tên màu gần nhất
                string colorName = GetColorName(selectedColor);

                //MessageBox.Show($"Color Name: {colorName}\nHex Color: {hexColor}\nRGB: {selectedColor.R}, {selectedColor.G}, {selectedColor.B}");

                var newColorDto = new ColorDTO
                {
                    Name = colorName,
                    ColorCode = hexColor,
                };
                _colors.Add(newColorDto);
            }

            // Hiển thị danh sách màu đã chọn
            lbxColor.Items.Add(colorDialog.Color);
        }

        private void btnPickImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Select a File to Upload"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var filePath in openFileDialog.FileNames)
                {

                    _selectedFilePath = openFileDialog.FileName;
                    string directoryPath = Path.GetDirectoryName(_selectedFilePath);
                    string combinedPath = Path.Combine(directoryPath, Path.GetFileName(_selectedFilePath));
                    _selectedFilePath = combinedPath;
                    MessageBox.Show($"File selected: {combinedPath}");

                    using (var stream = new MemoryStream(File.ReadAllBytes(_selectedFilePath)))
                    {

                        PictureBox pictureBox = new PictureBox
                        {
                            Image = Image.FromStream(stream),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Width = 100, // Điều chỉnh kích thước theo ý muốn
                            Height = 100,
                            Margin = new Padding(5)
                        };

                        flowLayoutPanel.Controls.Add(pictureBox); // Thêm PictureBox vào FlowLayoutPanel
                    }

                    // Tạo file giả lập đầu tiên
                    byte[] imageData1 = File.ReadAllBytes(_selectedFilePath);
                    var fileStream1 = new MemoryStream(imageData1);
                    _formFiles.Add(new FormFile(
                        baseStream: fileStream1,
                        baseStreamOffset: 0,
                        length: fileStream1.Length,
                        name: "file1",
                        fileName: _selectedFilePath
                    )
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "image/png"
                    });
                }
            }


        }

        private void ProductAdd_Load(object sender, EventArgs e)
        {
            lbxColor.DrawMode = DrawMode.OwnerDrawFixed; // Kích hoạt chế độ vẽ tùy chỉnh
            lbxColor.DrawItem += LbxColor_DrawItem; // Liên kết sự kiện vẽ
        }
    }
}