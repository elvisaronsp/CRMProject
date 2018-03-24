using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMProject.Models;

namespace CRMProject.Controllers
{
    public class IndividualCustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IndividualCustomers
        public ActionResult Index()
        {
            var individualCustomer = db.IndividualCustomer.Include(i => i.SalesAgent);
            return View(individualCustomer.ToList());
        }

        // GET: IndividualCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualCustomer individualCustomer = db.IndividualCustomer.Find(id);
            if (individualCustomer == null)
            {
                return HttpNotFound();
            }
            return View(individualCustomer);
        }

        // GET: IndividualCustomers/Create
        public ActionResult Create()
        {
            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name");
            return View();
        }

        // POST: IndividualCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IndividualCustomerId,Name,Surname,PhoneNumber,City,Adress,SalesAgentId")] IndividualCustomer individualCustomer)
        {
            if (ModelState.IsValid)
            {
                db.IndividualCustomer.Add(individualCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name", individualCustomer.SalesAgentId);
            return View(individualCustomer);
        }

        // GET: IndividualCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualCustomer individualCustomer = db.IndividualCustomer.Find(id);
            if (individualCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name", individualCustomer.SalesAgentId);
            return View(individualCustomer);
        }

        // POST: IndividualCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndividualCustomerId,Name,Surname,PhoneNumber,City,Adress,SalesAgentId")] IndividualCustomer individualCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(individualCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name", individualCustomer.SalesAgentId);
            return View(individualCustomer);
        }

        // GET: IndividualCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualCustomer individualCustomer = db.IndividualCustomer.Find(id);
            if (individualCustomer == null)
            {
                return HttpNotFound();
            }
            return View(individualCustomer);
        }

        // POST: IndividualCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndividualCustomer individualCustomer = db.IndividualCustomer.Find(id);
            db.IndividualCustomer.Remove(individualCustomer);
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
