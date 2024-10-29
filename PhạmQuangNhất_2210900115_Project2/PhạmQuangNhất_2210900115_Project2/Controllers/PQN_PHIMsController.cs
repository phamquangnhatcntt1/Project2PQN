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
    public class PQN_PHIMsController : Controller
    {
        private Entities db = new Entities();

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
        public ActionResult Create([Bind(Include = "MaPhim,TenPhim,ThoiLuong,TheLoai,DaoDien,MoTa")] PHIM pHIM)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "MaPhim,TenPhim,ThoiLuong,TheLoai,DaoDien,MoTa")] PHIM pHIM)
        {
            if (ModelState.IsValid)
            {
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
