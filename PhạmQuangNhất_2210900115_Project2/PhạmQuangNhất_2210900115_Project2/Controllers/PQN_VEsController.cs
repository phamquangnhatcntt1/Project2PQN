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
    public class PQN_VEsController : Controller
    {
        private Entities db = new Entities();

        // GET: PQN_VEs
        public ActionResult Index()
        {
            var vEs = db.VEs.Include(v => v.KHACH_HANG).Include(v => v.SUAT_CHIEU);
            return View(vEs.ToList());
        }

        // GET: PQN_VEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VE vE = db.VEs.Find(id);
            if (vE == null)
            {
                return HttpNotFound();
            }
            return View(vE);
        }

        // GET: PQN_VEs/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            ViewBag.MaSuatChieu = new SelectList(db.SUAT_CHIEU, "MaSuatChieu", "MaSuatChieu");
            return View();
        }

        // POST: PQN_VEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVe,MaSuatChieu,MaKhachHang,SoGhe,GiaVe")] VE vE)
        {
            if (ModelState.IsValid)
            {
                db.VEs.Add(vE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", vE.MaKhachHang);
            ViewBag.MaSuatChieu = new SelectList(db.SUAT_CHIEU, "MaSuatChieu", "MaSuatChieu", vE.MaSuatChieu);
            return View(vE);
        }

        // GET: PQN_VEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VE vE = db.VEs.Find(id);
            if (vE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", vE.MaKhachHang);
            ViewBag.MaSuatChieu = new SelectList(db.SUAT_CHIEU, "MaSuatChieu", "MaSuatChieu", vE.MaSuatChieu);
            return View(vE);
        }

        // POST: PQN_VEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVe,MaSuatChieu,MaKhachHang,SoGhe,GiaVe")] VE vE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", vE.MaKhachHang);
            ViewBag.MaSuatChieu = new SelectList(db.SUAT_CHIEU, "MaSuatChieu", "MaSuatChieu", vE.MaSuatChieu);
            return View(vE);
        }

        // GET: PQN_VEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VE vE = db.VEs.Find(id);
            if (vE == null)
            {
                return HttpNotFound();
            }
            return View(vE);
        }

        // POST: PQN_VEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VE vE = db.VEs.Find(id);
            db.VEs.Remove(vE);
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
