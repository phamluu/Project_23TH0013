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
    public class Chitietdonhangs_23TH0013Controller : Controller
    {
        private Project_23TH0013Entities db = new Project_23TH0013Entities();

        // GET: Chitietdonhangs_23TH0013
        public ActionResult Index()
        {
            var chitietdonhangs = db.Chitietdonhangs.Include(c => c.Donhang).Include(c => c.Sanpham);
            return View(chitietdonhangs.ToList());
        }

        // GET: Chitietdonhangs_23TH0013/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs_23TH0013/Create
        public ActionResult Create()
        {
            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Madon");
            ViewBag.MaCake = new SelectList(db.Sanphams, "MaCake", "TenCake");
            return View();
        }

        // POST: Chitietdonhangs_23TH0013/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madon,MaCake,Soluong,Dongia")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Chitietdonhangs.Add(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Madon", chitietdonhang.Madon);
            ViewBag.MaCake = new SelectList(db.Sanphams, "MaCake", "TenCake", chitietdonhang.MaCake);
            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs_23TH0013/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Madon", chitietdonhang.Madon);
            ViewBag.MaCake = new SelectList(db.Sanphams, "MaCake", "TenCake", chitietdonhang.MaCake);
            return View(chitietdonhang);
        }

        // POST: Chitietdonhangs_23TH0013/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madon,MaCake,Soluong,Dongia")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Madon", chitietdonhang.Madon);
            ViewBag.MaCake = new SelectList(db.Sanphams, "MaCake", "TenCake", chitietdonhang.MaCake);
            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs_23TH0013/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // POST: Chitietdonhangs_23TH0013/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            db.Chitietdonhangs.Remove(chitietdonhang);
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
