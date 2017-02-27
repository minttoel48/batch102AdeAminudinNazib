using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using perpustakaan.DAO;
using perpustakaan.ViewModel;

namespace waMvcDay15.Controllers
{
    public class KecamatanController : Controller
    {
        // GET: Anggota
        public ActionResult Index()
        {
            return View(MstKecamatanDAO.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstKecamatanViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstKecamatanDAO.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create",IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstKecamatanViewModel model = MstKecamatanDAO.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstKecamatanViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstKecamatanDAO.Update(data))
                {
                    return RedirectToAction("index");
                }
                
            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstKecamatanViewModel model = MstKecamatanDAO.CariID(id);
            return PartialView("Delete", model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteKecamatan(MstKecamatanViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstKecamatanDAO.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }   
            return View("index");
        }
    }
}