using Source.Dtos.Account;
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

namespace Source.Views
{
    public partial class _2StepVerification : Form
    {
        public static int frmConfirmEmailLocationFixedY;
        private readonly AccountService _AccountService;
        public static bool isVerifyEmail = false;
        public _2StepVerification()
        {
            InitializeComponent();
            _AccountService = new AccountService();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _2StepVerification_Load(object sender, EventArgs e)
        {
            frmConfirmEmailLocationFixedY = Login.parentY + 50;
            this.Location = new Point(Setting.parentX * 3 / 2 - 30, Setting.parentY + 50);
        }

        private void modalEffect_Timer_Tick(object sender, EventArgs e)
        {
            int y = Setting.parentY += 3;
            this.Location = new Point(Setting.parentX * 3 / 2, y - 100);
            if (Opacity >= 1 && y - 100 >= frmConfirmEmailLocationFixedY)
            {
                modalEffect_Timer.Stop();
            }
            else if (Opacity != 1)
            {
                Opacity += 0.03;
            }
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            var data = new Verify2FADto { VerifyCode = tbxCode.Text };
            var result = await _AccountService.Verify2FA(data);
            if (result.Success)
            {
                MessageBox.Show("Vertify Email successfull");
                isVerifyEmail = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vertify Email Faile, Your code is not correct");
            }
        }

        private void lblOther_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
