using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Source.Service;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Source.Views.Admin
{
    public partial class ImageDelete : Form
    {
        private readonly ImageService _imageService;
        private Guid _productId;
        private List<Guid> selectedImageIds = new List<Guid>(); // Lưu ID các ảnh đã chọn
        public ImageDelete()
        {
            InitializeComponent();
            _imageService = new ImageService();
        }
        public ImageDelete(Guid productId)
        {
            InitializeComponent();
            _imageService = new ImageService();
            _productId = productId;
        }

        private void ImageDelete_Load(object sender, EventArgs e)
        {

        }
        private void LoadImage()
        {
            //var image = _imageService.GetImagesByProductId(this._productId).Result.Data.Url;
            //// Xóa các control cũ trong panel nếu có
            //pnImg.Controls.Clear();

            //// Kích thước và khoảng cách giữa các ảnh
            //int x = 10, y = 10;
            //int imageWidth = 100, imageHeight = 100;
            //int margin = 10;

            //foreach (var url in image)
            //{
            //    // Tạo PictureBox
            //    PictureBox pictureBox = new PictureBox
            //    {
            //        Size = new Size(imageWidth, imageHeight),
            //        Location = new Point(x, y),
            //        SizeMode = PictureBoxSizeMode.StretchImage
            //    };

            //    // Tải ảnh từ URL
            //    using (WebClient webClient = new WebClient())
            //    {
            //        byte[] imageData = webClient.DownloadData(url);
            //        using (var stream = new System.IO.MemoryStream(imageData))
            //        {
            //            pictureBox.Image = Image.FromStream(stream);   
            //            pictureBox.Tag = image;  // Lưu ảnh vào Tag
            //        }
            //    }

            //    // Thêm PictureBox vào panel
            //    pnImg.Controls.Add(pictureBox);

            //    // Cập nhật vị trí cho ảnh tiếp theo
            //    x += imageWidth + margin;

            //    // Nếu vị trí vượt quá chiều rộng của panel, xuống dòng
            //    if (x + imageWidth > pnImg.Width)
            //    {
            //        x = 10;
            //        y += imageHeight + margin;
            //    }
            //}
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            //if (sender is PictureBox pictureBox)
            //{
            //    int id = (int)pictureBox.Tag; // Lấy ID từ Tag

            //    if (selectedImageIds.Contains(id))
            //    {
            //        // Nếu ảnh đã được chọn, bỏ chọn
            //        selectedImageIds.Remove(id);
            //        pictureBox.BorderStyle = BorderStyle.None; // Bỏ viền sáng
            //    }
            //    else
            //    {
            //        // Nếu ảnh chưa được chọn, thêm vào danh sách
            //        selectedImageIds.Add(id);
            //        pictureBox.BorderStyle = BorderStyle.Fixed3D; // Hiện viền sáng
            //    }

            //    // Hiển thị danh sách đã chọn (tuỳ chọn để kiểm tra)
            //    Console.WriteLine("Selected IDs: " + string.Join(", ", selectedImageIds));
            //}
        }
    }
}
