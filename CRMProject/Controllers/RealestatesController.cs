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
using CRMProject.Repository;

namespace CRMProject.Controllers
{
    public class RealestatesController : Controller
    {

        private readonly IRealestateRepository _realestateRepository;

        public RealestatesController(IRealestateRepository _realestateRepository)
        {
            this._realestateRepository = _realestateRepository;
        }

        // GET: Realestates
        public ActionResult Index()
        {
            var customers = _realestateRepository.Get()
                .Where(x => x.RealestateId > 0)
                .Fetch();

            return View(customers);
        }

        // GET: Realestates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realestate realestate = _realestateRepository.Get().Where(x => x.RealestateId == id).Fetch().FirstOrDefault();
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
            var validation = new RealestateValidation();
            var result = validation.Validate(realestate);


            if (result.IsValid)
            {
                _realestateRepository.Create(realestate);
                
                return RedirectToAction("Index");
            }

            ModelState.Clear();

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
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
            Realestate realestate = _realestateRepository.Get().Where(x => x.RealestateId == id).Fetch().FirstOrDefault();
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
                _realestateRepository.Update(realestate);

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
            Realestate realestate = _realestateRepository.Get().Where(x => x.RealestateId == id).Fetch().FirstOrDefault();
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
            Realestate realestate = _realestateRepository.Get().Where(x => x.RealestateId == id).Fetch().FirstOrDefault();
            _realestateRepository.Delete(realestate);

            return RedirectToAction("Index");

            
        }

        
    }
}
