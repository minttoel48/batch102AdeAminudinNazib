using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using perpustakaan.DAO;
using perpustakaan.ViewModel;
using System.Web.Mvc;


namespace waMvcDay15.Web.Controllers
{
    public class PinjamanHeaderController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxPinjamanHeaderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPinjamanHeaderDAO.Add(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            TrxPinjamanHeaderViewModel model = TrxPinjamanHeaderDAO.CariBerdasarkanId(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrxPinjamanHeaderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPinjamanHeaderDAO.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }

        public ActionResult Delete(int id)
        {
            TrxPinjamanHeaderViewModel model = TrxPinjamanHeaderDAO.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TrxPinjamanHeaderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPinjamanHeaderDAO.Delete(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
    }
}