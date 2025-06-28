using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Ocsp;
using Source.Dtos.Order;
using Source.Models;
using Source.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.Views.Custommer
{
    public partial class Cart : Form
    {
        private readonly CartService _cartService;
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly DiscountsService _discountService;
        private readonly List<CartItem> _selectedItemsInCart;
        private readonly List<CartItem> _cartItems;

        public Cart()
        {
            InitializeComponent();
            _cartService = new CartService();
            _userService = new UserService();
            _productService = new ProductService();
            _discountService = new DiscountsService();
            _selectedItemsInCart = new List<CartItem>();
            _cartItems = new List<CartItem>();

            if (_selectedItemsInCart.Count == 0 && !cbxAllBot.Checked)
            {
                lblTotalProduct.Text = "Tổng thanh toán là: 0";
                lblTotalPrice.Text = "0";
            }
        }

        private void pnProduct_Paint(object sender, PaintEventArgs e)
        {

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
            pnlCart.Controls.Add(childForm);
            pnlCart.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private async void btnBuy_Click(object sender, EventArgs e)
        {
            CreateOrderDto _createOrder = new CreateOrderDto()
            {
                UserId = Guid.NewGuid()
            };

            var userId = await _userService.GetUserIdByToken();
            _createOrder.UserId = userId.Data.UserId; 
            
            var response_user = await _userService.GetUserByToken();
            _createOrder.ShippingAddress = response_user.Data.User.FullAddress; 

            foreach (var item in _selectedItemsInCart)
            {

                var product = (await _productService.GetProductByIdAsync(item.ProductId)).Data;
                var discount = product.DiscountId.HasValue ? (await _discountService.GetDiscountByIdAsync(product.DiscountId.Value)).Data : null;
                CreateOrderDetailDto _createOrderDetail = new CreateOrderDetailDto()
                {
                    OrderId = _createOrder.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Color = item.Color,
                    Size = item.Size,
                    UnitPrice = item.UnitPrice,
                    DiscountAmount = discount != null ? discount.Percentage : 0
                };
                _createOrder.OrderDetails.Add(_createOrderDetail);
                await _cartService.RemoveFromCartAsync(userId.Data.UserId, item.Id);
            }
            openChildForm(new PaymentCustomer(_createOrder));
        }
        private Panel ClonePanel(Panel original, CartItem item)
        {
            var clonedPanel = new Panel
            {
                Width = original.Width,
                Height = original.Height,
                BorderStyle = original.BorderStyle,
                Dock = original.Dock,
                BackColor = original.BackColor,
                Margin = original.Margin,
                Padding = original.Padding
            };

            foreach (Control control in original.Controls)
            {
                Control clonedControl = null;

                if (control is Label label)
                {
                    clonedControl = new Label
                    {
                        Text = label.Text,
                        Location = label.Location,
                        Size = label.Size,
                        Font = label.Font,
                        ForeColor = label.ForeColor,
                        BackColor = label.BackColor,
                        Name = label.Name // Sao chép thuộc tính Name
                    };
                    if (label.Name == "lblDelete")
                    {
                        clonedControl.Click += lblDelete_Click;
                        clonedControl.Tag = item;
                    }
                }
                else if (control is PictureBox pictureBox)
                {
                    clonedControl = new PictureBox
                    {
                        Image = pictureBox.Image,
                        Location = pictureBox.Location,
                        Size = pictureBox.Size,
                        SizeMode = pictureBox.SizeMode,
                        BackColor = pictureBox.BackColor,
                        Name = pictureBox.Name // Sao chép thuộc tính Name
                    };
                }
                else if (control is CheckBox checkBox)
                {
                    clonedControl = new CheckBox
                    {
                        Text = checkBox.Text,
                        Location = checkBox.Location,
                        Size = checkBox.Size,
                        Font = checkBox.Font,
                        ForeColor = checkBox.ForeColor,
                        BackColor = checkBox.BackColor,
                        Checked = checkBox.Checked,
                        Name = checkBox.Name, // Sao chép thuộc tính Name
                        Tag = item
                    };
                    ((CheckBox)clonedControl).CheckedChanged += cbxProduct_CheckedChanged;
                }
                else if (control is Panel panel)
                {
                    clonedControl = ClonePanel(panel, item);
                    clonedControl.Location = panel.Location;
                    clonedControl.Name = panel.Name; // Sao chép thuộc tính Name
                }
                // Add more control types as needed

                if (clonedControl != null)
                {
                    clonedPanel.Controls.Add(clonedControl);
                }
            }

            return clonedPanel;
        }

        private async void lblDelete_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (sender is Label label && label.Tag is CartItem item)
                {
                    // Code to delete the product from the cart
                    var userId = (await _userService.GetUserIdByToken()).Data.UserId;
                    await _cartService.RemoveFromCartAsync(userId, item.Id);

                    // Optionally, remove the panel from the UI
                    var panel = label.Parent as Panel;
                    if (panel != null)
                    {
                        pnlProductList.Controls.Remove(panel);
                    }

                    MessageBox.Show($"Deleted item: {item.Product.Name}");

                }
            }
        }

        private async void Cart_Load(object sender, EventArgs e)
        {
            pnlProductList.Controls.Clear();
            _cartItems.Clear();
            var response = await _userService.GetUserIdByToken(); // Replace with actual user ID
            var userId = response.Data.UserId;
            var response1 = await _cartService.GetCartByUserIdAsync(userId);

            var cart = response1.Data;
            _cartItems.AddRange(cart.CartItems);
            foreach (var item in cart.CartItems)
            {
                var productPanel = ClonePanel(pnlProduct, item);

                var nameLabel = productPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblNameProduct");
                if (nameLabel != null)
                {
                    nameLabel.Text = item.Product.Name;
                }
                var colorSize = productPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblColorSize");
                if (colorSize != null)
                {
                    colorSize.Text = item.Color + "," + item.Size;
                }

                var priceOldLabel = productPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblOldPrice");
                if (priceOldLabel != null)
                {
                    priceOldLabel.Text = item.Product.Price.ToString("C");
                }

                var priceCurLabel = productPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblCurrentPrice");
                if (priceCurLabel != null)
                {

                    var product = (await _productService.GetProductByIdAsync(item.ProductId)).Data;
                    var discount = product.DiscountId.HasValue ? (await _discountService.GetDiscountByIdAsync(product.DiscountId.Value)).Data : null;
                    var priceAfterDiscount = discount != null ? item.Product.Price * (1 - discount.Percentage / 100) : item.Product.Price;
                    priceCurLabel.Text = priceAfterDiscount.ToString("C");


                }

                var quantityLabel = productPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblQuantity");
                if (quantityLabel != null)
                {
                    quantityLabel.Text = item.Quantity.ToString();
                }
                var PriceProduct = productPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblPriceProduct");
                if (PriceProduct != null)
                {

                    var resutl = Decimal.Parse(priceCurLabel.Text.TrimStart('$')) * item.Quantity;
                    PriceProduct.Text = resutl.ToString("C");
                }
                var productPictureBox = productPanel.Controls.OfType<PictureBox>().FirstOrDefault(pb => pb.Name == "pictureBoxProduct");
                if (productPictureBox != null)
                {
                    var response2 = await _productService.GetAllImagesFromProductById(item.ProductId);
                    var listImage = response2.Data.ToList();
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            byte[] imageData = await client.GetByteArrayAsync(listImage[0].Url);
                            using (MemoryStream stream = new MemoryStream(imageData))
                            {
                                productPictureBox.Image = System.Drawing.Image.FromStream(stream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải ảnh: " + ex.Message);
                    }
                }
                pnlProductList.Controls.Add(productPanel);
            }
            
            lblCount.Text = "Chọn tất cả (" + _selectedItemsInCart.Count.ToString() + ")";
            lblTotalProduct.Text = "Tổng thanh toán(" + _selectedItemsInCart.Count + " Sản phẩm):";
        }

        private async void cbxProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is CartItem item)
            {
                if (checkBox.Checked)
                {
                    _selectedItemsInCart.Add(item);
                }
                else
                {
                    _selectedItemsInCart.Remove(item);
                }
            }

            lblCount.Text = "Chọn tất cả (" + _selectedItemsInCart.Count.ToString() + ")";
            if (_selectedItemsInCart.Count == 0 && !cbxAllBot.Checked)
            {
                lblTotalProduct.Text = "Tổng thanh toán là: 0";
                lblTotalPrice.Text = "0";
            }
            else
            {
                decimal total = 0;
                var itemsToProcess = _selectedItemsInCart.ToList(); // Create a copy of the collection
                foreach (var selectedItem in itemsToProcess)
                {
                    var product = (await _productService.GetProductByIdAsync(selectedItem.ProductId)).Data;
                    var discount = product.DiscountId.HasValue ? (await _discountService.GetDiscountByIdAsync(product.DiscountId.Value)).Data : null;
                    var priceAfterDiscount = discount != null ? selectedItem.Product.Price * (1 - discount.Percentage / 100) : selectedItem.Product.Price;
                    total += priceAfterDiscount * selectedItem.Quantity;

                    
                }
                lblTotalProduct.Text = "Tổng thanh toán là (" + _selectedItemsInCart.Count + ") sản phẩm: ";
                lblTotalPrice.Text = total.ToString("C");
            }
            if (_selectedItemsInCart.Count == 0 && !cbxAllBot.Checked)
            {
                lblTotalProduct.Text = "Tổng thanh toán là: 0";
                lblTotalPrice.Text = "0";
            }
        }



        private async void cbxAllBot_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cbxAllBot.Checked;

            foreach (Control control in pnlProductList.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control innerControl in panel.Controls)
                    {
                        if (innerControl is CheckBox checkBox && checkBox.Name == "cbxProduct")
                        {
                            checkBox.Checked = isChecked;
                        }
                    }
                }
            }

            // Clear or add all items to _selectedItemsInCart based on the state of cbxAllBot
            if (isChecked)
            {
                _selectedItemsInCart.Clear();
                _selectedItemsInCart.AddRange(_cartItems);
            }
            else
            {
                _selectedItemsInCart.Clear();
            }

            lblCount.Text = "Chọn tất cả (" + _selectedItemsInCart.Count.ToString() + ")";
            if (_selectedItemsInCart.Count == 0)
            {
                lblTotalProduct.Text = "Tổng thanh toán là: 0";
                lblTotalPrice.Text = "0";
            }
            else
            {
                decimal total = 0;
                foreach (var selectedItem in _selectedItemsInCart)
                {
                    var product = (await _productService.GetProductByIdAsync(selectedItem.ProductId)).Data;
                    var discount = product.DiscountId.HasValue ? (await _discountService.GetDiscountByIdAsync(product.DiscountId.Value)).Data : null;
                    var priceAfterDiscount = discount != null ? selectedItem.Product.Price * (1 - discount.Percentage / 100) : selectedItem.Product.Price;
                    total += priceAfterDiscount * selectedItem.Quantity;
                }
                lblTotalProduct.Text = "Tổng thanh toán là (" + _selectedItemsInCart.Count + ") sản phẩm: ";
                lblTotalPrice.Text = total.ToString("C");
            }
        }
 

        private async void lblDelMul_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn tất cả xóa sản phẩm này khỏi giỏ hàng không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (sender is Label label && label.Tag is CartItem item)
                {
                    // Code to delete the product from the cart
                    var userId = (await _userService.GetUserIdByToken()).Data.UserId;
                    await _cartService.ClearCartAsync(userId);

                    // Optionally, remove the panel from the UI
                    var panel = label.Parent as Panel;
                    if (panel != null)
                    {
                        pnlProductList.Controls.Remove(panel);
                    }

                    MessageBox.Show($"Deleted item: {item.Product.Name}");
                }
            }
        }


    }
}
