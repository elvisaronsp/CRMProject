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
    public class BusinessCustomersController : Controller
    {

        private readonly IBusinessCustomerRepository _businessCustomerRepository;
        private readonly ISalesAgentRepository _salesAgentRepository;

        public BusinessCustomersController(IBusinessCustomerRepository _businessCustomerRepository, ISalesAgentRepository _salesAgentRepository)
        {
            this._businessCustomerRepository = _businessCustomerRepository;
            this._salesAgentRepository = _salesAgentRepository;
        }

        // GET: BusinessCustomers
        public ActionResult Index()
        {
            var customers = _businessCustomerRepository.Get()
                .Include(x => x.SalesAgent)
                .Where(x => x.BusinessCustomerId > 0)
                .Fetch();
            return View(customers);
        }

        // GET: BusinessCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCustomer businessCustomer = _businessCustomerRepository.Get().Where(x => x.BusinessCustomerId == id).Fetch().FirstOrDefault();
            if (businessCustomer == null)
            {
                return HttpNotFound();
            }
            return View(businessCustomer);
        }

        // GET: BusinessCustomers/Create
        public ActionResult Create()
        {
            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name");
            return View();
        }

        // POST: BusinessCustomers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( BusinessCustomer businessCustomer)
        {
            if (ModelState.IsValid)
            {
                _businessCustomerRepository.Create(businessCustomer);
                
                return RedirectToAction("Index");
            }

            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name", businessCustomer.SalesAgentId);
            return View(businessCustomer);
        }

        // GET: BusinessCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCustomer businessCustomer = _businessCustomerRepository.Get().Include(x => x.SalesAgent).Where(x => x.BusinessCustomerId == id).Fetch().FirstOrDefault(); 
            if (businessCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name", businessCustomer.SalesAgentId);
            return View(businessCustomer);
        }

        // POST: BusinessCustomers/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessCustomer businessCustomer)
        {
            if (ModelState.IsValid)
            {
                _businessCustomerRepository.Update(businessCustomer);
                return RedirectToAction("Index");
            }
            ViewBag.SalesAgentId = new SelectList(_salesAgentRepository.Get().Fetch(), "SalesAgentId", "Name", businessCustomer.SalesAgentId);
            return View(businessCustomer);
        }

        // GET: BusinessCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCustomer businessCustomer = _businessCustomerRepository.Get().Include(x => x.SalesAgent).Where(x => x.BusinessCustomerId == id).Fetch().FirstOrDefault(); 
            if (businessCustomer == null)
            {
                return HttpNotFound();
            }
            return View(businessCustomer);
        }

        // POST: BusinessCustomers/Delete/5

        //[Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessCustomer businessCustomer = _businessCustomerRepository.Get().Include(x => x.SalesAgent).Where(x => x.BusinessCustomerId == id).Fetch().FirstOrDefault();
            _businessCustomerRepository.Delete(businessCustomer);
            return RedirectToAction("Index");
        }

        
    }
}
