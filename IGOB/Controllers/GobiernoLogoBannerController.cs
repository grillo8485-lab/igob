using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.ReglasNegocios;
using iGob.Entidades;

namespace IGOB.Controllers
{
    public class GobiernoLogoBannerController : ValidaSession
    {
        private brGobiernoLogoBanner ObrGobiernoLogoBanner = new brGobiernoLogoBanner();
        // GET: GobiernoLogoBanner
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult saveLogoBanner(beGobiernoLogoBanner logobanner)
        {
            var save = ObrGobiernoLogoBanner.guardarGobiernoLogoBanner(logobanner);
            return Json(save, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult updateLogoBanner(beGobiernoLogoBanner logobanner)
        {
            var save = ObrGobiernoLogoBanner.actualizarGobiernoLogoBanner(logobanner);
            return Json(save, JsonRequestBehavior.AllowGet);
        }
    }
}