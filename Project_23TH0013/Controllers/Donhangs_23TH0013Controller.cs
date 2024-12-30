using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_23TH0013.Models;

namespace Project_23TH0013.Controllers
{
    public class Donhangs_23TH0013Controller : Controller
    {
        private Project_23TH0013Entities db = new Project_23TH0013Entities();

        // GET: Donhangs_23TH0013
        public ActionResult Index()
        {
            var donhangs = db.Donhangs.Include(d => d.Khachhang);
            return View(donhangs.ToList());
        }

        // GET: Donhangs_23TH0013/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhang donhang = db.Donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // GET: Donhangs_23TH0013/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachhang = new SelectList(db.Khachhangs, "MaKhachhang", "Hoten");
            return View();
        }

        // POST: Donhangs_23TH0013/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madon,Ngaydat,Tinhtrang,MaKhachhang")] Donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Donhangs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachhang = new SelectList(db.Khachhangs, "MaKhachhang", "Hoten", donhang.MaKhachhang);
            return View(donhang);
        }

        // GET: Donhangs_23TH0013/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhang donhang = db.Donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachhang = new SelectList(db.Khachhangs, "MaKhachhang", "Hoten", donhang.MaKhachhang);
            return View(donhang);
        }

        // POST: Donhangs_23TH0013/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madon,Ngaydat,Tinhtrang,MaKhachhang")] Donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachhang = new SelectList(db.Khachhangs, "MaKhachhang", "Hoten", donhang.MaKhachhang);
            return View(donhang);
        }

        // GET: Donhangs_23TH0013/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhang donhang = db.Donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: Donhangs_23TH0013/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donhang donhang = db.Donhangs.Find(id);
            db.Donhangs.Remove(donhang);
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
