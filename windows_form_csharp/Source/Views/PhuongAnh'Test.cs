//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Internal;
//using Source.Dtos.Image;
//using Source.Dtos.Order;
//using Source.Dtos.Payment;
//using Source.Dtos.Product;
//using Source.Dtos.Role;
//using Source.Service;
//using Source.Views.Admin;

//namespace Source.Views
//{
//    public partial class PhuongAnh_Test : Form
//    {
//        private readonly ImageService _imageService;
//        private readonly OrderService _orderService;
//        private readonly ProductService _productService;
//        private readonly PaymentService _paymentService;
//        private readonly PermissionService _permissionService;
//        public PhuongAnh_Test()
//        {
//            InitializeComponent();
//            _imageService = new ImageService();
//            _orderService = new OrderService();
//            _productService = new ProductService();
//            _paymentService = new PaymentService();
//            _permissionService = new PermissionService();
//        }
//        // Test Image Service
//        private async void TestUploadMultipleImages()
//        {
//            var formFiles = new List<IFormFile>();

//            // Tạo file giả lập đầu tiên
//            byte[] imageData1 = File.ReadAllBytes("D:\\31sua.png");
//            var fileStream1 = new MemoryStream(imageData1);
//            formFiles.Add(new FormFile(
//                baseStream: fileStream1,
//                baseStreamOffset: 0,
//                length: fileStream1.Length,
//                name: "file1",
//                fileName: "image1.png"
//            )
//            {
//                Headers = new HeaderDictionary(),
//                ContentType = "image/png"
//            });

//            // Tạo file giả lập thứ hai
//            byte[] imageData2 = File.ReadAllBytes("D:\\31sua.png");
//            var fileStream2 = new MemoryStream(imageData2);
//            formFiles.Add(new FormFile(
//                baseStream: fileStream2,
//                baseStreamOffset: 0,
//                length: fileStream2.Length,
//                name: "file2",
//                fileName: "image2.png"
//            )
//            {
//                Headers = new HeaderDictionary(),
//                ContentType = "image/png"
//            });
//            var response = await _imageService.UploadMultipleImages(formFiles.ToArray(), Guid.Parse("AB3A1D7B-23A7-45BD-9E75-1EA2640F9D2B"), "altText");
//            if(response != null && response.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {response.Message}");
//                foreach (var item in response.Data)
//                {
//                    MessageBox.Show($"{item.CreatedAt}: {item.Url}");
//                }
          
//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", response.Errors)}");
//            }   
//        }
//        private async void TestGetImagesByProductId()
//        {
//            string s = "AB3A1D7B-23A7-45BD-9E75-1EA2640F9D2B";
//            Guid guid = Guid.Parse(s);
//            var registerResponse = await _imageService.GetImagesByProductId(guid);
//            if (registerResponse != null && registerResponse.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Url}");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }
//        }
     
        
//        private async void TestUpdateImages()
//        {
//            var newFiles = new List<IFormFile>();
//            // Tạo file giả lập đầu tiên
//            byte[] imageData1 = File.ReadAllBytes("D:\\31sua.png");
//            var fileStream1 = new MemoryStream(imageData1);
//            newFiles.Add(new FormFile(
//                baseStream: fileStream1,
//                baseStreamOffset: 0,
//                length: fileStream1.Length,
//                name: "file3",
//                fileName: "image3.png"
//            )
//            {
//                Headers = new HeaderDictionary(),
//                ContentType = "image/png"
//            });

//            // Tạo file giả lập thứ hai
//            byte[] imageData2 = File.ReadAllBytes("D:\\31sua.png");
//            var fileStream2 = new MemoryStream(imageData2);
//            newFiles.Add(new FormFile(
//                baseStream: fileStream2,
//                baseStreamOffset: 0,
//                length: fileStream2.Length,
//                name: "file4",
//                fileName: "image4.png"
//            )
//            {
//                Headers = new HeaderDictionary(),
//                ContentType = "image/png"
//            });
//            var productId = Guid.Parse("AB3A1D7B-23A7-45BD-9E75-1EA2640F9D2B");
//            string altText = "Updated product images";
//            var imageIdsToDelete = new List<Guid> { Guid.Parse("75215F36-6F91-4F47-B92B-C6883C2D2F18"), Guid.Parse("BE25D2D8-F23F-45B6-B9FD-C9A61D0F8DC1") }; // 


//            // Gọi hàm cập nhật ảnh
//            var response = await _imageService.UpdateImages(productId, newFiles.ToArray(), imageIdsToDelete, altText);
//            if (response != null && response.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {response.Message}");
//                foreach (var item in response.Data)
//                {
//                    MessageBox.Show($"Id: {item.Id} \n  {item.UpdatedAt}: {item.Url}");
//                }
//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", response.Errors)}");
//            }

//        }
//        private async void TestDeleteImage()
//        {
//            string s = "9EAABDF5-9676-490F-AA74-30EFEBFC7654";
//            Guid guid = Guid.Parse(s);
//            var registerResponse = await _imageService.DeleteImage(guid);
//            if (registerResponse == true)
//            {
//                MessageBox.Show($"Registration Successful\nMessage:");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError:");
//            }
//        }
//        // Test Order Service
//        private async void TestCreateOrder()
//        {
//            //CreateOrderDto orderDto = new CreateOrderDto
//            //{
//            //    OrderDetails = new List<CreateOrderDetailDto>(),
//            //    Status = "Pending",
//            //    TotalAmount = 0
//            //};

//            //// Tạo chi tiết đơn hàng
//            //CreateOrderDetailDto orderDetailDto = new CreateOrderDetailDto
//            //{
//            //    ProductId = Guid.Parse("DD3A1D7B-23A7-45BD-9E75-1EA2640F9D2D"),
//            //    Quantity = 99,
//            //    UnitPrice = 564.65m,
//            //    DiscountAmount = 0.2m
//            //};

//            //// Thêm chi tiết đơn hàng và cập nhật tổng số tiền
//            //orderDto.OrderDetails.Add(orderDetailDto);
//            //orderDto.TotalAmount += orderDetailDto.Quantity * orderDetailDto.UnitPrice - orderDetailDto.DiscountAmount;

//            //var registerResponse = await _orderService.CreateOrder(orderDto);
//            //if (registerResponse != null && registerResponse.Success)
//            //{
//            //    MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}");
//            //}
//            //else
//            //{
//            //    MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            //}


//            CreateOrderDto orderDto = new CreateOrderDto
//            {
//                Status = "Pending",
//              // Sẽ được tính toán từ OrderDetails
//                OrderDetails = new List<CreateOrderDetailDto>
//                {
//                    new CreateOrderDetailDto
//                    {
//                        ProductId = Guid.Parse("AB3A1D7B-23A7-45BD-9E75-1EA2640F9D1A"),
//                        Quantity = 2,
//                        UnitPrice = 100m,
//                        DiscountAmount = 10m
//                    },
//                    new CreateOrderDetailDto
//                    {
//                        ProductId = Guid.Parse("AB3A1D7B-23A7-45BD-9E75-1EA2640F9D2B"),
//                        Quantity = 1,
//                        UnitPrice = 200m,
//                        DiscountAmount = 20m
//                    }
//                }
//            };
//            //foreach (var detail in orderDto.OrderDetails)
//            //{
//            //    // Giả sử có một phương thức để lấy thông tin sản phẩm
//            //    var product = await _productService.GetProductByIdAsync(detail.ProductId);
//            //    if (product != null)
//            //    {
//            //        detail.UnitPrice = product.Data.Price; // Gán giá sản phẩm
//            //    }
//            //    else
//            //    {
//            //        throw new Exception($"Product with ID {detail.ProductId} not found.");
//            //    }
//            //}

//            // Tính tổng tiền
//            //orderDto.TotalAmount = orderDto.OrderDetails.Sum(d => (d.UnitPrice * d.Quantity) - d.DiscountAmount);

//            var registerResponse = await _orderService.CreateOrderAsync(orderDto);

//            if (registerResponse != null && registerResponse.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.TotalAmount}");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }
//        }
//        //private async void TestGetOrderById()
//        //{
//        //    string s = "0C03C7F7-525E-4493-BEF9-4A8863D64D82";
//        //    Guid guid = Guid.Parse(s);
//        //    var registerResponse = await _orderService.GetOrderById(guid);
//        //    if (registerResponse != null && registerResponse.Success)
//        //    {
//        //        MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.OrderDate}");

//        //    }
//        //    else
//        //    {
//        //        MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//        //    }
//        //}
//        private async void TestGetAllOrders()
//        {
//            var registerResponse = await _orderService.GetAllOrders();
//            if (registerResponse != null && registerResponse.Success)
//            {
//                var orderIds = registerResponse.Data.Select(item => item.Id).ToList();
//                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nOrder IDs: {string.Join("\n ", orderIds)}");
//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }
//        }
//        private async Task TestUpdateOrderStatus()
//        {
//            string s = "3925AF8E-3EBA-4F95-87BA-AF64F060DC78";
//            Guid guid = Guid.Parse(s);
//            UpdateOrderDto status = new UpdateOrderDto { status = "Completed"  };
//            var registerResponse = await _orderService.UpdateOrderStatus(guid, status);
//            if (registerResponse != null && registerResponse.Success)
//            {
//                MessageBox.Show($"Successful\nMessage: {registerResponse}");

//            }
//            else
//            {
//                MessageBox.Show($"Failed\nError: { registerResponse}");
//            }
//        }
//        private async void TestCreatePayment()
//        {
//            CreatePaymentDto paymentDto = new CreatePaymentDto()
//            {
//                OrderId = Guid.Parse("C4585F87-368E-4577-B96B-43DC8033E0CC"),
//                Amount = 16.6m,
//                PaymentMethod = "TienMat"
//            };
//            var registerResponse = await _paymentService.CreatePayment(paymentDto);

//            if (registerResponse != null )
//            {
//                MessageBox.Show($"Registration Successful \nUser: {registerResponse.PaymentMethod}");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: can not add payment for order");
//            }

//        }
//        private async void TestGetPaymentByOrderId()
//        {
//            string s = "5451221C-1148-4739-81B9-05E6DC3C62DF";
//            Guid guid = Guid.Parse(s);
//            var registerResponse = await _paymentService.GetPaymentByOrderId(guid);
//            if (registerResponse != null && registerResponse.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Id}");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }
//        }
//        private async void TestGetPermissions()
//        {
//            var registerResponse = await _permissionService.GetPermissions();
//            if (registerResponse != null && registerResponse.Success)
//            {
//                //if (registerResponse.Data.permissionList == null)
//                //{
//                //    MessageBox.Show("Bi null Data");
//                //}
//                //else
//                //{

//                    MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Count()}");
//                //}

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }
//        }
//        private async void TestGetPermissionsWithRoles()
//        {
//            var registerResponse = await _permissionService.GetPermissionsWithRoles();
//            if (registerResponse != null && registerResponse.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.PermissionName}");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }
//        }
//        private async void TestGetById()
//        {
//            string s = "39A94C5C-85F2-427D-99A9-08DD0207DCCF";
//            Guid guid = Guid.Parse(s);
//            var registerResponse = await _permissionService.GetById(guid);
//            if (registerResponse != null && registerResponse.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Name}");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }
//        }
//        private async void TestCreateOrUpdatePermission()
//        {
//            CreatePermissionDto permissionDto = new CreatePermissionDto()
//            {
//                PermissionId = new Guid(),
//                Name = "create_category",
//                Description = "create category",
//                IsCorePermission = false,
//            };
//            var registerResponse = await _permissionService.CreateOrUpdatePermission(permissionDto);

//            if (registerResponse != null && registerResponse.Success)
//            {
//                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Name}");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
//            }

//        }
//        private async void TestDeletePermission()
//        {
//            string s = "A8FA42D4-E4BA-415D-A8E5-F758864FADD0";
//            Guid guid = Guid.Parse(s);
//            var registerResponse = await _permissionService.DeletePermission(guid);
//            if (registerResponse == true)
//            {
//                MessageBox.Show($"Registration Successful\nMessage:");

//            }
//            else
//            {
//                MessageBox.Show($"Registration Failed\nError:");
//            }
//        }
//        private void btnTest_Click(object sender, EventArgs e)
//        {
//            //TestUploadMultipleImages();
//            //TestGetImagesByProductId();
//            //TestUpdateImages(); 
//            //TestDeleteImage();

//            //TestCreateOrder();
//            //TestGetOrderById();
//            //TestGetAllOrders();  
//            //TestUpdateOrderStatus();

//            //TestCreatePayment(); 
//            //TestGetPaymentByOrderId();

//            //TestGetPermissions();           
//            //TestGetPermissionsWithRoles(); 
//            //TestGetById();
//            //TestCreateOrUpdatePermission();
//            //TestDeletePermission();
//        }
//    }
//}
