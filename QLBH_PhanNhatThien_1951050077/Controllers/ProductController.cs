using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_PhanNhatThien_1951050077.Models;

namespace QLBH_PhanNhatThien_1951050077.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        NorthwindDataContext dt = new NorthwindDataContext();
        public ActionResult ListProducts()
        {
            var p = dt.Products.Select(s => s).ToList();
            return View(p);
        }
        public ActionResult Create()
        {
            ViewData["NCC"] = new SelectList(dt.Suppliers, "SupplierID", "CompanyName");
            ViewData["LoaiSP"] = new SelectList(dt.Categories, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form, Product pro)
        {
            var tenSP = form["ProductName"];

            if (string.IsNullOrEmpty(tenSP))
                ViewData["Loi"] = "vui long nhap ten san pham";
            else
            {
                pro.CategoryID = int.Parse(form["LoaiSP"]);
                pro.SupplierID = int.Parse(form["NCC"]);
                dt.Products.InsertOnSubmit(pro);
                dt.SubmitChanges();
            }

            return RedirectToAction("ListProducts");
        }
        public ActionResult Details(int id)
        {
            Product p = dt.Products.FirstOrDefault(s => s.ProductID == id);
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            var p = dt.Products.Where(s => s.ProductID == id).FirstOrDefault();
            ViewData["LoaiSP"] = new SelectList(dt.Categories, "CategoryID", "CategoryName");
            ViewData["NCC"] = new SelectList(dt.Suppliers, "SupplierID", "CompanyName");
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form, int id)
        {
            var p = dt.Products.Where(s => s.ProductID == id).FirstOrDefault();

            p.ProductName = form["ProductName"];
            p.SupplierID = int.Parse(form["NCC"]);
            p.CategoryID = int.Parse(form["LoaiSP"]);
            p.QuantityPerUnit = form["QuantityperUnit"];
            p.UnitPrice = Decimal.Parse(form["UnitPrice"]);
            p.UnitsInStock = short.Parse(form["UnitsInStock"]);
            p.UnitsOnOrder = short.Parse(form["UnitsOnOrder"]);
            //p.ReorderLevel = short.Parse(form["ReorderLevel"]);
            //p.Discontinued = bool.Parse(form["Discontinued"]);

            dt.SubmitChanges();

            UpdateModel(p);
            

            return RedirectToAction("ListProducts");
        }
        public ActionResult Delete(int id)
        {
            var p = dt.Products.FirstOrDefault(s => s.ProductID == id);

            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var p = dt.Products.FirstOrDefault(s => s.ProductID == id);

            dt.Products.DeleteOnSubmit(p);
            dt.SubmitChanges();

            return RedirectToAction("ListProducts");
        }
    }
}