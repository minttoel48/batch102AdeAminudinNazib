using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using perpustakaan.DAO;
using perpustakaan.ViewModel;
using System.Web.Mvc;

namespace waMvcDay15.Web.Controllers
{
    public class PinjamanDetailController : Controller
    {
        public ActionResult Index()
        {
            return View(TrxPinjamanDetailDAO.GetData());
        }
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxPinjamanDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPinjamanDetailDAO.Add(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            TrxPinjamanDetailViewModel model = TrxPinjamanDetailDAO.CariBerdasarkanId(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrxPinjamanDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPinjamanDetailDAO.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }

        public ActionResult Delete(int id)
        {
            TrxPinjamanDetailViewModel model = TrxPinjamanDetailDAO.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TrxPinjamanDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPinjamanDetailDAO.Delete(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
    }
}