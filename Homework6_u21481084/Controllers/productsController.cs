using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework6_u21481084.Models;
using PagedList.Mvc;
using PagedList;
namespace Homework6_u21481084.Controllers
{
    public class productsController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();

        // GET: products
        public ActionResult Index(string search, int? i)
        {
            var products = db.products.Include(p => p.brand).Include(p => p.category);
            return View(products.Where(x => x.product_name.StartsWith(search) || search==null).ToList().ToPagedList(i ?? 1,10));
        }

        // GET: products/Details/5
        [HttpPost]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details",product);
        }
   

        // GET: products/Create
        [HttpPost]
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name");
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
            return PartialView();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "product_id,product_name,brand_id,category_id,model_year,list_price")] product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", product.brand_id);
        //    ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", product.category_id);
        //    return View(product);
        //}

        // GET: products/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", product.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", product.category_id);
            return PartialView(product);
        }
        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
     
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "product_id,product_name,brand_id,category_id,model_year,list_price")] product product)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", product.brand_id);
        //        ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", product.category_id);
        //        return PartialView("Edit", new { id = product.product_id });
        //    }
        //    ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", product.brand_id);
        //    ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", product.category_id);
        //    return PartialView("Edit", new { id = product.product_id });
        //}

        // GET: products/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        // POST: products/Delete/5
      
        
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /////////////////////////////////////////////////
        ///
        public JsonResult GetbyID(int ID)
        {
            return Json(db.products.FirstOrDefault(x => x.product_id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(product prods)
        {
            db.products.Add(prods);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(product prod)
        {
            var data = db.products.FirstOrDefault(x => x.product_id == prod.product_id);
            if (data != null)
            {
                data.product_name = prod.product_name;
                data.model_year = prod.model_year;
                data.list_price = prod.list_price;
                data.brand = prod.brand;
                data.category = prod.category;
                db.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }


   






}
