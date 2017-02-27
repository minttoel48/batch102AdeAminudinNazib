using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using perpustakaan.DAO;
using perpustakaan.ViewModel;

namespace waMvcDay15.Controllers
{
    public class KelurahanController : Controller
    {
        // GET: Anggota
        public ActionResult Index()
        {
            return View(MstKelurahanDAO.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstKelurahanViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstKelurahanDAO.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create",IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstKelurahanViewModel model = MstKelurahanDAO.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstKelurahanViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstKelurahanDAO.Update(data))
                {
                    return RedirectToAction("index");
                }
                
            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstKelurahanViewModel model = MstKelurahanDAO.CariID(id);
            return PartialView("Delete", model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteKelurahan(MstKelurahanViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstKelurahanDAO.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }   
            return View("index");
        }
    }
}