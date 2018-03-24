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

namespace CRMProject.Controllers
{
    public class BusinessCustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public readonly IGenericBusinessCustomerRepository genericBusinessCustomerRepository;

        // GET: BusinessCustomers
        public ActionResult Index()
        {
            var businessCustomer = db.BusinessCustomer.Include(b => b.SalesAgent);
            return View(businessCustomer.ToList());
        }

        // GET: BusinessCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCustomer businessCustomer = db.BusinessCustomer.Find(id);
            if (businessCustomer == null)
            {
                return HttpNotFound();
            }
            return View(businessCustomer);
        }

        // GET: BusinessCustomers/Create
        public ActionResult Create()
        {
            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name");
            return View();
        }

        // POST: BusinessCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusinessCustomerId,CompanyName,ContactPhoneNumber,City,Adress,SalesAgentId")] BusinessCustomer businessCustomer)
        {
            if (ModelState.IsValid)
            {
                db.BusinessCustomer.Add(businessCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name", businessCustomer.SalesAgentId);
            return View(businessCustomer);
        }

        // GET: BusinessCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCustomer businessCustomer = db.BusinessCustomer.Find(id);
            if (businessCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name", businessCustomer.SalesAgentId);
            return View(businessCustomer);
        }

        // POST: BusinessCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusinessCustomerId,CompanyName,ContactPhoneNumber,City,Adress,SalesAgentId")] BusinessCustomer businessCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalesAgentId = new SelectList(db.SalesAgent, "SalesAgentId", "Name", businessCustomer.SalesAgentId);
            return View(businessCustomer);
        }

        // GET: BusinessCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCustomer businessCustomer = db.BusinessCustomer.Find(id);
            if (businessCustomer == null)
            {
                return HttpNotFound();
            }
            return View(businessCustomer);
        }

        // POST: BusinessCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessCustomer businessCustomer = db.BusinessCustomer.Find(id);
            db.BusinessCustomer.Remove(businessCustomer);
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
