using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMProject.BusinessLogic;
using CRMProject.Interfaces;
using CRMProject.Models;

namespace CRMProject.Controllers
{
    public class SalesAgentsController : Controller
    {
        private readonly ISalesAgentRepository _salesAgentRepository;

        public SalesAgentsController(ISalesAgentRepository _salesAgentRepository)
        {
            this._salesAgentRepository = _salesAgentRepository;
        }

        // GET: SalesAgents
        public ActionResult Index()
        {
            return View(_salesAgentRepository.Get().Where(x=>x.SalesAgentId > 0).Fetch());
        }

        // GET: SalesAgents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAgent salesAgent = _salesAgentRepository.Get().Where(x => x.SalesAgentId == id).Fetch().FirstOrDefault();
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
        public ActionResult Create( SalesAgent salesAgent)
        {
            var validation = new SalesAgentValidation();
            var result = validation.Validate(salesAgent);

            if (result.IsValid)
            {
                _salesAgentRepository.Create(salesAgent);
                return RedirectToAction("Index");
            }

            ModelState.Clear();

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
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
            SalesAgent salesAgent = _salesAgentRepository.Get().Where(x => x.SalesAgentId == id).Fetch().FirstOrDefault();
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
                _salesAgentRepository.Update(salesAgent);
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
            SalesAgent salesAgent = _salesAgentRepository.Get().Where(x => x.SalesAgentId == id).Fetch().FirstOrDefault();
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
            SalesAgent salesAgent = _salesAgentRepository.Get().Where(x => x.SalesAgentId == id).Fetch().FirstOrDefault();
            _salesAgentRepository.Delete(salesAgent);
            return RedirectToAction("Index");
        }

        
    }
}
