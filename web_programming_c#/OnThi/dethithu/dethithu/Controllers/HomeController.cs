using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using dethithu.Models;
using System.Data.Entity;
using System.IO;
using System.Text.RegularExpressions;

namespace dethithu.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuanLyBanQuanAoEntities _context;
        public HomeController() : this(new QuanLyBanQuanAoEntities()) { }
        public HomeController(QuanLyBanQuanAoEntities context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var sp = _context.PhanLoaiSanPham
                     .Include(pl => pl.Sanpham)
                     .ToList();
            return View(sp);
        }

        public ActionResult PhanLoaiSP()
        {
            var sp = _context.PhanLoaiSanPham.ToList();
            return View(sp);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetProductsByCategory(int categoryId)
        {
            // Lọc sản phẩm theo phân loại (theo tên hoặc ID)
            var products = _context.Sanpham
                         .Where(sp => sp.PhanLoaiSanPhamID == categoryId)
                         .ToList();

            // Trả về PartialView với danh sách sản phẩm lọc được
            return PartialView("_ProductList", products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TrangThaiList = new SelectList(new[]
            {
                new { Value = (byte?)1, Text = "Hoạt động" },
                new { Value = (byte?)0, Text = "Không hoạt động" }
            }, "Value", "Text");
            ViewBag.NoiBatList = new SelectList(new[]
           {
                new { Value = (byte?)1, Text = "Nổi bật" },
                new { Value = (byte?)0, Text = "Không nổi bật" }
            }, "Value", "Text");
            ViewBag.PhanLoaiSanPhamList = new SelectList(new[]
           {
                new { Value = "1", Text = "Shoes" },
                new { Value = "2", Text = "Tshirts" },
                new { Value = "3", Text = "Pants" },
                new { Value = "4", Text = "Hoodie" },
                new { Value = "5", Text = "Outer" },
                new { Value = "6", Text = "Jackets" },
                new { Value = "7", Text = "Accessories" }
            }, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sanpham model, HttpPostedFileBase file)
        {
            if (!string.IsNullOrEmpty(model.Gia.ToString()))
            {
                var giaPattern = @"^\d+\.\d+$";  // Cho phép số nguyên và số thập phân
                if (!Regex.IsMatch(model.Gia.ToString(), giaPattern))
                {
                    ModelState.AddModelError("Gia", "Giá phải là số hợp lệ");
                }
            }

            if (ModelState.IsValid)
            {
                // Xử lý file upload
                if (file != null && file.ContentLength > 0)
                {
                    // Kiểm tra định dạng file là .jpg
                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (fileExtension != ".jpg")
                    {
                        ModelState.AddModelError("AnhDaiDien", "Chỉ cho phép tải lên file .jpg");
                        model.AnhDaiDien = null;

                        ViewBag.TrangThaiList = new SelectList(new[]
                        {
                            new { Value = (byte?)1, Text = "Hoạt động" },
                            new { Value = (byte?)0, Text = "Không hoạt động" }
                        }, "Value", "Text"); // Gán giá trị đã chọn cho dropdown

                         ViewBag.NoiBatList = new SelectList(new[]
                         {
                            new { Value = (byte?)1, Text = "Nổi bật" },
                            new { Value = (byte?)0, Text = "Không nổi bật" }
                        }, "Value", "Text"); // Gán giá trị đã chọn cho dropdown

                         ViewBag.PhanLoaiSanPhamList = new SelectList(new[]
                        {
                            new { Value = "1", Text = "Shoes" },
                            new { Value = "2", Text = "Tshirts" },
                            new { Value = "3", Text = "Pants" },
                            new { Value = "4", Text = "Hoodie" },
                            new { Value = "5", Text = "Outer" },
                            new { Value = "6", Text = "Jackets" },
                            new { Value = "7", Text = "Accessories" }
                        }, "Value", "Text"); // Gán giá trị đã chọn cho dropdown

                        return View(model); // Trả lại view với lỗi
                    }

                    // Đặt đường dẫn để lưu ảnh
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);

                    // Lưu ảnh vào thư mục Content/images
                    file.SaveAs(path);

                    // Lưu tên file vào database (cột AnhDaiDien)
                    model.AnhDaiDien = fileName;
                }

                // Lưu các thông tin sản phẩm khác
                _context.Sanpham.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // Trả lại danh sách dropdown nếu xảy ra lỗi
            ViewBag.TrangThaiList = new SelectList(new[]
             {
                new { Value = (byte?)1, Text = "Hoạt động" },
                new { Value = (byte?)0, Text = "Không hoạt động" }
            }, "Value", "Text");
            ViewBag.NoiBatList = new SelectList(new[]
           {
                new { Value = (byte?)1, Text = "Nổi bật" },
                new { Value = (byte?)0, Text = "Không nổi bật" }
            }, "Value", "Text");

            ViewBag.PhanLoaiSanPhamList = new SelectList(new[]
            {
                new { Value = "1", Text = "Shoes" },
                new { Value = "2", Text = "Tshirts" },
                new { Value = "3", Text = "Pants" },
                new { Value = "4", Text = "Hoodie" },
                new { Value = "5", Text = "Outer" },
                new { Value = "6", Text = "Jackets" },
                new { Value = "7", Text = "Accessories" }
            }, "Value", "Text");

            return View(model);
        }
    }
}