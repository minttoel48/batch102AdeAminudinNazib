using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using perpustakaan.context;
using perpustakaan.DAO;
using perpustakaan.ViewModel;

namespace waMvcDay15.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataProvKota(int id)
        {
            return Json(MstKotaDAO.DataProvKota(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataKotaKec(int id)
        {
            return Json(MstKecamatanDAO.DataKotaKec(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAnggota()
        {
            return PartialView("_ListAnggota",MstAnggotaDAO.GetData());
        }

        public ActionResult GetBuku()
        {
            return PartialView("_GetBuku",MstBukuDAO.Getdata());
        }

        public ActionResult GetBukuByID(int id)
        {
            return PartialView("_rowBuku", MstBukuDAO.GetDataByID(id));
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SimpanPeminjaman(TrxPinjamanHeaderViewModel IsiData)
        {
            
            return PartialView("index");
        }
    }
}