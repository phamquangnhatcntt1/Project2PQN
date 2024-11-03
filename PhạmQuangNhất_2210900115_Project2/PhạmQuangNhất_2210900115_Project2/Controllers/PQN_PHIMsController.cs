using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhạmQuangNhất_2210900115_Project2.Models;

namespace PhạmQuangNhất_2210900115_Project2.Controllers
{
    public class PQN_PHIMsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: PQN_PHIMs
        public ActionResult Index()
        {
            return View(db.PHIMs.ToList());
        }

        // GET: PQN_PHIMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIM pHIM = db.PHIMs.Find(id);
            if (pHIM == null)
            {
                return HttpNotFound();
            }
            return View(pHIM);
        }

        // GET: PQN_PHIMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PQN_PHIMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhim,TenPhim,ThoiLuong,TheLoai,DaoDien,MoTa")] PHIM pHIM, HttpPostedFileBase HinhAnhFile)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnhFile != null && HinhAnhFile.ContentLength > 0)
                {
                    // Lưu file vào thư mục (ví dụ: Content/Images)
                    var fileName = Path.GetFileName(HinhAnhFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    HinhAnhFile.SaveAs(path);

                    // Lưu đường dẫn vào thuộc tính HinhAnh của model
                    pHIM.HinhAnh = "~/Content/Images/" + fileName;
                }

                db.PHIMs.Add(pHIM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHIM);
        }

        // GET: PQN_PHIMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIM pHIM = db.PHIMs.Find(id);
            if (pHIM == null)
            {
                return HttpNotFound();
            }
            return View(pHIM);
        }

        // POST: PQN_PHIMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhim,TenPhim,ThoiLuong,TheLoai,DaoDien,MoTa,HinhAnh")] PHIM pHIM, HttpPostedFileBase HinhAnhFile)
        {
            if (ModelState.IsValid)
            {
                // If a new image file is uploaded, handle it
                if (HinhAnhFile != null && HinhAnhFile.ContentLength > 0)
                {
                    // Save file to a specific directory (e.g., Content/Images)
                    var fileName = Path.GetFileName(HinhAnhFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    HinhAnhFile.SaveAs(path);

                    // Update the path in the model
                    pHIM.HinhAnh = "~/Content/Images/" + fileName;
                }
                else
                {
                    // If no new image file, retain the existing image path
                    var existingPhim = db.PHIMs.Find(pHIM.MaPhim);
                    pHIM.HinhAnh = existingPhim.HinhAnh;
                }

                // Update the database entry
                db.Entry(pHIM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHIM);
        }

        // GET: PQN_PHIMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIM pHIM = db.PHIMs.Find(id);
            if (pHIM == null)
            {
                return HttpNotFound();
            }
            return View(pHIM);
        }

        // POST: PQN_PHIMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIM pHIM = db.PHIMs.Find(id);
            db.PHIMs.Remove(pHIM);
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
    }
}
