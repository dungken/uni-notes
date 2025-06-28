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
    public partial class ConfirmEmail : Form
    {
        public static int frmConfirmEmailLocationFixedY;
        private readonly AccountService _AccountService;
        public ConfirmEmail()
        {
            InitializeComponent();
            _AccountService = new AccountService();
        }

        private void ConfirmEmail_Load(object sender, EventArgs e)
        {
            frmConfirmEmailLocationFixedY = Resgister.parentY + 50;
            this.Location = new Point(Resgister.parentX * 3 / 2 - 30, Resgister.parentY + 50);
        }
        private void modalEffect_Timer_Tick(object sender, EventArgs e)
        {
            int y = Resgister.parentY += 3;
            this.Location = new Point(Resgister.parentX * 3 / 2, y - 100);
            if (Opacity >= 1 && y - 100 >= frmConfirmEmailLocationFixedY)
            {
                modalEffect_Timer.Stop();
            }
            else if (Opacity != 1)
            {
                Opacity += 0.03;
            }
        }

        private void lblOther_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            var data = new ConfirmEmailDto { Code = tbxCode.Text, Email =  Resgister.emailForResgister};
            var result = await _AccountService.ConfirmEmail(data);
            if (result.Success)
            {
                MessageBox.Show("Vertify Email successfull");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vertify Email Faile, Your code is not correct");
            }
        }
    }
}
