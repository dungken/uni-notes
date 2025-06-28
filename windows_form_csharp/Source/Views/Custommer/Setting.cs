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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Source.Views.Custommer
{
    public partial class Setting : Form
    {
        private readonly UserService _userService;
        private readonly AccountService _accountService;
        public static int parentX, parentY;


        public Setting()
        {
            InitializeComponent();
            _userService = new UserService();
            _accountService = new AccountService();
            SetTwoFAStatusAsync();


        }
        private async void SetTwoFAStatusAsync()
        {
            var response = await _accountService.GetTwoFAStatus();
            rjToggleButton5.Checked = response.Data.TwoFactorEnabled;
        }
        private async void rjToggleButton5_CheckedChanged(object sender, EventArgs e)
        {



        }




        private async void rjToggleButton5_Click(object sender, EventArgs e)
        {
            rjToggleButton5.Enabled = false; // Disable the toggle button to prevent multiple clicks

            try
            {
                if (rjToggleButton5.Checked)
                {
                    var response = await _accountService.Enable2FA(); ;
                    if (response.Success)
                    {
                        MessageBox.Show("Please check your email to confirm your account.");
                        Form modalBackground = new Form();

                        using (_2StepVerification modal = new _2StepVerification())
                        {
                            modalBackground.StartPosition = FormStartPosition.Manual;
                            modalBackground.FormBorderStyle = FormBorderStyle.None;
                            modalBackground.Opacity = 0.50d;
                            modalBackground.Size = new Size(MainForm.frmWith, MainForm.frmHeight);


                            modalBackground.Location = new Point(MainForm.frmMainLocationX, MainForm.frmMainLocationY);
                            modalBackground.ShowInTaskbar = false;
                            modalBackground.Show();
                            modal.Owner = modalBackground;

                            parentX = MainForm.frmMainLocationX + MainForm.pnlChildFormLocationX;
                            parentY = MainForm.frmMainLocationY + MainForm.pnlChildFormLocationY;
                            modal.ShowDialog();
                            modalBackground.Dispose();

                        }
                        var result = await _accountService.GetTwoFAStatus();

                        if (result.Data.TwoFactorEnabled)
                        {
                            MessageBox.Show("2FA is enabled");
                        }
                        else
                        {
                            MessageBox.Show("2FA is not run, please change later");
                        }
                    }
                    else
                    {
                        MessageBox.Show("2FA failed: " + response.Message);
                    }

                }
                else
                {
                    await Disable2FA();
                    MessageBox.Show("2FA is disabled");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                SetTwoFAStatusAsync();
                rjToggleButton5.Enabled = true; // Re-enable the toggle button
            }
        }
        private async Task Disable2FA()
        {
            // Implementation for disabling 2FA
            await _accountService.Disable2FA();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword();
            form.Show();
        }
    }
}
