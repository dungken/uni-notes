using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Source.Models;
using Source.MyCustomControl;
using Source.Service;
using Source.Views;
using Source.Views.Custommer;
namespace Source.Views
{
    public partial class MainForm : Form
    {
        public static int frmMainLocationX, frmMainLocationY;
        public static int pnlChildFormLocationX, pnlChildFormLocationY;
        public static int frmWith, frmHeight;

        private readonly UserService _userService;
        public MainForm()
        {
            InitializeComponent();

            customuzeDesing();
            _userService = new UserService();
            openChildForm(new HomeCustomer());
        }
        private void customuzeDesing()
        {
            pnlSubMenuProducts.Visible = false;
            pnlSubMenuAvata.Visible = false;
            pnlSubNotifications.Visible = false;

        }

        private void hideSubMenu()
        {
            if (pnlSubMenuProducts.Visible == true)
            {
                pnlSubMenuProducts.Visible = false;
            }
            if (pnlSubMenuAvata.Visible == true)
            {
                pnlSubMenuAvata.Visible = false;
            }
            if (pnlSubNotifications.Visible == true)
            {
                pnlSubNotifications.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        // Tạo Form con 
        private Form? activeForm = null;
        private void openChildForm(Form childForm)
        {
            frmMainLocationX = Login.frmLoginLocationX;
            frmMainLocationY = Login.frmLoginLocationY;
            frmHeight = Login.frmHeight;
            frmWith = Login.frmWith;
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnHome.Image;
            lblNavigation.Text = "Home";
            openChildForm(new HomeCustomer());
            hideSubMenu();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            lblNavigation.Text = "Products";
            lblNavigationImage.Image = btnProducts.Image;
            showSubMenu(pnlSubMenuProducts);
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnCart.Image;
            lblNavigation.Text = "My Cart";
            openChildForm(new Custommer.Cart());
            hideSubMenu();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnAboutUs.Image;
            lblNavigation.Text = "About us";
            openChildForm(new AboutUs());
            hideSubMenu();
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnAboutUs.Image;
            lblNavigation.Text = "Support";
            openChildForm(new Support());
            hideSubMenu();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnSetting.Image;
            lblNavigation.Text = "Setting";
            openChildForm(new Setting());
            hideSubMenu();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAvarata_Click(object sender, EventArgs e)
        {

            pnlSubMenuAvata.Location = new Point(810, 6);
            pnlSubMenuAvata.BringToFront();
            showSubMenu(pnlSubMenuAvata);

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

            lblNavigationImage.Image = btnHome.Image;
            lblNavigation.Text = "Home";
            openChildForm(new HomeCustomer());
            hideSubMenu();

        }

        private void btnBestSeller_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnHome.Image;
            lblNavigation.Text = "Best-Seller";
            openChildForm(new ProductsCustomer());
        }

        private void btnMenTop_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnHome.Image;
            lblNavigation.Text = "Men's-top";
            openChildForm(new ProductsCustomer());
        }

        private void btnPants_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnHome.Image;
            lblNavigation.Text = "Pants";
            openChildForm(new ProductsCustomer());
        }

        private void btnCustomDesign_Click(object sender, EventArgs e)
        {
            lblNavigationImage.Image = btnHome.Image;
            lblNavigation.Text = "Custom-Design";
            openChildForm(new DesignCustomer());
        }

        private void lblNotifications_Click(object sender, EventArgs e)
        {


            pnlSubNotifications.Location = new Point(660, 0);
            pnlSubNotifications.BringToFront();
            showSubMenu(pnlSubNotifications);

        }

        private void btnProfilePage_Click(object sender, EventArgs e)
        {
            openChildForm(new ProfilePage());
        }

        private void btnOrderInvoices_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderInvoices());
        }

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Location X" + this.Location.X.ToString());
            frmMainLocationX = this.Location.X;
            frmMainLocationY = this.Location.Y;
            pnlChildFormLocationX = pnlChildForm.Location.X;
            pnlChildFormLocationY = pnlChildForm.Location.Y;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var username = await _userService.GetUsernameByToken();
            lblUsername.Text = username.Data.UserName;
        }


    }
}
