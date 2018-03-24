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
    public class SalesAgentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SalesAgents
        public ActionResult Index()
        {
            return View(db.SalesAgent.ToList());
        }

        // GET: SalesAgents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAgent salesAgent = db.SalesAgent.Find(id);
            if (salesAgent == null)
            {
                return HttpNotFound();
            }
            return View(salesAgent);
        }

        // GET: SalesAgents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesAgents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesAgentId,Name,Surname,Rank,PhoneNumber,HireDate,SaleValue,Sales")] SalesAgent salesAgent)
        {
            if (ModelState.IsValid)
            {
                db.SalesAgent.Add(salesAgent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesAgent);
        }

        // GET: SalesAgents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAgent salesAgent = db.SalesAgent.Find(id);
            if (salesAgent == null)
            {
                return HttpNotFound();
            }
            return View(salesAgent);
        }

        // POST: SalesAgents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesAgentId,Name,Surname,Rank,PhoneNumber,HireDate,SaleValue,Sales")] SalesAgent salesAgent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesAgent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesAgent);
        }

        // GET: SalesAgents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAgent salesAgent = db.SalesAgent.Find(id);
            if (salesAgent == null)
            {
                return HttpNotFound();
            }
            return View(salesAgent);
        }

        // POST: SalesAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesAgent salesAgent = db.SalesAgent.Find(id);
            db.SalesAgent.Remove(salesAgent);
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
