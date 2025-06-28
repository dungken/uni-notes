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
using Source.Service;

namespace Source.Views.Admin
{
    public partial class CategoriesAdd : Form
    {
        private readonly CategoriesService _categoriesService;

        // Các thuộc tính để trả về thông tin nhập vào form
        public string _categoryName { get; private set; }
        public string _categoryDescription { get; private set; }
        public string _categoryStatus { get; private set; } // Status
        public Guid? _parentCategoryId { get; private set; }
        public CategoriesAdd()
        {
            InitializeComponent();
            _categoriesService = new CategoriesService();

            // Lấy tất cả các danh mục để cho người dùng chọn danh mục cha
            LoadParentCategories();
        }
        // Lấy danh sách các danh mục cha từ service để người dùng chọn
        private async void LoadParentCategories()
        {
            var response = await _categoriesService.GetAllCategories();
            if (response.Success)
            {
                // Thêm danh mục cha vào ListBox
                lbxParent.DataSource = response.Data;
                lbxParent.DisplayMember = "Name";
                lbxParent.ValueMember = "Id";
                lbxParent.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Failed to load parent categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CategoriesAdd_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("Category name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbxDescription.Text))
            {
                MessageBox.Show("Category description cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy thông tin từ form
            _categoryName = tbxName.Text;
            _categoryDescription = tbxDescription.Text;

            // Kiểm tra trạng thái từ RadioButton
            if (rbtnActive.Checked)
            {
                _categoryStatus = "Active";
            }
            else if (rbtnInactive.Checked)
            {
                _categoryStatus = "Inactive";
            }
            else if (rbtnPending.Checked)
            {
                _categoryStatus = "Pending";
            }
            else
            {
                MessageBox.Show("Please select a status!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem người dùng có chọn danh mục cha trong ListBox không
            if (lbxParent.SelectedItem != null)
            {
                _parentCategoryId = ((CategoryDto)lbxParent.SelectedItem).Id;
            }
            else
            {
                _parentCategoryId = null; // Nếu không có danh mục cha, thì gán là null
            }

            // Tạo đối tượng CategoryDto cho mục mới
            var newCategoryDto = new CreateCategoryDto
            {
                Name = _categoryName,
                Description = _categoryDescription,
                Status = _categoryStatus,
                ParentCategoryId = _parentCategoryId
            };

            // Gọi service để thêm danh mục vào backend
            var response = await _categoriesService.CreateCategoryAsync(newCategoryDto);

            if (response.Success)
            {
                // Thông báo thành công và đóng form
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add category. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
