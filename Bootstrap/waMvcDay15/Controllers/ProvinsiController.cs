using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using perpustakaan.DAO;
using perpustakaan.ViewModel;

namespace waMvcDay15.Controllers
{
    public class ProvinsiController : Controller
    {
        // GET: Anggota
        public ActionResult Index()
        {
            return View(MstProvinsiDAO.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstProvinsiViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstProvinsiDAO.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create",IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstProvinsiViewModel model = MstProvinsiDAO.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstProvinsiViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstProvinsiDAO.Update(data))
                {
                    return RedirectToAction("index");
                }
                
            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstProvinsiViewModel model = MstProvinsiDAO.CariID(id);
            return PartialView("Delete", model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(MstProvinsiViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstProvinsiDAO.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }   
            return View("index");
        }
    }
}