using iGob.Entidades;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class ReactivosConclusionEMController : ValidaSession
    {
        // GET: ReactivosConclusionEM
        public ActionResult Index()
        {
            ClsReactivosConclusionEM model = new ClsReactivosConclusionEM();
            return View(model.getAllReactivosConclusionEM());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveReactivosConclusionEM(beReactivosConclusionEM pReactivosConclusionEM)
        {
            try
            {
                ClsReactivosConclusionEM model = new ClsReactivosConclusionEM();
                var b = model.saveReactivosConclusionEM(pReactivosConclusionEM);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult updateReactivosConclusionEM(beReactivosConclusionEM pReactivosConclusionEM)
        {
            try
            {
                ClsReactivosConclusionEM model = new ClsReactivosConclusionEM();
                var b = model.updateReactivosConclusionEM(pReactivosConclusionEM);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getReactivo(int pIdReactivosConclusionEM)
        {
            try
            {
                ClsReactivosConclusionEM model = new ClsReactivosConclusionEM();
                var b = model.getReactivosConclusionEM(pIdReactivosConclusionEM);
                return PartialView("Reactivo", b);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}