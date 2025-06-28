using Newtonsoft.Json.Linq;
using Source.Dtos.Account;
using Source.Dtos.Reponse;
using Source.Service;
using Source.Utils;
using System;
using System.Formats.Tar;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using static Google.Apis.Requests.BatchRequest;

namespace Source.Views
{
    public partial class ForgetPassword : Form
    {
        // Biến thành viên để lưu trạng thái OTP và email
        private string userEmail;
        private string password;
        private string confirm_password;
        public static Guid userId;
        private readonly AccountService _accountService;
        public static int parentX, parentY;
        private readonly UserService _userService = new UserService();
        private static readonly HttpClient client = new HttpClient();
        public string EmailOFUser;
        public string ResetToken;
        public ForgetPassword()
        {
            InitializeComponent();
            _accountService = new AccountService();
            txtNewPassword.Hide();
            btnConfirm.Hide();
            label3.Hide();
            panel4.Hide();
            panel3.Hide();
            label4.Hide();
            txtConfirm.Hide();

        }


        private async void btnGetLink_Click(object sender, EventArgs e)
        {
            userEmail = txtEmail.Text.ToString();

            if (string.IsNullOrWhiteSpace(userEmail))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ.");
                return;
            }

            MessageBox.Show("Vui lòng xác minh Email để đổi mật khẩu.");

            var SendCodeForForgetPassword = new SendCodeForForgetPassword()
            {
                Email = userEmail
            };
  
            var response = await _accountService.SendCodeForForgetPasswordAsync(SendCodeForForgetPassword);
            if (response.Success)
            {
                userId = response.Data.userId;
                Utils.Config.token = response.Data.Token;
                EmailOFUser = response.Data.Email;
                ResetToken = response.Data.ResetToken;
            }
            Form modalBackground = new Form();

            using (_2StepVerificationForForgetPass modal = new _2StepVerificationForForgetPass())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = 0.50d;
                modalBackground.Size = new System.Drawing.Size(this.Width, this.Height);
                modalBackground.Location = new Point(this.Location.X, this.Location.Y);
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                modal.Owner = modalBackground;

                parentX = this.Location.X + Login.pnlChildFormLocationX + 200;
                parentY = this.Location.Y + Login.pnlChildFormLocationY;
                modal.ShowDialog();
                modalBackground.Dispose();
            }

            if (_2StepVerificationForForgetPass.isVerifyEmail)
            {
                this.Show();
                txtNewPassword.Show();
                btnConfirm.Show();
                label3.Show();
                panel4.Show();
                panel3.Show();
                label4.Show();
                txtConfirm.Show();
                txtEmail.Hide();
                btnGetLink.Hide();
                label2.Hide();
                panel7.Hide();

            }

        }   
        

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var new_pass = txtNewPassword.Text.Trim();
            var conf = txtConfirm.Text.Trim();


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
                password = new_pass.ToString();
                await ChangePasswordAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConfirm.Enabled = true;
            }
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }
        private async Task ChangePasswordAsync()
        {
            ResetPasswordDto changePasswordDto = new ResetPasswordDto
            {
                Token = ResetToken,
                Email = EmailOFUser,
                NewPassword = password
            };
            var response = await _accountService.ResetPassword(changePasswordDto);
            if (response != null && response.Success)
            {
                MessageBox.Show($"Thay đổi mật khẩu thành công\nMessage: {response.Message}");
            }
            else
            {
                var errorMessage = response?.Errors != null ? string.Join("\n", response.Errors) : "Unknown error";
                MessageBox.Show($"Thay đổi mật khẩu thất bại\nError: {errorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
