using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using perpustakaan.DAO;
using perpustakaan.ViewModel;

namespace waMvcDay15.Controllers
{
    public class KotaController : Controller
    {
        // GET: Anggota
        public ActionResult Index()
        {
            return View(MstKotaDAO.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstKotaViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstKotaDAO.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create",IsiData);
        }



        public ActionResult Edit(int id)
        {
            MstKotaViewModel model = MstKotaDAO.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstKotaViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstKotaDAO.Update(data))
                {
                    return RedirectToAction("index");
                }
                
            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstKotaViewModel model = MstKotaDAO.CariID(id);
            return PartialView("Delete", model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(MstKotaViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstKotaDAO.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }   
            return View("index");
        }
    }
}