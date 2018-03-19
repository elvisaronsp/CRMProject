using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMProject.Interfaces;
using CRMProject.Models;
using CRMProject.Repository;

namespace CRMProject.Controllers
{
    public class RealestatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly GenericRealestateRepository genericRealestasteRepository;


        public RealestatesController (GenericRealestateRepository genericRealestateRepository)
        {
            
        }

        // GET: Realestates
        public ActionResult Index()
        {
            return View(db.Realestate.ToList());
        }

        // GET: Realestates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realestate realestate = db.Realestate.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // GET: Realestates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Realestates/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Realestate realestate)
        {
            if (ModelState.IsValid)
            {
                db.Realestate.Add(realestate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realestate);
        }

        // GET: Realestates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realestate realestate = db.Realestate.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // POST: Realestates/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Realestate realestate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realestate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realestate);
        }

        // GET: Realestates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realestate realestate = db.Realestate.Find(id);
            if (realestate == null)
            {
                return HttpNotFound();
            }
            return View(realestate);
        }

        // POST: Realestates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Realestate realestate = db.Realestate.Find(id);
            db.Realestate.Remove(realestate);
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
