using Source.Dtos.Account;
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

namespace Source.Views
{
    public partial class ChangePassword : Form
    {
        private readonly AccountService _accountService;
        private string new_password;
        private string old_password;

        public ChangePassword()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            var old_pass = txtOldPassword.Text.Trim();
            var new_pass = txtPassWord.Text.Trim();
            var conf = txtConfirmPass.Text.Trim();

            // Kiểm tra email
            if (string.IsNullOrEmpty(old_pass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrEmpty(new_pass) || string.IsNullOrEmpty(conf))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu và xác nhận mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // So sánh mật khẩu và xác nhận
            if (new_pass != conf)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                new_password = new_pass.ToString();
                old_password = old_pass.ToString();
                await ChangePasswordAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnChangePassword.Enabled = true;
            }
        }

        private async Task ChangePasswordAsync()
        {
            ChangePasswordDto changePasswordDto = new ChangePasswordDto
            {
                CurrentPassword = old_password,
                NewPassword = new_password
            };
            var response = await _accountService.ChangePassword(changePasswordDto);
            if (response != null && response.Success)
            {
                MessageBox.Show($"Password Change Successful\nMessage: {response.Message}");
            }
            else
            {
                var errorMessage = response?.Errors != null ? string.Join("\n", response.Errors) : "Unknown error";
                MessageBox.Show($"Password Change Failed\nError: {errorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
