using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhạmQuangNhất_2210900115_Project2.Models;

namespace PhạmQuangNhất_2210900115_Project2.Controllers
{
    public class PQN_SUAT_CHIEUController : Controller
    {
        private Entities db = new Entities();

        // GET: PQN_SUAT_CHIEU
        public ActionResult Index()
        {
            var sUAT_CHIEU = db.SUAT_CHIEU.Include(s => s.PHIM).Include(s => s.PHONG_CHIEU);
            return View(sUAT_CHIEU.ToList());
        }

        // GET: PQN_SUAT_CHIEU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUAT_CHIEU sUAT_CHIEU = db.SUAT_CHIEU.Find(id);
            if (sUAT_CHIEU == null)
            {
                return HttpNotFound();
            }
            return View(sUAT_CHIEU);
        }

        // GET: PQN_SUAT_CHIEU/Create
        public ActionResult Create()
        {
            ViewBag.MaPhim = new SelectList(db.PHIMs, "MaPhim", "TenPhim");
            ViewBag.MaPhong = new SelectList(db.PHONG_CHIEU, "MaPhong", "TenPhong");
            return View();
        }

        // POST: PQN_SUAT_CHIEU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSuatChieu,MaPhong,MaPhim,ThoiGianBatDau,ThoiGianKetThuc")] SUAT_CHIEU sUAT_CHIEU)
        {
            if (ModelState.IsValid)
            {
                db.SUAT_CHIEU.Add(sUAT_CHIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhim = new SelectList(db.PHIMs, "MaPhim", "TenPhim", sUAT_CHIEU.MaPhim);
            ViewBag.MaPhong = new SelectList(db.PHONG_CHIEU, "MaPhong", "TenPhong", sUAT_CHIEU.MaPhong);
            return View(sUAT_CHIEU);
        }

        // GET: PQN_SUAT_CHIEU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUAT_CHIEU sUAT_CHIEU = db.SUAT_CHIEU.Find(id);
            if (sUAT_CHIEU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhim = new SelectList(db.PHIMs, "MaPhim", "TenPhim", sUAT_CHIEU.MaPhim);
            ViewBag.MaPhong = new SelectList(db.PHONG_CHIEU, "MaPhong", "TenPhong", sUAT_CHIEU.MaPhong);
            return View(sUAT_CHIEU);
        }

        // POST: PQN_SUAT_CHIEU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSuatChieu,MaPhong,MaPhim,ThoiGianBatDau,ThoiGianKetThuc")] SUAT_CHIEU sUAT_CHIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUAT_CHIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhim = new SelectList(db.PHIMs, "MaPhim", "TenPhim", sUAT_CHIEU.MaPhim);
            ViewBag.MaPhong = new SelectList(db.PHONG_CHIEU, "MaPhong", "TenPhong", sUAT_CHIEU.MaPhong);
            return View(sUAT_CHIEU);
        }

        // GET: PQN_SUAT_CHIEU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUAT_CHIEU sUAT_CHIEU = db.SUAT_CHIEU.Find(id);
            if (sUAT_CHIEU == null)
            {
                return HttpNotFound();
            }
            return View(sUAT_CHIEU);
        }

        // POST: PQN_SUAT_CHIEU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUAT_CHIEU sUAT_CHIEU = db.SUAT_CHIEU.Find(id);
            db.SUAT_CHIEU.Remove(sUAT_CHIEU);
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
