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
using Control = System.Windows.Forms.Control;

namespace Source.Views.Custommer
{
    public partial class OptionShippingMethod : Form
    {
        public static int frmOptionShippingLocationFixedY;
        public OptionShippingMethod()
        {
            InitializeComponent();
            AttachClickEvent(pnlAllOption1);
            AttachClickEvent(panel1);
        }


        // Hàm đệ quy để gán sự kiện MouseClick cho Panel và tất cả các control con
        private void AttachClickEvent(Control control)
        {
            control.MouseClick += pnlAllOption1_MouseDown;
            foreach (Control child in control.Controls)
            {
                AttachClickEvent(child); // Gán sự kiện cho control con
            }
        }
        private void OptionShippingMethod_Load(object sender, EventArgs e)
        {
            frmOptionShippingLocationFixedY = PaymentCustomer.parentY + 50;
            this.Location = new Point(PaymentCustomer.parentX * 3 / 2 - 30, PaymentCustomer.parentY + 50);
        }
        private void modalEffect_Timer_Tick(object sender, EventArgs e)
        {
            int y = PaymentCustomer.parentY += 3;
            this.Location = new Point(PaymentCustomer.parentX * 3 / 2, y - 100);
            if (Opacity >= 1 && y - 100 >= frmOptionShippingLocationFixedY)
            {
                modalEffect_Timer.Stop();
            }
            else if (Opacity != 1)
            {
                Opacity += 0.03;
            }
        }
        private void pictureBoxReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlAllOption1_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            pictureBoxTickGreen1.Visible = false;
            MessageBox.Show($"Mouse clicked at ({mouseX}, {mouseY}) in Panel.");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

      
    }
}
