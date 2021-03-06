﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Ki_3.Models;

namespace Project_Ki_3.Areas.Admin.Controllers
{
    public class InsurancesController : Controller
    {
        private MyDb db = new MyDb();

        // GET: Admin/Insurances
        public ActionResult Index()
        {
            return View(db.Insurances.ToList());
        }

        // GET: Admin/Insurances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // GET: Admin/Insurances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Insurances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                var insurances = new Insurance()
                {
                    Name = insurance.Name,
                    Description = insurance.Description,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeleteAt = DateTime.Now
                };
                db.Insurances.Add(insurances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insurance);
        }

        // GET: Admin/Insurances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Admin/Insurances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedAt,UpdatedAt,DeleteAt")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                var insurances = new Insurance()
                {
                    Name = insurance.Name,
                    Description = insurance.Description,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeleteAt = DateTime.Now
                };
                db.Entry(insurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insurance);
        }

        // GET: Admin/Insurances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Admin/Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insurance insurance = db.Insurances.Find(id);
            db.Insurances.Remove(insurance);
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
