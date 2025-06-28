using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
   
    public class HomeController : Controller
    {
        QuanLyBanQuanAoEntities db = new QuanLyBanQuanAoEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.CateList = db.PhanLoaiSanPhams.Select(x => x.TenPhanLoai).ToList();

            ViewBag.ProductList = db.Sanphams.ToList();
            return View();
        }

        public ActionResult _ProductList(string category)
        {
            category = category.TrimStart('#');
            int categoryId = db.PhanLoaiSanPhams.Where(x => x.TenPhanLoai.ToLower() == category).Select(x => x.PhanLoaiSanPhamID).FirstOrDefault();
            var productList = db.Sanphams.Where(x => x.PhanLoaiSanPhamID == categoryId).ToList();
            return PartialView(productList);
        }
        public ActionResult Create()    
        {
            var Cate = db.PhanLoaiSanPhams.ToList();
            ViewBag.CateListCreate = new SelectList(Cate, "PhanLoaiSanPhamID", "TenPhanLoai") ;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sanpham p)
        {
            if (!ModelState.IsValid)
            {
                // Reload categories and return the view with errors
                var categories = db.PhanLoaiSanPhams.ToList();
                ViewBag.CateListCreate = new SelectList(categories, "PhanLoaiSanPhamID", "TenPhanLoai");
                return View(p);

            }
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (p.ImageFile != null && p.ImageFile.ContentLength > 0)
                {
                    // Validate file extension
                    var allowedExtensions = ".jpg";
                    var fileExtension = Path.GetExtension(p.ImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("", "Invalid file type. Only .jpeg, .jpg, .png files are allowed.");
                    }
                    else if (p.ImageFile.ContentLength > 1000000) // 1 MB
                    {
                        ModelState.AddModelError("", "File size must be less than or equal to 1 MB.");
                    }
                    else
                    {
                        // Generate a unique file name to avoid overwriting files
                        var fileName = Path.GetFileName(p.ImageFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);

                        // Save the file to the server
                        p.ImageFile.SaveAs(path);

                        // Set FilePath to just the file name (for storage in the database)
                        p.AnhDaiDien = fileName;
                    }
                }

                // Proceed if ModelState is valid
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Sanphams.Add(p); // Add the new product to the database
                        db.SaveChanges(); // Save changes to the database

                        // Set success message
                        TempData["InsertMessage"] = "<script>alert('Data Inserted!');</script>";

                        return RedirectToAction("Index", "Home"); // Redirect to the index page or wherever appropriate
                    }
                    catch
                    {
                        // Set failure message
                        TempData["InsertMessage"] = "<script>alert('Data Not Inserted!');</script>";
                    }
                }
                else
                {
                    // Set failure message
                    TempData["InsertMessage"] = "<script>alert('Data Not Inserted!');</script>";
                }
            }
            else
            {
                // Set failure message
                TempData["InsertMessage"] = "<script>alert('Data Not Inserted!');</script>";
            }

            return View(p);

        }
    }
}