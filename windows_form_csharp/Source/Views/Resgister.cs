using Source.Dtos.Account;
using Source.Dtos.User;
using Source.Service;
using Source.Views.Custommer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Source.Views
{
    public partial class Resgister : Form
    {
        public static int frmResgisterLocationX, frmResgisterLocationY;
        public static int pnlChildFormLocationX, pnlChildFormLocationY;
        public static int frmWith, frmHeight;
        private readonly AccountService _AccountService;
        private readonly UserService _userService ;
        public static string emailForResgister;

        public static int parentX, parentY;
        public Resgister()
        {
            InitializeComponent();
            _AccountService = new AccountService();
            _userService = new UserService();
        }


        // Tạo Form con 
        private Form? activeForm = null;
        private void openChildForm(Form childForm)
        {
            frmResgisterLocationX = this.Location.X;
            frmResgisterLocationY = this.Location.Y;
            frmHeight = this.Height;
            frmWith = this.Width;
            pnlChildFormLocationX = pnlChildForm.Location.X;
            pnlChildFormLocationY = pnlChildForm.Location.Y;
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

        private void Resgister_Load(object sender, EventArgs e)
        {

        }

        private void lblExit_Click(object sender, EventArgs e)
        {

            openChildForm(new Login());

        }

        // Hàm kiểm tra email hợp lệ
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private async void btnResgiter_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các textbox
            var username = textBox1.Text;
            var email = textBox4.Text;
            emailForResgister = email;
            var password = textBox2.Text;
            var firstName = txtFirstName.Text; 
            var lastName = txtLastName.Text;
            var confirmPassword = textBox3.Text;
            var isAgreementChecked = ckAgreement.Checked;

            // Kiểm tra các trường hợp hợp lệ
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("A valid email is required.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.");
                return;
            }
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("First name is required.");
                return;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Last name is required.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (!isAgreementChecked)
            {
                MessageBox.Show("You must agree to the terms.");
                return;
            }
            var registerUserDto = new RegisterUserDto
            {
                Email = email,
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            // Gọi hàm đăng ký từ AccountService
            var response = await _AccountService.RegisterAsync(registerUserDto);

            if (response.Success)
            {

                MessageBox.Show("Please check your email to confirm your account.");
                Form modalBackground = new Form();

                using (ConfirmEmail modal = new ConfirmEmail())
                {
                    modalBackground.StartPosition = FormStartPosition.Manual;
                    modalBackground.FormBorderStyle = FormBorderStyle.None;
                    modalBackground.Opacity = 0.50d;
                    modalBackground.Size = new Size(Login.frmWith, Login.frmHeight);


                    modalBackground.Location = new Point(Login.frmLoginLocationX, Login.frmLoginLocationY);
                    modalBackground.ShowInTaskbar = false;
                    modalBackground.Show();
                    modal.Owner = modalBackground;

                    parentX = Login.frmLoginLocationX + Login.pnlChildFormLocationX;
                    parentY = Login.frmLoginLocationY + Login.pnlChildFormLocationY;
                    modal.ShowDialog();
                    modalBackground.Dispose();

                }
                var result = await _userService.IsEmailConfirmedAsync(email);
                if (result.Data)
                {
                    MessageBox.Show("Resgister successfull, now you can log in with new account of you");
                    openChildForm(new Login());
                }
                else
                {
                    await _userService.DeleteByUsernameOrEmail(email);
                }


            }
            else
            {
                MessageBox.Show("Registration failed: " + response.Message);
            }

        }
    }
}
