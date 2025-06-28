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
    public partial class RequestProductsOfCustomer : Form
    {
        public RequestProductsOfCustomer()
        {
            InitializeComponent();
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
            pnlRequestProductsOfCustomer.Controls.Add(childForm);
            pnlRequestProductsOfCustomer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
          
            openChildForm(new DesignCustomer());
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            
            openChildForm(new DesignCustomer());
        }
    }
}
