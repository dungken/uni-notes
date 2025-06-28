using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Source.Dtos.User;
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
    public partial class ProfilePage : Form
    {
        private string selectedFilePath = "";
        private readonly UserService _userService;
        private readonly AccountService _accountService;

        public ProfilePage()
        {
            InitializeComponent();
            _userService = new UserService();
            _accountService = new AccountService();
            LoadUserData();
        }
        private async void LoadUserData()
        {
            var user = await _userService.GetUserByToken();
            var userName = await _userService.GetUsernameByToken();
            if (user != null && user.Data != null)
            {
                txtFirstName.Text = user.Data.User.FirstName;
                txtLastName.Text = user.Data.User.LastName;
                txtEmail.Text = userName.Data.UserName;
                txtPhoneNumber.Text = user.Data.User.PhoneNumber;
                txtShipAddress.Text = user.Data.User.FullAddress;
                textBox1.Text = user.Data.User.Gender;
                txtCreateDate.Text = user.Data.User.CreatedAt.ToString("MM/dd/yyyy");

                if (!string.IsNullOrEmpty(user.Data.User.ProfilePicture))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetAsync(user.Data.User.ProfilePicture);
                        if (response.IsSuccessStatusCode)
                        {
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            {
                                pictureBox1.Image = Image.FromStream(stream);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to load profile picture.");
                        }
                    }
                }
            }
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
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            openChildForm(new HomeCustomer());
        }
        private async Task UpdateUserData()
        {
            var updateInfo = new UpdatePersonalInfoDto
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                FullAddress = txtShipAddress.Text,
                Gender = textBox1.Text
            };

            var result = await _userService.UpdatePersonalInformation(updateInfo);

            if (result.Success)
            {
                MessageBox.Show("User information updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update user information: " + result.Message);
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                var userName = await _userService.GetUsernameByToken();

                var result = await _userService.UploadImage(selectedFilePath, userName.Data.UserName);
            }
            else
            {
                MessageBox.Show("No file selected to upload.");
            }
             await UpdateUserData();
            MessageBox.Show("Save Success");
            openChildForm(new HomeCustomer());
        }

        private async void btnChooseAvarta_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Select a File to Upload"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                string directoryPath = Path.GetDirectoryName(selectedFilePath);
                string combinedPath = Path.Combine(directoryPath, Path.GetFileName(selectedFilePath));
                selectedFilePath = combinedPath;
                MessageBox.Show($"File selected: {combinedPath}");

                using (var stream = new MemoryStream(File.ReadAllBytes(selectedFilePath)))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
        }
    }
}
