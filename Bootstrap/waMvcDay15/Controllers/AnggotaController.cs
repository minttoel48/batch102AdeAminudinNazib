using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using perpustakaan.DAO;
using perpustakaan.ViewModel;

namespace waMvcDay15.Controllers
{
    public class AnggotaController : Controller
    {
        // GET: Anggota
        public ActionResult Index()
        {            
            return View(MstAnggotaDAO.GetData());
        }

        public ActionResult Create()
        {
            ViewBag.ListProv = new SelectList(MstProvinsiDAO.GetData(), "ID", "NamaProvinsi");
            ViewBag.ListKota = new SelectList(MstKotaDAO.GetData(), "ID", "NamaKota");
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstAnggotaViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstAnggotaDAO.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create",IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstAnggotaViewModel model = MstAnggotaDAO.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstAnggotaViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstAnggotaDAO.Update(data))
                {
                    return RedirectToAction("index");
                }
                
            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        { 
            MstAnggotaViewModel model = MstAnggotaDAO.CariID(id);
            return PartialView("Delete", model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(MstAnggotaViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstAnggotaDAO.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }   
            return View("index");
        }
    }
}