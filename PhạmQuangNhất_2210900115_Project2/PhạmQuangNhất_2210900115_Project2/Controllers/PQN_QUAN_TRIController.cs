﻿using System;
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
    public class PQN_QUAN_TRIController : Controller
    {
        private Entities db = new Entities();

        // GET: PQN_QUAN_TRI
        public ActionResult Index()
        {
            return View(db.QUAN_TRI.ToList());
        }

        // GET: PQN_QUAN_TRI/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // GET: PQN_QUAN_TRI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PQN_QUAN_TRI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tai_khoan,Mat_khau,Trang_thai")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.QUAN_TRI.Add(qUAN_TRI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUAN_TRI);
        }

        // GET: PQN_QUAN_TRI/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: PQN_QUAN_TRI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tai_khoan,Mat_khau,Trang_thai")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUAN_TRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUAN_TRI);
        }

        // GET: PQN_QUAN_TRI/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: PQN_QUAN_TRI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            db.QUAN_TRI.Remove(qUAN_TRI);
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
