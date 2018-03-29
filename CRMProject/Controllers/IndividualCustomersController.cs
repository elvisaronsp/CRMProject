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
    public class IndividualCustomersController : Controller
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly ISalesAgentRepository _salesAgentRepository;

        public IndividualCustomersController(IIndividualCustomerRepository _individualCustomerRepository, ISalesAgentRepository _salesAgentRepository)
        {
            this._individualCustomerRepository = _individualCustomerRepository;
            this._salesAgentRepository = _salesAgentRepository;
        }

        // GET: IndividualCustomers
        public ActionResult Index()
        {
            var customers = _individualCustomerRepository.Get().Include(x => x.SalesAgent).Where(x => x.IndividualCustomerId > 0).Fetch();
            return View(customers);
        }

        // GET: IndividualCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualCustomer individualCustomer = _individualCustomerRepository.Get().Where(x=>x.IndividualCustomerId==id).Fetch().FirstOrDefault();
            if (individualCustomer == null)
            {
                return HttpNotFound();
            }
            return View(individualCustomer);
        }

        // GET: IndividualCustomers/Create
        public ActionResult Create()
        {
            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name");
            return View();
        }

        // POST: IndividualCustomers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IndividualCustomerId,Name,Surname,PhoneNumber,City,Adress,SalesAgentId")] IndividualCustomer individualCustomer)
        {
            if (ModelState.IsValid)
            {
                _individualCustomerRepository.Create(individualCustomer);
                return RedirectToAction("Index");
            }

            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name", individualCustomer.SalesAgentId);
            return View(individualCustomer);
        }

        // GET: IndividualCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualCustomer individualCustomer = _individualCustomerRepository.Get().Where(x => x.IndividualCustomerId == id).Fetch().FirstOrDefault();
            if (individualCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name", individualCustomer.SalesAgentId);
            return View(individualCustomer);
        }

        // POST: IndividualCustomers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndividualCustomerId,Name,Surname,PhoneNumber,City,Adress,SalesAgentId")] IndividualCustomer individualCustomer)
        {
            if (ModelState.IsValid)
            {
                _individualCustomerRepository.Update(individualCustomer);
                return RedirectToAction("Index");
            }
            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name", individualCustomer.SalesAgentId);
            return View(individualCustomer);
        }

        // GET: IndividualCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualCustomer individualCustomer = _individualCustomerRepository.Get().Where(x => x.IndividualCustomerId == id).Fetch().FirstOrDefault();
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
            IndividualCustomer individualCustomer = _individualCustomerRepository.Get().Where(x => x.IndividualCustomerId == id).Fetch().FirstOrDefault();
            _individualCustomerRepository.Delete(individualCustomer);
            return RedirectToAction("Index");
        }

        
    }
}
