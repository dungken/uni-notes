using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;
using Source.Dtos.Category;
using Source.Service;
using Panel = System.Windows.Forms.Panel;

namespace Source.Views.Admin
{
    public partial class CategoriesEdit : Form
    {
        private readonly CategoriesService _categoriesService;
        private CategoryDto _category;

        public CategoriesEdit()
        {
            InitializeComponent();
            _categoriesService = new CategoriesService();
            pnStatus.Paint += PanelLine_Paint;
            pnBasicInfor.Paint += PanelLine_Paint;
            pnParentCategory.Paint += PanelLine_Paint;
        }
        public CategoriesEdit(CategoryDto category)
        {
            InitializeComponent();

            pnStatus.Paint += PanelLine_Paint;
            pnBasicInfor.Paint += PanelLine_Paint;
            pnParentCategory.Paint += PanelLine_Paint;

            _categoriesService = new CategoriesService();
            _category = category;
            LoadCategoryData();
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

        private void CategoriesEdit_Load(object sender, EventArgs e)
        {

        }
        private async void LoadParentCategories(Guid? selectedParentId = null)
        {
            var response = await _categoriesService.GetAllCategories();
            if (response.Success && response != null)
            {
                lbxParent.Items.Clear();
                foreach (var category in response.Data)
                {
                    var listItem = new ListBoxItem
                    {
                        Text = category.Name,
                        Value = category.Id
                    };
                    lbxParent.Items.Add(listItem);

                    // Nếu danh mục cha hiện tại khớp với ID, chọn nó
                    if (selectedParentId.HasValue && category.Id == selectedParentId)
                    {
                        lbxParent.SelectedItem = listItem;
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to load parent categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Định nghĩa class ListBoxItem để chứa giá trị ẩn
        public class ListBoxItem
        {
            public string Text { get; set; }
            public Guid Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void LoadCategoryData()
        {
            tbxName.Text = _category.Name;
            tbxDescription.Text = _category.Description;
            if (_category.Status == "Active")
                rbtnActive.Checked = true;
            else if (_category.Status == "Inactive")
                rbtnInactive.Checked = true;
            else
                rbtnPending.Checked = true;
            LoadParentCategories(_category.ParentCategoryId);
        }
        

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy ID của danh mục cha
            Guid? parentCategoryId = null;
            if (lbxParent.SelectedItem is ListBoxItem selectedItem)
            {
                parentCategoryId = selectedItem.Value;
            }
            if (string.IsNullOrEmpty(tbxDescription.Text))
            {
                MessageBox.Show("Category description cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy dữ liệu đã chỉnh sửa
            _category.Name = tbxName.Text;
            _category.Description = tbxDescription.Text;
            if (rbtnActive.Checked)
            {
                _category.Status = "Active";
            }
            else if (rbtnInactive.Checked)
            {
                _category.Status = "Inactive";
            }
            else if (rbtnPending.Checked)
            {
                _category.Status = "Pending";
            }
            else
            {
                MessageBox.Show("Please select a status!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi API để cập nhật
            var result = await _categoriesService.UpdateCategoryAsync(_category.Id, new UpdateCategoryDto
            {
                Name = _category.Name,
                Description = _category.Description,
                Status = _category.Status,
                ParentCategoryId = parentCategoryId
            });

            if (result.Success)
            {
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Đóng form và báo thành công
            }
            else
            {
                MessageBox.Show("Failed to update category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
