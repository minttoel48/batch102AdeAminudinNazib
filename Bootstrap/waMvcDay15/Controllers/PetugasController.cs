using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using perpustakaan.DAO;
using perpustakaan.ViewModel;

namespace waMvcDay15.Controllers
{
    public class PetugasController : Controller
    {
        // GET: Petugas
        public ActionResult Index()
        {
            return View(MstPetugasDAO.GetData());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstPetugasViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstPetugasDAO.Add(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            MstPetugasViewModel model = MstPetugasDAO.CariBerdasarkanID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstPetugasViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstPetugasDAO.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Update", model);
        }

        public ActionResult Delete(int id)
        {
            MstPetugasViewModel model = MstPetugasDAO.CariBerdasarkanID(id);
            return PartialView("Delete", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(MstPetugasViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstPetugasDAO.Delete(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }

        public ActionResult Details(int id)
        {
            MstPetugasViewModel model = MstPetugasDAO.CariBerdasarkanID(id);
            return PartialView("Details", model);
        }
    }
}