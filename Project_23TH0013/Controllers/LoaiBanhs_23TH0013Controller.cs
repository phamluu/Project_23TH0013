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
    public class LoaiBanhs_23TH0013Controller : Controller
    {
        private Project_23TH0013Entities db = new Project_23TH0013Entities();

        // GET: LoaiBanhs_23TH0013
        public ActionResult Index()
        {
            return View(db.LoaiBanhs.ToList());
        }

        // GET: LoaiBanhs_23TH0013/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiBanh loaiBanh = db.LoaiBanhs.Find(id);
            if (loaiBanh == null)
            {
                return HttpNotFound();
            }
            return View(loaiBanh);
        }

        // GET: LoaiBanhs_23TH0013/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiBanhs_23TH0013/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiBanh loaiBanh)
        {
            if (ModelState.IsValid)
            {
                db.LoaiBanhs.Add(loaiBanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiBanh);
        }

        // GET: LoaiBanhs_23TH0013/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiBanh loaiBanh = db.LoaiBanhs.Find(id);
            if (loaiBanh == null)
            {
                return HttpNotFound();
            }
            return View(loaiBanh);
        }

        // POST: LoaiBanhs_23TH0013/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiBanh loaiBanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiBanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiBanh);
        }

        // GET: LoaiBanhs_23TH0013/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiBanh loaiBanh = db.LoaiBanhs.Find(id);
            if (loaiBanh == null)
            {
                return HttpNotFound();
            }
            return View(loaiBanh);
        }

        // POST: LoaiBanhs_23TH0013/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiBanh loaiBanh = db.LoaiBanhs.Find(id);
            db.LoaiBanhs.Remove(loaiBanh);
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
