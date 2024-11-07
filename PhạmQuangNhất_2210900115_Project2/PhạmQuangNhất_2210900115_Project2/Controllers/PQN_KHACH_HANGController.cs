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
    public class PQN_KHACH_HANGController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: PQN_KHACH_HANG
        public ActionResult Index()
        {
            return View(db.KHACH_HANG.ToList());
        }

        // GET: PQN_KHACH_HANG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // GET: PQN_KHACH_HANG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PQN_KHACH_HANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,Ho_ten,Tai_khoan,Mat_khau,Dia_chi,Dien_thoai,Email,Ngay_sinh,Ngay_cap_nhat,Gioi_tinh,Tich_diem,Trang_thai")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACH_HANG.Add(kHACH_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHACH_HANG);
        }

        // GET: PQN_KHACH_HANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: PQN_KHACH_HANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,Ho_ten,Tai_khoan,Mat_khau,Dia_chi,Dien_thoai,Email,Ngay_sinh,Ngay_cap_nhat,Gioi_tinh,Tich_diem,Trang_thai")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACH_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHACH_HANG);
        }

        // GET: PQN_KHACH_HANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: PQN_KHACH_HANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            db.KHACH_HANG.Remove(kHACH_HANG);
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
        public ActionResult Login()
        {
            return View();
        }

        // POST: PQN_KHACH_HANG/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Tai_khoan, string Mat_khau)
        {
            if (string.IsNullOrEmpty(Tai_khoan) || string.IsNullOrEmpty(Mat_khau))
            {
                ModelState.AddModelError("", "Username and password are required.");
                return View();
            }

            // Validate user credentials
            var user = db.KHACH_HANG.SingleOrDefault(k => k.Tai_khoan == Tai_khoan && k.Mat_khau == Mat_khau);
            if (user != null)
            {
                // Set session or cookie here if login is successful
                Session["UserID"] = user.MaKH;
                Session["Username"] = user.Tai_khoan;

                return RedirectToAction("Index", "Home"); // Redirect to homepage or dashboard
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }
        }

        // Logout Action
        public ActionResult Logout()
        {
            Session.Clear(); // Clear session data
            return RedirectToAction("Login", "PQN_KHACH_HANG");
        }

    }
}
