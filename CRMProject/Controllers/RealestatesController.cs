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

        public readonly IGenericRealestateRepository genericRealestateRepository;

        public RealestatesController(IGenericRealestateRepository genericRealestateRepository)
        {
            this.genericRealestateRepository = genericRealestateRepository;
        }

        // GET: Realestates
        public ActionResult Index()
        {
            return View(genericRealestateRepository.GetWhere(x=>x.RealestateId>0));
        }

        // GET: Realestates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realestate realestate = genericRealestateRepository.GetWhere(x=>x.RealestateId == id).FirstOrDefault();
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
                genericRealestateRepository.Create(realestate);
                
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
            Realestate realestate = genericRealestateRepository.GetWhere(x => x.RealestateId == id).FirstOrDefault();
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
                genericRealestateRepository.Update(realestate);

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
            Realestate realestate = genericRealestateRepository.GetWhere(x => x.RealestateId == id).FirstOrDefault();
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
            Realestate realestate = genericRealestateRepository.GetWhere(x => x.RealestateId == id).FirstOrDefault();
            genericRealestateRepository.Delete(realestate);

            return RedirectToAction("Index");

            
        }

        
    }
}
