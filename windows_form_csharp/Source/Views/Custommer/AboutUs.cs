using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.Views.Custommer
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void MakePictureBoxCircular(PictureBox pictureBox)
        {
            // Tạo vùng hình tròn theo kích thước của PictureBox
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);

            // Thiết lập vùng hiển thị của PictureBox là hình tròn
            pictureBox.Region = new Region(path);
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            MakePictureBoxCircular(pictureBox1);
            MakePictureBoxCircular(pictureBox2);
            MakePictureBoxCircular(pictureBox3);
            MakePictureBoxCircular(pictureBox4);
        }


    }
}
