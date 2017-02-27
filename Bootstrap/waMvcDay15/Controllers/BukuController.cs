using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//tambahkan
using perpustakaan.ViewModel;
using perpustakaan.DAO;


namespace waMvcDay15.Controllers
{
    public class BukuController : Controller
    {
        // GET: Buku
        public ActionResult Index()
        {
            return View(MstBukuDAO.Getdata());
        }


        //-----------script tambah data------------
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MstBukuViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstBukuDAO.Add(mdl))
                {
                    return RedirectToAction("Index");
                }
            }


            return PartialView("Index", mdl);
        }

        //-----------script edit data------------
        public ActionResult Edit(int id)
        {
            MstBukuViewModel model = MstBukuDAO.CariIDBuku(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstBukuViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstBukuDAO.Update(mdl))
                {
                    return RedirectToAction("Index");
                }

            }
            return View("Edit", mdl);
        }

        //-----------script hapus data------------
        public ActionResult Delete(int id)
        {
            MstBukuViewModel model = MstBukuDAO.CariIDBuku(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstBukuViewModel mdl)
        {

            // MstBukuDAO.Hapus(mdl);

            if (ModelState.IsValid)
            {
                if (MstBukuDAO.Hapus(mdl))
                {
                    return RedirectToAction("index");
                }
            }


            return View("Index");
        }


    }
}