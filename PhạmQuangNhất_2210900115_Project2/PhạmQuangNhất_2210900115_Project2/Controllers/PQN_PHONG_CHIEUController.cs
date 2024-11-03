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
    public class PQN_PHONG_CHIEUController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: PQN_PHONG_CHIEU
        public ActionResult Index()
        {
            return View(db.PHONG_CHIEU.ToList());
        }

        // GET: PQN_PHONG_CHIEU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONG_CHIEU pHONG_CHIEU = db.PHONG_CHIEU.Find(id);
            if (pHONG_CHIEU == null)
            {
                return HttpNotFound();
            }
            return View(pHONG_CHIEU);
        }

        // GET: PQN_PHONG_CHIEU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PQN_PHONG_CHIEU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhong,TenPhong,SoGhe,LoaiPhong")] PHONG_CHIEU pHONG_CHIEU)
        {
            if (ModelState.IsValid)
            {
                db.PHONG_CHIEU.Add(pHONG_CHIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHONG_CHIEU);
        }

        // GET: PQN_PHONG_CHIEU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONG_CHIEU pHONG_CHIEU = db.PHONG_CHIEU.Find(id);
            if (pHONG_CHIEU == null)
            {
                return HttpNotFound();
            }
            return View(pHONG_CHIEU);
        }

        // POST: PQN_PHONG_CHIEU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhong,TenPhong,SoGhe,LoaiPhong")] PHONG_CHIEU pHONG_CHIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONG_CHIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHONG_CHIEU);
        }

        // GET: PQN_PHONG_CHIEU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONG_CHIEU pHONG_CHIEU = db.PHONG_CHIEU.Find(id);
            if (pHONG_CHIEU == null)
            {
                return HttpNotFound();
            }
            return View(pHONG_CHIEU);
        }

        // POST: PQN_PHONG_CHIEU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHONG_CHIEU pHONG_CHIEU = db.PHONG_CHIEU.Find(id);
            db.PHONG_CHIEU.Remove(pHONG_CHIEU);
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
